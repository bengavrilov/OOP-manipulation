using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Cheat_codes
{
    class Program
    {
        static int aCounter = 0;
        static char firstChar;
        static StreamWriter fileOut = new StreamWriter(@"G:\Cheat codes\Cheat codes\obj\Debug\Results.txt");
        static string[] cheatCodes = System.IO.File.ReadAllLines(@"G:\Cheat codes\Cheat codes\obj\Debug\RecursionTest1024.txt");
        static int correctCount;

        static void Main(string[] args)
        {           
            var watch = System.Diagnostics.Stopwatch.StartNew();
            for (int i = 0; i < cheatCodes.Count(); i++)
            {
                aCounter = 0;
                firstChar = cheatCodes[i][0];
                if (IsItCheatCode(cheatCodes[i]) == "Yes")
                {
                    correctCount++;
                }
                Console.WriteLine(cheatCodes[i] + ":" + IsItCheatCode(cheatCodes[i]));
                fileOut.WriteLine(cheatCodes[i] + ":" + IsItCheatCode(cheatCodes[i]));
            }

            Console.WriteLine("Number of Cheat Codes: " + correctCount);
            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;
            double totalTime = Math.Round(elapsedMs * 0.001, 2);
            Console.WriteLine("Total Time: " + totalTime);
            Console.ReadLine();
        }

        /*static public string IsItCheatCode(string input)
        {
            if (firstChar == 'A' || firstChar == 'X')
            {
                if (input.Length == 1)
                {
                    if (input[0] == 'X' && aCounter == 0)
                    {
                        return "Yes";
                    }
                    else if (input[0] == 'B' && aCounter == 1)
                    {
                        return "Yes";
                    }
                    return "No";
                }
                else if (input[0] == 'A')
                {
                    aCounter++;
                    if (input[1] == 'X')
                    {
                        input = input.Substring(1, input.Length - 1);
                        return IsItCheatCode(input);
                    }
                    else if (input[1] == 'A')
                    {
                        input = input.Substring(1, input.Length - 1);
                        return IsItCheatCode(input);
                    }
                    return "No";
                }
                else if (input[0] == 'B' && aCounter != 0)
                {
                    aCounter--;
                    if (input[1] == 'Y')
                    {
                        input = input.Substring(1, input.Length - 1);
                        return IsItCheatCode(input);
                    }
                    else if (input[1] == 'B')
                    {
                        input = input.Substring(1, input.Length - 1);
                        return IsItCheatCode(input);
                    }
                    return "No";
                }
                else if (input[0] == 'X')
                {
                    if (input[1] == 'B')
                    {
                        input = input.Substring(1, input.Length - 1);
                        return IsItCheatCode(input);
                    }
                    else if (input[1] == 'Y')
                    {
                        input = input.Substring(1, input.Length - 1);
                        return IsItCheatCode(input);
                    }
                    return "No";
                }
                else if (input[0] == 'Y')
                {
                    if (input[1] == 'A')
                    {
                        input = input.Substring(1, input.Length - 1);
                        return IsItCheatCode(input);
                    }
                    else if (input[1] == 'X')
                    {
                        input = input.Substring(1, input.Length - 1);
                        return IsItCheatCode(input);
                    }
                    return "No";
                }
                return "No";
            }
            return "No";
        }*/

        static public string IsItCheatCode(string input)
        {
            if (firstChar == 'A' || firstChar == 'X')
            {
                if (input.Length == 1)
                {
                    if (input[0] == 'X' && aCounter == 0)
                    {
                        return "Yes";
                    }
                    else if (input[0] == 'B' && aCounter == 1)
                    {
                        return "Yes";
                    }
                    return "No";
                }
                else if (input[0] == 'A')
                {
                    aCounter++;
                    switch(input[1])
                    {
                        case 'X':
                            input = input.Substring(1, input.Length - 1);
                            return IsItCheatCode(input);                    
                        case 'A':
                            input = input.Substring(1, input.Length - 1);
                            return IsItCheatCode(input);
                        default:
                            return "No";
                    }
                }
                else if (input[0] == 'B' && aCounter != 0)
                {
                    aCounter--;
                    switch (input[1])
                    {
                        case 'Y':
                            input = input.Substring(1, input.Length - 1);
                            return IsItCheatCode(input);
                        case 'B':
                            input = input.Substring(1, input.Length - 1);
                            return IsItCheatCode(input);
                        default:
                            return "No";
                    }
                }
                else if (input[0] == 'X')
                {
                    switch (input[1])
                    {
                        case 'B':
                            input = input.Substring(1, input.Length - 1);
                            return IsItCheatCode(input);
                        case 'Y':
                            input = input.Substring(1, input.Length - 1);
                            return IsItCheatCode(input);
                        default:
                            return "No";
                    }
                }
                else if (input[0] == 'Y')
                {
                    switch (input[1])
                    {
                        case 'A':
                            input = input.Substring(1, input.Length - 1);
                            return IsItCheatCode(input);
                        case 'X':
                            input = input.Substring(1, input.Length - 1);
                            return IsItCheatCode(input);
                        default:
                            return "No";
                    }
                }
                return "No";
            }
            return "No";
        }
    }
}
