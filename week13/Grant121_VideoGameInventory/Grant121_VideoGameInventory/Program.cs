using System;
using System.Collections.Generic;
using Method_Library_Grant121;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grant121_VideoGameInventory
{
    // Video Game Inventory
    // Console
    // 
    // Eric Grant
    // 11-20-2017
    //

    class Program
    {
        static void Main(string[] args)
        {
            List<VideoGame> inventory = new List<VideoGame>();
            Generic_Display GD = new Generic_Display();
            Generic_Input GI = new Generic_Input();

            inventory = InitializeVideoGameInventory();

            inventory.Add(DisplayGetGame(GI));

            DisplayInventory(inventory, GD);

        }

        public static VideoGame DisplayGetGame(Generic_Input GI)
        {
            VideoGame newGame = new VideoGame();

            Console.WriteLine("Enter Game Title:");
            Console.Write(">");
            newGame.Title = Console.ReadLine();
            Console.WriteLine();

            Console.WriteLine("Enter Game Publisher:");
            Console.Write(">");
            newGame.Publisher = Console.ReadLine();
            Console.WriteLine();

            Console.WriteLine("Enter Game Price:");
            newGame.Price = GI.GetValidDouble();
            Console.WriteLine();

            Console.WriteLine("Is Game Multiplayer:");
            Console.Write(">");
            newGame.Multiplayer = bool.Parse(Console.ReadLine());
            Console.WriteLine();

            return newGame;
        }

        public static void DisplayInventory(List<VideoGame> inventory, Generic_Display GD)
        {
            GD.DisplayNewScreen("Inventory");

            Console.Write("Title".PadRight(20));
            Console.Write("Publisher".PadRight(20));
            Console.Write("Price".PadRight(20));
            Console.Write("Online".PadRight(20));
            Console.WriteLine();
            Console.WriteLine();

            foreach (VideoGame game in inventory)
            {
                string price = game.Price.ToString();
                Console.Write(game.Title.PadRight(20));
                Console.Write(game.Publisher.PadRight(20));
                Console.Write($"${price}".PadRight(20));
                if (game.Multiplayer)
                {
                    Console.Write("Multiplayer".PadRight(20));
                } else
                {
                    Console.Write("Singleplayer".PadRight(20));
                }
                Console.WriteLine();

            }

            GD.DisplayAnyKey();
        }

        public static List<VideoGame> InitializeVideoGameInventory()
        {
            List<VideoGame> inventory = new List<VideoGame>();

            VideoGame vg001 = new VideoGame
            {
                Title = "Call Of Mario",
                Publisher = "Nintendo",
                Price = 59.99,
                Multiplayer = false
            };

            VideoGame vg002 = new VideoGame
            {
                Title = "Dues Ex: Dog",
                Publisher = "Ubisoft",
                Price = 79.99,
                Multiplayer = false
            };

            VideoGame vg003 = new VideoGame
            {
                Title = "Minecraft 2",
                Publisher = "Mojang",
                Price = 39.99,
                Multiplayer = true
            };

            VideoGame vg004 = new VideoGame
            {
                Title = "The Evil Outside",
                Publisher = "Bethesda",
                Price = 59.99,
                Multiplayer = false
            };

            inventory.Add(vg001);
            inventory.Add(vg002);
            inventory.Add(vg003);
            inventory.Add(vg004);

            return inventory;
        }
    }

    class VideoGame
    {
        #region Field

        private string _title;
        private string _publisher;
        private double _price;
        private bool _multiplayer;


        #endregion

        #region Properties

        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }

        public string Publisher
        {
            get { return _publisher; }
            set { _publisher = value; }
        }

        public double Price
        {
            get { return _price; }
            set { _price = value; }
        }

        public bool Multiplayer
        {
            get { return _multiplayer; }
            set { _multiplayer = value; }
        }

        #endregion

        #region Constructors

        public VideoGame()
        {

        }

        #endregion

        #region Methods

        #endregion
    }
}
