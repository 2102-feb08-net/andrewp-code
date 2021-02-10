using System;

namespace RPS
{
    class RPSClient
    {
        private int playerScore = 0;
        private int computerScore = 0;
        private RPSDifficulty currentDifficulty = RPSDifficulty.Normal;

        public RPSChoices takeChoiceInput()
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

        public Boolean takeDifficultyInput()
        {
            Console.WriteLine("Please choose your difficulty\n0 - Easy | 1 - Normal | 2 - Hard | q - Quit");
            switch (Console.ReadLine())
            {
                case "0":
                    currentDifficulty = RPSDifficulty.Easy;
                    return true;
                case "1":
                    currentDifficulty = RPSDifficulty.Normal;
                    return true;
                case "2":
                    currentDifficulty = RPSDifficulty.Hard;
                    return true;
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

        public RPSChoices impossibleChoice(RPSChoices playerChoice)
        {
            var choice = (int) playerChoice;
            return (RPSChoices)((choice + 1) % 3);
        }

        public void printScore()
        {
            Console.WriteLine("Player\tComputer");
            Console.WriteLine($"{playerScore}\t{computerScore}\n");
        }

        public RPSChoices makeComputerChoice(RPSChoices playerChoice)
        {
            if (currentDifficulty == RPSDifficulty.Easy)
                return fixedChoice();
            if (currentDifficulty == RPSDifficulty.Normal)
                return randomChoice();
            return impossibleChoice(playerChoice);
        }

        public void playTurn(RPSChoices userChoice, RPSChoices computerChoice)
        {
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

        public void turn()
        {
            var userChoice = takeChoiceInput();
            var computerChoice = makeComputerChoice(userChoice);

            Console.WriteLine($"\nYou have chosen {userChoice}");
            Console.WriteLine($"Computer has chosen {computerChoice}\n");

            playTurn(userChoice, computerChoice);

        }
    }
}