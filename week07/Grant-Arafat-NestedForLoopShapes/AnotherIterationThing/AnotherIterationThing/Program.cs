using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnotherIterationThing
{
    class Program
    {
        //declare vars
        //
        static int width;
        static int height;
        static string selectedShape;
        static bool running = true;

        static void Main(string[] args)
        {
            //eric grant, Kazi Arafat
            //for loop shapes
            //make shapes out of stars using for loops
            //10-4-2017
            //10-9-2017

            OpeningScreen();
            
            while (running)
            {
                DisplayMenu();
                if (running)
                {
                    GetShapeDimensions();
                    DisplayShape(selectedShape);
                }
            }
            
            ClosingScreen();
        }

        static void DisplayHeader(string title)
        {
            Console.Clear();
            Console.WriteLine($"~~~{title}~~~\n");
        }

        /// <summary>
        /// display opening screen
        /// </summary>
        static void OpeningScreen()
        {
            Console.WriteLine("***Fancy Shapes***");
            Console.WriteLine("We gon draw some real fancy shapes right soon.");

            AnyKeyToContinue(true);
        }

        /// <summary>
        /// display a menu that propts the user to select their desired shape
        /// </summary>
        static void DisplayMenu()
        {
            bool breakLoop = false;

            DisplayHeader("Main Menu");

            Console.WriteLine("Select your desired shape:");
            Console.Write("<Square\n<Rectangle\n<Triangle\n<Hollow Rectangle\n<Flipped Triangle\n<Hollow Triangle\n<Exit\nExtra Shapes:\n<Pyramid\n<Diamond\n<Parallelogram\n>");

            while (!breakLoop)
            {
                selectedShape = Console.ReadLine().ToLower();
                switch (selectedShape)
                {
                    case "square":
                    case "rectangle":
                    case "triangle":
                    case "hollow triangle":
                    case "hollow rectangle":
                    case "flipped triangle":
                    case "pyramid":
                    case "diamond":
                    case "parallelogram":
                        breakLoop = true;
                        break;

                    case "exit":
                        running = false;
                        breakLoop = true;
                        break;

                    default:
                        Console.Write("Invalid input.\n>");
                        break;
                }
            }
            breakLoop = false;

            AnyKeyToContinue(true);
        }

        /// <summary>
        /// display a selected shape
        /// </summary>
        static void DisplayShape(string shape)
        {
            switch (shape)
            {
                case "square":
                    PrintFilledSquare(width);
                    break;

                case "rectangle":
                    PrintFilledRectangle(height,width);
                    break;

                case "triangle":
                    PrintFilledRightTriangle(height);
                    break;

                case "hollow triangle":
                    PrintHollowTriangle(height);
                    break;

                case "hollow rectangle":
                    PrintHollowRectangle(height,width);
                    break;

                case "flipped triangle":
                    PrintFlippedTriangle(height);
                    break;

                case "pyramid":
                    PrintPyramid(height);
                    break;

                case "diamond":
                    PrintDiamond(width);
                    break;

                case "parallelogram":
                    PrintParallelogram(height,width);
                    break;

                default:
                    break;
            }
        }

        /// <summary>
        /// get input on height and width from user
        /// </summary>
        static void GetShapeDimensions()
        {
            DisplayHeader("User Input");
            Console.WriteLine("Please enter a width.");
            while(!int.TryParse(Console.ReadLine(),out width)){
                Console.Write("Invalid data. Please enter an int.\n>");
            }
            Console.WriteLine("Please enter a height.");
            while (!int.TryParse(Console.ReadLine(), out height))
            {
                Console.Write("Invalid data. Please enter an int.\n>");
            }
        }

        /// <summary>
        /// display closing screen
        /// </summary>
        static void ClosingScreen()
        {
            Console.Clear();
            Console.WriteLine("***Later Nerd***");

            AnyKeyToContinue(false);
        }

        /// <summary>
        /// prompt user to press any key to continue
        /// </summary>
        /// <param name="clear">should screen be cleared</param>
        static void AnyKeyToContinue(bool clear)
        {
            Console.CursorVisible = false;
            Console.WriteLine("\nPress any key to continue.\n");
            Console.ReadKey();
            Console.CursorVisible = true;
            if (clear)
            {
                Console.Clear();
            }
        }

        /// <summary>
        /// Print a filled square out of stars
        /// </summary>
        /// <param name="width">width of square</param>
        static void PrintFilledSquare(int width)
        {
            DisplayHeader("Filled Square");
            for (int y = 0; y < width; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    Console.Write("* ");
                }
                Console.WriteLine("");
            }
            AnyKeyToContinue(true);
        }

        /// <summary>
        /// Print a filled rectangle out of stars
        /// </summary>
        /// <param name="width">width of rectangle</param>
        /// <param name="height">height of rectangle</param>
        static void PrintFilledRectangle(int width, int height)
        {
            DisplayHeader("Filled Rectangle");
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    Console.Write("* ");
                }
                Console.WriteLine("");
            }
            AnyKeyToContinue(true);
        }

        /// <summary>
        /// Print a filled right triangle out of stars
        /// </summary>
        /// <param name="height">height of triangle</param>
        static void PrintFilledRightTriangle(int height)
        {
            DisplayHeader("Filled Right Triangle");
            for (int y = 0; y < height; y++)
            {
                for (int x = -1; x < y; x++)
                {
                    Console.Write("* ");
                }
                Console.WriteLine("");
            }
            AnyKeyToContinue(true);
        }

        /// <summary>
        /// print a hollow rectangle
        /// </summary>
        /// <param name="height">height of rectangle</param>
        /// <param name="width">width of rectangle</param>
        static void PrintHollowRectangle(int height, int width)
        {
            DisplayHeader("Hollow Rectangle");
            for (int y = 0; y < height; y++)
            {
                if (y == 0 || y == height - 1)
                {
                    for (int x = 0; x < width; x++)
                    {
                        Console.Write("* ");
                    }
                    
                } else
                {
                    Console.Write("* ");
                    for (int x = 0; x < width - 2; x++)
                    {
                        Console.Write("  ");
                    }
                    Console.Write("* ");
                }
                Console.WriteLine("");
            }
            AnyKeyToContinue(true);
        }

        /// <summary>
        /// Print a flipped filled right triangle out of stars
        /// </summary>
        /// <param name="height">height of triangle</param>
        static void PrintFlippedTriangle(int height)
        {
            DisplayHeader("Flipped Triangle");
            for (int y = 0; y < height; y++)
            {
                for (int x = width; x > y; x--)
                {
                    Console.Write("  ");
                }
                for (int x = -1; x < y; x++)
                {
                    Console.Write("* ");
                }
                Console.WriteLine("");
            }
            AnyKeyToContinue(true);
        }

        /// <summary>
        /// Print a hollow right triangle out of stars
        /// </summary>
        /// <param name="height">height of triangle</param>
        static void PrintHollowTriangle(int height)
        {
            int currentLine = 0;
            DisplayHeader("Hollow Triangle");
            for (int y = 0; y < height; y++)
            {
                if (y == 0)
                {
                    Console.Write("* ");
                } else if (y == height - 1)
                {
                    for (int x = 0; x < height; x++)
                    {
                        Console.Write("* ");
                    }
                }
                else
                {
                    Console.Write("* ");
                    for (int x = 1; x < currentLine; x++)
                    {
                        Console.Write("  ");
                    }
                    Console.Write("* ");
                }
                Console.WriteLine("");
                currentLine++;
            }
            AnyKeyToContinue(true);
        }

        static void PrintPyramid(int height)
        {
            int currentLine1 = 1;
            int currentLine2 = 1;
            DisplayHeader("Pyramid");
            for (int y = 0; y < width; y++)
            {
                for (int x = 1; x < height - currentLine2 + 2; x++)
                {
                    Console.Write("  ");
                }
                for (int x = 0; x < currentLine1; x++)
                {
                    Console.Write("* ");
                }
                currentLine1 += 2;
                currentLine2++;
                Console.WriteLine();
            }
            AnyKeyToContinue(true);
        }

        static void PrintDiamond(int width)
        {
            int currentLine1 = 1;
            int currentLine2 = 1;
            DisplayHeader("Diamond");
            for (int y = 0; y < width / 2; y++)
            {
                for (int x = 1; x < height / 2 - currentLine2 + 2; x++)
                {
                    Console.Write("  ");
                }
                for (int x = 0; x < currentLine1; x++)
                {
                    Console.Write("* ");
                }
                currentLine1 += 2;
                currentLine2++;
                Console.WriteLine();
            }

            for (int y = 0; y < width / 2 + 1; y++)
            {
                for (int x = 0; x < height / 2 - currentLine2 + 1; x++)
                {
                    Console.Write("  ");
                }
                for (int x = 0; x < currentLine1; x++)
                {
                    Console.Write("* ");
                }
                currentLine1 -= 2;
                currentLine2--;
                Console.WriteLine();
            }
            AnyKeyToContinue(true);
        }

        static void PrintParallelogram(int height, int width)
        {
            DisplayHeader("Parallelogram");
            for (int y = 0; y < height; y++)
            {
                for (int x = width; x > y; x--)
                {
                    Console.Write("  ");
                }
                for (int x = -1; x < y; x++)
                {
                    Console.Write("* ");
                }
                for (int x = height; x > y; x--)
                {
                    Console.Write("* ");
                }
                Console.WriteLine("");
            }
            AnyKeyToContinue(true);
        }
    }
}
