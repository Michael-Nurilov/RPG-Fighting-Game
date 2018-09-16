using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dragon_Slayer
{
    class Program
    {
        //Displays the choices the user has
        private static void Choices()
        {
            Console.Clear();
            Console.WriteLine("Press 1 to view your stats");
            Console.WriteLine("Press 2 to enter the inn");
            Console.WriteLine("Press 3 to enter the store");
            Console.WriteLine("Press 4 to enter the armory");
            Console.WriteLine("Press 5 to view your inventory");
            Console.WriteLine("Press 6 to enter the plains");
            Console.WriteLine("Press 7 to enter the river");
            Console.WriteLine("Press 8 to enter the forest");
            Console.WriteLine("Press 9 to enter the bridge");
            Console.WriteLine("Press 10 to enter the castle!");
        }


        //Displays an introductory greeting to the player
        private static string Greeting()
        {
            Console.WriteLine("Welcome to Dragon Slayer where you goal is to well, you guessed it SLAY A DRAGON!");
            Console.WriteLine("Equipped with a sword and shield you will fight many enemies, one of them is definitely a dragon.");
            Console.WriteLine("This game is rather hard and it is going to take some forethought and clever planning to win");
            Console.WriteLine("Some tips for you hero are, make sure to always upgrade your sword and shield");
            Console.WriteLine("Make sure to buy potions are they are very useful in battle");
            Console.WriteLine("Use the Inn to replenish your health in between battles");
            Console.WriteLine("Fight the same enemy a couple times to make sure you are strong enough to face your next opponent");
            Console.WriteLine("Always guard when the enemy is charging up for a special attack");
            Console.WriteLine("Never charge a special attack when the enemy is charging for a special attack");
            Console.WriteLine("If the coast is clear and your special bar is full unleash you special attack!");
            Console.WriteLine("What would you like to name your hero!");
            string name = Console.ReadLine();
            return name;
        }


        //The game
        public static void Main(string[] args)
        {
            //Sets the title bar to Dragon Slayer
            Console.Title = "Dragon Slayer";


            //Initializing player
            Player Player = new Player();


            //Sets the player name
            Player.name = Greeting();


            //Game Loop
            while (Player.currentHealth > 0 && Player.dragonAlive == true)
            {
                //Offers the player multiple choices
                Choices();
                string choice = Console.ReadLine();


                //If the player selects choice one they will see their stats
                if (choice == "1")
                {
                    Player.DisplayStats();
                }


                //If the player selects choice two they will enter the inn
                else if (choice == "2")
                {
                    Inn.EnterInn(Player);
                }


                //If the player selects choice three they will enter the store
                else if (choice == "3")
                {
                    Store.EnterStore(Player);
                }


                //If the player enters choice four they will enter the armory
                else if (choice == "4")
                {
                    Armory.EnterArmory(Player);
                }

                
                //If the player selects choice five they will see their inventory
                else if (choice == "5")
                {
                    Player.playerInventory.DisplayInventory(Player);
                }


                //If the player selects choice six they will enter a fight against a goblin in the plains
                else if (choice == "6")
                {
                    BattleSystem.EnterBattle(Player, new Enemy("Goblin", 100, 10, 2, 50, 100, 3, 6, 15), "plain");
                }

            
                //If the player selects choice seven they will enter a fight against a frog in the rivers
                else if (choice == "7")
                {
                    if (Player.plainCleared == true)
                    {
                        BattleSystem.EnterBattle(Player, new Enemy("Frog", 200, 30, 8, 200, 500, 3, 6, 10), "river");
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("You have not yet traversed through the plains");
                        Console.ReadKey();
                    }
                }


                //If the player selects choice eight they will enter a fight against a bear in the forests
                else if (choice == "8")
                {
                    if (Player.plainCleared == true && Player.riverCleared == true)
                    {
                        BattleSystem.EnterBattle(Player, new Enemy("Bear", 700, 85, 50, 500, 1000, 3, 6, 20), "forest");
                    }
                    else if (Player.plainCleared == true)
                    {
                        Console.Clear();
                        Console.WriteLine("You have not yet traversed past the river");
                        Console.ReadKey(); 
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("You have not yet traversed through the plains");
                        Console.ReadKey();
                    }
                }

            
                //If the player selects choice nine they will eneter a fight against a troll under the bridge
                else if (choice == "9")
                {
                    if (Player.plainCleared == true && Player.riverCleared == true && Player.forestCleared == true)
                    {
                        BattleSystem.EnterBattle(Player, new Enemy("Troll", 1500, 220, 50, 1500, 5000, 5, 10, 15), "bridge");

                    }
                    else if (Player.plainCleared == true && Player.riverCleared == true)
                    {
                        Console.Clear();
                        Console.WriteLine("You have not yet traversed through the forest");
                        Console.ReadKey();
                    }
                    else if (Player.plainCleared == true)
                    {
                        Console.Clear();
                        Console.WriteLine("You have not yet traversed past the river");
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("You have not yet traversed through the plains");
                        Console.ReadKey();
                    }
                }


                //The final area if the user selects choice 10 they will battle against two golems and then a dragon
                else if (choice == "10")
                {
                    string castleChoice = "";
                    if (Player.plainCleared == true && Player.riverCleared == true && Player.forestCleared == true && Player.bridgeCleared == true)
                    {
                        //Gives the player an option to proceed or go back
                        while (castleChoice != "1" && castleChoice != "2")
                        {
                            Console.Clear();
                            Console.WriteLine("You have reached the castle where the dragon resides");
                            Console.WriteLine("Once you step into the castle there is no turning back");
                            Console.WriteLine("There will most likely be many enemies for you to face");
                            Console.WriteLine("Are you sure you want to proceed?");
                            Console.WriteLine();
                            Console.WriteLine("1 to proceed");
                            Console.WriteLine("2 to go back");
                            castleChoice = Console.ReadLine();
                        }


                        //If the player chooses to proceed there is no going back
                        if (castleChoice == "1")
                        {
                            Console.Clear();
                            Console.WriteLine("You decide to enter the castle to face the dragon");
                            Console.ReadKey();


                            //Battle against first golem
                            BattleSystem.EnterBattle(Player, new Enemy("Golem", 3000, 340, 100, 3000, 1000, 3, 6, 15), "main hall", 1, 1);

                            if(Player.currentHealth <= 0)
                            {
                                break;
                            }


                            //Battle against second golem
                            BattleSystem.EnterBattle(Player, new Enemy("Golem", 3000, 340, 100, 3000, 1000, 3, 6, 15), "staircase", 1, 1);

                            if (Player.currentHealth <= 0)
                            {
                                break;
                            }


                            Console.Clear();
                            Console.WriteLine("After defeating the second golem you are able to proceed through the castle");
                            Console.ReadKey();
                            Console.WriteLine("You climb the steps and reach the top of the castle where you hear the dragon");


                            //Battle against dragon
                            BattleSystem.EnterBattle(Player, new Enemy("Dragon", 7000, 420, 220, 0, 0, 4, 7, 15), "balcony", 1, 1);

                            if (Player.currentHealth <= 0)
                            {
                                break;
                            }
                        }


                        //If the player chooses to go back he is free to wander about
                        else if (castleChoice == "2")
                        {
                            Console.Clear();
                            Console.WriteLine("You decide not to enter the castle");
                            Console.ReadKey();
                        }
                    }
                    else if (Player.plainCleared == true && Player.riverCleared == true && Player.forestCleared == true)
                    {
                        Console.Clear();
                        Console.WriteLine("You have not yet traversed past the bridge");
                        Console.ReadKey();
                    }
                    else if (Player.plainCleared == true && Player.riverCleared == true)
                    {
                        Console.Clear();
                        Console.WriteLine("You have not yet traversed through the forest");
                        Console.ReadKey();
                    }
                    else if (Player.plainCleared == true)
                    {
                        Console.Clear();
                        Console.WriteLine("You have not yet traversed past the river");
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("You have not yet traversed through the plains");
                        Console.ReadKey();
                    }
                }


                //Special command to give the player 500 exp and gold
                else if (choice == "500")
                {
                    Player.ExperienceGain(500);
                    Player.gold += 500;
                }


                //Special command to skip the player to the frog area and give the correct exp and gold
                else if (choice == "Level Frog")
                {
                    Player.ExperienceGain(300);
                    Player.gold += 400;
                    Player.plainCleared = true;
                }


                //Special command to skip the player to the bear area and give the correct exp and gold
                else if (choice == "Level Bear")
                {
                    Player.ExperienceGain(2100);
                    Player.gold += 2500;
                    Player.plainCleared = true;
                    Player.riverCleared = true;
                }


                //Special command to skip the player to the troll area and give the correct exp and gold
                else if (choice == "Level Troll")
                {
                    Player.ExperienceGain(4500);
                    Player.gold += 10000;
                    Player.plainCleared = true;
                    Player.riverCleared = true;
                    Player.forestCleared = true;
                }


                //Special command to skip the player to the dragon area and give the correct exp and gold
                else if (choice == "Level Dragon")
                {
                    Player.ExperienceGain(100000);
                    Player.gold += 100000;
                    Player.plainCleared = true;
                    Player.riverCleared = true;
                    Player.forestCleared = true;
                    Player.bridgeCleared = true;
                }


                //Gives the player 10000 gold
                else if (choice == "10000 Gold")
                {
                    Player.gold += 10000;
                }


                //Gives the player max exp and gold
                else if (choice == "100000")
                {
                    Player.ExperienceGain(100000);
                    Player.gold += 100000;
                }
                else
                {

                }
            }


            //These are the conditions for if the player has died or killed the dragon


            //If the player has died
            if (Player.currentHealth <= 0)
            {
                Console.Clear();
                Console.WriteLine("You have died in combat, Game Over!");
                Console.ReadKey();
            }


            //If the player has killed the dragon
            else if (Player.dragonAlive == false)
            {
                Console.Clear();
                Console.WriteLine("You have fought and slain many strong and powerful foes");
                Console.WriteLine("Most importantly, you have slain the dragon and saved the realm");
                Console.WriteLine("Congratulations you have won the game!");
                Console.ReadKey();
            }


            
            else
            {
                Console.Clear();
                Console.WriteLine("Error");
                Console.ReadKey();
            }
        }
    }
}
