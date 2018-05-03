using FinchAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_Finch_LightAndSound
{
    class Program
    {
        static void Main(string[] args)
        {
            ///////////////////////////////////////////////////////////
            //
            // Solution:      Demo - The Sound and Light Show (Starter)
            // Description:   Starter file for classroom demo
            // Author:        John E Velis
            // Created:       1/21/2016
            // Modified:
            //
            ///////////////////////////////////////////////////////////

            ///////////////////////////////////////////////////////////
            //
            // Declare, create a Finch object and connect to it
            //
            ///////////////////////////////////////////////////////////

            //
            // Declare the Finch variable and create (instantiate) a new Finch object
            //
            int num;
            Finch myFinch;
            myFinch = new Finch();

            //
            // Connect to the Finch robot
            //
            myFinch.connect();

            //
            // Inform and prompt the user
            //
            Console.WriteLine();
            Console.WriteLine("You are now connected to the Finch robot.");
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();

            //
            //move
            //
            Console.WriteLine();
            Console.WriteLine("We goin places.");
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();

            //
            //move forward and back
            //
            myFinch.setMotors(200,200);
            myFinch.wait(1000);
            myFinch.setMotors(0, 0);

            myFinch.wait(500);

            myFinch.setMotors(-200, -200);
            myFinch.wait(1000);
            myFinch.setMotors(0, 0);

            //
            //turn left
            //
            myFinch.setMotors(100, 200);
            myFinch.wait(1000);
            myFinch.setMotors(0, 0);

            myFinch.wait(500);

            myFinch.setMotors(-100, -200);
            myFinch.wait(1000);
            myFinch.setMotors(0, 0);

            //
            //turn right
            //
            myFinch.setMotors(200, 100);
            myFinch.wait(1000);
            myFinch.setMotors(0, 0);

            myFinch.wait(500);

            myFinch.setMotors(-200, -100);
            myFinch.wait(1000);
            myFinch.setMotors(0, 0);

            //
            //spin
            //
            myFinch.setMotors(200, -200);
            myFinch.wait(2000);
            myFinch.setMotors(0, 0);

            //
            //for loop
            //
            Console.WriteLine();
            Console.WriteLine("Time to get flashed kid.");
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();

            myFinch.setLED(0, 0, 0);
            myFinch.noteOff();
            for (int i = 0; i < 3; i++)
            {
                for (int x = 0; x < 5; x++)
                {
                    myFinch.noteOn(300);
                    myFinch.setLED(126, 0, 126);
                    myFinch.wait(100);
                    myFinch.setLED(0, 0, 0);
                    myFinch.noteOff();
                    myFinch.wait(100);
                }
                myFinch.wait(100);
                for (int l = 0; l < 5; l++)
                {
                    myFinch.noteOn(500);
                    myFinch.setLED(0, 126, 126);
                    myFinch.wait(100);
                    myFinch.setLED(0, 0, 0);
                    myFinch.noteOff();
                    myFinch.wait(100);
                }
                myFinch.wait(100);
                for (int j = 0; j < 5; j++)
                {
                    myFinch.noteOn(700);
                    myFinch.setLED(0, 0, 126);
                    myFinch.wait(100);
                    myFinch.setLED(0, 0, 0);
                    myFinch.noteOff();
                    myFinch.wait(100);
                }
                myFinch.wait(100);
            }

            ///////////////////////////////////////////////////////////
            //
            // Control the Finch robot's LED
            // (Red, Green, Blue) value range: 0-255
            //
            ///////////////////////////////////////////////////////////

            //
            // Inform and prompt the user
            //
            Console.WriteLine();
            Console.WriteLine("This is a demonstration of controlling the LED on the Finch robot.");
            Console.WriteLine("The Finch will flash white and then red for a second each.");
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();

            // Wait one second 1000 = 1 second
            myFinch.wait(1000);

            // Turn on all colors (white light)
            myFinch.setLED(255, 255, 255);

            // Wait one second 1000 = 1 second
            myFinch.wait(1000);

            // Turn off all colors
            myFinch.setLED(0, 0, 0);

            // Wait one second 1000 = 1 second
            myFinch.wait(1000);

            // Flash red for one second
            myFinch.setLED(255, 0, 0);
            myFinch.wait(1000);
            myFinch.setLED(0, 0, 0);

            //
            // Info and prompt the user
            //
            Console.WriteLine();
            Console.WriteLine("The Finch robot's LED demo is done.");
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();

            ///////////////////////////////////////////////////////////
            //
            // Control the Finch robot's tone generator
            // (hertz) 262 = middle C
            // 
            ///////////////////////////////////////////////////////////

            //
            // Inform and prompt the user
            //
            Console.WriteLine();
            Console.WriteLine("This is a demonstration of controlling the tone generator on the Finch robot.");
            Console.WriteLine("The Finch will play a middle C for one second and ");
            Console.WriteLine("then a middle F for half a second and");
            Console.WriteLine("then a middle A for two seconds.");
            Console.WriteLine("The Finch will rest for one second between each note.");
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();

            // Wait one second 1000ms = 1 second
            myFinch.wait(1000);

            // Turn on middle C (262 hertz)
            myFinch.noteOn(262);

            // Wait one second 1000sm = 1 second
            myFinch.wait(1000);

            // Turn off middle C
            myFinch.noteOff();

            // Wait one second 1000sm = 1 second
            myFinch.wait(1000);

            // Turn on middle F (349 hertz)
            myFinch.noteOn(349);

            // Wait half a second 500ms = 0.5 second
            myFinch.wait(500);

            // Turn off middle F
            myFinch.noteOff();

            // Wait one second 1000ms = 1 second
            myFinch.wait(1000);

            // Play middle A (440 hertz) for two seconds
            myFinch.noteOn(440);
            myFinch.wait(2000);
            myFinch.noteOff();

            // Wait one second 1000ms = 1 second
            myFinch.wait(1000);

            //
            // Info and prompt the user
            //
            Console.WriteLine();
            Console.WriteLine("The Finch robot's sound demo is done.");
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();

            ///////////////////////////////////////////////////////////
            //
            // Disconnect from the Finch robot and exit the application
            // 
            ///////////////////////////////////////////////////////////

            //
            // Disconnect from the Finch robot
            //
            myFinch.disConnect();

            //
            // Info and prompt the user
            //
            Console.WriteLine();
            Console.WriteLine("You are now disconnected from the Finch robot.");
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();

            //
            // Pause the console window before exiting
            //
            Console.WriteLine();
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }
}
