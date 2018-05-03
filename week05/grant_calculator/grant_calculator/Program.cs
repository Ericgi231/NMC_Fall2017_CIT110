using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace grant_calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            //Eric Grant
            //calculator
            //calculator using if elses
            //9-25-2017
            //

            //vars
            //
            string uInput = "";
            double operand1, operand2;
            string operation;
            string operationWord = "";
            double output = 0;

            //get operands from user
            //
            Console.WriteLine("Calculator by Eric Grant");

            Console.Write("Input first operand:\n>");
            uInput = Console.ReadLine();
            while (!double.TryParse(uInput, out operand1))
            {
                Console.Write("Invalid input\n\nInput first operand:\n>");
                uInput = Console.ReadLine();
            }

            Console.Write("\nInput second operand:\n>");
            uInput = Console.ReadLine();
            while (!double.TryParse(uInput, out operand2))
            {
                Console.Write("Invalid input\n\nInput second operand:\n>");
                uInput = Console.ReadLine();
            }

            //operation
            //
            Console.Write("\nEnter operation (add, subtract, multiply, divide):\n>");
            operation = Console.ReadLine().ToLower();

            //perform operation on operators
            //
            switch (operation)
            {
                case "add":
                    operationWord = "sum";
                    output = operand1 + operand2;
                    break;

                case "subtract":
                    operationWord = "difference";
                    output = operand1 - operand2;
                    break;

                case "multiply":
                    operationWord = "product";
                    output = operand1 * operand2;
                    break;

                case "divide":
                    operationWord = "quotient";
                    output = operand1 / operand2;
                    break;

                default:
                    Console.CursorVisible = false;
                    Console.WriteLine("\nInvalid input.");
                    Console.ReadKey();
                    Environment.Exit(0);
                    break;
            }

            //display output
            //
            Console.WriteLine($"\nThe {operationWord} of {operand1} and {operand2} is {output}");

            //pause on end
            //
            Console.CursorVisible = false;
            Console.WriteLine("\nPress any key to continue");
            Console.ReadKey();
        }
    }
}
