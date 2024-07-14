using static ShoppingCartApplication.Product;

namespace ShoppingCartApplication
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome To Shopping Cart Application.");
            MainMenu();
        }

        private static void MainMenu()
        {
            while (true)
            {
                Console.WriteLine("1- Pick Your Shops Categories");
                Console.WriteLine("2- Cart Items");
                Console.WriteLine("3- CheckOut");
                Console.WriteLine("4- Exit");

                if (int.TryParse(Console.ReadLine(), out int choice))
                {
                    switch (choice)
                    {
                        case 1:
                            HandleShopCategories();
                            break;
                        case 2:
                            HandleCartItems();
                            break;
                        case 3:
                            ShoppingCart.TotalCost();
                            Environment.Exit(0);
                            break;
                        case 4:
                            Environment.Exit(0);
                            break;
                        default:
                            Console.WriteLine("Invalid option. Please choose between 1 and 4.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                }
            }
        }

        private static void HandleShopCategories()
        {
            while (true)
            {
                Product.PrintCategory();
                Console.WriteLine("4- Main List");
                Console.WriteLine("5- Exit");
                Console.WriteLine("Shop Numbers:");

                if (int.TryParse(Console.ReadLine(), out int category))
                {
                    string[] Name = new string[0];
                    string[] Price = new string[0];

                    if (category >= 1 && category <= 3)
                    {
                        switch (category)
                        {
                            case 1:
                                (Name, Price) = GroceryStore.GetData();
                                break;
                            case 2:
                                (Name, Price) = ClothingStore.GetData();
                                break;
                            case 3:
                                (Name, Price) = ElectronicsStore.GetData();
                                break;
                        }

                        Console.WriteLine("=====================\n=========================");
                        Console.WriteLine("1- Choose\n2- MainMenu\n3- CheckOut\n4- Exit");

                        if (int.TryParse(Console.ReadLine(), out int choice2))
                        {
                            switch (choice2)
                            {
                                case 1:
                                    ProductGenerator.ChooseItem(Name, Price);
                                    break;
                                case 2:
                                    return;
                                case 3:
                                    ShoppingCart.TotalCost();
                                    Environment.Exit(0);
                                    break;
                                case 4:
                                    Environment.Exit(0);
                                    break;
                                default:
                                    Console.WriteLine("Invalid option. Returning to Main Menu.");
                                    return;
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid input. Returning to Main Menu.");
                            return;
                        }
                    }
                    else if (category == 4)
                    {
                        return;
                    }
                    else if (category == 5)
                    {
                        Environment.Exit(0);
                    }
                    else
                    {
                        Console.WriteLine("Invalid category. Please choose a valid shop number.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                }
            }
        }

        private static void HandleCartItems()
        {
            ShoppingCart.View();
            Console.WriteLine("1- Remove Item\n2- MainMenu\n3- CheckOut\n4- Exit");

            if (int.TryParse(Console.ReadLine(), out int choose))
            {
                switch (choose)
                {
                    case 1:
                        ShoppingCart.RemoveItems();
                        break;
                    case 2:
                        return;
                    case 3:
                        ShoppingCart.TotalCost();
                        Environment.Exit(0);
                        break;
                    case 4:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid option. Returning to Main Menu.");
                        return;
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Returning to Main Menu.");
            }
        }

    }
}
