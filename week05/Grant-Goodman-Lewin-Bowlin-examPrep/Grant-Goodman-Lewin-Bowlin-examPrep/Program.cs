using System;
using FinchAPI;
using HidSharp;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grant_Goodman_Lewin_Bowlin_examPrep
{
    class Program
    {
        static void Main(string[] args)
        {
            //eric grant, gabe goodman, shawn lewin, James Bowlin
            //exam prep
            //understanding concepts that will be on the exam
            //9-27-2017

            //instantiate finch boy
            //
            Finch myFinch = new Finch();

            //vars
            //
            double cars = 6.5;
            int cars2 = (int)cars;

            //methods
            //
            
            void CodeThing(int num1, int num2)
            {
                num1 = num1 + num2;
                Console.WriteLine($"{num1}");
            }

            //main
            //
            CodeThing(5,10);
            CodeThing(10,20);

            Console.WriteLine($"{cars}");
            Console.WriteLine($"{cars2}");


            //wait on end
            //
            Console.CursorVisible = false;
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }
}
