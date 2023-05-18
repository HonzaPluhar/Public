public class Program
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
    public int MaximumAttempts = 3;



    //number generator
    Random rnd = new Random();
    public void RollingNumber()
    {

        RolledNumber = rnd.Next(1, 7);   // creates a number between 1 and 6
    }


    public void EnteredNumber()
    {
        Console.WriteLine("Quess the number");
        int userinput = int.Parse(Console.ReadLine());
        CheckUserInput(userinput);

        if (userinput > 0 && userinput < 7)
        {
            CurrentAttempt++;
            NumberOfAttemptsCheck();
        }


    }

    public void CheckUserInput(int userinput)
    {
        if (userinput > 0 && userinput < 7)
        {


            if (userinput == RolledNumber)
            {
                Console.WriteLine("Congratulatoins! You have won!");
                Console.WriteLine("Thank you for using this application. For exit press any key.");
                Playing = false;
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Sorry that was not correct!");
            }
        }
        else
        {
            Console.WriteLine("Incorrect number! Quess the number between 1 and 6!");
        }
    }

    public void NumberOfAttemptsCheck()
    {
        if (CurrentAttempt >= MaximumAttempts)
        {


            Playing = false;
            Console.WriteLine("You loose! :-(");
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
