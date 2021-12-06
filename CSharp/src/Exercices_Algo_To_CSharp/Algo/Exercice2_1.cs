using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algo
{
    class Exercice2_1
    {
        public static void Run()
        {
            string userInput;
            double kilometers;
            do
            {
                Console.WriteLine("Enter a distance in kilometers to convert it to miles or press 'q' to quit");
                userInput = Console.ReadLine();
                if (userInput.Equals("q"))
                {
                    Console.WriteLine("Bye bye");
                    Environment.Exit(0);
                }
                else
                {
                    if (CheckIsNumber(userInput, out kilometers))
                    {
                        if (kilometers > 0.01d && kilometers < 1000000d)
                        {
                            Console.WriteLine($"{kilometers} kilometers are equal to {ConvertKilometersToMiles(kilometers)} miles");
                        } else
                        {
                            Console.WriteLine("\nInvalid Input\n");
                        }
                    } 
                    else
                    {
                        Console.WriteLine("\nInvalid Input\n");
                    }
                }
            } while (true);
        }


        public static void Run2()
        {
            string userInput;
            double distance;
            string[] distanceAndUnits;
            do
            {
                Console.Write("Enter a distance and its unit (km or mi) spaced with a space to be converted or press 'q' to quit : ");
                userInput = Console.ReadLine();
                if (userInput.Equals("q"))
                {
                    Console.WriteLine("Bye bye");
                    Environment.Exit(0);
                }
                else
                {
                    distanceAndUnits = userInput.Split(' ');
                    if (CheckIsNumber(distanceAndUnits[0], out distance))
                    {
                        if (distance > 0.01d && distance < 1000000d)
                        {
                            if (CheckIfMiles(distanceAndUnits))
                            {
                                Console.WriteLine($"{distance} miles are equal to {ConvertMilesToKilometers(distance)} kilometers");
                            }
                            else
                            {
                                Console.WriteLine($"{distance} kilometers are equal to {ConvertKilometersToMiles(distance)} miles");
                            }
                        }
                        else
                        {
                            Console.WriteLine("\nInvalid Input\n");
                        }
                    }
                    else
                    {
                        Console.WriteLine("\nInvalid Input\n");
                    }
                }
            } while (true);
        }


        /// <summary>
        /// Convert a miles distance into kilometers
        /// </summary>
        /// <param name="miles"></param>
        /// <returns>A distance converted into kilometers from miles</returns>
        private static double ConvertMilesToKilometers(double miles)
        {
            return (miles * 1.609d);
        }


        /// <summary>
        /// Check if the units entered by the user is "mi"
        /// </summary>
        /// <param name="distanceAndUnits"></param>
        /// <returns>True if the user wants to convert miles to kilometers</returns>
        private static bool CheckIfMiles(string[] distanceAndUnits)
        {
            return (distanceAndUnits.Length > 1 && distanceAndUnits[1] == "mi");
        }



        /// <summary>
        /// Check if a string can be converted to double. If it can, then convert the string in seconde parameter
        /// </summary>
        /// <param name="stringToCheck"></param>
        /// <param name="kilometers"></param>
        /// <returns>return true if the string param can be converted to double</returns>
        private static bool CheckIsNumber(string stringToCheck, out double kilometers)
        {
            return double.TryParse(stringToCheck, out kilometers);
        }

        /// <summary>
        /// Convert a kilometers distance into miles
        /// </summary>
        /// <param name="kilometers"></param>
        /// <returns>A distance in miles</returns>
        private static double ConvertKilometersToMiles(double kilometers)
        {
            return (kilometers / 1.609d);
        }
    }
}
