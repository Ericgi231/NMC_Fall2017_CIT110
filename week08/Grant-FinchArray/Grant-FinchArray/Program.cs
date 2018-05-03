using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinchAPI;

namespace Grant_FinchArray
{
    class Program
    {
        //eric grant
        //finch array
        //store data from the finch in an array
        //10-16-17

        static void Main(string[] args)
        {
            Finch tim = InstantiateFinch();

            bool breakLoop = false;
            DisplayOpenScreen();
            while (!breakLoop)
            {
                breakLoop = DisplayRunApplicationScreen(tim, breakLoop);
            }
            DisplayEndScreen(tim);

        }

        /// <summary>
        /// Instantiate a new finch named tim
        /// </summary>
        /// <returns>tim the finch</returns>
        static Finch InstantiateFinch()
        {
            PrintHeader("Connect Tim Robot");
            Finch tim = new Finch();
            Console.WriteLine($"Tim connected: {tim.connect()}");
            DisplayAnyKey();
            return tim;
        }

        /// <summary>
        /// print a header
        /// </summary>
        /// <param name="title">the text to put in the header</param>
        static void PrintHeader(string title)
        {
            Console.WriteLine($"\t~~~{title}~~~\n");
        }

        /// <summary>
        /// display opening screen
        /// </summary>
        static void DisplayOpenScreen()
        {
            PrintHeader("Opening Screen");

            Console.WriteLine("Finch Arrays");
            Console.WriteLine("This app will gather data from the dinch and store it in an array.");
            Console.WriteLine("By: Eric Grant");

            DisplayAnyKey();
        }

        /// <summary>
        /// display main application loop
        /// </summary>
        static bool DisplayRunApplicationScreen(Finch tim, bool breakLoop)
        {
            int[] dataParameters = new int[2];
            double[] sensorReadings = new double[dataParameters[0]];
            bool parametersSet = false;
            bool dataSet = false;
            bool breakSwitch = false;
            while (!breakSwitch)
            {
                PrintHeader("Main Menu");
                Console.WriteLine("Please select an option.");
                Console.Write("1. Get Data Parameters\n2. Acquire Data Set\n3. Display Data Set\n4. Exit Program\n>");
                string uInput = Console.ReadLine();
                int uSelect = ValidateInt(uInput);
                Console.Clear();
                switch (uSelect)
                {
                    case 1:
                        dataParameters = DisplayGetParameters();
                        parametersSet = true;
                        break;

                    case 2:
                        if (parametersSet)
                        {
                            sensorReadings = DisplayGetDataScreen(dataParameters, tim);
                            dataSet = true;
                        } else
                        {
                            Console.WriteLine("No parameters set.");
                        }
                        break;

                    case 3:
                        if (dataSet)
                        {
                            DisplayTempData(sensorReadings);
                        } else
                        {
                            Console.WriteLine("No data set.");
                        }
                        break;

                    case 4:
                        breakLoop = true;
                        breakSwitch = true;
                        break;

                    default:
                        break;
                }
            }
            return breakLoop;
        }

        static int[] DisplayGetParameters()
        {
            PrintHeader("Input Data");
            int[] dataParameters = new int[2];
            dataParameters[0] = DisplayGetNumOfReadings();
            dataParameters[1] = DisplayGetNumOfSeconds();
            DisplayEchoReadingVars(dataParameters[0], dataParameters[1]);
            DisplayAnyKey();

            return dataParameters;
        }

        static double[] DisplayGetDataScreen(int[] dataParameters, Finch tim)
        {
            PrintHeader("Lets Go");
            Console.WriteLine("We are ready to get data from Tim");
            DisplayAnyKey();

            double[] sensorReadings = new double[dataParameters[0]];

            sensorReadings = DisplayGetFinchData(dataParameters[0], dataParameters[1], sensorReadings, tim);

            return sensorReadings;
        }

        /// <summary>
        /// display all data readings in fahrenheit
        /// </summary>
        /// <param name="sensorReadings">an array of all readings</param>
        static void DisplayTempData(double[] sensorReadings)
        {
            PrintHeader("Data Readings In Fahrenheit");
            int i = 1;
            foreach (double temp in sensorReadings)
            {
                Console.WriteLine($"Data point #{i}: {temp}");
                i++;
            }
            DisplayAnyKey();
        }


        /// <summary>
        /// Display a screen that gets data from the finch over time
        /// </summary>
        /// <param name="numData">number of data points to get</param>
        /// <param name="numSeconds">seonds to wait between data points</param>
        /// <param name="sensorReadings">an array of all readings</param>
        /// <param name="tim">tim the finch</param>
        /// <returns>an array of data readings</returns>
        static double[] DisplayGetFinchData(int numData, int numSeconds, double[] sensorReadings, Finch tim)
        {
            PrintHeader("Reading Temp In Celsuis");
            for (int x = 0; x < numData; x++)
            {
                sensorReadings[x] = tim.getTemperature();
                Console.WriteLine($"Current temp: {sensorReadings[x]}");
                sensorReadings[x] = sensorReadings[x] * 1.8 + 32;
                tim.wait(numSeconds * 1000);
            }
            DisplayAnyKey();

            return sensorReadings;
        }

        /// <summary>
        /// display prompt for number of readings
        /// </summary>
        /// <returns>num of readings</returns>
        static int DisplayGetNumOfReadings()
        {
            Console.Write("How many readings do you want the finch to take?\n>");
            string uInput = Console.ReadLine();
            int numberOfDataPoints = ValidateInt(uInput);
            Console.WriteLine();
            return numberOfDataPoints;
        }

        /// <summary>
        /// display prompt for number of seconds between readings
        /// </summary>
        /// <returns>num of seconds</returns>
        static int DisplayGetNumOfSeconds()
        {
            Console.Write("How many secons should Tim wait between each reading?\n>");
            string uInput = Console.ReadLine();
            int secondsBetweenDataPoints = ValidateInt(uInput);
            Console.WriteLine();
            return secondsBetweenDataPoints;
        }

        static void DisplayEchoReadingVars(int numData, int numSeconds)
        {
            Console.WriteLine($"Number of readings: {numData}\nSeconds between readings: {numSeconds}");
        }

        /// <summary>
        /// validate a string into an int
        /// </summary>
        /// <param name="intToConvert">sting to convert</param>
        /// <returns>converted string</returns>
        static int ValidateInt(string intToConvert)
        {
            int intConverted;
            while (!int.TryParse(intToConvert, out intConverted))
            {
                Console.Write("Invalid data. Please enter an int.\n>");
                intToConvert = Console.ReadLine();
            }
            return intConverted;
        }

        /// <summary>
        /// display prompt for user to press any key to continue
        /// </summary>
        static void DisplayAnyKey()
        {
            Console.CursorVisible = false;
            Console.WriteLine("\nPress any key to continue.");
            Console.ReadKey();
            Console.Clear();
            Console.CursorVisible = true;
        }

        /// <summary>
        /// display end screen
        /// </summary>
        static void DisplayEndScreen(Finch tim)
        {
            tim.disConnect();
            PrintHeader("End Screen");

            Console.WriteLine("Later nerd.");
            
            DisplayAnyKey();
        }
    }
}
