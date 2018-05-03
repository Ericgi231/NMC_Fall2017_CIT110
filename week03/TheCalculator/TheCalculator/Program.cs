using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            //variables
            //
            int operand1, operand2;
            int sum, dif, mul;
            double div;
            string uInput;

            //greet
            //
            Console.WriteLine("Calculator");

            //get first number
            //
            Console.WriteLine("\nWhat is the first number?");
            uInput = Console.ReadLine();
            operand1 = int.Parse(uInput);

            //get second number
            //
            Console.WriteLine("\nWhat is the second number?");
            uInput = Console.ReadLine();
            operand2 = int.Parse(uInput);

            //get output
            //
            sum = operand1 + operand2;
            dif = operand1 - operand2;
            div = (double)operand1 / (double)operand2;
            mul = operand1 * operand2;

            //print sum
            //
            Console.WriteLine($"\nThe sum is {sum}");
            Console.WriteLine($"\nThe difference is {dif}");
            Console.WriteLine($"\nThe quotient is {div}");
            Console.WriteLine($"\nThe product is {mul}");




            //pause before end
            //
            Console.WriteLine("\nPress any key to continue");
            Console.ReadKey();
        }
    }
}
