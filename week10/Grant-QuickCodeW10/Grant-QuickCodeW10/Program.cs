using System;

namespace Grant_QuickCodeW10
{
    class Program
    {
        public enum Fruit{
            ORANGE,
            APPLE,
            BANANA,
            MELLON,
            CHERRY,
            GRAPE
        }

        static void Main(string[] args)
        {
            string uInput;
            Fruit[] fruitArray = new Fruit[3];

            for (int i = 0; i < fruitArray.Length; i++)
            {
                do
                {
                    Console.WriteLine($"Select fruit {i + 1}");
                    uInput = Console.ReadLine().ToUpper();
                } while (!Enum.TryParse<Fruit>(uInput, out fruitArray[i]));
            }

            Console.Write("Your selected fruits: ");
            foreach (Enum fruit in fruitArray)
            {
                Console.Write($"{fruit}; ");
            }

            Console.ReadKey();
            
        }
    }
}
