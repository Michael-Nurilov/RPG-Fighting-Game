using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dragon_Slayer
{
    static class BattleText
    {
        //Displays the start battle options
        public static void StartBattle(Player _player, Enemy _enemy)
        {
            Console.Clear();
            Console.WriteLine("You have encountered a {0}, what will you do?", _enemy.name);
            Console.WriteLine("{0}'s Health: {1}", _enemy.name, _enemy.health);
            Console.WriteLine("{0}'s Health: {1}", _player.name, _player.currentHealth);
            _player.DisplaySpecialBar();
            Console.WriteLine("1 to Attack                          2 to Guard");
            Console.WriteLine("3 to use an Item                     4 to Run");
        }


        //Displays the castle battle options
        public static void StartCastleBattle(Player _player, Enemy _enemy)
        {
            Console.Clear();
            Console.WriteLine("You have encountered a {0}, what will you do?", _enemy.name);
            Console.WriteLine("{0}'s Health: {1}", _enemy.name, _enemy.health);
            Console.WriteLine("{0}'s Health: {1}", _player.name, _player.currentHealth);
            _player.DisplaySpecialBar();
            Console.WriteLine("1 to Attack                          2 to Guard");
            Console.WriteLine("3 to use an Item                     4 to Charge a Special Attack");
        }


        //Displays the during battle options
        public static void DuringBattle(Player _player, Enemy _enemy)
        {
            Console.Clear();
            Console.WriteLine("What is your next move?");
            Console.WriteLine("{0}'s Health: {1}", _enemy.name, _enemy.health);
            Console.WriteLine("{0}'s Health: {1}", _player.name, _player.currentHealth);
            _player.DisplaySpecialBar();
            Console.WriteLine("1 to Attack                          2 to Guard");
            Console.WriteLine("3 to use an Item                     4 to Charge a Special Attack");
        }


        //Displays the player attacking
        public static void PlayerAttack(Player _player, Enemy _enemy)
        {
            Console.Clear();
            Console.WriteLine("{0} strikes the {1} for {2} damage", _player.name, _enemy.name, _player.DamageDone(_enemy.defense));
            Console.WriteLine("{0}'s Health: {1}", _enemy.name, _player.Attack(_enemy.health, _enemy.defense));
            Console.WriteLine("{0}'s Health: {1}", _player.name, _player.currentHealth);
            _player.DisplaySpecialBar();
            Console.ReadKey();
        }


        //Displays the player special attack charging
        public static void PlayerSpecialAttackCharge(Player _player, Enemy _enemy)
        {
            Console.Clear();
            Console.WriteLine("{0} begins charging for a special attack", _player.name);
            Console.WriteLine("{0}'s Health: {1}", _enemy.name, _enemy.health);
            Console.WriteLine("{0}'s Health: {1}", _player.name, _player.currentHealth);
            _player.DisplaySpecialBar();
            Console.ReadKey();
        }


        //Displays the player not having enough special bar
        public static void PlayerSpecialBarNotEnough(Player _player, Enemy _enemy)
        {
            Console.Clear();
            Console.WriteLine("{0} does not have enough special power built up", _player.name);
            Console.WriteLine("{0}'s Health: {1}", _enemy.name, _enemy.health);
            Console.WriteLine("{0}'s Health: {1}", _player.name, _player.currentHealth);
            _player.DisplaySpecialBar();
            Console.ReadKey();
        }


        //Displays the player getting interrupted on his special attack
        public static void PlayerSpecialAttackInterrupted(Player _player, Enemy _enemy)
        {
            Console.Clear();
            Console.WriteLine("The {0} unleashes a massive attack on an unprepared {1} and deals {2} damage", _enemy.name, _player.name, _enemy.SpecialAttackInterruption(_player.defense));
            Console.WriteLine("{0}'s Health: {1}", _enemy.name, _enemy.health);
            Console.WriteLine("{0}'s Health: {1}", _player.name, _player.currentHealth);
            _player.DisplaySpecialBar();
            Console.ReadKey();
        }


        //Displays the player special attacking
        public static void PlayerSpecialAttack(Player _player, Enemy _enemy)
        {
            Console.Clear();
            Console.WriteLine("{0} unleashes a charged special power and strikes the {1} for {2} damage", _player.name, _enemy.name, _player.SpecialAttack(_enemy.defense));
            Console.WriteLine("{0}'s Health: {1}", _enemy.name, _enemy.health);
            Console.WriteLine("{0}'s Health: {1}", _player.name, _player.currentHealth);
            _player.DisplaySpecialBar();
            Console.ReadKey();
        }


        //Displays the player special attacking interrupting an enemy
        public static void PlayerSpecialAttackInterrupt(Player _player, Enemy _enemy)
        {
            Console.Clear();
            Console.WriteLine("{0} unleashes a charged special power on an unprepared {1} and deals {2} damage", _player.name, _enemy.name, _player.SpecialAttackInterrupt(_enemy.defense));
            Console.WriteLine("{0}'s Health: {1}", _enemy.name, _enemy.health);
            Console.WriteLine("{0}'s Health: {1}", _player.name, _player.currentHealth);
            _player.DisplaySpecialBar();
            Console.ReadKey();
        }


        //Displays the enemy attacking
        public static void EnemyAttack(Player _player, Enemy _enemy)
        {
            Console.Clear();
            Console.WriteLine("The {0} strikes {1} for {2} damage", _enemy.name, _player.name, _enemy.DamageDone(_player.defense));
            Console.WriteLine("{0}'s Health: {1}", _enemy.name, _enemy.health);
            Console.WriteLine("{0}'s Health: {1}", _player.name, _player.currentHealth);
            _player.DisplaySpecialBar();
            Console.ReadKey();
        }


        //Displays the enemy charging his special attack
        public static void EnemyCharge(Player _player, Enemy _enemy)
        {
            Console.Clear();
            Console.WriteLine("The {0} is charging up for a massive attack", _enemy.name);
            Console.WriteLine("{0}'s Health: {1}", _enemy.name, _enemy.health);
            Console.WriteLine("{0}'s Health: {1}", _player.name, _player.currentHealth);
            _player.DisplaySpecialBar();
            Console.ReadKey();
        }

        
        //Displays the enemys charge attacking the player
        public static void EnemyChargeAttack(Player _player, Enemy _enemy)
        {
            Console.Clear();
            Console.WriteLine("The {0} unleashes a stored energy and strikes {1} for {2} damage", _enemy.name, _player.name, _enemy.ChargeDamage(_player.defense));
            Console.WriteLine("{0}'s Health: {1}", _enemy.name, _enemy.health);
            Console.WriteLine("{0}'s Health: {1}", _player.name, _player.currentHealth);
            _player.DisplaySpecialBar();
            Console.ReadKey();
        }


        //Displays the player guarding
        public static void Guard(Player _player, Enemy _enemy)
        {
            Console.Clear();
            Console.WriteLine("{0} puts up a shield and prepares for an incoming attack", _player.name);
            Console.WriteLine("{0}'s Health: {1}", _enemy.name, _enemy.health);
            Console.WriteLine("{0}'s Health: {1}", _player.name, _player.currentHealth);
            _player.DisplaySpecialBar();
            Console.ReadKey();
        }


        //Displays the player guarding a normal attack
        public static void GuardNormalBlock(Player _player, Enemy _enemy)
        {
            Console.Clear();
            Console.WriteLine("{0} guards against the {1}'s attack and takes {2} damage", _player.name, _enemy.name, _player.Guard(_enemy.attack));
            Console.WriteLine("{0}'s Health: {1}", _enemy.name, _enemy.health);
            Console.WriteLine("{0}'s Health: {1}", _player.name, _player.currentHealth);
            _player.DisplaySpecialBar();
            Console.ReadKey();
        }


        //Displays the player guarding a special attack
        public static void GuardChargedBlock(Player _player, Enemy _enemy)
        {
            Console.Clear();
            Console.WriteLine("{0} guards against the {1}'s charged attack and takes {2} damage", _player.name, _enemy.name, _player.Guard(_enemy.attack * 3));
            Console.WriteLine("{0}'s Health: {1}", _enemy.name, _enemy.health);
            Console.WriteLine("{0}'s Health: {1}", _player.name, _player.currentHealth);
            _player.DisplaySpecialBar();
            Console.ReadKey();
        }


        //Displays the enemy guarding against the player attack
        public static void EnemyGuard(Player _player, Enemy _enemy)
        {
            Console.Clear();
            Console.WriteLine("The {0} takes a defense stance and prepares for your incoming attack", _enemy.name);
            Console.WriteLine("{0}'s Health: {1}", _enemy.name, _enemy.health);
            Console.WriteLine("{0}'s Health: {1}", _player.name, _player.currentHealth);
            _player.DisplaySpecialBar();
            Console.ReadKey();
        }


        //Displays the enemy guarding against the player special attack
        public static void EnemyGuardAttack(Player _player, Enemy _enemy)
        {
            Console.Clear();
            Console.WriteLine("{0} unleashes a special attack on the prepared {1} and deals {2} damage", _player.name, _enemy.name, _enemy.SpecialAttackGuarded(_player.attack));
            Console.WriteLine("{0}'s Health: {1}", _enemy.name, _enemy.health);
            Console.WriteLine("{0}'s Health: {1}", _player.name, _player.currentHealth);
            _player.DisplaySpecialBar();
            Console.ReadKey();
        }


        //Displays the player using a potion to heal
        public static void PotionHeal(Player _player, Enemy _enemy, Potion _potion)
        {
            Console.Clear();
            Console.WriteLine("{0} drinks a {1} and gains {2} health", _player.name, _potion.name, _potion.healingValue);
            Console.WriteLine("{0}'s Health: {1}", _enemy.name, _enemy.health);
            Console.WriteLine("{0}'s Health: {1}", _player.name, _player.currentHealth);
            _player.DisplaySpecialBar();
            Console.ReadKey();
        }
    }
}
