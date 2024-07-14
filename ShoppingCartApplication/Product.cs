using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCartApplication
{
    public class Product
    {
        public enum ProductCategory { Food , Clothing, Electronics };
        public ProductCategory Category { get; set; }
        public string[] Name { get; set; }
        public string[] Price { get; set; }

        public static void PrintCategory()
        {
            int count = 1;
            ProductCategory[] allCategories = (ProductCategory[])Enum.GetValues(typeof(ProductCategory));
            foreach (var categories in allCategories)
            {
                Console.WriteLine(count + "- "+categories);
                count++;
            }
        }
    }
}
