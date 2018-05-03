using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickCodeName
{
    class Program
    {
        //author:Eric Grant
        //title:Method Quick Code
        //description:Get user name and return it
        //date:10/16/17

        static void Main(string[] args)
        {
            string name = DisplayGetUserName();
            DisplayUserName(name);
        }

        /// <summary>
        /// Display a screen that propts the user for their name
        /// </summary>
        /// <returns>the inputed name</returns>
        static string DisplayGetUserName()
        {
            Console.Write("What is your name?\n>");
            string name = Console.ReadLine();

            DisplayAnyKeyToContinue();
            return name;
        }

        /// <summary>
        /// Display the users name
        /// </summary>
        /// <param name="name">the users name</param>
        static void DisplayUserName(string name)
        {
            Console.WriteLine($"Your name is {name}");
            DisplayAnyKeyToContinue();
        }

        /// <summary>
        /// prompt user to press any key to continue
        /// </summary>
        static void DisplayAnyKeyToContinue()
        {
            Console.WriteLine("\nPress any key to continue.");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
