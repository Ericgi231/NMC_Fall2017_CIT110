using FinchAPI;
using System;
using System.IO;

namespace CA_SensorFinchDataArrayPers
{
    class Program
    {
        //author: Eric Grant
        //template author: John Velis
        //program: Finch Data Array & I/O
        //desription:
        //date: 10/23/2017

        // global variables
        //
        static Finch tim = new Finch();
        static int numberOfDataPoints;
        static double secondsBetweenDataPoints;
        static double[] temperatures = new double[0];
        static string dataPathTemperature;
        static string dataPathLight;
        static string[] temperatureAsString;
        static int[] lightLevels;
        static string[] lightLevelsAsString;

        /// <summary>
        /// Main method - application starting point
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            DisplayOpeningScreen();
            DisplayMainMenu();
            DisplayClosingScreen();
        }

        /// <summary>
        /// display menu
        /// </summary>
        static void DisplayMainMenu()
        {
            string menuChoice;
            bool exiting = false;

            while (!exiting)
            {
                DisplayHeader("Main Menu");

                temperatures = new double[numberOfDataPoints];
                lightLevels = new int[numberOfDataPoints];

                Console.WriteLine("1. Connect to Finch Robot");
                Console.WriteLine("2. Setup Application");
                Console.WriteLine("3. Acquire Temperature Data");
                Console.WriteLine("4. Acquire Light Data");
                Console.WriteLine("5. Save Data");
                Console.WriteLine("6. Load Data");
                Console.WriteLine("7. Display Data");
                Console.WriteLine("8. Quit");
                Console.Write("\nSelect Option:\n>");
                menuChoice = Console.ReadLine();

                switch (menuChoice)
                {
                    case "1":
                        DisplayConnectToFinch();
                        break;

                    case "2":
                        DisplaySetupApplication();
                        break;

                    case "3":
                        DisplayAcquireTemperatureDataSet();
                        break;

                    case "4":
                        DisplayAcquireLightDataSet();
                        break;

                    case "5":
                        DisplaySaveDataSet();
                        break;

                    case "6":
                        DisplayRetrieveDataSet();
                        break;

                    case "7":
                        DisplayDataSet();
                        break;

                    case "8":
                        exiting = true;
                        break;

                    default:
                        break;
                }
            }
        }

        /// <summary>
        /// display prompt user to press enter to save data to data.txt
        /// </summary>
        static void DisplaySaveDataSet()
        {
            DisplayHeader("Save Data Set");

            dataPathTemperature = "Data/temp.txt";
            temperatureAsString = new string[numberOfDataPoints];

            dataPathLight = "Data/light.txt";
            lightLevelsAsString = new string[numberOfDataPoints];

            int i = 0;
            foreach (double dataPoint in temperatures)
            {
                temperatureAsString[i] = dataPoint.ToString();
                i++;
            }

            i = 0;
            foreach (int dataPoint in lightLevels)
            {
                lightLevelsAsString[i] = dataPoint.ToString();
                i++;
            }

            Console.WriteLine("Press enter to save data.");
            Console.ReadKey();

            try
            {
                File.WriteAllLines(dataPathTemperature, temperatureAsString);
                File.WriteAllLines(dataPathLight, lightLevelsAsString);
            }
            catch (DirectoryNotFoundException)
            {
                Console.WriteLine("Folder does not exist. One will be created and the data will be saved.");
                Directory.CreateDirectory("Data");
                File.WriteAllLines(dataPathTemperature, temperatureAsString);
                File.WriteAllLines(dataPathLight, lightLevelsAsString);
            }

            Console.WriteLine("Data saved.");

            DisplayContinuePrompt();
        }

        /// <summary>
        /// display a screen to retrieve data from data.txt
        /// </summary>
        static void DisplayRetrieveDataSet()
        {
            DisplayHeader("Load Data Set");

            dataPathTemperature = "Data/temp.txt";
            temperatureAsString = new string[numberOfDataPoints];

            dataPathLight = "Data/light.txt";
            lightLevelsAsString = new string[numberOfDataPoints];

            Console.WriteLine("Press enter to load data.");
            Console.ReadKey();

            try
            {
                temperatureAsString = File.ReadAllLines(dataPathTemperature);
                lightLevelsAsString = File.ReadAllLines(dataPathLight);
            }
            catch (Exception)
            {
                Console.WriteLine("Failed to load data.");
            }

            numberOfDataPoints = temperatureAsString.Length;
            temperatures = new double[numberOfDataPoints];

            numberOfDataPoints = lightLevelsAsString.Length;
            lightLevels = new int[numberOfDataPoints];

            int i = 0;
            foreach (string dataPoint in temperatureAsString)
            {
                temperatures[i] = double.Parse(dataPoint);
                i++;
            }

            i = 0;
            foreach (string dataPoint in lightLevelsAsString)
            {
                lightLevels[i] = int.Parse(dataPoint);
                i++;
            }

            Console.WriteLine("Data loaded.");

            DisplayContinuePrompt();
        }

        /// <summary>
        /// display the data set
        /// </summary>
        static void DisplayDataSet()
        {
            DisplayHeader("Current Data Set");

            int i = 1;
            Console.WriteLine("Temperature Data");
            foreach (double dataPoint in temperatures)
            {
                Console.WriteLine($"Data Point {i}: {dataPoint}F");
            }

            Console.WriteLine();

            i = 1;
            Console.WriteLine("Light Level Data");
            foreach (double dataPoint in lightLevels)
            {
                Console.WriteLine($"Data Point {i}: {dataPoint}");
            }

            DisplayContinuePrompt();
        }

        /// <summary>
        /// acquire data 
        /// </summary>
        static void DisplayAcquireTemperatureDataSet()
        {
            DisplayHeader("Acquire Temperature Data Set");

            //
            // pause for user
            //
            Console.WriteLine("The Finch Robot is ready. Press Enter to begin.");
            Console.ReadLine();

            //
            // acquire data
            //
            for (int index = 0; index < numberOfDataPoints; index++)
            {
                temperatures[index] = tim.getTemperature();
                Console.WriteLine($"Data Point {index + 1}: {temperatures[index]}c");
                temperatures[index] = temperatures[index] * 1.8 + 32;
                tim.wait((int)(secondsBetweenDataPoints * 1000));
            }

            DisplayContinuePrompt();
        }

        static void DisplayAcquireLightDataSet()
        {
            DisplayHeader("Acquire Light Data Set");

            //
            // pause for user
            //
            Console.WriteLine("The Finch Robot is ready. Press Enter to begin.");
            Console.ReadLine();

            //
            // acquire data
            //
            for (int index = 0; index < numberOfDataPoints; index++)
            {
                lightLevels[index] = (tim.getLeftLightSensor() + tim.getRightLightSensor()) / 2;
                Console.WriteLine($"Data Point {index + 1}: {lightLevels[index]}");
                tim.wait((int)(secondsBetweenDataPoints * 1000));
            }

            DisplayContinuePrompt();
        }

        /// <summary>
        /// get the application parameters
        /// </summary>
        static void DisplaySetupApplication()
        {
            DisplayHeader("Setup Application");

            Console.Write("Enter the number of data points:\n>");
            try
            {
                numberOfDataPoints = int.Parse(Console.ReadLine());
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid Data. Enter an int.");
            }
            
            Console.Write("\nEnter the seconds between data points:\n>");
            try
            {
                secondsBetweenDataPoints = double.Parse(Console.ReadLine());
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid Data. Enter an int.");
            }

            Console.WriteLine($"\nNumber of Data Points: {numberOfDataPoints}");
            Console.WriteLine($"Seconds Between Data Points {secondsBetweenDataPoints}");

            DisplayContinuePrompt();
        }

        /// <summary>
        /// connect to Finch Robot
        /// </summary>
        static void DisplayConnectToFinch()
        {
            DisplayHeader("Connect to Finch");

            if (tim.connect())
            {
                Console.WriteLine("Finch Robot is connected and ready.");
                tim.setLED(100,100,100);
            }
            else
            {
                Console.WriteLine("Finch Robot is not connect. Please check the wires.");
            }

            DisplayContinuePrompt();
        }

        /// <summary>
        /// display opening screen
        /// </summary>
        static void DisplayOpeningScreen()
        {
            DisplayHeader("Opening Screen");

            Console.WriteLine("Finch Data Array Persistence");
            Console.WriteLine("Main Author: Eric Grant");
            Console.WriteLine("Template Author: John Velis");

            DisplayContinuePrompt();
        }

        /// <summary>
        /// display closing screen
        /// </summary>
        static void DisplayClosingScreen()
        {
            DisplayHeader("End Screen");

            tim.setLED(100, 100, 100);
            tim.disConnect();

            Console.WriteLine("Later nerd.");

            Console.WriteLine("\nPress any key to exit.");
            Console.ReadKey();
        }

        /// <summary>
        /// display continue prompt
        /// </summary>
        static void DisplayContinuePrompt()
        {
            Console.CursorVisible = false;
            Console.WriteLine("\nPress any key to continue.");
            Console.ReadKey();
            Console.CursorVisible = true;
        }

        /// <summary>
        /// display header
        /// </summary>
        static void DisplayHeader(string headerTitle)
        {
            Console.Clear();
            Console.WriteLine($"~~~{headerTitle}~~~\n");
        }
    }
}
