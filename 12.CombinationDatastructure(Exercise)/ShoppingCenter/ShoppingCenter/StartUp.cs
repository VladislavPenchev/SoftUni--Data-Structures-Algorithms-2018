namespace ShoppingCenter
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            int numberOfCommands = int.Parse(Console.ReadLine());

            for (int i = 0;i < numberOfCommands; i++)
            {
                string line = Console.ReadLine();
                string[] lineInfo = line.Split(new[] {' '},2);

                string command = lineInfo[0];
                string productInfo = lineInfo[1];

                string[] arrayOfProductInfo = productInfo.Split(';');

                switch (command)
                {
                    case "AddProduct"
                        string name = arrayOfProductInfo[0];
                        double price = double.Parse(arrayOfProductInfo[1]);
                        string producer = arrayOfProductInfo[2];

                        Product product = new Product(name, price, producer);
                        break;
                    case "DeleteProducts"
                        break;
                    case "FindProductsByName"
                        break;
                    case "FindProductsByProducer"
                        break;
                    case "FindProductsByPriceRange"
                        break;  
                }
            }           
        }
    }
}
