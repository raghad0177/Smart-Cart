using ShoppingCartApplication;

namespace ShoppingCartApplicationTests
{
    public class UnitTest1
    {
        [Fact]
        public void AddItemsTest()
        {
            Dictionary<string, int> choosed = new Dictionary<string, int> { };
            choosed["Raghad"] = 100;

            bool result = ShoppingCart.AddItems(choosed);
           
            Assert.True(result);
        }

        [Fact]
        public void RemoveItemsTest()
        {
            Dictionary<string, int> choosed = new Dictionary<string, int> { };
            choosed["Raghad"] = 100;
            ShoppingCart.AddItems(choosed);


            var input = new StringReader("1");
            TextReader originalInput = Console.In; 
            Console.SetIn(input);

            bool result = ShoppingCart.RemoveItems();
            Assert.True(result);
        }

        [Fact]
        public void ValidClacTest()
        {
            Dictionary<string, int> choosed = new Dictionary<string, int> { };
            choosed["Raghad"] = 100;
            choosed["Rana"] = 200;
            ShoppingCart.AddItems(choosed);
            int Actual = 300;

            int cost = ShoppingCart.TotalCost();

            Assert.Equal(Actual, cost);
        }

    }
}