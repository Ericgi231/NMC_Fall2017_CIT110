using FinchAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment1
{
    class Program
    {
        // **************************************
        // * Name:Eric Grant
        // * Course:CIT110
        // * Date:10-2-2017
        // * Assessment:Test 1
        // **************************************
        static void Main(string[] args)
        {
            //instantiate finch
            //
            Finch tim= new Finch();
            tim.connect();

            //declare vars
            //
            string uInput;
            int timTone = 0;

            //methods
            //
            ///<summary>Ask user to press enter to continue program</summary>
            void anyKeyToContinue(string message){
                Console.CursorVisible = false;
                Console.WriteLine($"\n{message}\n");
                Console.ReadKey();
                Console.CursorVisible = true;
            }

            //part 1
            //
            Console.WriteLine("Exercising my Finch - Part 1.\n");

            //set red nose and motor speed
            //
            Console.WriteLine("Turning my nose red and backing up for 3 seconds.");
            tim.setLED(255,0,0);
            tim.setMotors(-200,-200);

            //wait 3 seconds
            //
            tim.wait(3000);

            //turn off nose and motors, also beep
            //
            Console.WriteLine("Now I'm stopped and my nose is off.");
            tim.setLED(0, 0, 0);
            tim.setMotors(0, 0);

            //beep for 1 second
            //
            Console.WriteLine("Excuse me...I beeped!");
            tim.noteOn(400);
            tim.wait(1000);
            tim.noteOff();

            anyKeyToContinue("That was easy. Press the enter key to continue to Part 2.");
            //
            //end part 1

            //part 2
            //

            //get user input
            //
            Console.WriteLine("Should I turn left or right?");
            Console.WriteLine("Enter Left or Right and press the Enter key.");
            uInput = Console.ReadLine().ToLower();

            //test user inpput
            //
            switch (uInput)
            {
                case "left":
                    Console.WriteLine("Turning left with my nose blue.");
                    tim.setLED(0,0,255);
                    tim.setMotors(-200,200);
                    tim.wait(2000);
                    tim.setLED(0, 0, 0);
                    tim.setMotors(0, 0);
                    break;

                case "right":
                    Console.WriteLine("Turning right with my nose green.");
                    tim.setLED(0, 255, 0);
                    tim.setMotors(200, -200);
                    tim.wait(2000);
                    tim.setLED(0, 0, 0);
                    tim.setMotors(0, 0);
                    break;

                default:
                    Console.WriteLine("Invalid user entry!");
                    break;
            }

            anyKeyToContinue("OK. On to Part 3. Press the any key");
            //
            //end part 2

            //part 3
            //
            Console.WriteLine("I'd like to make some noise.");
            Console.WriteLine("I'll make a tone for one second as long as you don't ask me to go too high.");
            Console.WriteLine("The top of my range is 800.");

            //do while the tone is less then or equal to 800
            //
            do
            {
                //get user input
                ///
                Console.WriteLine("Enter a tone value.");

                //determine if valid and use if it is
                //
                if(int.TryParse(Console.ReadLine(), out timTone))
                {
                    tim.noteOn(timTone);
                    tim.wait(1000);
                    tim.noteOff();
                } else
                {
                    Console.WriteLine("Invalid input.");
                }
            } while (timTone <= 800);

            //disconect finch
            //
            tim.disConnect();

            anyKeyToContinue("OK, I'm done!");
            //
            //end part 3
        }
    }
}
