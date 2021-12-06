using System;
using System.Collections.Generic;
using System.Text;

namespace Toto
{
    public class MaClasse
    {
        /// <summary>
        /// Print the message in the console and get user input
        /// </summary>
        /// <param name="message"></param>
        /// <returns>User input</returns>
        public static string GetUserInput(string message)
        {
            Console.Write(message+ " ");
            return Console.ReadLine();
        }
    }
}
