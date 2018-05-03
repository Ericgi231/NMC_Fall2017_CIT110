using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheConversation
{
    class Program
    {
        static void Main(string[] args)
        {
            //declaring variables
            //
            string uInput;
            string myName;
            string yName;
            int yAge;

            myName = "Eric";


            //set console
            //
            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.WindowHeight = 10;
            Console.WindowWidth = 50;
            Console.Clear();

            //talking to user and getting info
            //
            Console.WriteLine("Hello World!");
            Console.WriteLine("My name is {0}.\n",myName);

            Console.Write("What is your name? ");
            yName = Console.ReadLine();
            Console.Beep(261,1000);

            Console.Clear();

            Console.Write("What is your age? ");
            uInput = Console.ReadLine();
            yAge = int.Parse(uInput);
            Console.Beep(261,1000);

            Console.WriteLine($"\nHello {yName}!");
            
            //conditional to determine output based on age
            //
            if (yAge > 99)
            {
                Console.WriteLine($"You are probably dead!\n");

            }
            else if (yAge > 49 && yAge < 100)
            {
                Console.WriteLine($"Wowzers! You are such a wise man of good age!\n");

            }
            else
            {
                Console.WriteLine($"Nice! {yAge} year olds are my favorite!\n");
            }

            //end input
            //
            Console.Clear();
            Console.CursorVisible = false;
            Console.WriteLine("<Press ENTER To Close Window>");
            Console.Read();
        }
    }
}
