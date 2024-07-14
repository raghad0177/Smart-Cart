using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ShoppingCartApplication
{
    public class ShoppingCart
    {
        static List<Dictionary<string, int>> Items = new List<Dictionary<string, int>>();

        public static bool AddItems(Dictionary<string, int> item)
        {
            int initialCount = Items.Count;
            Items.Add(item);
            if (Items.Count > initialCount)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool RemoveItems()
        {
            int initialCount = Items.Count;
            int item = -1;
            while (item < 1 || item > Items.Count)
            {
                Console.Write("Item Number ? ");
                if (!int.TryParse(Console.ReadLine(), out item) || item < 1 || item > Items.Count)
                {
                    Console.WriteLine("Invalid Option. Pick a valid item number to remove.");
                }
            }
            Items.RemoveAt(item - 1);
            if (Items.Count == initialCount-1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static void View() {
            int count = 1;
            Console.WriteLine("Items:");
            foreach (var item in Items)
            {
                foreach (var kvp in item)
                {
                    Console.WriteLine($"{count++} {kvp.Key}: {kvp.Value}");
                }
            }
            TotalCost();

        }

        public static int TotalCost() { 
            int total = 0;
            foreach (var item in Items)
            {
                foreach (var kvp in item)
                {
                    total += kvp.Value;
                }
                Console.WriteLine();
            }
            Console.WriteLine("Total cost : "+total);
            return total;
        }

    }
}
