using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quickCodeCars
{
    class Program
    {
        static void Main(string[] args)
        {
            //Eric Grant
            //car validator
            //validate users cars
            //9-27-2017
            //

            //vars
            //
            string uInput;
            double validData;
            bool valid = true;

            //get user input
            //
            //Console.Write("How many cars do you own?\n>");
            //uInput = Console.ReadLine();
            //while(!double.TryParse(uInput, out validData))
            //{
            //    Console.WriteLine("Invalid data, try again.\n");
            //    Console.Write("How many cars do you own?\n>");
            //    uInput = Console.ReadLine();
            //}

            do
            {
                Console.Write("How many cars do you own?\n>");
                uInput = Console.ReadLine();
                valid = double.TryParse(uInput, out validData);
                if (!valid)
                {
                    Console.WriteLine("Invalid data, try again.\n");
                }
            } while (!double.TryParse(uInput, out validData));

            //output data
            //
            Console.WriteLine($"You have {validData} cars.\n");

            //wait on end
            //
            Console.CursorVisible = false;
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }
}
