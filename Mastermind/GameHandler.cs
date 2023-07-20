using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mastermind
{
    public class GameHandler
    {
        string computerInput;
        public GameHandler(string compInput)
        {
            this.computerInput = compInput;
        }

        public void Game(string computerInput)
        {
            int i = 0;

            List<string> finalOutput = new List<string>();
            Stack<string> perInput = new Stack<string>();

            while (i < 10)
            {
                Console.WriteLine();
                Console.WriteLine($"ROUND {i + 1}");
                string perInputOutput = "";
                string userInput = Console.ReadLine();
                if (userInput != null)
                {
                    int userInputLength = userInput.Length;
                    int n;
                    bool isNumeric = int.TryParse(userInput, out n);
                    if (userInputLength == 4 && isNumeric && userInput[0] != 0)
                    {
                        //STORE THE USERINPUT IN MAP
                        List<char> uniqueUserInput = new List<char>();
                        foreach(char c in userInput)
                        {
                            if (!uniqueUserInput.Contains(c))
                            {
                                uniqueUserInput.Add(c);
                            }
                        }

                        for (int j = 0; j < 4 && j < uniqueUserInput.Count; j++)
                        {
                            if (computerInput.Contains(uniqueUserInput[j]))
                            {
                                if (computerInput[j] == uniqueUserInput[j])
                                {
                                    perInputOutput += "BULL ";
                                }
                                else
                                {
                                    perInputOutput += "COW ";
                                }
                            }
                        }
                        if (perInputOutput == "")
                        {
                            perInputOutput += $"{userInput}: No match found";
                        }
                        i++;

                        finalOutput.Add($"{userInput}: " + perInputOutput);
                        perInput.Push($"{userInput}: " + perInputOutput);

                        Console.WriteLine();
                        Console.WriteLine($"Input {i}");

                        while (perInput.Count > 0)
                        {
                            Console.WriteLine(perInput.Pop());
                        }
                        for (int j = finalOutput.Count - 1; j >= 0; j--)
                        {
                            perInput.Push(finalOutput[j]);
                        }
                        if (perInputOutput == "BULL BULL BULL BULL ")
                        {
                            Console.WriteLine("Yayy.....YOU WON!!");
                            return;
                        }
                        if (i == 10)
                        {
                            Console.WriteLine("Oops.....YOU LOST!!");
                            return;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Enter correct input");
                    }
                }

            }
        }
    }
}
