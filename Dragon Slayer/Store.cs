using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dragon_Slayer
{
    static class Store
    {
        //Private fields
        private static Potion BasicPotion = new Potion(1, "Basic Potion", 100, 100, 10, "Restores 100 Health");
        private static Potion MegaPotion = new Potion(2, "Mega Potion", 1500, 300, 10, "Restores 300 Health");
        private static Potion GigaPotion = new Potion(3, "Giga Potion", 5000, 1000, 10, "Restores 1000 Health");
             
        private static Potion BaseBasicPotion = new Potion(1, "Basic Potion", 100, 100, 1, "Restores 100 Health");
        private static Potion BaseMegaPotion = new Potion(2, "Mega Potion", 1500, 300, 1, "Restores 300 Health");
        private static Potion BaseGigaPotion = new Potion(3, "Giga Potion", 5000, 1000, 1, "Restores 1000 Health");
               
        private static List<Item> StoreInventory = new List<Item>();
            
        private static List<Item> BaseStoreInventory = new List<Item>();
           
        private static List<Item> SortedStoreInventory = new List<Item>();


        //Constructor
        static Store()
        {
            StoreSetup();
        }


        //Sets up the store
        private static void StoreSetup()
        {
            StoreInventory.Add(BasicPotion);
            StoreInventory.Add(GigaPotion);
            StoreInventory.Add(MegaPotion);
            BaseStoreInventory.Add(BaseBasicPotion);
            BaseStoreInventory.Add(BaseMegaPotion);
            BaseStoreInventory.Add(BaseGigaPotion);
        }


        //Displays the store 
        private static void DisplayStore(Player _Player)
        {
            Console.Clear();
            SortedStoreInventory = StoreInventory.OrderBy(o => o.ID).ToList();
            Console.WriteLine("Welcome to the store {0} what would you like to buy", _Player.name);
            Console.WriteLine("{0}'s Gold: {1}", _Player.name, _Player.gold);
            Console.WriteLine();

            //Displays all the items in the store
            for (int i = 0; i < SortedStoreInventory.Count; i++)
            {
                Console.WriteLine("{0} - {1} - {2} Gold - {3} - {4}x Quantity", SortedStoreInventory.IndexOf(SortedStoreInventory[i]) + 1,
                                  SortedStoreInventory[i].name, SortedStoreInventory[i].goldValue,
                                  SortedStoreInventory[i].description, SortedStoreInventory[i].quantity);
            }
            Console.WriteLine();
            Console.WriteLine("Type 10 to Exit");
        }


        //Adds to the store
        private static void AddtoStore(Item item, Item baseItem)
        {
            StoreInventory.Add(item);
            BaseStoreInventory.Add(baseItem);
        }


        //Removes from the store
        private static void RemovefromStore(Item item)
        {
            if (item.quantity > 0)
            {
                item.quantity--;
            }
            else
            {
            }
        }


        //The item is out of stock display a message
        private static void OutOfStock()
        {
            Console.Clear();
            Console.WriteLine("We don't have any of that item left, sorry");
            Console.ReadKey();
        }

        
        //The purchase was successful
        private static void SuccessfulPurchase(Item _item)
        {
            Console.Clear();
            Console.WriteLine("You have bought {0} for {1} gold", _item.name, _item.goldValue);
            Console.ReadKey();
        }


        //The purchase was a failure
        private static void FailedPurchase()
        {
            Console.Clear();
            Console.WriteLine("You do not have enough gold to purchase this item");
            Console.ReadKey();
        }


        //Enters the player into the store
        public static void EnterStore(Player player)
        {
            while (true)
            {
                DisplayStore(player);

                string storeChoice = Console.ReadLine();

                for (int i = 0; i < SortedStoreInventory.Count; i++)
                {
                    if (storeChoice == ((SortedStoreInventory.IndexOf(SortedStoreInventory[i]) + 1).ToString()))
                    {
                        if (SortedStoreInventory[i].quantity > 0)
                        {
                            if (player.gold >= SortedStoreInventory[i].goldValue)
                            {
                                SuccessfulPurchase(BaseStoreInventory[i]);
                                player.gold -= BaseStoreInventory[i].goldValue;
                                player.playerInventory.AddtoInventory(BaseStoreInventory[i]);
                                RemovefromStore(SortedStoreInventory[i]);
                            }
                            else if (player.gold < SortedStoreInventory[i].goldValue)
                            {
                                FailedPurchase();
                            }
                            else
                            {
                                Console.WriteLine("Error");
                            }
                        }
                        else
                        {
                            OutOfStock();
                        }
                    }
                    else if (storeChoice == "10")
                    {
                        return;
                    }
                }
            }
        }
    }
}
