using System;

namespace CallFunctionsFromOtherProject
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Evaluation.PascalTriangle triangle = new();
            triangle.DisplayTenFirstPascalRows();
        }
    }
}
