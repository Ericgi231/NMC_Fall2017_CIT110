using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grant_QuickCode9
{
    class Program
    {
        static void Main(string[] args)
        {
            PostColors(GetColors());
        }

        static string[] GetColors()
        {
            string[] colors = new string[5];

            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"Please enter color #{i + 1}");
                colors[i] = Console.ReadLine();
            }

            return colors;
        }

        static void PostColors(string[] colors)
        {
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"Color #{i + 1}: {colors[i]}");
            }
            Console.ReadKey();
        }
    }
}
