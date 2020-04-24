//Project Name: Cheat_codes.cs 
//File Name: Recursion.cs
//Author: Ben Gavrilov
//Due Date: April 4, 2017
//Modified Date: April 4, 2017
//Program Description: This program analyzes a text file to determine weather a sequence of letters is a cheat code. It then outputs the results onto the screen and an output file.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;

namespace Cheat_codes
{
    class Recursion
    {

        //A global counter to store the number of 'A' characters that have been found in a single string
        static int aCounter = 0;

        //A global character variable to store the first character of a single string
        static char firstChar;

        static void Main(string[] args)
        {

            //Create a variable to store the time passed
            Stopwatch watch = new Stopwatch();

            //Prompt the user into entering a file name
            Console.WriteLine("Enter name of text file in bin/debug folder");  

            //Run the following code and see if there is an exception that has occured
            try
            {

                //Read in the text document to an array of strings for each line
                string[] cheatCodes = System.IO.File.ReadAllLines(Console.ReadLine() + ".txt");

                //Start the timer
                watch.Start();

                //Clear the screen
                Console.Clear();

                //Create an empty text file named Gavrilov_B
                File.WriteAllText("Gavrilov_B.txt", String.Empty);

                // Create a new StreamWriter object to increase the buffer to 65.5k and speed up text writing
                using (StreamWriter fileOut = new StreamWriter("Gavrilov_B.txt", true, Encoding.UTF8, 65536))
                {

                    //Run the following code for each string in the array
                    foreach (string Line in cheatCodes)
                    {

                        //Reset the 'A' counter for every new string
                        aCounter = 0;

                        //Reset the first character for every new string
                        firstChar = Line[0];

                        //Output to the screen and store the result onto the file
                        Console.WriteLine(Line + ":" + IsItCheatCode(Line));
                        fileOut.WriteLine(Line + ":" + IsItCheatCode(Line));
                    }

                    //Close the out file
                    fileOut.Close();
                }
                
            }
            //Enter when any exception has occured
            catch (Exception e)
            {

                //Clear the screen and notify the user that there is an error
                Console.Clear();
                Console.WriteLine("Invalid- Unsuccessful Run");
            }

            //Stop the timer
            watch.Stop();

            //Get rid of this
            var elapsedMs = watch.ElapsedMilliseconds;
            double totalTime = Math.Round(elapsedMs * 0.001, 2);
            Console.WriteLine(totalTime);

            //Wait for any user input to end the program
            Console.ReadLine();
        }

        /// <summary>
        /// The program determines weather a a sequence of letters is a cheatcode
        /// </summary>
        /// <param name="input">The string that needs to be analyzed</param>
        /// <returns>A "yes" or "no" value as to if the string is a cheat code</returns>
        static public string IsItCheatCode(string input)
        {

            //If the first character is 'A' or 'X' then determine if the string length is 1
            if (firstChar == 'A' || firstChar == 'X')
            {
                if (input.Length == 1)
                {

                    //If the first index is 'X' and the aCounter is zero then return a "yes"
                    if (input[0] == 'X' && aCounter == 0)
                    {
                        return "YES";
                    }
                    //If the first index is 'B' and the aCounter is one then return a "yes"
                    else if (input[0] == 'B' && aCounter == 1)
                    {
                        return "YES";
                    }
                    //Otherwise return a "no"
                    return "NO";
                }
                //If the first index is 'A' then increment the aCounter and determine the options for the second index
                else if (input[0] == 'A')
                {
                    aCounter++;
                    switch(input[1])
                    {

                        //If the second index is 'X' then recurse the subprogram with the new string without the first index
                        case 'X':
                            input = input.Substring(1, input.Length - 1);
                            return IsItCheatCode(input);
                        //If the second index is 'A' then recurse the subprogram with the new string without the first index
                        case 'A':
                            input = input.Substring(1, input.Length - 1);
                            return IsItCheatCode(input);
                        //Otherwise return a "no"
                        default:
                            return "NO";
                    }
                }
                else if (input[0] == 'B' && aCounter != 0)
                {

                    //Increment the aCounter and determine the options for the second index
                    aCounter--;
                    switch (input[1])
                    {

                        //If the second index is 'Y' then recurse the subprogram with the new string without the first index
                        case 'Y':
                            input = input.Substring(1, input.Length - 1);
                            return IsItCheatCode(input);
                        //If the second index is 'B' then recurse the subprogram with the new string without the first index
                        case 'B':
                            input = input.Substring(1, input.Length - 1);
                            return IsItCheatCode(input);
                        //Otherwise return a "no"
                        default:
                            return "NO";
                    }
                }
                else if (input[0] == 'X')
                {

                    //Determine the options for the second index
                    switch (input[1])
                    {

                        //If the second index is 'B' then recurse the subprogram with the new string without the first index
                        case 'B':
                            input = input.Substring(1, input.Length - 1);
                            return IsItCheatCode(input);
                        //If the second index is 'Y' then recurse the subprogram with the new string without the first index
                        case 'Y':
                            input = input.Substring(1, input.Length - 1);
                            return IsItCheatCode(input);
                        //Otherwise return a "no"
                        default:
                            return "NO";
                    }
                }
                else if (input[0] == 'Y')
                {

                    //Determine the options for the second index
                    switch (input[1])
                    {

                        //If the second index is 'A' then recurse the subprogram with the new string without the first index
                        case 'A':
                            input = input.Substring(1, input.Length - 1);
                            return IsItCheatCode(input);
                        //If the second index is 'X' then recurse the subprogram with the new string without the first index
                        case 'X':
                            input = input.Substring(1, input.Length - 1);
                            return IsItCheatCode(input);
                        //Otherwise return a "no"
                        default:
                            return "NO";
                    }
                }
                //Otherwise return a "no" if the first index isn't any of the above options
                return "NO";
            }
            //Otherwise return a "no" if the first character is none of the above options
            return "NO";
        }
    }
}
