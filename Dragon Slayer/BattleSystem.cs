using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dragon_Slayer
{
    static class BattleSystem
    {
        public static void EnterBattle(Player player, Enemy enemy, string location)
        {
            Random choiceGen = new Random();
            //Set important values to 0
            int loop = 0;
            int runAway = 0;
            int loopCharge = 0;
            int guardCharge = 0;
            int specialCharge = 0;
            int goback = 0;
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


                //Player attack
                if (battleChoice == "1")
                {
                    BattleText.PlayerAttack(player, enemy);
                    enemy.health -= player.DamageDone(enemy.defense);
                    if (enemy.health <= 0)
                    {
                        Console.Clear();
                        Console.WriteLine("You have defeated the {0} and have gained {1} experience and {2} gold", 
                            enemy.name, enemy.experience, enemy.gold);
                        player.ExperienceGain(enemy.experience);
                        player.gold += enemy.gold;


                        //Depending in the enemy the user is fighting the corresponding value in player will be updated
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


                        Console.ReadKey();
                        break;
                    }
                    if (loopCharge == 1)
                    {
                        player.currentHealth -= enemy.ChargeDamage(player.defense);
                        BattleText.EnemyChargeAttack(player, enemy);
                        loopCharge = 0;
                        if (player.currentHealth <= 0)
                        {
                            Console.Clear();
                            break;
                        }
                    }
                    else
                    {
                        int battleGen = choiceGen.Next(1, 5);
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


                //Player guard
                else if (battleChoice == "2")
                {
                    player.specialBar--;
                    BattleText.Guard(player, enemy);
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
                        int battleGen = choiceGen.Next(1, 5);
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
                }


                //Player item
                else if (battleChoice == "3")
                {
                    bool battleGoBack = false;
                    bool itemUsed = false;
                    while (battleGoBack == false)
                    {
                        player.playerInventory.BattleInventory(player, enemy);
                        string inventoryChoice = Console.ReadLine();
                        if (inventoryChoice == "10")
                        {
                            battleGoBack = true;
                        }
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
                                int battleGen = choiceGen.Next(1, 5);
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
                                battleGoBack = true;
                            }
                        }
                    }
                }


                //Player special attack
                else if (battleChoice == "4")
                {
                    if (player.specialBar == 4)
                    {
                        player.specialBar -= 4;
                        BattleText.PlayerSpecialAttackCharge(player, enemy);
                        specialCharge++;
                        if (loopCharge == 1)
                        {
                            player.currentHealth -= enemy.SpecialAttackInterruption(player.defense);
                            BattleText.PlayerSpecialAttackInterrupted(player, enemy);
                            specialCharge--;
                            if (player.currentHealth < 0)
                            {
                                Console.Clear();
                                break;
                            }
                            loopCharge--;
                            goback++;
                        }
                    }
                    else
                    {
                        BattleText.PlayerSpecialBarNotEnough(player, enemy);
                        goback++;
                    }
                    if (goback == 0)
                    {
                        int battleGen = choiceGen.Next(1, 5);
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
                                    Console.Clear();
                                    Console.WriteLine("You have defeated the {0} and have gained {1} experience and {2} gold", enemy.name, enemy.experience, enemy.gold);
                                    player.ExperienceGain(enemy.experience);
                                    player.gold += enemy.gold;
                                    player.plainCleared = true;
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
                                    Console.Clear();
                                    Console.WriteLine("You have defeated the {0} and have gained {1} experience and {2} gold", enemy.name, enemy.experience, enemy.gold);
                                    player.ExperienceGain(enemy.experience);
                                    player.gold += enemy.gold;
                                    player.plainCleared = true;
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
                                    Console.Clear();
                                    Console.WriteLine("You have defeated the {0} and have gained {1} experience and {2} gold", enemy.name, enemy.experience, enemy.gold);
                                    player.ExperienceGain(enemy.experience);
                                    player.gold += enemy.gold;
                                    player.plainCleared = true;
                                    Console.ReadKey();
                                    break;
                                }
                                specialCharge--;
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

                    }
                    else
                    {
                        goback--;
                    }
                }


                else
                {

                }
            }
        }    
    }
}
