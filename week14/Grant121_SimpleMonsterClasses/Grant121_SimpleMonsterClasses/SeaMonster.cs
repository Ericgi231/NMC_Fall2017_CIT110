using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grant121_SimpleMonsterClasses
{
    class SeaMonster
    {
        #region Fields

        private string _color;
        private bool _hasScales;
        private string _name;
        private int _length;
        private DateTime _dateOfBirth;
        private SeaMonsterType _monsterType;
        private string _favoriteThing;

        #endregion

        #region Properties

        public string Color
        {
            get { return _color; }
            set { _color = value; }
        }

        public bool HasScales
        {
            get { return _hasScales; }
            set { _hasScales = value; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public int Length
        {
            get { return _length; } 
            set { _length = (int)(value * 3.28084); }//convert meters to feet
        }

        public DateTime DateOfBirth
        {
            get { return _dateOfBirth; }
            set { _dateOfBirth = value; }
        }

        public SeaMonsterType MonsterType
        {
            get { return _monsterType; }
            set { _monsterType = value; }
        }

        public string FavoriteThing
        {
            get { return _favoriteThing; } //read only
        }

        #endregion

        #region Constructors

        public SeaMonster()
        {
            Random rand = new Random();
            _favoriteThing = SetFaveThing(rand);

        }

        #endregion

        #region Methods

        static string SetFaveThing(Random rand)
        {
            string thing = "nothing";
            switch (rand.Next(1, 4))
            {
                case 0:
                    thing = "shiny rock";
                    break;
                case 1:
                    thing = "rubber duck";
                    break;
                case 2:
                    thing = "gold";
                    break;
                case 3:
                    thing = "blow fish";
                    break;
            }

            return thing;
        }

        public void Greeting(SeaMonster seaMonster)
        {
            Console.WriteLine($"Hello flesh bag. I am {seaMonster.Name} of the sea! Thank you for creating me.");
        }

        public void GoodBye(SeaMonster seaMonster)
        {
            Console.WriteLine($"{seaMonster.Name} splashes out of the water to wave you a farewell.");
        }

        #endregion

    }
}
