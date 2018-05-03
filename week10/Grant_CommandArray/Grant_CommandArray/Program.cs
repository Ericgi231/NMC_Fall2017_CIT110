using System;
using FinchAPI;
using System.IO;
using System.Collections.Generic;

namespace Grant_CommandArray
{
    class Program
    {
        //author: Eric Grant
        //title: Finch Command Array
        //description: Get user input to build out a finch command array that will control Tim the finch
        //date: 11/1/2017
        //

        //global enums
        //
        public enum FinchCommand
        {
            DONE,
            MOVEFORWARD,
            MOVEBACKWARD,
            STOPMOTORS,
            DELAY,
            TURNRIGHT,
            TURNLEFT,
            LEDON,
            LEDOFF,
            READTEMP
        }

        public enum MenuOption
        {
            INITIALIZE,
            PARAMETERS,
            COMMANDS,
            DISPLAY,
            EXECUTE,
            TERMINATE,
            VALUES,
            SAVE,
            LOAD,
            EXIT
        }

        //global vars
        //
        static Finch tim = new Finch();
        static FinchCommand[] commands;
        static string[] commandsAsString;

        static List<double> temps = new List<double>();
        
        static int commandDuration;
        static int numberOfCommands;
        static int motorSpeed;
        static int LEDBrightness;
        static string[] paramArray = new string[4];

        static bool finchActive = false;
        static bool breakLoop = false;

        //application
        //
        static void Main(string[] args)
        {
            //main app
            //

            DisplayOpen();
            while (!breakLoop)
            {
                ProcessMenuChoice(DisplayMenu());
            }
            DisplayExit();
        }

        /// <summary>
        /// display opening screen
        /// </summary>
        /// <param name="tim"></param>
        static void DisplayOpen()
        {
            DisplayScreen("Opening Screen");

            Console.WriteLine("Title: Finch Command Array");
            Console.WriteLine("Description: Get user input to build out a finch command array that will control Tim the finch.");
            Console.WriteLine("Author: Eric Grant");

            DisplayAnyKey();
        }

        /// <summary>
        /// display main menu screen
        /// </summary>
        static MenuOption DisplayMenu()
        {
            DisplayScreen("Main Menu");

            MenuOption userMenuChoice;
            string uInput;

            Console.WriteLine("Select an Option:");
            int i = 0;
            foreach (MenuOption option in Enum.GetValues(typeof(MenuOption)))
            {
                Console.WriteLine($"{i}: {option}");
                i++;
            }
            Console.WriteLine();

            do
            {
                Console.Write(">");
                uInput = Console.ReadLine().ToUpper();
            } while (!Enum.TryParse<MenuOption>(uInput, out userMenuChoice));

            DisplayAnyKey();
            return userMenuChoice;
        }

        /// <summary>
        /// process the choice made in menu screen
        /// </summary>
        static void ProcessMenuChoice(MenuOption userMenuChoice)
        {
            switch (userMenuChoice)
            {
                case MenuOption.INITIALIZE:
                    DisplayInitializeFinch();
                    break;
                case MenuOption.PARAMETERS:
                    DisplayGetCommandParameters();
                    break;
                case MenuOption.COMMANDS:
                    DisplayGetCommands();
                    break;
                case MenuOption.DISPLAY:
                    DisplayUserCommands();
                    break;
                case MenuOption.EXECUTE:
                    DisplayExecuteCommands();
                    break;
                case MenuOption.TERMINATE:
                    DisplayTerminateFinch();
                    break;
                case MenuOption.VALUES:
                    DisplayValues();
                    break;
                case MenuOption.SAVE:
                    DisplaySave();
                    break;
                case MenuOption.LOAD:
                    DisplayLoad();
                    break;
                case MenuOption.EXIT:
                    breakLoop = true;
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// display saved data screen. data is saved to TempData.txt inside Data folder
        /// </summary>
        static void DisplaySave()
        {
            DisplayScreen("Save Commands Data");

            commandsAsString = new string[commands.Length];
            int i = 0;
            foreach (double command in commands)
            {
                commandsAsString[i] = command.ToString();
                i++;
            }

            try
            {
                File.WriteAllLines("Data/CommandData.txt", commandsAsString);
                Console.WriteLine("Command Data saved.");
            } catch (Exception)
            {
                Console.WriteLine("Failed to find directory. One will be created and data will be saved.");
                File.Create("Data");
                File.WriteAllLines("Data/CommandData.txt", commandsAsString);
            }

            paramArray = new string[4] { commandDuration.ToString(), numberOfCommands.ToString(), motorSpeed.ToString(), LEDBrightness.ToString()};

            try
            {
                File.WriteAllLines("Data/ParamData.txt", paramArray);
                Console.WriteLine("Parameter Data saved.");
            }
            catch (Exception)
            {
                Console.WriteLine("Failed to find directory. One will be created and data will be saved.");
                File.Create("Data");
                File.WriteAllLines("Data/ParamData.txt", paramArray);
            }

            DisplayAnyKey();
        }

        /// <summary>
        /// display load data screen. data is loaded from TempData.txt inside data folder.
        /// </summary>
        static void DisplayLoad()
        {
            DisplayScreen("Load Commands Data");

            try
            {
                commandsAsString = File.ReadAllLines("Data/CommandData.txt");
                Console.WriteLine("Commands loaded.");
            }
            catch (Exception)
            {
                Console.WriteLine("No commands saved.");
            }

            try
            {
                paramArray = File.ReadAllLines("Data/ParamData.txt");
                Console.WriteLine("Parameters loaded.");
            }
            catch (Exception)
            {
                Console.WriteLine("No parameters saved.");
            }

            commands = new FinchCommand[commandsAsString.Length];

            int i = 0;
            foreach (string command in commandsAsString)
            {
                Enum.TryParse<FinchCommand>(command, out commands[i]);
                i++;
            }

            commandDuration = int.Parse(paramArray[0]);
            numberOfCommands = int.Parse(paramArray[1]);
            motorSpeed = int.Parse(paramArray[2]);
            LEDBrightness = int.Parse(paramArray[3]);

            DisplayAnyKey();
        }

        /// <summary>
        /// display collected temp values
        /// </summary>
        static void DisplayValues()
        {
            DisplayScreen("Temperature Values");

            if (temps.Count != 0)
            {
                int i = 0;
                foreach (double temp in temps)
                {
                    Console.WriteLine($"Temperature #{i}: {temp}");
                    i++;
                }
            } else
            {
                Console.WriteLine("Must gather temperature data first.");
            }

            DisplayAnyKey();
        }

        /// <summary>
        /// display screen to execute the given commands
        /// </summary>
        static void DisplayExecuteCommands()
        {
            DisplayScreen("Execution");

            try
            {
                temps.Clear();
                foreach (FinchCommand command in commands)
                {
                    Console.WriteLine($"Performing: {command}\n");
                    switch (command)
                    {
                        case FinchCommand.DONE:
                            return;
                        case FinchCommand.MOVEFORWARD:
                            tim.setMotors(motorSpeed, motorSpeed);
                            break;
                        case FinchCommand.MOVEBACKWARD:
                            tim.setMotors(-motorSpeed, -motorSpeed);
                            break;
                        case FinchCommand.STOPMOTORS:
                            tim.setMotors(0, 0);
                            break;
                        case FinchCommand.DELAY:
                            break;
                        case FinchCommand.TURNRIGHT:
                            tim.setMotors(motorSpeed, -motorSpeed);
                            break;
                        case FinchCommand.TURNLEFT:
                            tim.setMotors(-motorSpeed, motorSpeed);
                            break;
                        case FinchCommand.LEDON:
                            tim.setLED(LEDBrightness, LEDBrightness, LEDBrightness);
                            break;
                        case FinchCommand.LEDOFF:
                            tim.setLED(0, 0, 0);
                            break;
                        case FinchCommand.READTEMP:
                            temps.Add(tim.getTemperature());
                            break;
                        default:
                            break;
                    }
                    tim.wait(commandDuration);
                }
            } catch (Exception)
            {
                Console.WriteLine("Must set commands first.");
            }

            DisplayAnyKey();
        }

        /// <summary>
        /// display initialize screen
        /// </summary>
        static void DisplayInitializeFinch()
        {
            DisplayScreen("Initialize Finch");
            finchActive = tim.connect();
            
            Console.WriteLine($"Finch connected: {finchActive}");
            if (finchActive)
            {
                tim.noteOn(500);
                tim.setLED(255,255,255);
                tim.wait(500);
                tim.setLED(0,0,0);
                tim.noteOff();
            }

            DisplayAnyKey();
        }

        /// <summary>
        /// display terminate screen
        /// </summary>
        static void DisplayTerminateFinch()
        {
            DisplayScreen("Terminate Finch");
            if (finchActive)
            {
                tim.noteOn(500);
                tim.setLED(255, 255, 255);
                tim.wait(500);
                tim.setLED(0, 0, 0);
                tim.noteOff();
                tim.disConnect();
                Console.WriteLine($"Finch terminated");
            } else
            {
                Console.WriteLine("No finch detected.");
            }
            
            DisplayAnyKey();
        }

        /// <summary>
        /// display get users desired commands
        /// </summary>
        static void DisplayGetCommands()
        {
            DisplayScreen("Get Commands");
            string uInput;

            Console.WriteLine("Enter the desired commands from those available:");
            int i = 0;
            foreach (FinchCommand fCommand in Enum.GetValues(typeof(FinchCommand)))
            {
                Console.WriteLine($"{i}: {fCommand}");
                i++;
            }
            for (int x = 0; x < numberOfCommands; x++)
            {
                Console.WriteLine($"\nCommand #{x + 1}:");
                do
                {
                    Console.Write(">");
                    uInput = Console.ReadLine().ToUpper();
                } while (!Enum.TryParse<FinchCommand>(uInput, out commands[x]));
            }

            try
            {
                Console.WriteLine("\nSelected commands:");
                foreach (FinchCommand uCommand in commands)
                {
                    Console.WriteLine(uCommand);
                }
            } catch (Exception)
            {
                Console.WriteLine("\nMust set command parameters first.");
            }
            

            DisplayAnyKey();
        }

        /// <summary>
        /// display users selected commands
        /// </summary>
        static void DisplayUserCommands()
        {
            DisplayScreen("Selected Commands");

            try
            {
                Console.WriteLine("Selected commands:");
                foreach (FinchCommand uCommand in commands)
                {
                    Console.WriteLine(uCommand);
                }
            } catch (Exception)
            {
                Console.WriteLine("\nMust set commands before they can be shown.");
            }
            

            DisplayAnyKey();
        }

        /// <summary>
        /// display screen and call all get parameters
        /// </summary>
        static void DisplayGetCommandParameters()
        {
            DisplayScreen("Get command parameters");

            DisplayGetNumberOfCommands();
            Console.WriteLine();
            DisplayGetDelayDuration();
            Console.WriteLine();
            DisplayGetMotorSpeed();
            Console.WriteLine();
            DisplayGetLEDBrightness();

            DisplayAnyKey();
        }

        /// <summary>
        /// display get number of commands
        /// </summary>
        static void DisplayGetNumberOfCommands()
        {
            Console.Write("Number of Commands:\n");
            numberOfCommands = InputInt();
            commands = new FinchCommand[numberOfCommands];
        }

        /// <summary>
        /// display get command duration
        /// </summary>
        static void DisplayGetDelayDuration()
        {
            Console.Write("Duration of Commands in Seconds:\n");
            commandDuration = InputInt() * 1000;
        }

        /// <summary>
        /// display get motor speed
        /// </summary>
        static void DisplayGetMotorSpeed()
        {
            Console.Write("Motor Speed (0-255):\n");
            do
            {
                motorSpeed = InputInt();
            } while (!(motorSpeed <= 255 && motorSpeed >= 0));
        }

        /// <summary>
        /// display get led brightness
        /// </summary>
        static void DisplayGetLEDBrightness()
        {
            Console.Write("Brightness of LED (0-255):\n");
            do
            {
                LEDBrightness = InputInt();
            } while (!(LEDBrightness <= 255 && LEDBrightness >= 0));
        }
        
        /// <summary>
        /// get and validate an int from the user
        /// </summary>
        /// <returns></returns>
        static int InputInt()
        {
            int num;
            string uInput;
            do
            {
                Console.Write(">");
                uInput = Console.ReadLine();
            } while (!int.TryParse(uInput, out num));
            return num;
        }

        /// <summary>
        /// display exit screen
        /// </summary>
        /// <param name="tim"></param>
        static void DisplayExit()
        {
            DisplayScreen("Closing Screen");

            Console.WriteLine("Thanks for using my program.");
            Console.WriteLine("Later nerd.");

            DisplayAnyKey();
        }

        /// <summary>
        /// prompt user to press button to continue
        /// </summary>
        static void DisplayAnyKey()
        {
            Console.CursorVisible = false;
            Console.WriteLine("\n~~~Press any key to continue~~~");
            Console.ReadKey();
            Console.CursorVisible = true;
        }

        /// <summary>
        /// clear screen and print title
        /// </summary>
        /// <param name="title"></param>
        static void DisplayScreen(string title)
        {
            Console.Clear();
            Console.WriteLine($"~~~{title}~~~\n");
        }
    }
}
