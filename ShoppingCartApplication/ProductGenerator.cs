using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static ShoppingCartApplication.Product;

namespace ShoppingCartApplication
{
    public class ProductGenerator

    {
        static List<Dictionary<string, int>> RandomItems = new List<Dictionary<string, int>>();
        static Product product1 = new Product();
        public static void ChooseItem(string[] Name, string[]Price)
        {
            Dictionary<string, int> choosed = new Dictionary<string, int> { };

            int[] newPrice = new int[Price.Length];

            for (int i = 0; i < Price.Length; i++)
            {
                Price[i] = Price[i].Replace("$", "");
                newPrice[i] = (int)Convert.ChangeType(Price[i], typeof(int));
            }
            int item = 0;
            while (true)
            {
                Console.WriteLine("Pick Item To Add (1-5):");
                if (int.TryParse(Console.ReadLine(), out  item) && item >= 1 && item <= 5)
                {
                    choosed[Name[item - 1]] = newPrice[item - 1];
                    ShoppingCart.AddItems(choosed);
                    Console.WriteLine("Item added successfully.");
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid Item. Pick Again.");
                }
            }
        }
        public static void GenerateRandomProduct()
        {
            Random rnd = new Random();
            int random = rnd.Next(15);
            string[] names;
            string[] price;
            names = new string[] { "Apple", "Banana", "Bread", "Milk", "Cheese",
                                             "T.Shirt", "Jeans", "Jacket", "Sweater", "Dress",
                                              "Laptop", "Smartphone", "Headphones", "Monitor", "Camera"  };
            price = new string[] { "2$", "3$", "7$", "6$", "1$",
                                               "20$", "30$", "70$", "60$", "100$",
                                               "200$", "300$", "700$", "600$", "1000$" };
            price[random] = price[random].Replace("$", "");
            string newName = names[random];
            int newPrice = (int)Convert.ChangeType(price[random], typeof(int));
            ShoppingCart.AddRandomItems(names[random], newPrice);
        }
        public static (string[], string[]) GenerateProduct(ProductCategory product)
        {
            string[] names;
            string[] price;
            switch (product)
            {
                case ProductCategory.Food:
                    names = new string[] { "Apple", "Banana", "Bread", "Milk", "Cheese" };
                    price = new string[] { "2$", "3$", "7$", "6$", "1$" };
                    product1.Price = price;
                    product1.Name = names;
                    break;
                case ProductCategory.Clothing:
                    names = new string[] { "T.Shirt", "Jeans", "Jacket", "Sweater", "Dress" };
                    price = new string[] { "20$", "30$", "70$", "60$", "100$" };
                    product1.Price = price;
                    product1.Name = names;
                    break;
                case ProductCategory.Electronics:
                    names = new string[] { "Laptop", "Smartphone", "Headphones", "Monitor", "Camera" };
                    price = new string[] { "200$", "300$", "700$", "600$", "1000$" };
                    product1.Price = price;
                    product1.Name = names;
                    break;
                default:
                    names = new string[] { "Unknown" };
                    product1.Name = names;
                    break;
            }
            for (int i = 0; product1.Name.Length > i; i++)
            {
                Console.WriteLine(i+1 +"- " + product1.Name[i] + "With Price: " + product1.Price[i]);
            }
            return (product1.Name, product1.Price);
        }
    }
}
