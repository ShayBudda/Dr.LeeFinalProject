using Dr.LeeFinalProject;
using System; // Importing the System namespace
using System.Collections.Generic; // Importing the Collections.Generic namespace
using System.IO; // Importing the IO namespace

public class InventoryManagementSystem // Declaring the main class
{
    public static void Main(string[] args) // Main method
    {
        Inventory inventory = new Inventory(); // Creating an instance of Inventory
        // Path to the inventory file
        string filePath;
        while (true) // Loop until a valid file is entered
        {
            Console.Write("Enter file path to which you want to modify: ");
            filePath = Console.ReadLine(); // Read the item name
            if (!string.IsNullOrWhiteSpace(filePath)) // Check if the name is not null or whitespace
            {
                break; // Exit the loop if the name is valid
            }
            else
            {
                Console.WriteLine("Invalid path. Please enter a valid path.");
            }
        }
        Console.WriteLine($"Loading items from {Path.GetFullPath(filePath)}");

        inventory.LoadItemsFromFile(filePath); // Loading items from file

        // User menu loop
        bool exit = false; // Boolean to control the loop
        while (!exit) // While loop to display the menu until user decides to exit
        {
            Console.WriteLine("1. Add Item");
            Console.WriteLine("2. Update Item");
            Console.WriteLine("3. Delete Item");
            Console.WriteLine("4. View Items");
            Console.WriteLine("5. Exit And Save");
            Console.Write("Select an option: ");
            string option = Console.ReadLine(); // Reading user input

            switch (option) // Switch statement to handle different menu options
            {
                case "1":
                    AddItem(inventory); // Call AddItem method
                    break;
                case "2":
                    UpdateItem(inventory); // Call UpdateItem method
                    break;
                case "3":
                    DeleteItem(inventory); // Call DeleteItem method
                    break;
                case "4":
                    ViewItems(inventory); // Call ViewItems method
                    break;
                case "5":
                    exit = true; // Setting exit to true to break the loop
                    break;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
        Console.WriteLine($"Saving items to {Path.GetFullPath(filePath)}");
        inventory.SaveItemsToFile(filePath);

        
    }

    private static void AddItem(Inventory inventory) // Method to add a new item
    {
        string name;
        while (true) // Loop until a valid name is entered
        {
            Console.Write("Enter item name: ");
            name = Console.ReadLine(); // Read the item name
            if (!string.IsNullOrWhiteSpace(name)) // Check if the name is not null or whitespace
            {
                break; // Exit the loop if the name is valid
            }
            else
            {
                Console.WriteLine("Invalid name. Please enter a valid name.");
            }
        }

        Category category;
        while (true) // Loop until a valid category is entered
        {
            Console.Write("Enter item category (Blocks, BlockEntities, PartialBlocks): ");
            if (Enum.TryParse(Console.ReadLine(), true, out category) && Enum.IsDefined(typeof(Category), category)) // Try to parse and validate the category
            {
                break; // Exit the loop if parsing is successful and the category is defined in the enum
            }
            else
            {
                Console.WriteLine("Invalid category. Please enter a valid category.");
            }
        }

        int quantity;
        while (true) // Loop until a valid quantity is entered
        {
            Console.Write("Enter item quantity: ");
            if (int.TryParse(Console.ReadLine(), out quantity)) // Try to parse the input as an integer
            {
                break; // Exit the loop if parsing is successful
            }
            else
            {
                Console.WriteLine("Invalid quantity. Please enter a valid integer.");
            }
        }

        double price;
        while (true) // Loop until a valid price is entered
        {
            Console.Write("Enter item price: ");
            if (double.TryParse(Console.ReadLine(), out price)) // Try to parse the input as a double
            {
                break; // Exit the loop if parsing is successful
            }
            else
            {
                Console.WriteLine("Invalid price. Please enter a valid number.");
            }
        }

        int id = new Random().Next(1, 10000); // Generating a random ID for the item

        Item newItem = new Item(id, name, category, quantity, price); // Creating a new item
        inventory.AddItem(newItem); // Adding the new item to inventory

        Console.WriteLine("Item added successfully!");
    }


    private static void UpdateItem(Inventory inventory) // Method to update an existing item
    {
        int id;
        while (true) // Loop until a valid ID is entered
        {
            Console.Write("Enter item ID to update: ");
            if (int.TryParse(Console.ReadLine(), out id)) // Try to parse the input as an integer
            {
                break; // Exit the loop if parsing is successful
            }
            else
            {
                Console.WriteLine("Invalid ID. Please enter a valid integer.");
            }
        }

        string name;
        while (true) // Loop until a valid name is entered
        {
            Console.Write("Enter new item name: ");
            name = Console.ReadLine(); // Read the item name
            if (!string.IsNullOrWhiteSpace(name)) // Check if the name is not null or whitespace
            {
                break; // Exit the loop if the name is valid
            }
            else
            {
                Console.WriteLine("Invalid name. Please enter a valid name.");
            }
        }

        Category category;
        while (true) // Loop until a valid category is entered
        {
            Console.Write("Enter new item category (Blocks, BlockEntities, PartialBlocks): ");
            if (Enum.TryParse(Console.ReadLine(), true, out category) && Enum.IsDefined(typeof(Category), category)) // Try to parse and validate the category
            {
                break; // Exit the loop if parsing is successful and the category is defined in the enum
            }
            else
            {
                Console.WriteLine("Invalid category. Please enter a valid category.");
            }
        }

        int quantity;
        while (true) // Loop until a valid quantity is entered
        {
            Console.Write("Enter new item quantity: ");
            if (int.TryParse(Console.ReadLine(), out quantity)) // Try to parse the input as an integer
            {
                break; // Exit the loop if parsing is successful
            }
            else
            {
                Console.WriteLine("Invalid quantity. Please enter a valid integer.");
            }
        }

        double price;
        while (true) // Loop until a valid price is entered
        {
            Console.Write("Enter new item price: ");
            if (double.TryParse(Console.ReadLine(), out price)) // Try to parse the input as a double
            {
                break; // Exit the loop if parsing is successful
            }
            else
            {
                Console.WriteLine("Invalid price. Please enter a valid number.");
            }
        }

        inventory.UpdateItem(id, name, category, quantity, price); // Updating the item

        Console.WriteLine("Item updated successfully!");
    }


    private static void DeleteItem(Inventory inventory) // Method to delete an item
    {
        Console.Write("Enter item ID to delete: ");
        int id = int.Parse(Console.ReadLine()); // Reading item ID

        inventory.DeleteItem(id); // Deleting the item from inventory

        Console.WriteLine("Item deleted successfully!");
    }

    private static void ViewItems(Inventory inventory) // Method to view all items
    {
        List<Item> items = inventory.GetItems(); // Getting the list of items
        if (items.Count == 0) // Checking if there are no items
        {
            Console.WriteLine("No items in inventory.");
        }
        else
        {
            foreach (Item item in items) // Iterating through each item
            {
                Console.WriteLine($"[ID: {item.Id}] [Name: {item.Name}] [Category: {item.Category}] [Quantity: {item.Quantity}] [Price: {item.Price}]"); // Displaying item details
            }
        }
    }
}

// This project is an inventory management system that utilizes several methods to create a way to create, store, delete, or update items.
// When you run the project it will prompt you with inputs. First it will ask you the file directory of the text file you want to update.
// After pasting that, it will ask if you want to add, update, delete, or view items in the text file. This can be used for games, shopping carts,
// or general tracking of items. I like the flexibility this program allows for. More about how the code works is within the comments. 

