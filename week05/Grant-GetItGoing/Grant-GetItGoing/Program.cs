using System;
using FinchAPI;
using HidSharp;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grant_GetItGoing
{
    class Program
    {
        static void Main(string[] args)
        {
            //eric grant
            //get it going
            //get user input and have the finch use it
            //9-27-2017
            //

            //instantiate finch and console
            //
            Finch tim = new Finch();
            bool finchDetected = tim.connect();

            Console.Title = "Get It Going, Eric Grant";

            //vars
            //
            string uInput;
            string uName;

            int[] timColor = {0,0,0};
            string timColorWord;
            string timDisplay = "";
            int timTone;
            int timDuration;
            int timSpeed;
            double timSpeedDisplay;

            bool running = true;
            bool breakLoop = false;
            bool correctInput = true;

            //methods
            //
            ///<summary>pause until user presses a key</summary>
            void KeyToContinue()
            {
                Console.CursorVisible = false;
                Console.WriteLine("\nPress any key to continue.");
                Console.ReadKey();
                Console.Clear();
                Console.CursorVisible = true;
            }

            ///<summary>set a colored header text</summary>
            void SetHeader(string headText, ConsoleColor headColor)
            {
                Console.ForegroundColor = headColor;
                Console.WriteLine($"{headText}\n");
                Console.ForegroundColor = ConsoleColor.White;
            }

            //title card
            //
            SetHeader("Title Card", ConsoleColor.Green);
            Console.WriteLine("Get It Going\nBy: Eric Grant\n");
            Console.WriteLine("This program will ask you for input that will be used by the finch.\n");
            if (finchDetected)
            {
                Console.WriteLine("Finch connected.");
            } else
            {
                Console.WriteLine("Finch not found.");
            }
            KeyToContinue();

            //loop that contains all actions
            // gf
            do
            {
                //get user name
                //
                SetHeader("Enter Name", ConsoleColor.Green);
                do
                {
                    Console.Write("What is your name?\n>");
                    uInput = Console.ReadLine();
                    if (uInput == "")
                    {
                        Console.WriteLine("\nAny name will work\n");
                    }
                } while (uInput == "");
                uName = uInput;
                Console.Clear();

                //greet user and ask for input
                //
                SetHeader("Selection Screen", ConsoleColor.Blue);
                Console.WriteLine($"Welcome {uName}!");
                Console.WriteLine("Please provide some input.");
                KeyToContinue();

                //loop that contains all the data gathered
                //
                do
                {
                    //get nose color
                    //
                    SetHeader("Nose Color", ConsoleColor.Blue);
                    do
                    {
                        Console.Write("Should the nose be Red, Green, or Blue?\n>");
                        uInput = Console.ReadLine().ToLower();
                        switch (uInput)
                        {
                            case "red":
                                timColor = new int[] { 255, 0, 0 };
                                breakLoop = true;
                                break;

                            case "green":
                                timColor = new int[] { 0, 255, 0 };
                                breakLoop = true;
                                break;

                            case "blue":
                                timColor = new int[] { 0, 0, 255 };
                                breakLoop = true;
                                break;

                            default:
                                Console.WriteLine("\nInvalid Input.\n(red, green, blue)\n");
                                break;
                        }
                    } while (!breakLoop);
                    timColorWord = uInput;
                    breakLoop = false;
                    KeyToContinue();

                    //get tone
                    //
                    SetHeader("Finch Tone", ConsoleColor.Blue);
                    do
                    {
                        Console.Write("What tone between 100 and 20,000 should the finch play?\n>");
                        uInput = Console.ReadLine().ToLower();
                        if (!int.TryParse(uInput, out timTone) || timTone <= 100 || timTone >= 20000)
                        {
                            Console.WriteLine("\nInvalid Input.\n(100 - 20000)\n");
                        }
                    } while (!int.TryParse(uInput, out timTone) || timTone <= 100 || timTone >= 20000);
                    KeyToContinue();

                    //get speed
                    //
                    SetHeader("Finch Speed", ConsoleColor.Blue);
                    do
                    {
                        Console.Write("Out of 100%, what speed should the finch move at?\n>");
                        uInput = Console.ReadLine().ToLower();
                        if (!double.TryParse(uInput, out timSpeedDisplay) || timSpeedDisplay < 0 || timSpeedDisplay > 100)
                        {
                            Console.WriteLine("\nInvalid Input.\n(0 - 100)\n");
                        }
                    } while (!double.TryParse(uInput, out timSpeedDisplay) || timSpeedDisplay < 0 || timSpeedDisplay > 100);
                    timSpeed = (int)((timSpeedDisplay / 100) * 255);
                    KeyToContinue();

                    //get display
                    //
                    SetHeader("Finch Display", ConsoleColor.Blue);
                    do
                    {
                        Console.Write("Do you want to display temp or light?\n>");
                        uInput = Console.ReadLine().ToLower();
                        switch (uInput)
                        {
                            case "temp":
                                timDisplay = "Temperature";
                                breakLoop = true;
                                break;

                            case "light":
                                timDisplay = "Average Light Level";
                                breakLoop = true;
                                break;

                            default:
                                Console.WriteLine("\nInvalid Input.\n(temp or light)\n");
                                break;
                        }
                    } while (!breakLoop);
                    breakLoop = false;
                    KeyToContinue();

                    //get duration
                    //
                    SetHeader("Finch Duration", ConsoleColor.Blue);
                    do
                    {
                        Console.Write("How many seconds do you want the finch to run?\n>");
                        uInput = Console.ReadLine().ToLower();
                        if (!int.TryParse(uInput, out timDuration))
                        {
                            Console.WriteLine("\nInvalid Input.\n(any whole number)\n");
                        }
                    } while (!int.TryParse(uInput, out timDuration));
                    KeyToContinue();

                    //confirm input
                    //
                    SetHeader("Confirm Input", ConsoleColor.Green);
                    do
                    {
                        Console.WriteLine($"Color: {timColorWord}");
                        Console.WriteLine($"Tone: {timTone}hz");
                        Console.WriteLine($"Speed: {timSpeedDisplay}%");
                        Console.WriteLine($"Display: {timDisplay}");
                        Console.WriteLine($"Duration: {timDuration} Seconds");
                        Console.Write("\nDoes this all look correct?\nYes or No?\n>");
                        uInput = Console.ReadLine().ToLower();
                        switch (uInput)
                        {
                            case "yes":
                                correctInput = true;
                                breakLoop = true;
                                break;

                            case "no":
                                correctInput = false;
                                breakLoop = true;
                                break;

                            default:
                                Console.WriteLine("\nInvalid Input.\n(yes or no)\n");
                                break;
                        }
                    } while (!breakLoop);
                    breakLoop = false;
                    KeyToContinue();

                } while (!correctInput);

                //confirm start running application
                //
                SetHeader("Running Application Screen", ConsoleColor.Yellow);
                Console.WriteLine("Let the games begin!");
                KeyToContinue();

                //running application
                //
                SetHeader("Running Application Screen", ConsoleColor.Yellow);
                tim.setLED(timColor[0], timColor[1], timColor[2]);
                tim.noteOn(timTone);tim.setMotors(timSpeed,timSpeed);
                for(int i=0; i < timDuration; i++)
                {
                    if (timDisplay == "Temperature")
                    {
                        Console.WriteLine($"Current Temp: {(tim.getTemperature() * 1.8) + 32} Fahrenheit\n");
                    } else if (timDisplay == "Average Light Level")
                    {
                        Console.WriteLine($"Current AVG Light: {(tim.getLeftLightSensor() * tim.getRightLightSensor()) / 2}\n");
                    }
                    tim.wait(1000);
                }
                tim.setLED(0, 0, 0);
                tim.noteOff();
                tim.setMotors(0,0);
                KeyToContinue();

                //ask user if they wish to restart
                //
                SetHeader("Restart?", ConsoleColor.Red);
                do
                {
                    Console.Write("Would you like to restart the program?\nYes or no?\n>");
                    uInput = Console.ReadLine().ToLower();
                    switch (uInput)
                    {
                        case "yes":
                            running = true;
                            breakLoop = true;
                            break;

                        case "no":
                            running = false;
                            breakLoop = true;
                            break;

                        default:
                            Console.WriteLine("\nInvalid Input.\n(yes or no)\n");
                            break;
                    }
                } while (!breakLoop);
                breakLoop = false;
                KeyToContinue();

            } while (running);

            //disconect finch
            //
            tim.disConnect();

            //end
            //
            SetHeader("End Screen", ConsoleColor.Red);
            Console.WriteLine($"Goodbye {uName}, I hope you had fun :^)");
            KeyToContinue();
        }
    }
}
