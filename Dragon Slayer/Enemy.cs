using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dragon_Slayer
{
    class Enemy
    {
        //Private fields
        private int _health;
        private int _attack;
        private int _defense;
        private int _experience;
        private int _gold;


        //Public fields
        public string name;
        public int health
        {
            get
            {
                return _health;
            }
            set
            {
                if (value < 0)
                {
                    _health = 0;
                }
                else if (value > 10000000)
                {
                    _health = 10000000;
                }
                else
                {
                    _health = value;
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
                    _attack = value;
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
                    _defense = value;
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
        public double chargeModifier { get; set; }
        public double chargeInterruptModifier { get; set; }
        public double guardModifier { get; set; }


        //Constructor
        public Enemy(string name, int health, int attack, int defense, int experience, int gold, int chargeModifier,
            int chargeInterruptModifier, int guardModifier)
        {
            this.name = name;
            this.health = health;
            this.attack = attack;
            this.defense = defense;
            this.experience = experience;
            this.gold = gold;
            this.chargeModifier = chargeModifier;
            this.chargeInterruptModifier = chargeInterruptModifier;
            this.guardModifier = guardModifier;
        }



        //Combat calculations 
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

        public int ChargeAttack(int hp, int defense)
        {
            int chargeAttack = 0;
            chargeAttack = (int)(attack * chargeModifier);

            int damage = chargeAttack - defense;
            if (damage < 0)
            {
                damage = 0;
            }
            hp -= damage;
            if (hp < 0)
            {
                hp = 0;
            }
            return hp;
        }

        public int ChargeDamage(int defense)
        {
            int chargeDamage = 0;
            chargeDamage = (int)(attack * chargeModifier);

            int damage = chargeDamage - defense;
            if (damage < 0)
            {
                damage = 0;
            }
            return damage;
        }

        public int SpecialAttackInterruption(int defense)
        {
            int specialAttackInterruption = (int)(attack * chargeInterruptModifier) - defense;

            if (specialAttackInterruption < 0)
            {
                specialAttackInterruption = 0;
            }
            return specialAttackInterruption;
        }

        public int SpecialAttackGuarded(int attack)
        {
            int specialAttackGuarded;

            specialAttackGuarded = (attack * 5) - (int)(defense * guardModifier);

            if (specialAttackGuarded <= 0)
            {
                specialAttackGuarded = 0;
            }
            return specialAttackGuarded;
        }
    }
}
