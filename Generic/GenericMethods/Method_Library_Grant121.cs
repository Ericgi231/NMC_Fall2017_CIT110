using System;
using FinchAPI;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Method_Library_Grant121
{
    public class Generic_Display
    {
        /// <summary>
        /// print header
        /// </summary>
        /// <param name="title">header string</param>
        public void DisplayHeader(string title)
        {
            Console.WriteLine($"\n~~~{title}~~~\n");
        }

        /// <summary>
        /// cleer screen then print header
        /// </summary>
        /// <param name="title">header string</param>
        public void DisplayNewScreen(string title)
        {
            Console.Clear();
            DisplayHeader(title);
        }

        /// <summary>
        /// display opening screen
        /// </summary>
        /// <param name="appName">name of application</param>
        /// <param name="appDesc">description of application</param>
        /// <param name="appAuth">authors of application</param>
        public void DisplayOpenScreen(string appName, string appDesc, string[] appAuth)
        {
            DisplayNewScreen("Opening Screen");
            Console.WriteLine($"Application: {appName}");
            Console.WriteLine($"Description: {appDesc}");
            Console.Write($"Author(s): ");
            foreach (string author in appAuth)
            {
                Console.Write($"{author},");
            }
            Console.WriteLine();
            DisplayAnyKey();
        }

        /// <summary>
        /// display closing screen
        /// </summary>
        /// <param name="appName">name of application</param>
        /// <param name="appAuth">authors of application</param>
        public void DisplayCloseScreen(string appName, string[] appAuth)
        {
            DisplayNewScreen("Closing Screen");
            Console.WriteLine($"Thank you for using {appName}.");
            Console.Write($"By: ");
            foreach (string author in appAuth)
            {
                Console.Write($"{author},");
            }
            Console.WriteLine("\nLater nerd.");
            DisplayAnyKey();
        }

        /// <summary>
        /// display prompt for user to press any key and pause program until key is pressed.
        /// </summary>
        public void DisplayAnyKey()
        {
            Console.CursorVisible = false;
            Console.WriteLine("\n~~~Press any key to continue~~~\n");
            Console.ReadKey();
            Console.CursorVisible = true;
        }
    }

    public class Generic_Input
    {
        /// <summary>
        /// get and return key press
        /// </summary>
        public string GetAnyKey()
        {
            string k;
            Console.Write(">");
            k = Console.ReadKey().ToString();
            return k;
        }

        /// <summary>
        /// get and return valid int
        /// </summary>
        /// <returns>int</returns>
        public int GetValidInt()
        {
            int i;
            do
            {
                Console.Write(">");
            }
            while (!int.TryParse(Console.ReadLine(), out i));
            return i;
        }

        /// <summary>
        /// get and return valid double
        /// </summary>
        /// <returns>int</returns>
        public double GetValidDouble()
        {
            double d;
            do
            {
                Console.Write(">");
            }
            while (!double.TryParse(Console.ReadLine(), out d));
            return d;
        }

        /// <summary>
        /// get and return a string
        /// </summary>
        /// <param name="toUpper">should string be all caps</param>
        /// <returns>string</returns>
        public string GetString(bool toUpper)
        {
            string s;
            Console.Write(">");
            s = Console.ReadLine().ToUpper();
            return s;
        }

        // TODO get and return a valid enum based on a given enumeration
        //
    }

    public class Generic_Alter
    {
        /// <summary>
        /// takes a multidimensional array and pulls a one-dimensional array from it
        /// </summary>
        /// <param name="mainArray">the multidimensional array pulling from</param>
        /// <param name="pullNum">the index of the array to be pulled</param>
        /// <param name="arrayLen">length of arrays inside main array</param>
        /// <returns>int array</returns>
        public int[] SpliceIntMultiArray(int[,] mainArray, int pullNum, int arrayLen)
        {
            int[] subArray = new int[arrayLen];

            for (int i = 0; i < arrayLen; i++)
            {
                subArray[i] = mainArray[pullNum, i];
            }

            return subArray;
        }
    }
}