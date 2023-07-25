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
        int[] computerInput;
        public GameHandler(int[] compInput)
        {
            this.computerInput = compInput;
        }

        public void Game(int[] computerInput)
        {
            string computerNumber = "";
            Console.WriteLine(computerNumber);
            for (int i = 0; i < computerInput.Length; i++)
            {
                computerNumber += computerInput[i].ToString();
            }

            Console.WriteLine(computerNumber);

            int round = 0;

            List<string> finalOutput = new();
            Stack<string> perInput = new();

            while (round < 10)
            {
                Console.WriteLine();
                Console.WriteLine($"ROUND {round + 1}");
                string perInputOutput = "";

                int[] userInput = new int[4];
                string? userNumber = Console.ReadLine();

                int n;
                bool isNumeric = int.TryParse(userNumber, out n);

                if ( userNumber != null && userNumber.Length == 4 && isNumeric) 
                {
                    for (int i = 0; i < userInput.Length; i++)
                    {
                        userInput[i] = Convert.ToInt32(userNumber[i] - '0');
                    }
                }
                else
                {
                    Console.WriteLine("Enter correct input");
                }
                
                if (userInput != null)
                {
                    //Comparing computer number and user input
                    for (int i = 0; i < userInput.Length; i++)
                    {
                        if (computerInput[i] == userInput[i])
                        {
                            perInputOutput += "BULL ";
                            computerInput[i] = -1;
                            userInput[i] = -1;
                        }
                    }

                    Dictionary<int, int> userInputFreq = new Dictionary<int, int>();
                    Dictionary<int, int> computerInputFreq = new Dictionary<int, int>();

                    for(int i = 0; i<4; i++)
                    {
                        if(userInput[i] != -1)
                        {
                            if (userInputFreq.ContainsKey(userInput[i]))
                            {
                                var val = userInputFreq[userInput[i]];
                                userInputFreq.Remove(userInput[i]);
                                userInputFreq.Add(userInput[i], val + 1);
                            }
                            else
                            {
                                userInputFreq.Add(userInput[i], 1);
                            }
                        }
                    }
                    for (int i = 0; i < 4; i++)
                    {
                        if (computerInput[i] != -1)
                        {
                            if (computerInputFreq.ContainsKey(computerInput[i]))
                            {
                                var val = computerInputFreq[computerInput[i]];
                                computerInputFreq.Remove(computerInput[i]);
                                computerInputFreq.Add(computerInput[i], val + 1);
                            }
                            else
                            {
                                computerInputFreq.Add(computerInput[i], 1);
                            }
                        }
                    }

                    foreach(KeyValuePair<int, int> entry in userInputFreq)
                    {
                        if (computerInputFreq.ContainsKey(entry.Key))
                        {
                            while(userInputFreq[entry.Key] != 0 && computerInputFreq[entry.Key] != 0)
                            {
                                perInputOutput += "COW ";
                                userInputFreq[entry.Key]--;
                                Console.WriteLine(userInputFreq[entry.Key]);
                                computerInputFreq[entry.Key]--;
                                Console.WriteLine(computerInputFreq[entry.Key]);
                            }
                        }
                    }

                    //int[] userInputFreqArray = new int[10];
                    //int[] computerInputFreqArray = new int[10];

                    //for(int i=0; i<userInput.Length; i++)
                    //{
                    //    if (userInput[i] != -1)
                    //    {
                    //        userInputFreqArray[userInput[i]]++;
                    //    }
                    //}
                    //for (int i = 0; i < computerInput.Length; i++)
                    //{
                    //    if (computerInput[i] != -1)
                    //    {
                    //        computerInputFreqArray[computerInput[i]]++;
                    //    }
                    //}

                    //for (int i = 0; i < 10; i++)
                    //{
                    //    if (userInputFreqArray[i] > 0 && computerInputFreqArray[i] > 0)
                    //    {
                    //        while (userInputFreqArray[i] != 0 && computerInputFreqArray[i] != 0)
                    //        {
                    //            perInputOutput += "COW ";
                    //            userInputFreqArray[i]--;
                    //            computerInputFreqArray[i]--;
                    //        }
                    //    }
                    //}

                    Console.WriteLine(perInputOutput);
                    if (perInputOutput == "")
                    {
                        perInputOutput += $"{userNumber}: No match found";
                    }

                    for (int i = 0; i < computerInput.Length; i++)
                    {
                        computerInput[i] = Convert.ToInt32(computerNumber[i] - '0');
                    }
                    round++;

                    //Storing and displaying result

                    finalOutput.Add($"{userNumber}: " + perInputOutput);
                    perInput.Push($"{userNumber}: " + perInputOutput);

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
                    if (perInputOutput == "BULL BULL BULL BULL ")
                    {
                        Console.WriteLine("Yayy.....YOU WON!!");
                        return;
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
