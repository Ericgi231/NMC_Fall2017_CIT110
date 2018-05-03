using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grant_EnumTest
{
    class Program
    {
        public enum Season
        {
            FALL,
            WINTER,
            SPRING,
            SUMMER,
            ULTRASUMMER
        }
        static void Main(string[] args)
        {
            double averageTemperature;
            Season seasonAsEnum;
            string seasonAsString;

            Console.WriteLine("What is your favorite season?");
            
            do
            {
                seasonAsString = Console.ReadLine().ToUpper();
            } while (!Enum.TryParse<Season>(seasonAsString, out seasonAsEnum));

            switch (seasonAsEnum)
            {
                case Season.FALL:
                    averageTemperature = 0;
                    break;
                case Season.WINTER:
                    averageTemperature = -200;
                    break;
                case Season.SPRING:
                    averageTemperature = 70;
                    break;
                case Season.SUMMER:
                    averageTemperature = 100;
                    break;
                case Season.ULTRASUMMER:
                    averageTemperature = 9999999999999999;
                    break;
                default:
                    averageTemperature = 0;
                    break;
            }

            Console.WriteLine($"Average temp: {averageTemperature}");

            Console.WriteLine("~~~");
            Console.ReadKey();
        }
    }
}
