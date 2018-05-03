using System;
using FinchAPI;
using Method_Library_Grant121;
using System.Collections.Generic;
using System.Linq;

namespace Grant_SuperFinch
{
    class Program
    {
        //eric grant
        //super finch Level 3
        //finch moves forward and is effected by light and temp levels
        //created: 11-8-2017
        //edit: 11-17-2017
        //

        /// <summary>
        /// possible shield levels of SuperTina
        /// </summary>
        public enum FinchLevel
        {
            HIGH = 3,
            MEDIUM = 2,
            LOW = 1,
            EMPTY = 0 
        }

        static void Main(string[] args)
        {
            Generic_Display GD = new Generic_Display();
            Generic_Input GI = new Generic_Input();
            Generic_Alter GA = new Generic_Alter();

            GD.DisplayOpenScreen("Super Finch", "Tina the super finch will move forward until she is murdered by lazers and freeze rays.", new string[1] {"Eric Grant"});
            DisplayMainLoop(GD, GI, GA);
            GD.DisplayCloseScreen("Super Finch", new string[1] {"Eric Grant"});
        }

        /// <summary>
        /// display main program loop
        /// </summary>
        static void DisplayMainLoop(Generic_Display GD, Generic_Input GI, Generic_Alter GA)
        {
            //declare constants
            //
            int[,] NOSECOLORS = new int[4, 3] { {0, 0, 0}, {255, 0, 0}, {0, 0, 255}, {0, 255, 0} };
            int[] SPEEDS = new int[4] { 0, 127, 191, 255};

            GD.DisplayNewScreen("Main App Loop");

            //instantiate SuperTina
            //
            Finch superTina = InstantiateFinch();
            FinchLevel superTinaLevel;

            Console.WriteLine("\nPlease enter the shield level for Super Tina (1-3)");
            superTinaLevel = InputFinchLevelValid();
            Console.WriteLine($"\nSuper Tinas shields are at {superTinaLevel} power level");

            int[] SuperTinaNoseColor = new int[3];
            SuperTinaNoseColor = GA.SpliceIntMultiArray(NOSECOLORS, (int)superTinaLevel, 3);
            int SuperTinaSpeed = SPEEDS[(int)superTinaLevel];

            //declare variables
            //
            bool breakLoop = false;

            //activate SuperTina
            //
            Console.WriteLine("\nSuper Tina is ready for battle.");
            GD.DisplayAnyKey();

            superTina.setMotors(SuperTinaSpeed, SuperTinaSpeed);
            superTina.setLED(SuperTinaNoseColor[0], SuperTinaNoseColor[1], SuperTinaNoseColor[2]);

            //main loop
            //
            while (!breakLoop)
            {
                breakLoop = DisplayActivateTim(superTina, NOSECOLORS, SPEEDS, superTinaLevel, GD, GI, GA);
            }

            superTina.disConnect();
        }

        /// <summary>
        /// instantiate and assign SuperTina the Finch
        /// </summary>
        /// <returns>Finch SuperTina</returns>
        static Finch InstantiateFinch()
        {
            Finch SuperTina = new Finch();
            if (SuperTina.connect())
            {
                Console.WriteLine("Super Tina is here.");
            } else
            {
                Console.WriteLine("Super Tina didn't show up.");
            }

            return SuperTina;
        }

        /// <summary>
        /// get valid FinchLevel input
        /// </summary>
        static FinchLevel InputFinchLevelValid()
        {
            FinchLevel finchLevel;
            string uInput;

            do
            {
                do
                {
                    Console.Write(">");
                    uInput = Console.ReadLine();
                } while (!Enum.TryParse<FinchLevel>(uInput, out finchLevel));
            } while ((int)finchLevel > 3 || (int)finchLevel < 1);

            return finchLevel;
        }

        static bool DisplayActivateTim(Finch superTina, int[,] NOSECOLORS, int[] SPEEDS, FinchLevel superTinaLevel, Generic_Display GD, Generic_Input GI, Generic_Alter GA)
        {
            double currentTemp, currentLight, ambientTemp, ambientLight, min, max;
            int[] levelArray = new int[3];
            bool breaking = false;

            ambientTemp = superTina.getTemperature();
            ambientLight = AverageLight(superTina);
            min = ambientTemp - 1;
            max = ambientLight + 3;

            Console.WriteLine($"Shields at {superTinaLevel} level.");

            while (!breaking)
            {
                currentTemp = superTina.getTemperature();
                currentLight = AverageLight(superTina);
                superTina.wait(200);

                switch (superTinaLevel)
                {
                    case FinchLevel.HIGH:
                        if (currentTemp < min && currentLight > max) //freeze ray and lazer
                        {
                            superTinaLevel--;
                            superTina.setMotors(SPEEDS[(int)superTinaLevel], SPEEDS[(int)superTinaLevel]);
                            Hit(superTina, GA.SpliceIntMultiArray(NOSECOLORS, (int)superTinaLevel, 3));
                            Console.WriteLine($"Shield levels at {superTinaLevel}!\n");
                        }
                        break;
                    case FinchLevel.MEDIUM:
                        if (currentLight > max) //just lazer
                        {
                            superTinaLevel--;
                            superTina.setMotors(SPEEDS[(int)superTinaLevel], SPEEDS[(int)superTinaLevel]);
                            Hit(superTina, GA.SpliceIntMultiArray(NOSECOLORS, (int)superTinaLevel, 3));
                            Console.WriteLine($"Shield levels at {superTinaLevel}!\n");
                        }
                        break;
                    case FinchLevel.LOW:
                        if (currentTemp < min) //just freeze ray
                        {
                            superTinaLevel--;
                            superTina.setMotors(SPEEDS[(int)superTinaLevel], SPEEDS[(int)superTinaLevel]);
                            Hit(superTina, GA.SpliceIntMultiArray(NOSECOLORS, (int)superTinaLevel, 3));
                            Console.WriteLine($"Shield levels at {superTinaLevel}!\n");
                        }
                        else if (currentLight > max) //just lazer
                        {
                            superTinaLevel--;
                            superTina.setMotors(SPEEDS[(int)superTinaLevel], SPEEDS[(int)superTinaLevel]);
                            Hit(superTina, GA.SpliceIntMultiArray(NOSECOLORS, (int)superTinaLevel, 3));
                            Console.WriteLine($"Shield levels at {superTinaLevel}!\n");
                        }
                        break;
                    case FinchLevel.EMPTY:
                        breaking = true;
                        break;
                    default:
                        break;
                }

                superTina.wait(200);
            }

            Console.WriteLine("SuperTina is dead. The world has been destroyed. All is lost, even hope.");

            GD.DisplayAnyKey();
            return breaking;
        }

        static void Hit(Finch superTina, int[] NOSECOLOR)
        {
            Console.WriteLine("HIT!");

            for (int i = 0; i < 3; i++)
            {
                superTina.setLED(255,255,255);
                superTina.noteOn(500);
                superTina.wait(500);
                superTina.setLED(0, 0, 0);
                superTina.noteOff();
                superTina.wait(500);
            }

            superTina.setLED(NOSECOLOR[0], NOSECOLOR[1], NOSECOLOR[2]);
        }

        static double AverageLight(Finch superTina)
        {
            double light = (superTina.getLeftLightSensor() + superTina.getRightLightSensor()) / 2;
            return light;
        }
    }
}
