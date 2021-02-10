using System;

namespace RPS
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new RPSClient();
            bool selected = false;

            while(true)
            {
                try
                {
                    if (!selected)
                        selected = client.takeDifficultyInput();
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
