using System;
using System.Linq;
using System.Collections.Generic;
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

            /*The most basic computation should be of the form number-operator-number
             Convert number-strings into floats then do computation using the inputted operator.
             This part of the code currently geared towards simplest computation (num-op-num). Still needs to
             be extended to handle longer computations. */
            List<float> numbers = new List<float> { };
            char op = '!';
            foreach (string item in parts)
                try
                {
                    float num = Int32.Parse(item);
                    numbers.Add(num);
                    //Console.WriteLine(item + " is a number");
                }
                // Catch exception to determine the operator
                catch(FormatException)
                {
                    if ( Array.IndexOf(operations, item[0]) > -1 )
                    {
                        op = operations[Array.IndexOf(operations, item[0])];
                        //Console.WriteLine(item + " is a valid operation");
                    }
                    else
                    {
                        Console.WriteLine(item + " is NOT a valid operation");
                    }
                    
                }
            
            try
            {
                float ans = compute(numbers[0], numbers[1], op); //issue with op variable here
                Console.WriteLine("Answer: " + ans);
            }
            catch
            {
                Console.WriteLine("Error in computing...");
            }
               
        }

        // Function to perform simplest computation
        public static float compute(float num1, float num2, char op)
        {
            float ans = 0;
            //Console.WriteLine("Your equation is: " + num1 + op + num2);
            if (op.Equals('+'))
            {
                ans = num1 + num2;
                return ans;
            }
            if (op.Equals('-'))
            {
                ans = num1 - num2;
                return ans;
            }
            if (op.Equals('*'))
            {
                ans = num1 * num2;
                return ans;
            }
            if (op.Equals('/'))
            {
                ans = num1 / num2;
                return ans;
            }

            return ans;
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