using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dr.LeeFinalProject
{
    public class Item // Declaring the Item class
    {
        private int id; // Private field for item ID
        private string name; // Private field for item name
        private Category category; // Private field for item category
        private int quantity; // Private field for item quantity
        private double price; // Private field for item price

        // Non-default constructor
        public Item(int id, string name, Category category, int quantity, double price)
        {
            this.id = id; // Initializing item ID
            this.name = name; // Initializing item name
            this.category = category; // Initializing item category
            this.quantity = quantity; // Initializing item quantity
            this.price = price; // Initializing item price
        }

        // Properties
        public int Id // Property for item ID
        {
            get { return id; } // Getter for ID
        }

        public string Name // Property for item name
        {
            get { return name; } // Getter for name
            set { name = value; } // Setter for name
        }

        public Category Category // Property for item category
        {
            get { return category; } // Getter for category
            set { category = value; } // Setter for category
        }

        public int Quantity // Property for item quantity
        {
            get { return quantity; } // Getter for quantity
            set { quantity = value; } // Setter for quantity
        }

        public double Price // Property for item price
        {
            get { return price; } // Getter for price
            set { price = value; } // Setter for price
        }
    }
}