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
                catch(InvalidOperationException)
                {
                    Console.WriteLine("\nInvalid input please try again.\n");
                }
                catch(SystemException)
                {
                    Console.WriteLine("\nQuitting RPS Game.");
                    break;
                }
            }
        }
    }
}
