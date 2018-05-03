using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Method_Library_Grant121;

namespace Grant121_SimpleMonsterClasses
{
    class Program
    {
        static void Main(string[] args)
        {
            Generic_Display display = new Generic_Display();
            Generic_Input input = new Generic_Input();
            Generic_Alter alter = new Generic_Alter();

            SeaMonster big = new SeaMonster();
            InitializeSeaMonsterBig(big);

            FurryMonster jodi = new FurryMonster();
            InitializeFurryMonsterJodi(jodi);

            List<SeaMonster> seaMonsters = new List<SeaMonster>();
            List<FurryMonster> furryMonsters = new List<FurryMonster>();

            seaMonsters.Add(big);
            furryMonsters.Add(jodi);

            bool exit = false;

            display.DisplayOpenScreen("Sea Monster Classes", "temp", new string[1] {"Eric Grant"});

            do
            {
                exit = MainMenu(seaMonsters, furryMonsters, display);
            } while (!exit);

        }

        /// <summary>
        /// display a title screen with menu
        /// </summary>
        /// <returns>MainMenuOption user selected</returns>
        static bool MainMenu(List<SeaMonster> seaMonsters, List<FurryMonster> furryMonsters ,Generic_Display display)
        {
            //declare vars
            //
            int selected = 0;
            ConsoleKeyInfo uKey;
            bool breaking = false;
            bool exit = false;

            string[] options = new string[5] 
            {
                "Make Sea Monster"
                , "Display Sea Monster Info"
                , "Make Furry Monster"
                , "Display Furry Monster Info"
                , "Exit"
            };

            Console.CursorVisible = false;

            //menu loop
            //
            do
            {
                Console.Clear();

                Console.WriteLine("~ MOSNTER MENU ~");
                Console.WriteLine("\nARROWS TO NAVIGATE\nENTER TO SELECT\n");

                //print options
                //
                for (int i = 0; i < options.Length; i++)
                {
                    if (selected == i)
                    {
                        Console.Write("(*) ");
                        Console.WriteLine(options[i]);
                    }
                    else
                    {
                        Console.Write("( ) ");
                        Console.WriteLine(options[i]);
                    }
                }

                //get input and determine selected option
                //
                uKey = Console.ReadKey(true);

                if (uKey.Key.ToString() == "DownArrow") //user moves down
                {
                    selected++;
                    if (selected > options.Length - 1)
                    {
                        selected = 0;
                    }
                }
                else if (uKey.Key.ToString() == "UpArrow") //user moves up
                {
                    selected--;
                    if (selected < 0)
                    {
                        selected = Convert.ToInt16(options.Length - 1);
                    }
                }
                else if (uKey.Key.ToString() == "Enter") //user selects option
                {
                    breaking = true;
                }

            } while (!breaking);

            switch (options[selected])
            {
                case "Make Sea Monster":
                    DisplayUserAddSeaMonsters(seaMonsters, display);
                    break;
                case "Display Sea Monster Info":
                    DisplayAllSeaMonsterInfo(seaMonsters, display);
                    break;
                case "Make Furry Monster":
                    DisplayUserAddFurryMonsters(furryMonsters, display);
                    break;
                case "Display Furry Monster Info":
                    DisplayAllFurryMonsterInfo(furryMonsters, display);
                    break;
                case "Exit":
                    exit = true;
                    display.DisplayNewScreen("Goodbye");

                    foreach (SeaMonster monster in seaMonsters)
                    {
                        monster.GoodBye(monster);
                    }

                    foreach (FurryMonster monster in furryMonsters)
                    {
                        monster.GoodBye(monster);
                    }

                    display.DisplayAnyKey();

                    display.DisplayCloseScreen("Sea Monster Classes", new string[1] { "Eric Grant" });
                    break;
                default:
                    break;
            }

            Console.CursorVisible = true;
            return exit;
        }

        static void DisplayUserAddSeaMonsters(List<SeaMonster> seaMonsters, Generic_Display display)
        {
            Generic_Input input = new Generic_Input();
            SeaMonsterType monsterType;
            string uInput;
            int year, month, day;

            display.DisplayNewScreen("Monster Maker");

            SeaMonster seaMonster = new SeaMonster();

            Console.WriteLine("Enter monster name:");
            seaMonster.Name = input.GetString(false);

            Console.WriteLine("Enter monster color:");
            seaMonster.Color = input.GetString(false);

            Console.WriteLine("Does monster have scales (true or false):");
            seaMonster.HasScales = input.GetBool();

            Console.WriteLine("Enter monster length in meters:");
            seaMonster.Length = input.GetValidInt();

            Console.WriteLine("When was the monster born.");
            Console.WriteLine("Year:");
            do
            {
                year = input.GetValidInt();
            } while (year < 0 || year > 2017);

            Console.WriteLine("Month:");
            do {
                month = input.GetValidInt();
            } while (month < 0 || month > 12);

            Console.WriteLine("Day:");
            do {
                day = input.GetValidInt();
            } while (day < 0 || day > 31);

            seaMonster.DateOfBirth = new DateTime(year, month, day);

            Console.WriteLine("Enter monster type (Fish, Cephalopod, Crustation, Jelly):");
            do
            {
                uInput = Console.ReadLine();
            } while (!Enum.TryParse<SeaMonsterType>(uInput, out monsterType));
            seaMonster.MonsterType = monsterType;

            seaMonsters.Add(seaMonster);

            Console.WriteLine();
            seaMonster.Greeting(seaMonster);

            display.DisplayAnyKey();
        }

        static void DisplaySeaMonsterInfo(SeaMonster seaMonster)
        {
            Console.WriteLine($"{seaMonster.Name} is a {seaMonster.Color} {seaMonster.MonsterType} sea monster.");
            if (seaMonster.HasScales)
            {
                Console.WriteLine("They have shiny scales.");
            } else
            {
                Console.WriteLine("They have weak flesh.");
            }
            Console.WriteLine($"They are {seaMonster.Length} feet tall.");
            Console.WriteLine($"They were born on {seaMonster.DateOfBirth}");
            Console.WriteLine($"They love their {seaMonster.FavoriteThing}");
            Console.WriteLine();
        }

        static void DisplayAllSeaMonsterInfo(List<SeaMonster> seaMonsters, Generic_Display display)
        {
            display.DisplayNewScreen("Main Application");

            foreach (SeaMonster seaMonster in seaMonsters)
            {
                DisplaySeaMonsterInfo(seaMonster);
            }

            display.DisplayAnyKey();
        }

        static void DisplayUserAddFurryMonsters(List<FurryMonster> furryMonsters, Generic_Display display)
        {
            Generic_Input input = new Generic_Input();
            FurryMonsterType monsterType;
            string uInput;
            int year, month, day;

            display.DisplayNewScreen("Monster Maker");

            FurryMonster furryMonster = new FurryMonster();

            Console.WriteLine("Enter monster name:");
            furryMonster.Name = input.GetString(false);

            Console.WriteLine("Enter monster color:");
            furryMonster.Color = input.GetString(false);

            Console.WriteLine("Does monster have claws (true or false):");
            furryMonster.HasClaws = input.GetBool();

            Console.WriteLine("Enter monster length in meters:");
            furryMonster.Length = input.GetValidInt();

            Console.WriteLine("When was the monster born.");
            Console.WriteLine("Year:");
            do
            {
                year = input.GetValidInt();
            } while (year < 0 || year > 2017);

            Console.WriteLine("Month:");
            do
            {
                month = input.GetValidInt();
            } while (month < 0 || month > 12);

            Console.WriteLine("Day:");
            do
            {
                day = input.GetValidInt();
            } while (day < 0 || day > 31);

            furryMonster.DateOfBirth = new DateTime(year, month, day);

            Console.WriteLine("Enter monster type (Cat, Dog, Horse, Rat):");
            do
            {
                Console.Write(">");
                uInput = Console.ReadLine();
            } while (!Enum.TryParse<FurryMonsterType>(uInput, out monsterType));
            furryMonster.MonsterType = monsterType;

            furryMonsters.Add(furryMonster);

            Console.WriteLine();
            furryMonster.Greeting(furryMonster);

            display.DisplayAnyKey();
        }

        static void DisplayFurryMonsterInfo(FurryMonster furryMonster)
        {
            Console.WriteLine($"{furryMonster.Name} is a {furryMonster.Color} {furryMonster.MonsterType} furry monster.");
            if (furryMonster.HasClaws)
            {
                Console.WriteLine("They have sharp claws.");
            }
            else
            {
                Console.WriteLine("They have strong paws.");
            }
            Console.WriteLine($"They are {furryMonster.Length} feet tall.");
            Console.WriteLine($"They were born on {furryMonster.DateOfBirth}");
            Console.WriteLine($"They love their {furryMonster.FavoriteThing}");
            Console.WriteLine();
        }

        static void DisplayAllFurryMonsterInfo(List<FurryMonster> furryMonsters, Generic_Display display)
        {
            display.DisplayNewScreen("Main Application");

            foreach (FurryMonster furryMonster in furryMonsters)
            {
                DisplayFurryMonsterInfo(furryMonster);
            }

            display.DisplayAnyKey();
        }

        static void InitializeSeaMonsterBig(SeaMonster seaMonster)
        {
            seaMonster.Name = "Big";
            seaMonster.Color = "Orange";
            seaMonster.HasScales = true;
            seaMonster.Length = 6;
            seaMonster.DateOfBirth = new DateTime(1948, 4, 7);
            seaMonster.MonsterType = SeaMonsterType.Fish;
        }

        static void InitializeFurryMonsterJodi(FurryMonster furryMonster)
        {
            furryMonster.Name = "Jodi";
            furryMonster.Color = "White";
            furryMonster.HasClaws = false;
            furryMonster.Length = 13;
            furryMonster.DateOfBirth = new DateTime(1965, 3, 6);
            furryMonster.MonsterType = FurryMonsterType.Horse;
        }

    }
}
