namespace Mastermind
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("MASTERMIND");
            Console.WriteLine();

            string ComputerInput = new GenerateRandomNumber().ComputerInput();
            Console.WriteLine(ComputerInput);

            GameHandler gameHandler = new(ComputerInput);
            gameHandler.Game(ComputerInput);

            Console.WriteLine();
            Console.WriteLine("Press ENTER to exit.");
            Console.ReadLine();
        }
    }
}