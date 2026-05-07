using System;
using System.Collections.Generic;
using System.Text;

namespace ProductLogic
{
    public class Inventory
    {
        private List<Product> products;

        public IReadOnlyCollection<Product> Products => products.AsReadOnly();


        public Inventory()
        {
            products = new List<Product>();


        }


        public void AddProduct(Product product)
        {

            if (product == null)
            {
                throw new ArgumentNullException(nameof(product));

            }

            else if(products.Any(x=>x.Name.ToLower()==product.Name.ToLower() && x.Category.ToLower() == product.Category.ToLower()))
            {

                throw new InvalidOperationException("Product already exists.");

            }
            
            products.Add(product);


        }


        public bool RemoveProduct(string name)
        {

            bool isFound = false;

            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentException("Name cannot be empty.");
            }

            else if (products.Any(x => x.Name.ToLower() == name.ToLower()))
            {

                var product = products.Find(x => x.Name.ToLower() == name.ToLower());


                products.Remove(product);

                isFound = true;


            }

            return isFound;


        }


        public List<Product> GetProductsByCategory(string category)
        {

            if (string.IsNullOrEmpty(category))
            {

                throw new ArgumentException("Category cannot be empty.");

            }

            List<Product> productsByCategory = products.Where(x => x.Category.ToLower() == category.ToLower()).ToList();


            return productsByCategory;


        }

        public List<Product> GetExpensiveProducts(decimal minPrice)
        {

            if (minPrice <= 0)
            {
                throw new ArgumentException("Minimum price must be greater than zero.");

            }

            return products.Where(x => x.Price >= minPrice).ToList();


        }



        public Product GetMostExpensiveProduct()
        {

            if (products.Count == 0)
            {
                return null;
            }


            return products.OrderByDescending(x => x.Price).FirstOrDefault();


        }


        public decimal GetTotalInventoryValue()
        {

            decimal priceForAllProducts = products.Sum(x => x.Quantity * x.Price);

            return priceForAllProducts;


        }


        public double GetAverageQuantity()
        {

            if (products.Count == 0)
            {
                return 0;

            }

            return products.Average(x => x.Quantity);


        }

        public HashSet<string> GetUniqueCategories()
        {

            List<string> CatNames = products.Select(x => x.Category).ToList();

            HashSet<string> qniqueCategories = new HashSet<string>(CatNames);

            return qniqueCategories;

        }

        public Dictionary<string, int> GetProductCountByCategory()
        {

            Dictionary<string, int> categoriesCounts = new Dictionary<string, int>();


            foreach(Product product in products)
            {

                if (!categoriesCounts.ContainsKey(product.Category))
                {

                    categoriesCounts[product.Category] = 0;
                }

                

                    categoriesCounts[product.Category]++;


                

            }

            return categoriesCounts;


        }


        public Dictionary<string, decimal> GetTotalValueByCategory()
        {

            Dictionary<string, decimal> totalValuePerCategory = products.GroupBy(x => x.Category).ToDictionary(x => x.Key, x => x.ToList().Sum(x=>x.GetTotalValue()));


            return totalValuePerCategory;



        }

    }
}
