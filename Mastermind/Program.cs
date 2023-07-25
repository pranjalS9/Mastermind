namespace Mastermind
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("MASTERMIND");
            Console.WriteLine();

            string computerInput = new GenerateRandomNumber().SecretCode();
            GameHandler gameHandler = new(computerInput);
            gameHandler.Game(computerInput);

            Console.WriteLine();
            Console.WriteLine("Press ENTER to exit.");
            Console.ReadLine();
        }
    }
}