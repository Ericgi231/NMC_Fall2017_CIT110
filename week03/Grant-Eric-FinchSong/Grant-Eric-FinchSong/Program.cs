using FinchAPI;
using System;

namespace FinchSong
{
    class Program
    {
        /// <summary>
        /// finches play tem shop
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            ///
            //COMMENT BLOCK
            //
            // title: finches play tem shop
            // description: two finches plays 'tem shop' by Toby Fox
            // application type: console
            // author: Eric Grant
            // date created: 9/15/2017
            // last modified: 9/17/2017
            //
            //COMMENT BLOCK END
            ///

            ///
            //VARIABLES
            //
            Finch myFinch;
            myFinch = new Finch();

            //length of a normal beat
            //
            int beatLen = 300;

            //length of a normal rest after beat
            //
            int beatRes = 50;

            //notes used in song
            //vars commented out are not used in this song
            //
            //int C3 = 130;
            int D3 = 146;
            //int E3 = 164;
            //int F3 = 174;
            int G3 = 196;
            //int A3 = 220;
            int B3 = 246;

            //int C4 = 261;
            int D4 = 293;
            int E4 = 329;
            int F4 = 349;
            int G4 = 392;
            //int A4 = 440;
            //int B4 = 493;

            //int C5 = 523; 
            int D5 = 587;
            int E5 = 659;
            int F5 = 698;
            int G5 = 784;
            int A5 = 880;
            int B5 = 988;

            //int C6 = 1046;
            int D6 = 1174;

            //
            //VARIABLES END
            ///

            ///
            //METHODS
            //

            ///<summary>
            ///sasafsafasfagg
            /// </summary>

            ///<summary>
            ///finch plays note and lights up nose
            ///</summary>
            ///<param name="note">frequencie of note</param>
            ///<param name="play">duration of note</param>
            ///<param name="hold">duration of rest after note</param>
            void FinchNote(int note, int play, int hold)
            {
                myFinch.setLED(255, 255, 255);
                myFinch.noteOn(note);
                myFinch.wait(play);

                myFinch.setLED(0, 0, 0);
                myFinch.noteOff();
                myFinch.wait(hold);
            }

            //background beat parts
            //
            void FinchBeat1()
            {
                FinchNote(G3, beatLen, beatRes);
                FinchNote(B3, beatLen, beatRes);
                FinchNote(D3, beatLen, beatRes);
                FinchNote(B3, beatLen, beatRes);
            }

            void FinchBeat2()
            {
                FinchNote(B3, beatLen, beatRes);
                FinchNote(E4, beatLen, beatRes);
                FinchNote(G3, beatLen, beatRes);
                FinchNote(E4, beatLen, beatRes);
            }

            void FinchBeat3()
            {
                FinchNote(D4, beatLen, beatRes);
                FinchNote(F4, beatLen, beatRes);
                FinchNote(G3, beatLen, beatRes);
                FinchNote(F4, beatLen, beatRes);
            }

            void FinchBeat4()
            {
                FinchNote(B3, beatLen, beatRes);
                FinchNote(E4, beatLen, beatRes);
                FinchNote(D4, beatLen, beatRes);
                FinchNote(F4, beatLen, beatRes);
            }

            void FinchBeat5()
            {
                FinchNote(D4, beatLen, beatRes);
                FinchNote(F4, beatLen, beatRes);
                FinchNote(G4, beatLen, beatRes);
                FinchNote(G3, beatLen, beatRes);
            }

            //
            //METHODS END
            ///

            //connect to the Finch robot
            myFinch.connect();

            //wait to start
            Console.WriteLine("'tem shop'");
            Console.WriteLine("Toby Fox");
            Console.WriteLine("Press any key to begin");
            Console.ReadKey();

            ///
            //FINCH 1 - BEAT
            //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            //the BEAT code should run on FINCH 1 simultaneously with the MELODY code on FINCH 2
            //remove the BEAT code from FINCH 2 and vise versa
            //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            //
            for (int x = 0; x < 2; x++)
            {
                FinchBeat1();
                FinchBeat1();
                FinchBeat2();
                FinchBeat3();
                FinchBeat1();
                FinchBeat1();
                FinchBeat4();
                FinchBeat5();
            }
            //
            //FINCH 1 - BEAT END
            ///

            ///
            //FINCH 2 - MELODY
            //
            for (int x = 0; x < 2; x++)
            {
                myFinch.wait(beatLen + beatRes);
                FinchNote(D6, beatLen + (beatLen / 2), beatRes);
                FinchNote(B5, beatLen + (beatLen / 2), beatRes);
                myFinch.wait(beatRes);

                FinchNote(G5, beatLen, beatRes);
                FinchNote(A5, beatLen / 2, beatRes / 2);
                FinchNote(G5, beatLen, beatRes);
                FinchNote(D5, beatLen / 2, beatRes / 2);
                FinchNote(E5, beatLen / 2, beatRes / 2);
                FinchNote(G5, beatLen / 2, beatRes / 2);

                myFinch.wait(beatLen + beatRes);
                FinchNote(E5, beatLen + (beatLen / 2), beatRes);
                FinchNote(G5, beatLen + (beatLen / 2), beatRes);
                myFinch.wait(beatRes);

                FinchNote(F5, beatLen, beatRes);
                FinchNote(G5, beatLen / 2, beatRes / 2);
                FinchNote(A5, beatLen, beatRes);
                myFinch.wait((beatLen + beatRes) / 2);
                myFinch.wait(beatLen + beatRes);

                myFinch.wait(beatLen + beatRes);
                FinchNote(D6, beatLen + (beatLen / 2), beatRes);
                FinchNote(B5, beatLen + (beatLen / 2), beatRes);
                myFinch.wait(beatRes);

                FinchNote(G5, beatLen, beatRes);
                FinchNote(A5, beatLen / 2, beatRes / 2);
                FinchNote(G5, beatLen, beatRes);
                FinchNote(D5, beatLen / 2, beatRes / 2);
                FinchNote(E5, beatLen / 2, beatRes / 2);
                FinchNote(G5, beatLen / 2, beatRes / 2);

                FinchNote(B5, beatLen / 2, beatRes / 2);
                FinchNote(B5, beatLen / 2, beatRes / 2);
                FinchNote(A5, beatLen, beatRes);
                FinchNote(A5, beatLen / 2, beatRes / 2);
                FinchNote(G5, beatLen / 2, beatRes / 2);
                FinchNote(E5, beatLen, beatRes);

                FinchNote(E5, beatLen, beatRes);
                FinchNote(G5, beatLen, beatRes);
                FinchNote(G5, beatLen, beatRes);
                myFinch.wait(beatLen + beatRes);
            }
            //
            //FINCH 2 - MELODY END
            ///

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
