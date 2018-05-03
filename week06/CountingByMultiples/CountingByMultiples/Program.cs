using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountingByMultiples
{
    class Program
    {
        static void Main(string[] args)
        {
            //eric grant
            //iteration quick code
            //iterate through a loop and display all multiples of 5
            //10-4-2017

            int z = 8;
            int n1 = -60;
            int n2 = 68;

            Console.WriteLine($"All multiples of {z} between {n1} and {n2}\n");

            for (int x = n1; x <= n2; x += z)
            {
                Console.WriteLine(x);
            }

            Console.CursorVisible = false;
            Console.WriteLine("\nPress any key to end.");
            Console.ReadKey();
        }
    }
}
