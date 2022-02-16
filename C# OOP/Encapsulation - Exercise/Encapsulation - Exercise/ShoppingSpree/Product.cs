using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingSpree
{
    public class Product
    {
        private string name;
        private decimal price;
        public Product(string name, decimal price)
        {
            this.Name = name;
            this.Price = price;
        }
        public string Name
        {
            get => this.name;
            private set
            {
                Validator.ThrowIfStringIsNullOrEmpty(value, "Name cannot be empty");
                this.name = value;
            }
        }

        public decimal Price
        {
            get => this.price;
            private set
            {
                Validator.ThrowIfNumberIsNegative(value, "Money cannot be negative");
                this.price = value;
            }
        }
    }
}
