using System;
using System.Collections.Generic;
using System.IO;
namespace GroceryStore
{
    class Program
    {
        static string currentDirectory = Directory.GetCurrentDirectory();
        static string filePath = $"{currentDirectory}\\myGroceryList.txt";

        static void Main(string[] args)
        {
            PrintMenuOptions();
        
            if (!File.Exists(filePath))
            {
                using (FileStream fs = File.Create(filePath));
            }

            // Get input
            var input = Console.ReadKey().Key;

            do
            {
                if (input == ConsoleKey.P)
                {
                    var product = CreateProduct();
                    WriteEntry(product);
                }
                else if (input == ConsoleKey.L)
                {
                    PrintFileContents();
                }

                PrintMenuOptions();
                input = Console.ReadKey().Key;

            } while (input != ConsoleKey.Q);
        }

        static string CreateProduct() {
            Console.WriteLine(Environment.NewLine + "Please enter the name of the product?");
            var name = Console.ReadLine();

            Console.WriteLine(Environment.NewLine + "Please enter the unit of measure of the product?");
            var unitOfMeasure = Console.ReadLine();

            Console.WriteLine(Environment.NewLine + "Please enter the quantity of the product?");
            var quantity = System.Convert.ToDecimal(Console.ReadLine());

            Console.WriteLine(Environment.NewLine + "Please enter the price of the product?");
            var price = System.Convert.ToDecimal(Console.ReadLine());

            var total = (price * quantity);
            var product = $"Name: {name} UnitOfMeasure: {unitOfMeasure} Quantity: {quantity} Price: {price} SubTotal: {total} {Environment.NewLine}";
            return product;
        }

        static void WriteEntry(string entry)
        {
            string lineToWrite = entry;
            File.AppendAllText(filePath, lineToWrite);
        }

        static void PrintFileContents()
        {
            Console.WriteLine("Current Grocery List" + Environment.NewLine);

            foreach (var line in File.ReadAllLines(filePath))
            {
                Console.WriteLine(line);
            }
            Console.WriteLine(Environment.NewLine);
        }

        static void PrintMenuOptions()
        {
            Console.WriteLine("Please enter [P] to add a new product to your cart" + Environment.NewLine);

            Console.WriteLine("Please enter [L] to list the current items in your cart." + Environment.NewLine);

            Console.Write("Please enter [Q] to quit the program" + Environment.NewLine);
        }

    }
}