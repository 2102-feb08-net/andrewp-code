using System;

namespace RPS
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new RPSClient();
            while(true)
            {
                try
                {
                    client.turn();
                    client.printScore();
                }
                catch(InvalidOperationException e)
                {
                    Console.WriteLine("\nInvalid input please try again.\n");
                }
            }
        }
    }
}
