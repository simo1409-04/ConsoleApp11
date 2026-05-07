using System;
using System.Collections.Generic;
using System.Text;

namespace ProductLogic
{
    public class Product
    {

        private string name;
        private string category;
        private decimal price;
        private int quantity;


        public string Name { get
            {
                return name;
            }
            private set
            {

                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Name cannot be empty.");

                }

                name = value;

            }
        }
        public string Category {
            get
            {
                return category;
            }
            private set
            {

                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Category cannot be empty.");
                }

                category = value;

            }
        }
        public decimal Price
        {
            get
            {
                return price;
            }
            private set
            {

                if (value<=0)
                {
                    throw new ArgumentException("Price must be greater than zero.");
                }


                price = value;
            }
        }
        public int Quantity
        {
            get
            {
                return quantity;
            }
            private set
            {

                if (value <0)
                {
                    throw new ArgumentException("Quantity cannot be negative.");
                }


                quantity = value;
            }
        }


        public Product (string name, string category, decimal price, int quantity)
        {


            this.Name = name;
            this.Category = category;
            this.Price = price;
            this.Quantity = quantity;


        }




        public decimal GetTotalValue()
        {

            return Price * Quantity;

        }


        public override string ToString()
        {
            return $"{this.Name} | {this.Category} | {this.Price} lv | Qty: {this.Quantity} | Total: {GetTotalValue():F2} lv";
        }


    }
}
