using Dr.LeeFinalProject;

public class Inventory // Declaring the Inventory class
{
    private List<Item> items; // Private field for the list of items

    public Inventory() // Constructor
    {
        items = new List<Item>(); // Initializing the items list
    }

    public void AddItem(Item item) // Method to add an item
    {
        items.Add(item); // Adding item to the list
    }

    public void UpdateItem(int id, string name, Category category, int quantity, double price) // Method to update an item
    {
        foreach (Item item in items) // Iterating through the items list
        {
            if (item.Id == id) // Checking if the item ID matches
            {
                item.Name = name; // Updating item name
                item.Category = category; // Updating item category
                item.Quantity = quantity; // Updating item quantity
                item.Price = price; // Updating item price
                break; // Exiting the loop after updating
            }
        }
    }

    public void DeleteItem(int id) // Method to delete an item
    {
        items.RemoveAll(item => item.Id == id); // Removing the item with the specified ID
    }

    public List<Item> GetItems() // Method to get all items
    {
        return items; // Returning the list of items
    }

    public void LoadItemsFromFile(string filename) // Method to load items from a file
    {
        if (File.Exists(filename)) // Checking if the file exists
        {
            string[] lines = File.ReadAllLines(filename); // Reading all lines from the file
            foreach (string line in lines) // Iterating through each line
            {
                string[] parts = line.Split(","); // Splitting the line into parts
                int id = int.Parse(parts[0]); // Parsing item ID
                string name = parts[1]; // Getting item name
                Category category = (Category)Enum.Parse(typeof(Category), parts[2]); // Parsing item category
                int quantity = int.Parse(parts[3]); // Parsing item quantity
                double price = double.Parse(parts[4]); // Parsing item price
                items.Add(new Item(id, name, category, quantity, price)); // Adding the item to the list
            }
        }
    }

    public void SaveItemsToFile(string filename) // Method to save items to a file
    {
        List<string> lines = new List<string>(); // Creating a list to hold the lines
        foreach (Item item in items) // Iterating through the items list
        {
            string line = $"{item.Id}, {item.Name}, {item.Category}, {item.Quantity}, {item.Price}"; // Creating a line for the item
            lines.Add(line); // Adding the line to the list
        }
        File.WriteAllLines(filename, lines); // Writing all lines to the file
    }
}
