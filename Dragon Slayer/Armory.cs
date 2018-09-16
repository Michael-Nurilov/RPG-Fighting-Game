using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dragon_Slayer
{
    static class Armory
    {
        //Display armory greeting
        private static void ArmoryGreeting(Player player)
        {
            Console.Clear();
            Console.WriteLine("Welcome to the armory where you can upgrade your sword and shield!");
            Console.WriteLine("{0}'s Gold: {1}", player.name, player.gold);
            Console.WriteLine();
        }


        //Display the armory
        private static void DisplayArmory(Player player)
        {
            ArmoryGreeting(player);


            //Display the sword stats
            player.Sword.DisplaySword(player.Sword);
            if (player.Sword.level < 4)
            {
                Console.WriteLine("Cost to Upgrade: {0}", player.Sword.goldValue);
            }
            Console.WriteLine("Attack Value: {0}", player.Sword.attackValue);
            Console.WriteLine("Press 1 to Upgrade");
            Console.WriteLine();


            //Display the armor stats
            player.Armor.DisplayArmor(player.Armor);
            if (player.Armor.level < 4)
            {
                Console.WriteLine("Cost to Upgrade: {0}", player.Armor.goldValue);
            }
            Console.WriteLine("Defense Value: {0}", player.Armor.defenseValue);
            Console.WriteLine("Press 2 to Upgrade");
            Console.WriteLine();


            Console.WriteLine("Type 10 to Exit");
        }

        
        //Enters the player into the armory
        public static void EnterArmory(Player player)
        {
            while (true)
            {
                DisplayArmory(player);
                string armorychoice = Console.ReadLine();


                //If the player chooses to upgrade the sword
                if (armorychoice == "1")
                {
                    //Check if the player can afford to upgrade the sword
                    if (player.gold >= ((Sword)player.Equipment[0]).goldValue)
                    {
                        //If the player has a maxed out sword then do nothing
                        if (((Sword)player.Equipment[0]).level >= 4)
                        {
                            Console.Clear();
                            Console.WriteLine("You have upgraded the sword to the maximum level");
                            Console.ReadKey();
                        }


                        //If the player has enough money and the sword is not max level upgrade the word
                        else
                        {
                            player.swordChecker = false;
                            player.gold -= ((Sword)player.Equipment[0]).goldValue;
                            ((Sword)player.Equipment[0]).Upgrade(player, ((Sword)player.Equipment[0]));
                            player.swordChecker = true;
                            Console.Clear();
                            DisplayArmory(player);
                        }
                    }


                    //The player cannot afford to upgrade the sword
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("You do not have enough gold");
                        Console.ReadKey();
                    }
                }


                //If the player chooses to upgrade the armor
                else if (armorychoice == "2")
                {
                    //Check the player has enough money to upgrade armor
                    if (player.gold >= ((Armor)player.Equipment[1]).goldValue)
                    {
                        //If the armor is max level then do nothing
                        if (((Armor)player.Equipment[1]).level >= 4)
                        {
                            Console.Clear();
                            Console.WriteLine("You have upgraded the armor to the maximum level");
                            Console.ReadKey();
                        }


                        //If the player has enough money and the armor is not max level then upgrade the armor
                        else
                        {
                            player.armorChecker = false;
                            player.gold -= ((Armor)player.Equipment[1]).goldValue;
                            ((Armor)player.Equipment[1]).Upgrade(player, ((Armor)player.Equipment[1]));
                            player.armorChecker = true;
                            Console.Clear();
                            DisplayArmory(player);
                        }
                    }


                    //The player does not have enough gold
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("You do not have enough gold");
                        Console.ReadKey();
                    }
                }


                //Exit the armory
                else if (armorychoice == "10")
                {
                    return;
                }
            }
        }
    }
}
