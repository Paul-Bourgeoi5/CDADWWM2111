using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algo
{
    class Exercice2_1_3
    {
        public static void Run()
        {
            string userInput;
            const string go = "go";
            const string quit = "quit";
            int index = 0;
            string[] userInputs = new string[20];

            do
            {
                Console.WriteLine("Saisisez une distance avec son unité(km ou mi) ou lancez la conversion avec go ou quitter le programme avec quit");
                userInput = Console.ReadLine();
                if (userInput.Equals(quit))
                {
                    QuitterProgramme();
                }
                if (userInput.Equals(go))
                {
                    ConvertAllPreviousInputs(userInputs);
                }
                else
                {
                    userInput = CheckUserInput(userInput);
                    index = AddUserInputToInputs(userInput, userInputs, index);
                }
            } while (true);



        }

        private static int AddUserInputToInputs(string userInput, string[] inputs, int index)
        {
            if (!userInput.Equals(""))
            {
                inputs[index] = userInput;
                index++;   
                if (index == inputs.Length)
                {
                    index = 0;
                }
            }
            return index;
        }

        private static string CheckUserInput(string userInput)
        {
            string[] splitInput = userInput.Split(' ');
            const string kilometers = " km";
            const string emptyString = "";

            if (splitInput[0] == "")
            {
                return emptyString;
            }
            if (splitInput.Length == 1)
            {
                return (userInput + kilometers);
            }
            else
            {
                return userInput;
            }
            
        }

        private static void ConvertAllPreviousInputs(string[] inputs)
        {
            const string miles = "mi";
            string[] input;
            double resultConversion;
            int index;

            for (index = 0; index < inputs.Length; index++)
            {
                if (inputs[index] != null)
                {
                    input = inputs[index].Split(' ');
                    if (input[0] != "")
                    {
                        if (input[1] == miles)
                        {
                            resultConversion = Double.Parse(input[0]) * 1.609d;
                            Console.WriteLine($"{input[0]} miles = {resultConversion} kilomètres");
                        }
                        else
                        {
                            resultConversion = Double.Parse(input[0]) / 1.609d;
                            Console.WriteLine($"{input[0]} kilomètres = {resultConversion} miles");
                        }
                    }
                  
                }
            }
            Array.Clear(inputs,0, inputs.Length);

        }

        private static void QuitterProgramme()
        {
            Environment.Exit(0);
        }
    }
}
