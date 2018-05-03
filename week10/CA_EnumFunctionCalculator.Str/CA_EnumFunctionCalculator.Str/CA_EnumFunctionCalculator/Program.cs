using System;

namespace CA_EnumCalculator
{
    class Program
    {
		//Eric Grant
		//Enum Calculator
		//Perform math calculations based on an operation enum
		//11/1/2017
        //
        // declare enum
        //
        public enum Operation {
            ADD,
            SUBTRACT,
            MULTIPLY,
            DIVIDE,
            MODULUS,
            POWER,
            SQUARE
        }

        /// <summary>
        /// application flow and loop
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            double number1 = 0, number2 = 0, answer = 0;

            string userResponse = "";
            string operation = "";
            Operation operationAsEnum = 0;
            string operationSymbol = "";
            dynamic[] operationValues = new dynamic[2];

            bool quitting = false;
            bool validResponse = false;

            DisplayOpeningScreen();

            //
            // application loop
            //
            while (!quitting)
            {
                number1 = DisplayGetNumber(validResponse, userResponse, number1);

                operationValues = DisplayGetOperation(validResponse, operation, operationSymbol, operationAsEnum, operationValues);
                operationAsEnum = operationValues[0];
                operationSymbol = operationValues[1];

                if (operationSymbol != "Sqr")
                {
                    number2 = DisplayGetNumber(validResponse, userResponse, number1);
                }

                answer = PerformOperation(operationAsEnum, answer, number1, number2);

                DisplayAnswer(operationAsEnum, number1, number2, answer, operationSymbol);

                quitting = DisplayGetQuitResponse(validResponse, userResponse, quitting);
            }

            DisplayClosingScreen();
        }

        /// <summary>
        /// display the opening screen
        /// </summary>
        private static void DisplayOpeningScreen()
        {
            //
            // display opening screen
            //
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("\t\tThe Simple Calculator");
            Console.WriteLine("\t\tLaughing Leaf Productions");
            Console.WriteLine();

            //
            // pause for user
            //
            Console.WriteLine("\t\tPress any key to continue.");
            Console.ReadKey();
        }

        /// <summary>
        /// get a number and validate the user's response
        /// </summary>
        private static double DisplayGetNumber(bool validResponse, string userResponse, double number)
        {
            //
            // reset bool to use for validation
            //
            validResponse = false;

            while (!validResponse)
            {
                ResetConsoleScreen();

                Console.Write("\tEnter a number:");
                userResponse = Console.ReadLine();

                if (!double.TryParse(userResponse, out number))
                {
                    Console.WriteLine("\tYou must enter a number. (2.4, 9, etc.)");

                    //
                    // pause for user
                    //
                    Console.WriteLine("\t\tPress any key to continue.");
                    Console.ReadKey();
                }
                else
                {
                    validResponse = true;
                }
            }

            return number;
        }

        /// <summary>
        /// get the operation and validate the user's response
        /// </summary>
        private static dynamic[] DisplayGetOperation(bool validResponse, string operation, string operationSymbol, Operation operationAsEnum, dynamic[] operationValues)
        {
            //
            // reset bool to use for validation
            //
            validResponse = false;

            while (!validResponse)
            {
                ResetConsoleScreen();

                Console.Write("\tEnter the operation ( ADD SUBTRACT MULTIPLY DIVIDE MODULUS POWER SQUARE):");
                do
                {
                    operation = Console.ReadLine().ToUpper();
                } while (!Enum.TryParse<Operation>(operation, out operationAsEnum));

                //
                // validate the user response and process their choice
                //
                switch (operationAsEnum)
                {
                    case Operation.ADD:
                        operationSymbol = "+";
                        validResponse = true;
                        break;

                    case Operation.SUBTRACT:
                        operationSymbol = "-";
                        validResponse = true;
                        break;

                    case Operation.MULTIPLY:
                        operationSymbol = "*";
                        validResponse = true;
                        break;

                    case Operation.DIVIDE:
                        operationSymbol = "/";
                        validResponse = true;
                        break;

                    case Operation.MODULUS:
                        operationSymbol = "%";
                        validResponse = true;
                        break;

                    case Operation.POWER:
                        operationSymbol = "^";
                        validResponse = true;
                        break;

                    case Operation.SQUARE:
                        operationSymbol = "Sqr";
                        validResponse = true;
                        break;

                    default:
                        Console.WriteLine("\tYou must enter a valid operation.");

                        //
                        // pause for user
                        //
                        Console.WriteLine("\t\tPress any key to continue.");
                        Console.ReadKey();
                        break;
                }
            }

            operationValues[0] = operationAsEnum;
            operationValues[1] = operationSymbol;

            return operationValues;
        }

        /// <summary>
        /// perform the calculation
        /// </summary>
        private static double PerformOperation(Operation operationAsEnum, double answer, double number1, double number2)
        {
            switch (operationAsEnum)
            {
                case Operation.ADD:
                    answer = number1 + number2;
                    break;

                case Operation.SUBTRACT:
                    answer = number1 - number2;
                    break;

                case Operation.MULTIPLY:
                    answer = number1 * number2;
                    break;

                case Operation.DIVIDE:
                    answer = number1 / number2;
                    break;

                case Operation.MODULUS:
                    answer = number1 % number2;
                    break;

                case Operation.POWER:
                    answer = number1;
                    for (int i = 1; i < number2; i++)
                    {
                        answer = answer * number1;
                    }
                    break;

                case Operation.SQUARE:
                    answer = number1 * number1;
                    break;

                default:
                    //
                    // note: the operation was already validated, but we do need
                    //       to ensure that the operation names match or our 
                    //       answer value will always equal 0
                    //
                    break;
            }

            return answer;
        }

        /// <summary>
        /// display the answer
        /// </summary>
        private static void DisplayAnswer(Operation operationAsEnum, double number1, double number2, double answer, string operationSymbol)
        {
            string answerString = "";

            ResetConsoleScreen();

            if (operationAsEnum == Operation.DIVIDE && number2 == 0)
            {
                Console.WriteLine("\tDividing by zero is not allowed.");
            }
            else
            {
                if (operationAsEnum == Operation.DIVIDE)
                {
                    answerString = answer.ToString("N2");
                }
                else
                {
                    answerString = answer.ToString("N");
                }

                if (operationAsEnum != Operation.SQUARE)
                {
                    Console.WriteLine($"\tAnswer: {number1} {operationSymbol} {number2} = {answerString}");
                }
                else
                {
                    Console.WriteLine($"\tAnswer: {number1} {operationSymbol} = {answerString}");
                }
            }

            //
            // pause for user
            //
            Console.WriteLine();
            Console.WriteLine("\t\tPress any key to continue.");
            Console.ReadKey();
        }

        /// <summary>
        /// ask the user to continue and validate the user's response
        /// </summary>
        private static bool DisplayGetQuitResponse(bool validResponse, string userResponse, bool quitting)
        {
            //
            // reset bool to use for validation
            //
            validResponse = false;

            while (!validResponse)
            {
                ResetConsoleScreen();

                Console.Write("\tWould you like to perform another calculation ( YES or NO ):");
                userResponse = Console.ReadLine().ToUpper();

                //
                // validate the user response and process their choice
                //
                if (!(userResponse == "NO" || userResponse == "YES"))
                {
                    Console.WriteLine("\tYou must enter either 'YES' or 'NO'.");

                    //
                    // pause for user
                    //
                    Console.WriteLine("\t\tPress any key to continue.");
                    Console.ReadKey();
                }
                else
                {
                    if (userResponse == "NO")
                    {
                        quitting = true;
                    }

                    validResponse = true;
                }
            }

            return quitting;
        }

        /// <summary>
        /// display the closing screen
        /// </summary>
        private static void DisplayClosingScreen()
        {
            ResetConsoleScreen();

            Console.WriteLine("\tThank you for using our application");
            Console.WriteLine();
            Console.WriteLine("\tLaughing Leaf Productions");
            Console.WriteLine();

            //
            // pause for user
            //
            Console.WriteLine("\t\tPress any key to exit.");
            Console.ReadKey();
        }

        /// <summary>
        /// reset the console screen and add a header
        /// </summary>
        private static void ResetConsoleScreen()
        {
            Console.Clear();

            //
            // display header
            //
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("\t\tThe Simple Calculator");
            Console.WriteLine();
            Console.WriteLine();
        }
    }
}
