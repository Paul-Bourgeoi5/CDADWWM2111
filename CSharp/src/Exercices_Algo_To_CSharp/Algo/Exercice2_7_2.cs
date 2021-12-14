using System;

namespace Algo
{
    class Exercice2_7_2
    {
        public static void Run()
        {
            const int twenty = 20;
            int i;  
            int youngCounter;
            int oldCounter;
            int twentyCounter;

            youngCounter = 0;
            oldCounter = 0;
            twentyCounter = 0;
            int[] peopleAge = new int[twenty];
            Console.WriteLine($"Enter the age of {twenty} persons one after anotherone");
            for (i = 0; i < peopleAge.Length; i++)
            {
                peopleAge[i] = int.Parse(Console.ReadLine());
            }
            for (i = 0; i < peopleAge.Length; i++)
            {
                if (peopleAge[i] < twenty)
                {
                    youngCounter++;
                  /*youngCounter = youngCounter + 1;
                    youngCounter += 1;*/
                }
                else if (peopleAge[i] > twenty)
                {
                    oldCounter++;
                }
                else
                {
                    twentyCounter++;
                }
            }

            if (youngCounter == 20)
            {
                Console.WriteLine("EVERYBODY IS LESS THAN 20");
            }
            else if (oldCounter == 20)
            {
                Console.WriteLine("EVERYBODY IS MORE THAN 20");
            }
            else
            {
                Console.WriteLine($"There are {youngCounter} young people\nthere are {oldCounter} old people\nThere are {twentyCounter} people who are 20");
            }


        }
    }
}
