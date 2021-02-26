using System;
using Humanizer;

namespace HelloVisualStudio
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Inventory App 1.0");
            Console.WriteLine("What item do you have?");
            string input = Console.ReadLine(); // computer, apple, 
            Console.WriteLine("How many do you have?");
            int quantity = int.Parse(Console.ReadLine());

            if (quantity != 1)
            {
                input = Pluralize(input);
            }

            Console.WriteLine($"You have {quantity} {input}.");
        }

        static string Pluralize(string item)
        {
            return item.Pluralize();
        }
    }
}
