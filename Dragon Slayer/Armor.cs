using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dragon_Slayer
{
    class Armor : Item
    {
        //Private fields
        private int _level;
        private int _defenseValue;


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
        public int defenseValue
        {
            get
            {
                return _defenseValue;
            }
            set
            {
                if (level == 0)
                {
                    _defenseValue = 0;
                }
                else if (level == 1)
                {
                    _defenseValue = 5;
                }
                else if (level == 2)
                {
                    _defenseValue = 15;
                }
                else if (level == 3)
                {
                    _defenseValue = 35;
                }
                else if (level == 4)
                {
                    _defenseValue = 75;
                }
            }
        }


        //Constructor
        public Armor(int _ID, string _name, int _goldValue, string _description, int _level, int _DefenseValue) :
            base(_ID, _name, _goldValue, 1, _description)
        {
            level = _level;
            defenseValue = _DefenseValue;
        }


        //Displays armor level
        public void DisplayArmor(Armor _armor)
        {
            if (_armor.level == 0)
            {
                Console.WriteLine("Armor Level: ░ ░ ░ ░");
            }
            else if (_armor.level == 1)
            {
                Console.WriteLine("Armor Level: █ ░ ░ ░");
            }
            else if (_armor.level == 2)
            {
                Console.WriteLine("Armor Level: █ █ ░ ░");
            }
            else if (_armor.level == 3)
            {
                Console.WriteLine("Armor Level: █ █ █ ░");
            }
            else if (_armor.level == 4)
            {
                Console.WriteLine("Armor Level: █ █ █ █");
            }
        }


        //Upgrades the armors level
        public void Upgrade(Player _player, Armor _armor)
        {
            _armor.level++;
            _armor.defenseValue++;
            _armor.goldValue++;
            _player.defense += 0;
        }
    }
}
