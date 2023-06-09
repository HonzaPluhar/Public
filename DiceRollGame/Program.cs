﻿public class Program
{
    static void Main(String[] args)
    {
        Console.WriteLine($"The dice has rolled! What number between 1 and 6 has been rolled?");
        Game game = new Game();
        game.PlayGame();

    }
}




public class Game
{
    public int RolledNumber;
    public int CurrentAttempt = 0;
    public bool Playing = true;
    public int MaximumAttempts = 6;



    //number generator
    Random rnd = new Random();
    public void RollingNumber()
    {
        RolledNumber = rnd.Next(1, 7);   // creates a number between 1 and 6
    }


    public void EnteredNumber()
    {
        Console.WriteLine("Guess the number");
        string userInputString = Console.ReadLine();
        int userInput;
        if (int.TryParse(userInputString, out userInput) && userInput > 0 && userInput < 7)
        {
            CheckUserInput(userInput);
            CurrentAttempt++;
            NumberOfAttemptsCheck();
        }
        else
        {
            Console.WriteLine("Incorrect number! Guess the number between 1 and 6!");
        }
    }

    public void CheckUserInput(int userinput)
    {
        if (userinput == RolledNumber)
        {
            Console.WriteLine("Congratulations! You have won!");
            Console.WriteLine("Thank you for using this application. For exit press any key.");
            Playing = false;
            Console.ReadKey();
        }
        else
        {
            Console.WriteLine("Sorry that was not correct!");
        }
    }

    public void NumberOfAttemptsCheck()
    {
        if (CurrentAttempt >= MaximumAttempts)
        {
            Console.WriteLine("You loose! :-(");
            Console.WriteLine("Thank you for using this application. For exit press any key.");
            Playing = false;
            Console.ReadKey();
        }
    }

    public void PlayGame()
    {
        RollingNumber();
        while (Playing)
        {
            EnteredNumber();
        }
    }
}
