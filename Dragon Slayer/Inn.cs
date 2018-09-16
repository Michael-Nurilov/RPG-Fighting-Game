using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dragon_Slayer
{
    static class Inn
    {
        //The cost to use the inn
        private const int GOLD_COST = 100;


        //Greeting to the inn
        private static void InnGreeting()
        { 
            Console.Clear();
            Console.WriteLine("Welcome to the inn would you like to heal your wounds?");
            Console.WriteLine("All it will cost is {0} gold", GOLD_COST);
            Console.WriteLine();
            Console.WriteLine("Press 1 to stay at the inn");
            Console.WriteLine();
            Console.WriteLine("Type 10 to exit");
        }


        //Enters the player to the inn
        public static void EnterInn(Player _player)
        {
            string choice;

            while (true)
            {
                InnGreeting();
                choice = Console.ReadLine();


                //If player chooses to stay at the inn
                if (choice == "1")
                {
                    //If the player has enough money 
                    if (_player.gold >= GOLD_COST)
                    {
                        //Heal the player take 100 gold and exit the player from the inn
                        _player.currentHealth = _player.topHealth;
                        _player.gold -= GOLD_COST;
                        Console.Clear();
                        Console.WriteLine("You have been healed, stay safe!");
                        Console.ReadKey();
                        return;
                    }


                    //If the player does not have enough gold
                    else
                    {
                        //Do not heal the player and exit the player from the inn
                        Console.Clear();
                        Console.WriteLine("You do not have enough gold sorry we won't take you in");
                        Console.ReadKey();
                        return;
                    }
                }


                //The player exits the inn
                else if (choice == "10")
                {
                    return;
                }
                else
                {

                }
            }
        }
    }
}
