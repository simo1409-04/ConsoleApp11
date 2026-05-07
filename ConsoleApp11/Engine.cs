using System;
using System.Collections.Generic;
using System.Text;
using ProductLogic;


namespace ConsoleApp11
{
    internal class Engine
    {

        public void Run()
        {

            Inventory inventory = new Inventory();

            inventory.AddProduct(new Product("Laptop", "Electronics", 1200m, 3));
            inventory.AddProduct(new Product("Mouse", "Electronics", 40m, 10));
            inventory.AddProduct(new Product("Keyboard", "Electronics", 80m, 5));
            inventory.AddProduct(new Product("Bread", "Food", 2.50m, 30));
            inventory.AddProduct(new Product("Milk", "Food", 3.20m, 20));
            inventory.AddProduct(new Product("T-Shirt", "Clothes", 25m, 15));
            inventory.AddProduct(new Product("Shoes", "Clothes", 90m, 7));
            inventory.AddProduct(new Product("Jacket", "Clothes", 150m, 4));

            PrintAllProducts(inventory);
            PrintElectronics(inventory);
            PrintExpensiveProductAbove100(inventory);
            PrintMostExpensiveProduct(inventory);
            PrintTotalInventoryValue(inventory);
            PrintAverageQuantity(inventory);
            PrintUniqueCategories(inventory);
            PrintProductCountByCategory(inventory);
            PrintTotalValuePerCategory(inventory);

        }


        public void PrintAllProducts(Inventory inventory)
        {


            Console.WriteLine("All products:");
            Console.WriteLine(string.Join(Environment.NewLine, inventory.Products));


        }


        public void PrintElectronics(Inventory inventory)
        {


            Console.WriteLine("Electronics:");
            Console.WriteLine(string.Join(Environment.NewLine, inventory.GetProductsByCategory("Electronics")));


        }


        public void PrintExpensiveProductAbove100(Inventory inventory)
        {


            Console.WriteLine("Expensive products above 100:");
            Console.WriteLine(string.Join(Environment.NewLine, inventory.GetExpensiveProducts(100)));



        }


        public void PrintMostExpensiveProduct(Inventory inventory)
        {


            Console.WriteLine("Most expensive product:");

            Console.WriteLine(inventory.GetMostExpensiveProduct());



        }


        public void PrintTotalInventoryValue(Inventory inventory)
        {


            Console.WriteLine("Total inventory value:");

            Console.WriteLine(inventory.GetTotalInventoryValue());



        }


        public void PrintAverageQuantity(Inventory inventory)
        {


            Console.WriteLine("Average quantity:");

            Console.WriteLine(inventory.GetAverageQuantity());



        }

        public void PrintUniqueCategories(Inventory inventory)
        {


            Console.WriteLine("Unique categories:");

            Console.WriteLine(string.Join(Environment.NewLine, inventory.GetUniqueCategories()));



        }


        public void PrintProductCountByCategory(Inventory inventory)
        {


            Console.WriteLine("Product count by category:");

            Console.WriteLine(string.Join(Environment.NewLine,inventory.GetProductCountByCategory().Select(x=>$"{x.Key} -> {x.Value}")));



        }


        public void PrintTotalValuePerCategory(Inventory inventory)
        {


            Console.WriteLine("Total value by category:");

            Console.WriteLine(string.Join(Environment.NewLine, inventory.GetTotalValueByCategory().Select(x => $"{x.Key} -> {x.Value:F2}")));



        }


    }
}
