using FinchAPI;
using System;

namespace Finch_Starter
{
    class Program
    {
        // *************************************************************
        // Application:     Finch lights and temp
        // Author:          Eric Grant
        // Date Created:    9-20-2017
        // Date Revised:    9-20-2017
        // *************************************************************

        static void Main(string[] args)
        {
            // create a new Finch object
            //
            Finch myFinch = new Finch();

            //vars
            //
            double temp;
            double lightL;
            double lightR;
            bool note = false;

            // call the connect method
            //
            bool isConnected;
            isConnected = myFinch.connect();
            Console.WriteLine($"isConnected = {isConnected}");
            Console.WriteLine("Any Key To Start\n");
            Console.ReadKey();

            // begin your code
            //

            //display temp
            //
            while (true) {
                temp = myFinch.getTemperature();
                lightL = myFinch.getLeftLightSensor();
                lightR = myFinch.getRightLightSensor();
                Console.WriteLine($"temp = {temp}");
                Console.WriteLine($"left light = {lightL}\nright light = {lightR}\n");
                if (lightL > 70 && lightR < 70) {
                    myFinch.setLED(255, 0, 0);
                    myFinch.noteOn(750);
                    note = true;
                    Console.WriteLine("left light is lit");
                }
                else if (lightL < 70 && lightR > 70)
                {
                    myFinch.setLED(0, 255, 0);
                    myFinch.noteOn(250);
                    note = true;
                    Console.WriteLine("right light is lit");
                }
                else if (lightL > 70 && lightR > 70)
                {
                    myFinch.setLED(255, 255, 255);
                    myFinch.noteOn(500);
                    note = true;
                    Console.WriteLine("both lights are lit");
                }
                else if (lightL < 70 && lightR < 70)
                {
                    myFinch.setLED(0, 0, 0);
                    if (note == true)
                    {
                        myFinch.noteOff();
                        note = false;
                    }
                    Console.WriteLine("no light is lit");
                }
                myFinch.wait(100);
                Console.Clear();
            }

            //end of your code
            //

            // call the disconnect method
            //
            Console.WriteLine("\nAny Key To End");
            Console.ReadKey();
            myFinch.disConnect();
        }
    }
}
