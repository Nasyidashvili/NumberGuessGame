using System;
using System.Collections.Generic;
using System.Text;


namespace NumberGuessGame
{
    public class Game
    {
        public void Start()
        {
            Console.WriteLine("""
                Welcome to the Number Guessing Game!
                I'm thinking of a number between 1 and 100.
                Please select a difficulty level: Easy, Medium, or Hard.
                """);
            var random = new Random();
            int randNumber = random.Next(1, 101);
            var (difficulty, chances) = SelectDifficulty();
            int attempts = PlayRound(chances, randNumber);

        }
        private (string difficulty, int chances) SelectDifficulty()
        {
            Console.Write("""
                1. Easy (10 chances),
                2. Medium (5 Chances),
                3. Hard (3 Chances)
                Enter your choice (1, 2, or 3): 
                """);
            var choice = Console.ReadLine();
            while (true)
            {
                switch(choice)
                {
                    case "1":
                        return ("Easy", 10);
                    case "2":
                        return ("Medium", 5);
                    case "3":
                        return ("Hard", 3);
                    default:
                        Console.WriteLine("Invalid choice. Please select 1, 2, or 3.");
                        choice = Console.ReadLine();
                        break;
                }
            }
        }

        private int PlayRound(int chances, int secret)
        {
            for (int i = 0; i < chances; i++)
            {
                Console.Write("Enter you guess: ");
                int.TryParse(Console.ReadLine(), out int guess);
                if (guess == secret)
                {
                    Console.WriteLine($"Congratulations! you guessed the number in {i + 1} attempts!");
                    return i + 1;
                } else if (guess > secret)
                {
                    Console.WriteLine("Number is less than your guess");
                    ShowHint(secret, i + 1, chances);
                } else
                {
                    Console.WriteLine("Number is greater than your guess");
                    ShowHint(secret, i + 1, chances);
                }
            }
            Console.WriteLine($"Sorry, you've used all your chances. The number was {secret}.");
            return chances;
        }
        private void ShowHint(int secret, int attempUsed, int totalChances)
        {
            if(attempUsed < totalChances / 2)
            {
                return;
            }
            if (secret % 2 == 0)
            {
                Console.WriteLine("Hint: The number is even.");

            }
            else
            {
                Console.WriteLine("Hint: The number is odd.");

            }

            if (secret <= 25)
                Console.WriteLine("Hint: The number is between 1 and 25.");
            else if (secret <= 50)
                Console.WriteLine("Hint: The number is between 26 and 50.");
            else if (secret <= 75)
                Console.WriteLine("Hint: The number is between 51 and 75.");
            else
                Console.WriteLine("Hint: The number is between 76 and 100.");
        }

        public bool AskPlayAgain()
        {
            Console.Write("Do you want to play again? (y/n): ");
            var choice = Console.ReadLine()!.Trim().ToLower();
            return choice == "y" || choice == "yes";

        }
    }
}
