using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dragon_Slayer
{
    static class BattleSystem
    {
        //Checks if the player has died
        private static void CheckIfPlayerIsDead(Player player)
        {
            //If player has died, exit loop 
            if (player.currentHealth <= 0)
            {
                Console.Clear();
            }
        }


        //Update the players progression 
        private static void UpdatePlayerProgression(Player player, Enemy enemy)
        {
            switch (enemy.name)
            {
                case "Goblin":
                    player.plainCleared = true;
                    break;
                case "Frog":
                    player.riverCleared = true;
                    break;
                case "Bear":
                    player.forestCleared = true;
                    break;
                case "Troll":
                    player.bridgeCleared = true;
                    break;
            }
        }


        //Gives the player experience and gold for winning
        private static void PlayerWin(Player player, Enemy enemy)
        {
            Console.Clear();
            Console.WriteLine("You have defeated the {0} and have gained {1} experience and {2} gold",
                enemy.name, enemy.experience, enemy.gold);
            player.ExperienceGain(enemy.experience);
            player.gold += enemy.gold;
        }


        //Enters the player into battle
        public static void EnterBattle(Player player, Enemy enemy, string location, int runAwayOption = 0, int loopOption = 0)
        {
            Random choiceGen = new Random();
            int battleGen = choiceGen.Next(1, 5);


            //Set important values to 0
            int loop = loopOption;
            int runAway = runAwayOption;
            int loopCharge = 0;
            int guardCharge = 0;
            int dead = 0;
            player.specialBar = 0;

            
            //Display information
            Console.Clear();
            Console.WriteLine("You travel through the {0} when all of a sudden", location);
            Console.ReadKey();
            Console.WriteLine("A {0} attacks!", enemy.name);
            Console.ReadKey();


            while (player.currentHealth > 0 && enemy.health > 0)
            {
                if (loop == 0)
                {
                    //If this is the start of the battle display starting battle text
                    BattleText.StartBattle(player, enemy);
                    loop++;
                }
                else
                {
                    //If the battle has been going on display during battle text
                    BattleText.DuringBattle(player, enemy);
                }
                string battleChoice = Console.ReadLine();


                //If the player chooses choice 4 and is the start of the battle they can run away
                if (battleChoice == "4" && runAway == 0)
                {
                    Console.Clear();
                    Console.WriteLine("You flee the battlefield");
                    Console.ReadKey();
                    break;
                }
                else
                {
                    runAway++;
                }


                switch (battleChoice)
                {
                    //Player attack
                    case "1":
                        //Display battle text for attacking
                        BattleText.PlayerAttack(player, enemy);


                        //Execute damage on enemy
                        enemy.health -= player.DamageDone(enemy.defense);


                        //Check if enemy health is zero
                        if (enemy.health <= 0)
                        {
                            //Rewards the player for winning
                            PlayerWin(player, enemy);


                            //Depending in the enemy the user is fighting the corresponding value in player will be updated
                            UpdatePlayerProgression(player, enemy);


                            Console.ReadKey();
                            break;
                        }


                        //Check if enemy has charge attacked
                        if (loopCharge == 1)
                        {
                            player.currentHealth -= enemy.ChargeDamage(player.defense);
                            BattleText.EnemyChargeAttack(player, enemy);
                            loopCharge = 0;


                            //If player has died, exit loop 
                            if (player.currentHealth <= 0)
                            {
                                Console.Clear();
                                break;
                            }
                        }
                        

                        else
                        {
                            battleGen = choiceGen.Next(1, 5);
                            switch (battleGen)
                            {
                                case 1:
                                    player.currentHealth -= enemy.DamageDone(player.defense);
                                    BattleText.EnemyAttack(player, enemy);
                                    if (player.currentHealth <= 0)
                                    {
                                        Console.Clear();
                                        break;
                                    }
                                    break;
                                case 2:
                                    player.currentHealth -= enemy.DamageDone(player.defense);
                                    BattleText.EnemyAttack(player, enemy);
                                    if (player.currentHealth <= 0)
                                    {
                                        Console.Clear();
                                        break;
                                    }
                                    break;
                                case 3:
                                    player.currentHealth -= enemy.DamageDone(player.defense);
                                    BattleText.EnemyAttack(player, enemy);
                                    if (player.currentHealth <= 0)
                                    {
                                        Console.Clear();
                                        break;
                                    }
                                    break;
                                case 4:
                                    BattleText.EnemyCharge(player, enemy);
                                    loopCharge++;
                                    break;
                                default:
                                    Console.WriteLine("Error");
                                    break;
                            }
                        }
                        break;


                    //Player guard
                    case "2":
                        //Update player special bar
                        player.specialBar--;
                        BattleText.Guard(player, enemy);


                        //If the enemy has charged unleash the charge attack
                        if (loopCharge == 1)
                        {
                            player.currentHealth -= player.Guard(enemy.attack * 3);
                            BattleText.GuardChargedBlock(player, enemy);
                            loopCharge = 0;
                            if (player.currentHealth <= 0)
                            {
                                Console.Clear();
                                break;
                            }
                        }
                        
                       
                        else
                        {
                            battleGen = choiceGen.Next(1, 5);
                            switch (battleGen)
                            {
                                case 1:
                                    player.currentHealth -= player.Guard(enemy.attack);
                                    BattleText.GuardNormalBlock(player, enemy);
                                    if (player.currentHealth <= 0)
                                    {
                                        Console.Clear();
                                        break;
                                    }
                                    break;
                                case 2:
                                    player.currentHealth -= player.Guard(enemy.attack);
                                    BattleText.GuardNormalBlock(player, enemy);
                                    if (player.currentHealth <= 0)
                                    {
                                        Console.Clear();
                                        break;
                                    }
                                    break;
                                case 3:
                                    player.currentHealth -= player.Guard(enemy.attack);
                                    BattleText.GuardNormalBlock(player, enemy);
                                    if (player.currentHealth <= 0)
                                    {
                                        Console.Clear();
                                        break;
                                    }
                                    break;
                                case 4:
                                    BattleText.EnemyCharge(player, enemy);
                                    loopCharge++;
                                    break;
                                default:
                                    Console.WriteLine("Error");
                                    break;
                            }
                        }
                        break;


                    //Player item
                    case "3":
                        bool itemUsed = false;
                        while (true)
                        {
                            //Display player inventory
                            player.playerInventory.BattleInventory(player, enemy);
                            string inventoryChoice = Console.ReadLine();


                            //Exit the battle inventory if choice is 10
                            if (inventoryChoice == "10")
                            {
                                break;
                            }


                            //If the choice equals the item number of an inventory item then use that item
                            for (int i = 0; i < player.playerInventory.SortedPlayerBag.Count; i++)
                            {

                                if (inventoryChoice == ((player.playerInventory.SortedPlayerBag.IndexOf(player.playerInventory.SortedPlayerBag[i]) + 1).ToString()))
                                {
                                    if (player.playerInventory.SortedPlayerBag[i] is Potion)
                                    {
                                        ((Potion)player.playerInventory.SortedPlayerBag[i]).potionHeal(player, enemy);
                                        player.playerInventory.RemovefromInventory(player.playerInventory.SortedPlayerBag[i]);
                                        itemUsed = true;
                                    }
                                }
                            }


                            //If the user used an item have the enemy attack
                            if (itemUsed == true)
                            {
                                if (loopCharge == 1)
                                {
                                    player.currentHealth -= enemy.ChargeDamage(player.defense);
                                    BattleText.EnemyChargeAttack(player, enemy);
                                    loopCharge = 0;
                                    itemUsed = false;
                                    if (player.currentHealth <= 0)
                                    {
                                        Console.Clear();
                                        break;
                                    }
                                }
                                else
                                {
                                    battleGen = choiceGen.Next(1, 5);
                                    switch (battleGen)
                                    {
                                        case 1:
                                            player.currentHealth -= enemy.DamageDone(player.defense);
                                            BattleText.EnemyAttack(player, enemy);
                                            if (player.currentHealth <= 0)
                                            {
                                                Console.Clear();
                                                break;
                                            }
                                            break;
                                        case 2:
                                            player.currentHealth -= enemy.DamageDone(player.defense);
                                            BattleText.EnemyAttack(player, enemy);
                                            if (player.currentHealth <= 0)
                                            {
                                                Console.Clear();
                                                break;
                                            }
                                            break;
                                        case 3:
                                            player.currentHealth -= enemy.DamageDone(player.defense);
                                            BattleText.EnemyAttack(player, enemy);
                                            if (player.currentHealth <= 0)
                                            {
                                                Console.Clear();
                                                break;
                                            }
                                            break;
                                        case 4:
                                            BattleText.EnemyCharge(player, enemy);
                                            loopCharge++;
                                            break;
                                        default:
                                            Console.WriteLine("Error");
                                            break;
                                    }
                                    itemUsed = false;
                                    break;
                                }
                            }
                        }
                        break;


                    //Player special attack
                    case "4":
                        //If the player has the energy for a special attack start charging
                        if (player.specialBar == 4)
                        {
                            player.specialBar -= 4;
                            BattleText.PlayerSpecialAttackCharge(player, enemy);


                            //If the enemy was already charging a special attack counter the players special attack
                            if (loopCharge == 1)
                            {
                                player.currentHealth -= enemy.SpecialAttackInterruption(player.defense);
                                BattleText.PlayerSpecialAttackInterrupted(player, enemy);
                                if (player.currentHealth < 0)
                                {
                                    Console.Clear();
                                    break;
                                }
                                loopCharge--;
                                break;
                            }
                        }
                        else
                        {
                            BattleText.PlayerSpecialBarNotEnough(player, enemy);
                            break;
                        }
                        battleGen = choiceGen.Next(1, 5);
                        switch (battleGen)
                        {
                            case 1:
                                player.currentHealth -= enemy.DamageDone(player.defense);
                                BattleText.EnemyAttack(player, enemy);
                                if (player.currentHealth <= 0)
                                {
                                    Console.Clear();
                                    dead = 1;
                                    break;
                                }
                                break;
                            case 2:
                                player.currentHealth -= enemy.DamageDone(player.defense);
                                BattleText.EnemyAttack(player, enemy);
                                if (player.currentHealth <= 0)
                                {
                                    Console.Clear();
                                    dead = 1;
                                    break;
                                }
                                break;
                            case 3:
                                BattleText.EnemyGuard(player, enemy);
                                guardCharge++;
                                break;
                            case 4:
                                BattleText.EnemyCharge(player, enemy);
                                loopCharge++;
                                break;
                            default:
                                Console.WriteLine("Error");
                                break;
                        }
                        if (dead == 0)
                        {
                            if (guardCharge == 1)
                            {
                                enemy.health -= enemy.SpecialAttackGuarded(player.attack);
                                BattleText.EnemyGuardAttack(player, enemy);
                                guardCharge--;
                                if (enemy.health <= 0)
                                {
                                    //Give the player rewards for winning 
                                    PlayerWin(player, enemy);


                                    //Update the players progression
                                    UpdatePlayerProgression(player, enemy);


                                    Console.ReadKey();
                                    break;
                                }
                                battleGen = choiceGen.Next(1, 5);
                                switch (battleGen)
                                {
                                    case 1:
                                        player.currentHealth -= enemy.DamageDone(player.defense);
                                        BattleText.EnemyAttack(player, enemy);
                                        if (player.currentHealth <= 0)
                                        {
                                            Console.Clear();
                                            break;
                                        }
                                        break;
                                    case 2:
                                        player.currentHealth -= enemy.DamageDone(player.defense);
                                        BattleText.EnemyAttack(player, enemy);
                                        if (player.currentHealth <= 0)
                                        {
                                            Console.Clear();
                                            break;
                                        }
                                        break;
                                    case 3:
                                        player.currentHealth -= enemy.DamageDone(player.defense);
                                        BattleText.EnemyAttack(player, enemy);
                                        if (player.currentHealth <= 0)
                                        {
                                            Console.Clear();
                                            break;
                                        }
                                        break;
                                    case 4:
                                        BattleText.EnemyCharge(player, enemy);
                                        loopCharge++;
                                        break;
                                    default:
                                        Console.WriteLine("Error");
                                        break;
                                }
                            }
                            else if (loopCharge == 1)
                            {
                                enemy.health -= player.SpecialAttackInterrupt(enemy.defense);
                                BattleText.PlayerSpecialAttackInterrupt(player, enemy);
                                loopCharge--;
                                if (enemy.health <= 0)
                                {
                                    //Give the player rewards for winning the battle
                                    PlayerWin(player, enemy);


                                    //Update players progression
                                    UpdatePlayerProgression(player, enemy);


                                    Console.ReadKey();
                                    break;
                                }
                            }
                            else
                            {
                                enemy.health -= player.SpecialAttack(enemy.defense);
                                BattleText.PlayerSpecialAttack(player, enemy);
                                if (enemy.health <= 0)
                                {
                                    //Give the player rewards for winning
                                    PlayerWin(player, enemy);


                                    //Update the players progression
                                    UpdatePlayerProgression(player, enemy);


                                    Console.ReadKey();
                                    break;
                                }
                                battleGen = choiceGen.Next(1, 5);
                                switch (battleGen)
                                {
                                    case 1:
                                        player.currentHealth -= enemy.DamageDone(player.defense);
                                        BattleText.EnemyAttack(player, enemy);
                                        if (player.currentHealth <= 0)
                                        {
                                            Console.Clear();
                                            break;
                                        }
                                        break;
                                    case 2:
                                        player.currentHealth -= enemy.DamageDone(player.defense);
                                         BattleText.EnemyAttack(player, enemy);
                                        if (player.currentHealth <= 0)
                                        {
                                            Console.Clear();
                                            break;
                                        }
                                        break;
                                    case 3:
                                        player.currentHealth -= enemy.DamageDone(player.defense);
                                        BattleText.EnemyAttack(player, enemy);
                                        if (player.currentHealth <= 0)
                                        {
                                            Console.Clear();
                                            break;
                                        }
                                        break;
                                    case 4:
                                        BattleText.EnemyCharge(player, enemy);
                                        loopCharge++;
                                        break;
                                    default:
                                        Console.WriteLine("Error");
                                        break;
                                }
                            }
                        }

                        break;


                    default:

                        break;
                }
            }
        }    
    }
}
