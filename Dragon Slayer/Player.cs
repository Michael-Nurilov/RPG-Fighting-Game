using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dragon_Slayer
{
    class Player
    {
        //Constants
        private const int PLAYER_MAXIMUM_LEVEL = 15;


        //Private fields
        private int _currentHealth;
        private int _topHealth;
        private int _attack;
        private int _defense;
        private int _gold;
        private int _experience;
        private int _level;
        private int expNeeded = 100;
        private int _specialBar = 0;


        //Public fields
        public string name;
        public int currentHealth
        {
            get
            {
                return _currentHealth;
            }
            set
            {
                if (value < 0)
                {
                    _currentHealth = 0;
                }
                else if (value > _topHealth)
                {
                    _currentHealth = _topHealth;
                }
                else
                {
                    _currentHealth = value;
                }
            }
        }
        public int topHealth
        {
            get
            {
                return _topHealth;
            }
            set
            {
                if (value < 0)
                {
                    _topHealth = 0;
                }
                else if (value > 10000000)
                {
                    _topHealth = 10000000;
                }
                else
                {
                    _topHealth = value;
                }
            }
        }
        public int attack
        {
            get
            {
                return _attack;
            }
            set
            {
                if (value < 0)
                {
                    _attack = 0;
                }
                else if (value > 1500000)
                {
                    _attack = 1500000;
                }
                else
                {
                    if (swordChecker == false)
                    {
                        if (Sword.level == 0)
                        {
                            _attack = value;
                        }
                        else if (Sword.level == 1)
                        {
                            _attack = value + Sword.attackValue;
                        }
                        else if (Sword.level == 2)
                        {
                            _attack = value + Sword.attackValue - 10;
                        }
                        else if (Sword.level == 3)
                        {
                            _attack = value + Sword.attackValue - 30;
                        }
                        else if (Sword.level == 4)
                        {
                            _attack = value + Sword.attackValue - 70;
                        }
                    }
                    else
                    {
                        _attack = value;
                    }
                }
            }
        }
        public int defense
        {
            get
            {
                return _defense;
            }
            set
            {
                if (value < 0)
                {
                    _defense = 0;
                }
                else if (value > 1000000)
                {
                    _defense = 1000000;
                }
                else
                {
                    if (armorChecker == false)
                    {
                        if (Armor.level == 0)
                        {
                            _defense = value;
                        }
                        else if (Armor.level == 1)
                        {
                            _defense = value + Armor.defenseValue;
                        }
                        else if (Armor.level == 2)
                        {
                            _defense = value + Armor.defenseValue - 5;
                        }
                        else if (Armor.level == 3)
                        {
                            _defense = value + Armor.defenseValue - 15;
                        }
                        else if (Armor.level == 4)
                        {
                            _defense = value + Armor.defenseValue - 35;
                        }
                    }
                    else
                    {
                        _defense = value;
                    }
                }
            }
        }
        public int gold
        {
            get
            {
                return _gold;
            }
            set
            {
                if (value < 0)
                {
                    _gold = 0;
                }
                else
                {
                    _gold = value;
                }
            }
        }
        public int experience
        {
            get
            {
                return _experience;
            }
            set
            {
                if (value < 0)
                {
                    _experience = 0;
                }
                else
                {
                    _experience = value;
                }
            }
        }
        public int level
        {
            get
            {
                return _level;
            }
            set
            {
                if (value < 1)
                {
                    _level = 1;
                }
                else if (value > 15)
                {
                    _level = 15;
                }
                else
                {
                    _level = value;
                }
            }
        }
        public int specialBar
        {
            get
            {
                return _specialBar;
            }
            set
            {
                if (value < 0)
                {
                    _specialBar = 0;
                }
                else if (value > 4)
                {
                    _specialBar = 4;
                }
                else
                {
                    _specialBar = value;
                }
            }
        }
        public bool swordChecker = true;
        public bool armorChecker = true;
        public List<Item> Equipment = new List<Item>();
        public PlayerInventory playerInventory = new PlayerInventory();
        public Sword Sword = new Sword(4, "Sword", 0, "A weapon which augments your attack", 1, 1);
        public Armor Armor = new Armor(5, "Armor", 0, "A weapon which augments your defense", 1, 1);


        //Progession indicator
        public bool dragonAlive = true;
        public bool plainCleared = false;
        public bool riverCleared = false;
        public bool forestCleared = false;
        public bool bridgeCleared = false;


        //Constructor
        public Player()
        {
            level = 1;
            experience = 0;
            topHealth = 100;
            currentHealth = 100;
            attack = 10;
            defense = 3;
            gold = 0;
            Equip();
        }


        //Equips the player with a sword and shield
        private void Equip()
        {
            Equipment.Add(Sword);
            Equipment.Add(Armor);
        }

        


        //Displays the users stats
        public void DisplayStats()
        {
            Console.Clear();
            Console.WriteLine("Level:          " + level);
            Console.WriteLine("Experience:     {0}/{1}", experience, expNeeded);
            Console.WriteLine("Health:         {0}/{1}", currentHealth, topHealth);
            Console.WriteLine("Attack:         " + attack + "(+{0})", Sword.attackValue);
            Console.WriteLine("Defense:        " + defense + "(+{0})", Armor.defenseValue);
            Console.WriteLine("Gold:           " + gold);
            Console.ReadKey();
        }


        //Displays the users special bar
        public void DisplaySpecialBar()
        {
            if (specialBar == 0)
            {
                Console.WriteLine("Special Bar: ░░░░░░░░");
            }
            else if (specialBar == 1)
            {
                Console.WriteLine("Special Bar: ██░░░░░░");
            }
            else if (specialBar == 2)
            {
                Console.WriteLine("Special Bar: ████░░░░");
            }
            else if (specialBar == 3)
            {
                Console.WriteLine("Special Bar: ██████░░");
            }
            else if (specialBar == 4)
            {
                Console.WriteLine("Special Bar: ████████");
            }
            else
            {
                Console.WriteLine("Error");
            }
        }


        //Levels the player to the next level and adjusts stats 
        private void LevelUp()
        {
            //If the current level is the maximum level then do not increase the level
            if (level >= PLAYER_MAXIMUM_LEVEL)
            {
                experience = expNeeded;
            }
            else
            {
                level++;
                topHealth += (int)(Math.Pow(level, 1.3) / 0.10);
                attack += (int)(Math.Pow(level, 1.3) / 0.8);
                defense += (int)(Math.Pow(level, 1.3) / 1.5);
                currentHealth = topHealth;
                Console.WriteLine("You have leveled up!");
                Console.WriteLine("You have gained {0} health", (int)(Math.Pow(level, 1.3) / 0.10));
                Console.WriteLine("You have gained {0} attack", (int)(Math.Pow(level, 1.3) / 0.8));
                Console.WriteLine("You have gained {0} defense", (int)(Math.Pow(level, 1.3) / 1.5));
            }
        }


        //Used when the player gains experience
        public void ExperienceGain(int amount)
        {
            experience += amount;
            while (experience >= expNeeded)
            {
                LevelUp();
                experience -= expNeeded;
                expNeeded += (int)(Math.Pow(level, 1.3) / 0.06);
            }
        }


        //Players attack
        public int Attack(int hp, int defense)
        {
            int damage = attack - defense;
            if (damage < 0)
            {
                damage = 0;
            }
            hp -= damage;
            if (hp < 0)
            {
                hp = 0;
            }
            specialBar++;
            return hp;
        }

        public int DamageDone(int defense)
        {
            int damage = attack - defense;
            if (damage < 0)
            {
                damage = 0;
            }
            return damage;
        }

        public int SpecialAttack(int defense)
        {
            int specialAttack = (attack * 5) - defense;
            if (specialAttack < 0)
            {
                specialAttack = 0;
            }
            return specialAttack;
        }

        public int SpecialAttackInterrupt(int defense)
        {
            int specialAttackInterrupt = (attack * 8) - defense;
            if (specialAttackInterrupt < 0)
            {
                specialAttackInterrupt = 0;
            }
            return specialAttackInterrupt;
        }

        public int Guard(int attack)
        {
            int GuardBlock = 0;
            GuardBlock = attack - (defense * 5);
            if (GuardBlock < 0)
            {
                GuardBlock = 0;
            }
            return GuardBlock;
        }
    }
}
