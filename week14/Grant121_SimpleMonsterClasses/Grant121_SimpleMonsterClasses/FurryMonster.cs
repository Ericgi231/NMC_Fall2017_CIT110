using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grant121_SimpleMonsterClasses
{
    class FurryMonster
    {
        #region Fields

        private string _color;
        private bool _hasClaws;
        private string _name;
        private int _length;
        private DateTime _dateOfBirth;
        private FurryMonsterType _monsterType;
        private string _favoriteThing;

        #endregion

        #region Properties

        public string Color
        {
            get { return _color; }
            set { _color = value; }
        }

        public bool HasClaws
        {
            get { return _hasClaws; }
            set { _hasClaws = value; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public int Length
        {
            get { return _length; }
            set //convert meters to feet
            {
                _length = (int)(_length * 3.28084);
                _length = value;
            }
        }

        public DateTime DateOfBirth
        {
            get { return _dateOfBirth; }
            set { _dateOfBirth = value; }
        }

        public FurryMonsterType MonsterType
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

        public FurryMonster()
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
                    thing = "flag";
                    break;
                case 1:
                    thing = "paint brush";
                    break;
                case 2:
                    thing = "tail";
                    break;
                case 3:
                    thing = "guns";
                    break;
            }

            return thing;
        }

        public void Greeting(FurryMonster furryMonster)
        {
            Console.WriteLine($"Hello friend 0w0. I am {furryMonster.Name}! I'm your OC now.");
        }

        public void GoodBye(FurryMonster furryMonster)
        {
            Console.WriteLine($"{furryMonster.Name} waves their {furryMonster.FavoriteThing} in the air as they say goodbye.");
        }

        #endregion

    }
}
