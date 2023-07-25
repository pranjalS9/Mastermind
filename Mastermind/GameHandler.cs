using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Mastermind
{
    public class GameHandler
    {
        string secretCode;
        public GameHandler(string secretCode)
        {
            this.secretCode = secretCode;
        }

        public void Game(string secretCode)
        {
            Console.WriteLine(secretCode);

            int round = 0;

            List<string> finalOutput = new();
            Stack<string> perInput = new();

            

            while (round < 10)
            {
                Console.WriteLine();
                Console.WriteLine($"ROUND {round + 1}");

                List<bool> visited = new List<bool>(secretCode.Length);

                string singleRoundResult = "";

                //Taking user input and storing in a string and list

                string? userNumber = Console.ReadLine();

                int n;
                bool isNumeric = int.TryParse(userNumber, out n);

                if (userNumber != null && userNumber.Length == 4 && isNumeric)
                {
                    for (int i = 0; i < userNumber.Length; i++)
                    {
                        if (secretCode[i] == userNumber[i])
                        {
                            singleRoundResult += "BULL ";
                            visited.Add(true);
                        }
                        else
                        {
                            visited.Add(false);
                        }
                    }

                    if (singleRoundResult == "BULL BULL BULL BULL ")
                    {
                        Console.WriteLine("Yayy.....YOU WON!!");
                        return;
                    }

                    Dictionary<int, int> userInputFreq = new Dictionary<int, int>();
                    Dictionary<int, int> computerInputFreq = new Dictionary<int, int>();

                    for (int i = 0; i < 4; i++)
                    {
                        if (visited[i] == false)
                        {
                            if (userInputFreq.ContainsKey(userNumber[i] - '0'))
                            {
                                var val = userInputFreq[userNumber[i] - '0'];
                                userInputFreq.Remove(userNumber[i] - '0');
                                userInputFreq.Add(userNumber[i] - '0', val + 1);
                            }
                            else
                            {
                                userInputFreq.Add(userNumber[i] - '0', 1);
                            }
                        }
                    }
                    for (int i = 0; i < 4; i++)
                    {
                        if (visited[i] == false)
                        {
                            if (computerInputFreq.ContainsKey(secretCode[i] - '0'))
                            {
                                var val = computerInputFreq[secretCode[i] - '0'];
                                computerInputFreq.Remove(secretCode[i] - '0');
                                computerInputFreq.Add(secretCode[i] - '0', val + 1);
                            }
                            else
                            {
                                computerInputFreq.Add(secretCode[i] - '0', 1);
                            }
                        }
                    }

                    foreach (KeyValuePair<int, int> entry in userInputFreq)
                    {
                        if (computerInputFreq.ContainsKey(entry.Key))
                        {
                            while (userInputFreq[entry.Key] != 0 && computerInputFreq[entry.Key] != 0)
                            {
                                singleRoundResult += "COW ";
                                userInputFreq[entry.Key]--;
                                computerInputFreq[entry.Key]--;
                            }
                        }
                    }

                    Console.WriteLine(singleRoundResult);
                    if (singleRoundResult == "")
                    {
                        singleRoundResult += $"{userNumber}: No match found";
                    }
                    round++;

                    //Storing and displaying result

                    finalOutput.Add($"{userNumber}: " + singleRoundResult);
                    perInput.Push($"{userNumber}: " + singleRoundResult);

                    Console.WriteLine();
                    Console.WriteLine($"Input {round}");

                    while (perInput.Count > 0)
                    {
                        Console.WriteLine(perInput.Pop());
                    }
                    for (int j = finalOutput.Count - 1; j >= 0; j--)
                    {
                        perInput.Push(finalOutput[j]);
                    }

                    if (round == 10)
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
