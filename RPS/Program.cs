using System;

namespace RPS
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new RPSClient();
            bool selected = false;

            while(!selected)
            {
                try
                {
                    selected = client.takeDifficultyInput();
                }
                catch(InvalidOperationException)
                {
                    Console.WriteLine("\nInvalid input please try again.\n");
                }
                catch(SystemException)
                {
                    Console.WriteLine("\nQuitting RPS Game.");
                    return;
                }
            }

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
                    return;
                }
            }
        }
    }
}
