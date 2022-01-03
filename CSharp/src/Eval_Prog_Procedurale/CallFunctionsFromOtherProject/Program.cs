using System;
using System.Diagnostics;

namespace CallFunctionsFromOtherProject
{
    class Program
    {
        static void Main(string[] args)
        {
            /*Persons cdas = new();
            Person cyril = new Person { Age = 121, Name = "Cyril" };
            cdas.Add(new Person { Age = 25, Name = "Xavier" });
            cdas.Add(cyril);
            cdas.Add(new Person { Age = 30, Name = "Julien" });
            cdas.Add(new Person { Age = 35, Name = "Fabrice" });
            cdas.Add(new Person { Age = 15, Name = "Axel" });
            cdas.Add(new Person { Age = 40, Name = "Ernest" });

            cdas.Reverse();


            Console.WriteLine(cdas.ToString());*/
            Stopwatch watch = new();
            Console.WriteLine("With StringBuilder :");
            watch.Start();
            for (int i = 0; i < 5; i++)
            {
                StringVsStringBuilder.WithStringBuilder().ToString();
            }
            watch.Stop();

            Console.WriteLine(watch.ElapsedMilliseconds);
            Console.WriteLine("\nWihoutStringBuilder :");
            watch.Restart();
            for (int i = 0; i < 5; i++)
            {
                StringVsStringBuilder.WithoutStringBuilder();
            }
            watch.Stop();
            Console.WriteLine(watch.ElapsedMilliseconds);

        }



    }
}
