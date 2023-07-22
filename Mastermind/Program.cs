namespace Mastermind
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("MASTERMIND");
            Console.WriteLine();

            int[] computerInput = new GenerateRandomNumber().ComputerInput();
            //string computerInput = "6906";
            GameHandler gameHandler = new(computerInput);
            gameHandler.Game(computerInput);

            Console.WriteLine();
            Console.WriteLine("Press ENTER to exit.");
            Console.ReadLine();
        }
    }
}