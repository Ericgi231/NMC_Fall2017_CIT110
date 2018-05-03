using FinchAPI;
using System;

namespace FinchesGotTalent
{
    class Program
    {
        /// <summary>
        /// Finches Got Talent Application
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            //comment block
            //
            // title: finches got talent
            // description: finch dances
            // application type: console
            // author: Eric Grant
            // date created: 9/14/2017
            // last modified: 9/14/2017
            //
            //comment block end

            //declare variables and instantiate new Finch
            //
            Finch myFinch;
            myFinch = new Finch();

            //creating methods
            //
            void FinchAction(int left, int right, int red, int green, int blue, int note, int wait)
            {
                myFinch.setMotors(left, right);
                myFinch.setLED(red, green, blue);
                myFinch.noteOn(note);
                myFinch.wait(wait);
                myFinch.noteOff();
            }

            //connect to the Finch robot
            //
            myFinch.connect();

            //wait to start
            //
            Console.WriteLine("Press any key to dance.");
            Console.ReadKey();

            //dance
            //
            //forward, green, 300hz, 2s
            FinchAction(50, 50, 0, 255, 0, 300, 2000);
            //back, red, 400hz, 2s
            FinchAction(-50, -50, 255, 0, 0, 400, 2000);
            //turn left, blue, 500hz, 1s
            FinchAction(-100, 100, 0, 0, 255, 500, 1000);
            //forward, green, 600hz, 1.7s
            FinchAction(60, 60, 0, 255, 0, 600, 1700);
            //back, red, 500hz, 1.7s
            FinchAction(-60, -60, 255, 0, 0, 500, 1700);
            //turn right, blue, 400hz, 1.5s
            FinchAction(100, -100, 0, 0, 255, 400, 1500);
            //forward, green, 300hz, 0.6s
            FinchAction(75, 75, 0, 255, 0, 300, 600);
            //back, red, 400hz, 0.6s
            FinchAction(-75, -75, 255, 0, 0, 400, 600);
            //turn left, blue, 500hz, 0.5s
            FinchAction(-250, 250, 0, 0, 255, 500, 500);
            //back, red, 600hz, 1s
            FinchAction(-85, -85, 255, 0, 0, 600, 1000);
            //turn right, blue, 500hz, 1.25s
            FinchAction(250, -250, 0, 0, 255, 500, 1250);
            //back, red, 400hz, 0.5s
            FinchAction(-100, -100, 255, 0, 0, 400, 500);
            //
            //dance end

            //disconnect from the Finch robot
            //
            myFinch.disConnect();

            //pause the console window before exiting
            //
            Console.WriteLine("\nPress any key to exit.");
            Console.ReadKey();
        }
    }
}
