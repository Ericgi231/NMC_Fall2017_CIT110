using System;
using FinchAPI;
using HidSharp;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grant_TellMeAboutIt
{
    class Program
    {
        //author: Eric Grant
        //title: Tell Me About It
        //description: 
        //date: 10-11-1017

        static void Main(string[] args)
        {
            //instantiate finch
            //
            Finch tim = new Finch();
            bool timConnected = tim.connect();

            //main app vars
            //
            int userChoice = 0;

            //main app loop
            //
            DisplayStartScreen(timConnected);

            DisplayGreenSelectAndSet(tim);

            do
            {
                userChoice = DisplayMainMenu();
                DecideAction(userChoice, tim);
            } while (userChoice != 7);

            DisplayEndScreen(tim);

            //diconnect finch
            //
            tim.disConnect();
        }

        static int DisplayMainMenu()
        {
            int userChoice;
            DisplayHeader("Main Menu");

            Console.WriteLine("Select an option:");
            Console.WriteLine("1. Temperature\n2. Flipped\n3. Beak\n4. Wings\n5. Light\n6. Obstacle \n7. Exit App");
            Console.Write(">");
            while (!int.TryParse(Console.ReadLine(), out userChoice) || userChoice < 1 || userChoice > 7)
            {
                Console.Write("Invalid data. Enter a valid number.\n>");
            }

            DisplayKeyToContinue();
            return userChoice;
        }

        static void DecideAction(int userChoice, Finch tim)
        {
            string timSide;

            switch (userChoice)
            {
                case 1:
                    DisplayTimTemp(tim);
                    break;

                case 2:
                    DisplayTimFlipped(tim);
                    break;

                case 3:
                    DisplayTimBeak(tim);
                    break;

                case 4:
                    DisplayTimWings(tim);
                    break;

                case 5:
                    Console.Write("Which sensor do you want to use? Left, Right, or average?\n>");
                    timSide = Console.ReadLine().ToLower();
                    while (timSide != "left" && timSide != "right" && timSide != "average")
                    {
                        Console.Write("Invalid data. Enter a valid string.\n>");
                        timSide = Console.ReadLine().ToLower();
                    }
                    DisplayKeyToContinue();
                    DisplayTimLight(timSide, tim);
                    break;

                case 6:
                    Console.Write("Which sensor do you want to use? Left or Right?\n>");
                    timSide = Console.ReadLine().ToLower();
                    while (timSide != "left" && timSide != "right")
                    {
                        Console.Write("Invalid data. Enter a valid string.\n>");
                        timSide = Console.ReadLine().ToLower();
                    }
                    DisplayKeyToContinue();
                    DisplayTimObstacle(timSide, tim);
                    break;

                default:
                    break;
            }
        }

        static void DisplayTimTemp(Finch tim)
        {
            DisplayHeader("Tim Temperature");

            Console.WriteLine($"Temperature: {tim.getTemperature()}");

            DisplayKeyToContinue();
        }

        static void DisplayTimFlipped(Finch tim)
        {
            DisplayHeader("Tim Flipped");

            if (!tim.isFinchUpsideDown())
            {
                Console.WriteLine("Tim is right side up.");
            } else if (tim.isFinchUpsideDown())
            {
                Console.WriteLine("Tim is upside down.");
            } else
            {
                Console.WriteLine("Tim is neither upside down or up right.");
            }

            DisplayKeyToContinue();
        }

        static void DisplayTimBeak(Finch tim)
        {
            DisplayHeader("Tim Beak Position");

            if (tim.isBeakDown())
            {
                Console.WriteLine("Tims beak is down.");
            } else if (tim.isBeakUp())
            {
                Console.WriteLine("Tims beak is up.");
            } else
            {
                Console.WriteLine("Tims beak is level.");
            }

            DisplayKeyToContinue();
        }

        static void DisplayTimWings(Finch tim)
        {
            DisplayHeader("Tim Wing Tilt");

            if (tim.isLeftWingDown())
            {
                Console.WriteLine("Tims left wing is down.");
            } else if (tim.isRightWingDown())
            {
                Console.WriteLine("Tims right wing is down.");
            } else
            {
                Console.WriteLine("Tim is level.");
            }

            DisplayKeyToContinue();
        }

        static void DisplayTimLight(string timSide, Finch tim)
        {
            DisplayHeader("Tim Light Detection");

            if (timSide == "left")
            {
                Console.WriteLine($"Tim detects that the light level in their left eye is {tim.getLeftLightSensor()}");
            }
            else if (timSide == "right")
            {
                Console.WriteLine($"Tim detects that the light level in their right eye is {tim.getRightLightSensor()}");
            }
            else if (timSide == "average")
            {
                Console.WriteLine($"Tim detects that the average light level is {(tim.getLeftLightSensor() + tim.getRightLightSensor()) / 2}");
            }

            DisplayKeyToContinue();
        }

        static void DisplayTimObstacle(string timSide, Finch tim)
        {
            DisplayHeader("Tim Obstacle Detection");

            if (timSide == "left")
            {
                Console.WriteLine($"Obstacle detected in Tims left eye: {tim.isObstacleLeftSide()}");
            }
            else if (timSide == "right")
            {
                Console.WriteLine($"Obstacle detected in Tims right eye: {tim.isObstacleRightSide()}");
            }

            DisplayKeyToContinue();
        }

        static void DisplayHeader(string title)
        {
            Console.WriteLine($"\t~~~{title}~~~\n");
        }

        static void DisplayKeyToContinue()
        {
            Console.CursorVisible = false;
            Console.WriteLine("\nPress any key to continue.");
            Console.ReadKey();
            Console.Clear();
            Console.CursorVisible = true;
        }

        static void DisplayStartScreen(bool timConnected)
        {
            DisplayHeader("Start Screen");

            Console.WriteLine("Tell Me About It");
            Console.WriteLine("Get some data from Tim the finch.");
            Console.WriteLine("Tims beak will be green while the app is running.");
            Console.WriteLine("Eric Grant");

            Console.WriteLine($"Tim connected = {timConnected}");

            DisplayKeyToContinue();
        }

        static int DisplayGreenSelect()
        {
            double shadeGreenPercent;

            Console.Write("What level of green would you like Tims nose to be?\nEnter a number between 0 and 1\n>");
            while (!double.TryParse(Console.ReadLine(), out shadeGreenPercent) || shadeGreenPercent < 0 || shadeGreenPercent > 1)
            {
                Console.Write("Invalid data. Please enter a decimal between 0 and 1.\n>");
            }

            int shadeGreenInt = Convert.ToInt32(255 * shadeGreenPercent);

            return shadeGreenInt;
        }

        static void DisplayGreenSelectAndSet(Finch tim)
        {
            DisplayHeader("Select Shade Of Green");

            int shadeGreen = DisplayGreenSelect();
            tim.setLED(0, shadeGreen, 0);

            DisplayKeyToContinue();
        }

        static void DisplayEndScreen(Finch tim)
        {
            tim.setLED(0, 0, 0);

            DisplayHeader("End Screen");

            Console.WriteLine("Thanks for using my app.");
            Console.WriteLine("Later nerd.");

            DisplayKeyToContinue();
        }
    }
}
