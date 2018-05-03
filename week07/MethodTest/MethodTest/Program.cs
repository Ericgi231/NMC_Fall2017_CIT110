using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MethodTest
{
    class Program
    {
        static void Main(string[] args)
        {
            string faveBook = DisplayGetUserFaveBook();
            int bookRead = DisplayGetUserBooksRead();

            DisplayUserInfo(faveBook,bookRead);
        }

        /// <summary>
        /// display screen that asks user for their favorite book
        /// </summary>
        /// <returns>users favorite book as string</returns>
        static string DisplayGetUserFaveBook()
        {
            Console.Write("What is your favorite book?\n>");
            string bookName = Console.ReadLine();

            AnyKeyToContinue();

            return bookName;
        }

        /// <summary>
        /// display screen that asks user for amount of books read in past year
        /// </summary>
        /// <returns>number of books read by user as int</returns>
        static int DisplayGetUserBooksRead()
        {
            int bookRead;
            Console.Write("How many books have you read in the past yeaer?\n>");
            while (!int.TryParse(Console.ReadLine(), out bookRead))
            {
                Console.Write("That is not a number.\n>");
            }

            AnyKeyToContinue();

            return bookRead;
        }

        /// <summary>
        /// display the users favorite book
        /// </summary>
        /// <param name="bookName">name of users favorite book</param>
        static void DisplayUserInfo(string bookName, int bookRead)
        {
            Console.WriteLine($"Your favorite book is {bookName}.");
            Console.WriteLine($"You have read {bookRead} books last year.");
            Console.WriteLine($"You should read {bookRead * 2} this year.");

            AnyKeyToContinue();
        }

        /// <summary>
        /// prompt user to press any key then clear screen
        /// </summary>
        static void AnyKeyToContinue()
        {
            Console.CursorVisible = false;
            Console.WriteLine("\nPress any key to continue.");
            Console.ReadKey();
            Console.Clear();
            Console.CursorVisible = true;
        }
    }
}
