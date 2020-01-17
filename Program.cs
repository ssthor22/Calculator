using System;
using System.Text.RegularExpressions;

namespace Computation
{
    class Calculator
    {
        public static void ProcessEq(string equation)
        {
            //Parse the equation using regular expression
            equation = equation.Replace(" ", "");
            char[] operations = { '+', '-', '*', '/' };
            string[] parts = Regex.Split(equation, @"(?<=[-+*/()])|(?=[-+*/()])");
            foreach (var item in parts)
                Console.WriteLine(item);
        }

        static void Main()
        {
            string usrinput;

            Console.WriteLine("Calculator\n");
            Console.WriteLine("----------\n");
            Console.WriteLine("Enter your math equation:\n");
            usrinput = Console.ReadLine();

            ProcessEq(usrinput);
        }
    }

        
}