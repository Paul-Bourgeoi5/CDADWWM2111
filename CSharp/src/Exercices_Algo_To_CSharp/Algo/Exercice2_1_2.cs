using System;
using System.Text;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Algo
{
    class Exercice2_1_2
    {
        /// <summary>
        /// CNot exactly corresponding to the asked exercice
        /// </summary>
        public static void Run()
        {
            const double min = 0.01;
            const double max = 1000000;
            string userInput;
            string matchedInput;
            double distance;
            bool keepGoing = true;
            // Regular expression looking for a 'q' as first character or looking for a distance with or without unit
            Regex mainRegex = new Regex(@"^q|([0-9]+(,[0-9]+)?\s*(mi|km)?)");
            //Regular expression looking for distances
            Regex distanceRegex = new Regex(@"^[0-9]+(,[0-9]+)?");
            MatchCollection matches;
            while (keepGoing)
            {
                Console.WriteLine("Please enter a valid value between 0.01 and 1.000.000 with a unit (km or mi) or quit with 'q'");
                userInput = Console.ReadLine();
                if (mainRegex.IsMatch(userInput))
                {
                    matches = mainRegex.Matches(userInput);
                    if (matches[0].Value.Equals("q")){
                        Console.WriteLine("Bye bye ...\n\nYou can press any key to leave");
                        Console.ReadKey();
                        Environment.Exit(0);
                    }
                    else
                    {
                        foreach (Match conversionNeeded in matches)
                        {
                            matchedInput = conversionNeeded.Value;
                            distance = double.Parse(distanceRegex.Match(matchedInput).Value);

                            if (distance > min && distance < max)
                            {
                                if (matchedInput.ToLower().EndsWith("mi"))
                                {
                                    Console.WriteLine($"{distance} miles is equal to {distance * 1.609d} kilometers\n");
                                }
                                else
                                {
                                    Console.WriteLine($"{distance} kilometers is equal to {distance / 1.609d} miles\n");
                                }
                            }
                            else
                            {
                                Console.WriteLine($"{distance} OUT OF BOUND");
                            }
                        }
                    }
                }
                else
                {
                    Console.WriteLine($"\n{userInput} is an INVALID VALUE\n");
                }
            }
        }
    }
}