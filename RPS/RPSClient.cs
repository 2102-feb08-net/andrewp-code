using System;

namespace RPS
{
    class RPSClient
    {
        private int playerScore = 0;
        private int computerScore = 0;
        public RPSChoices takeInput()
        {
            Console.WriteLine("Please input your choice\n0 - Rock | 1 - Paper | 2 - Scissors | q - Quit");
            
            switch (Console.ReadLine())
            {
                case "0":
                    return RPSChoices.Rock;
                case "1":
                    return RPSChoices.Paper;
                case "2":
                    return RPSChoices.Scissors;
                case "q":
                    throw new SystemException("Quit the game");
                default:
                    throw new InvalidOperationException("Invalid Operation");
            }
        }

        public RPSChoices randomChoice()
        {
            var rand = new Random();
            return (RPSChoices) rand.Next(3);
        }

        public RPSChoices fixedChoice()
        {
            return RPSChoices.Rock;
        }

        public void printScore()
        {
            Console.WriteLine("Player\tComputer");
            Console.WriteLine($"{playerScore}\t{computerScore}\n");
        }

        public void turn()
        {
            var userChoice = takeInput();
            var computerChoice = randomChoice();

            Console.WriteLine($"\nYou have chosen {userChoice}");
            Console.WriteLine($"Computer has chosen {computerChoice}\n");

            if (userChoice == computerChoice)
            {
                Console.WriteLine("Tie!");
                playerScore++;
                computerScore++;
                return;
            }

            if (Math.Abs(userChoice - computerChoice) == 2)
            {
                if (userChoice < computerChoice)
                {
                    Console.WriteLine("Win!");
                    playerScore++;
                }
                else
                {
                    Console.WriteLine("Lose!");
                    computerScore++;
                }
            }
            else
            {
                if (userChoice < computerChoice)
                {
                    Console.WriteLine("Lose!");
                    computerScore++;
                }
                else
                {
                    Console.WriteLine("Win!");
                    playerScore++;
                }
            }

        }
    }
}