using System;
using Method_Library_Grant121;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinchAPI;

namespace SentryFinch_Grant121
{
    class Program
    {
        //public methods
        //
        static Generic_Display GD = new Generic_Display();
        static Generic_Input GI = new Generic_Input();

        //public enums
        //
        public enum MenuOption
        {
            SETUP
            , ACTIVATE
            , EXIT
        }

        static void Main(string[] args)
        {
            Finch tim = InstantiateTim();
           
            GD.DisplayOpenScreen("Sentry Finch","tim will detect light and temp levels",new string[1] {"Eric Grant"});
            DisplayMenu(tim);
            tim.disConnect();
            GD.DisplayCloseScreen("Sentry Finch", new string[1] { "Eric Grant" });
            
        }

        static void DisplayMenu(Finch tim)
        {
            bool breaking = false;
            bool setup = false;
            double ambientTemp = 0, tolerance = 0;
            int ambientLight = 0;
            string uInput;
            MenuOption uInputAsEnum;

            while (!breaking)
            {
                GD.DisplayNewScreen("Main Menu");
                Console.WriteLine("Select Option:");
                foreach (MenuOption option in Enum.GetValues(typeof(MenuOption)))
                {
                    Console.WriteLine(option);
                }

                do
                {
                    Console.Write(">");
                    uInput = GI.GetString(true);
                } while (!Enum.TryParse<MenuOption>(uInput, out uInputAsEnum));

                switch (uInputAsEnum)
                {
                    case MenuOption.SETUP:
                        tolerance = DisplaySetupTim(tim, out ambientTemp, out ambientLight);
                        setup = true;
                        break;
                    case MenuOption.ACTIVATE:
                        if (setup)
                        {
                            DisplayActivateTim(tim, tolerance, ambientTemp, ambientLight);
                        } else
                        {
                            Console.WriteLine("Please run setup first.");
                            GD.DisplayAnyKey();
                        }
                        
                        break;
                    case MenuOption.EXIT:
                        breaking = true;
                        break;
                    default:
                        break;
                }
            }
            tim.disConnect();
        }

        static double DisplaySetupTim(Finch tim, out double ambientTemp, out int ambientLight)
        {
            double tolerance;

            GD.DisplayNewScreen("Setup Tim");

            Console.WriteLine("Enter the tolerance (2-10): ");
            do
            {
                Console.Write(">");
                tolerance = GI.GetValidDouble();
            } while (tolerance < 2 || tolerance > 10);
            

            ambientLight = tim.getLeftLightSensor();
            ambientTemp = tim.getTemperature();

            Console.WriteLine("Ambient light and temp levels set.");

            GD.DisplayAnyKey();

            return tolerance;
        }

        static void DisplayActivateTim(Finch tim, double tolerance, double ambientTemp, double ambientLight)
        {
            double currentTemp, currentLight, min, max;
            bool breaking = false;

            currentTemp = tim.getTemperature();
            currentLight = tim.getLeftLightSensor();
            min = ambientTemp - tolerance;
            max = ambientLight + tolerance;

            while (!breaking)
            {
                GD.DisplayNewScreen("Activate Tim");
                Console.WriteLine("Systems nominal.");
                tim.setLED(0, 100, 0);
                currentTemp = tim.getTemperature();
                currentLight = tim.getLeftLightSensor();
                tim.wait(200);

                if (currentTemp < min && currentLight > max)
                {
                    breaking = DisplayHitDouble(breaking, tim, currentLight, currentTemp);

                } else if (currentTemp < min && !(currentLight > max))
                {
                    breaking = DisplayHitFreeze(breaking, tim, currentTemp);

                } else if (currentLight > max && !(currentTemp < min))
                {
                    breaking = DisplayHitLazer(breaking, tim, currentLight);
                }

                tim.wait(200);
            }

            GD.DisplayAnyKey();
            tim.setLED(0,0,0);
            tim.noteOff();
        }

        static bool DisplayHitLazer(bool breaking, Finch tim, double currentLight)
        {
            GD.DisplayNewScreen("Activate Tim");
            breaking = true;
            tim.setLED(100, 0, 0);
            tim.noteOn(400);
            Console.WriteLine("Hit by lazer.");
            Console.WriteLine($"Light level is at: {currentLight}");
            return breaking;
        }

        static bool DisplayHitFreeze(bool breaking, Finch tim, double currentTemp)
        {
            GD.DisplayNewScreen("Activate Tim");
            breaking = true;
            tim.setLED(0, 0, 100);
            tim.noteOn(400);
            Console.WriteLine("Hit by freeze ray.");
            Console.WriteLine($"Temp is at: {currentTemp}");
            return breaking;
        }

        static bool DisplayHitDouble(bool breaking, Finch tim, double currentLight, double currentTemp)
        {
            GD.DisplayNewScreen("Activate Tim");
            breaking = true;
            tim.setLED(100, 100, 100);
            tim.noteOn(400);
            Console.WriteLine("Hit by freeze ray and lazer.");
            Console.WriteLine($"Temp is at: {currentTemp}");
            Console.WriteLine($"Light level is at: {currentLight}");
            return breaking;
        }

        static Finch InstantiateTim()
        {
            Finch tim = new Finch();
            tim.connect();
            return tim;
        }
    }
}
