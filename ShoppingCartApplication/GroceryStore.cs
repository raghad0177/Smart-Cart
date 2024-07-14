using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static ShoppingCartApplication.Product;

namespace ShoppingCartApplication
{
    public class GroceryStore
    {
        static Product product = new Product();
        public static (string[], string[]) GetData()
        {
            (string[] Name, string[] Price) = (new string[5], new string[5]);
            product.Category = ProductCategory.Food;
           (Name,Price)= ProductGenerator.GenerateProduct(product.Category);
            return (Name, Price);
        }
    }
   
}