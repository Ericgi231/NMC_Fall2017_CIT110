using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Grant_QuickCode10
{
    class Program
    {
        static void Main(string[] args)
        {

            

            try
            {
                File.WriteAllText("Data\\Data.txt", "Eric Grant");

            }
            catch (DirectoryNotFoundException)
            {
                Directory.CreateDirectory("Data\\");
                Console.WriteLine("Folder Created");
            }
            finally
            {

            }

            Console.ReadKey();
        }
    }
}
