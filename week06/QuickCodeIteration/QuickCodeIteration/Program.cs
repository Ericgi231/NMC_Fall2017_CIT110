using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickCodeIteration
{
    class Program
    {
        static void Main(string[] args)
        {
            //eric grant
            //iteration quick code
            //iterate through a loop and display all multiples of 5
            //10-4-2017

            Console.WriteLine("All multiples of 5 upto 100\n");

            for (int x = 5; x <= 100; x = x + 5)
            {
                Console.WriteLine(x);
            }

            Console.Clear();
            Console.WriteLine("\nPress any key to end.");
            Console.ReadKey();
        }
    }
}
