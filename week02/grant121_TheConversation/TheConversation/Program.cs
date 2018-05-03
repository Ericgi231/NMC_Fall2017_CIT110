using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheConversation
{
    class Program
    {
        static void Main(string[] args)
        {
            //declaring variables
            //
            string myName = "Velis";
            string userInput;
            string userName;
            string userLast;
            string userFave;
            int userAge;
            int userNum;

            //set console
            //
            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.White;
            Console.WindowHeight = 15;
            Console.WindowWidth = 100;
            Console.SetBufferSize(100, 15);
            Console.Clear();

            //get userName
            //
            Console.Write($"Hello traveler, what is your name?\n>");
            userName = Console.ReadLine();
            Console.Clear();

            //check if name is valid
            //
            if (userName == myName)
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.Clear();
                Console.WriteLine($"You can not use that name, that name is already taken. Be gone you foul name thief!");
                Console.WriteLine("\n<Press ENTER To Close Window>");
                Console.CursorVisible = false;
                Console.Read();
                System.Environment.Exit(1);
            }

            //get userAge
            //
            Console.Write($"And how many years of age be ye {userName}?\n>");
            userInput = Console.ReadLine();
            userAge = int.Parse(userInput);
            Console.Clear();

            //check if user is old enough
            //
            if (userAge < 21)
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.Clear();
                Console.WriteLine($"Sorry kid, you're to young to gamble. If the police ask, you never saw me.");
                Console.WriteLine("\n<Press ENTER To Close Window>");
                Console.CursorVisible = false;
                Console.Read();
                System.Environment.Exit(1);
            }

            //ask question
            //
            Console.WriteLine($"Well well {userName}, today is your lucky day. I am grand wizard {myName}! I shall grant you three wishes...\nIf you can answer this one simple question correctly.");
            Console.Write($"\nWho is the handsomest grand wizard of them all?\n>");
            userInput = Console.ReadLine();
            Console.Clear();

            //determine if answer is valid
            //
            if (userInput == myName)
            {
                Console.WriteLine($"Your answer is true. I shall grant your wishes.");
            }
            else
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.Clear();
                Console.WriteLine($"Your answer is false, leave my handsome presence!");
                Console.WriteLine("\n<Press ENTER To Close Window>");
                Console.CursorVisible = false;
                Console.Read();
                System.Environment.Exit(1);
            }

            //first wish, ask what color they want the text
            //
            Console.Write("\nFirst I shall change your text color.\nChoose a color: Red or Blue\n>");
            userInput = Console.ReadLine();
            Console.Write("\nBippity Boppity Boop... ");
            Console.Beep(700, 1000);

            //change the text color based on input
            //
            if (userInput == "Red")
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("You're red now.\n");
            }
            else if (userInput == "Blue")
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write("You're blue now.\n");
            }
            else
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.Clear();
                Console.WriteLine($"Stop fooling around, I got better things to do.");
                Console.WriteLine("\n<Press ENTER To Close Window>");
                Console.CursorVisible = false;
                Console.Read();
                System.Environment.Exit(1);
            }

            //ask user to continue so they have time to see the new color
            //
            Console.WriteLine($"\nI hope you enjoy your new perspective {userName}.\n\nPress ENTER for me to grant your next wish.");
            Console.CursorVisible = false;
            Console.ReadLine();
            Console.CursorVisible = true;
            Console.Clear();

            //second wish, ask for a string and a new string to replace it with
            Console.Write("For your second wish, I shall make your name better.\nWhat is your last name?\n>");
            userLast = Console.ReadLine();
            Console.Write($"\n{userLast}? Really now, we can do better.\nWhat is your favorite animal?\n>");
            userFave = Console.ReadLine();

            //change name and ask to continue
            //
            Console.Write($"\nCongrats {userName} {userLast}, your about to be less lame.\n\nBippity Boppity Boop... ");
            Console.Beep(700, 1000);
            userLast = userFave;
            Console.Write($"your new name is {userName} {userLast}. \n\nPress ENTER for me to grant your next wish.");
            Console.CursorVisible = false;
            Console.ReadLine();
            Console.CursorVisible = true;
            Console.Clear();

            //third wish, ask for a number
            Console.Write("Your third and final wish, a blank check.\nWhat number do you write?\n>");
            userInput = Console.ReadLine();
            userNum = int.Parse(userInput);
            Console.Write($"\nWell, no magic behind it this time {userLast}, just cash that in whenever.\n");

            //end input
            //
            Console.CursorVisible = false;
            Console.WriteLine("\n<Press ENTER To Close Window>");
            Console.ReadLine();
        }
    }
}
