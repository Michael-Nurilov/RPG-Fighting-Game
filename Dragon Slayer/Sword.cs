using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dragon_Slayer
{
    class Sword : Item
    {
        //Private fields
        private int _level;
        private int _attackValue;


        //Public fields
        public int level
        {
            get
            {
                return _level;
            }
            set
            {
                if (value < 0)
                {
                    _level = 0;
                }
                else if (value > 4)
                {
                    _level = 4;
                }
                else
                {
                    _level = value;
                }
            }
        }
        public int attackValue
        {
            get
            {
                return _attackValue;
            }
            set
            {
                if (level == 0)
                {
                    _attackValue = 0;
                }
                else if (level == 1)
                {
                    _attackValue = 10;
                }
                else if (level == 2)
                {
                    _attackValue = 30;
                }
                else if (level == 3)
                {
                    _attackValue = 70;
                }
                else if (level == 4)
                {
                    _attackValue = 150;
                }
            }
        }


        //Constructor
        public Sword(int _ID, string _name, int _goldValue, string _description, int _level, int _AttackValue) :
            base(_ID, _name, _goldValue, 1, _description)
        {
            level = _level;
            attackValue = _AttackValue;
        }


        //Display sword level
        public void DisplaySword(Sword _sword)
        {
            if (_sword.level == 0)
            {
                Console.WriteLine("Sword Level: ░ ░ ░ ░");
            }
            else if (_sword.level == 1)
            {
                Console.WriteLine("Sword Level: █ ░ ░ ░");
            }
            else if (_sword.level == 2)
            {
                Console.WriteLine("Sword Level: █ █ ░ ░");
            }
            else if (_sword.level == 3)
            {
                Console.WriteLine("Sword Level: █ █ █ ░");
            }
            else if (_sword.level == 4)
            {
                Console.WriteLine("Sword Level: █ █ █ █");
            }
        }


        //Upgrade the swords level
        public void Upgrade(Player _player, Sword _sword)
        {
            _sword.level++;
            _sword.attackValue++;
            _sword.goldValue++;
            _player.attack += 0;
        }
    }
}
