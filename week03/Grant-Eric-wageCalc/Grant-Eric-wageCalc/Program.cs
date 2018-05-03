using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grant_Eric_wageCalc
{
    class Program
    {
        static void Main(string[] args)
        {
            //declaring variables
            //
            string input;
            double hours;
            double earned;
            double wage = 10.75;

            //greet user and ask for hours worked
            //
            Console.WriteLine("Hello fellow kid!\n");
            Console.Write("Did you work this week?\nyes or no\n>");
            input = Console.ReadLine();

            if (input == "yes")
            {
                Console.Write("\nHow many hours did you work this week?\n>");
                input = Console.ReadLine();
                hours = Double.Parse(input);

                earned = hours * wage;

                Console.WriteLine($"\nIf you make ${wage} an hour, then you made ${earned} this week.");
            }
            else if (input == "no")
            {
                Console.WriteLine("\nGet a job.");
            }

            //end
            //
            Console.WriteLine("\nPress any key to continue");
            Console.ReadKey();

        }
    }
}
