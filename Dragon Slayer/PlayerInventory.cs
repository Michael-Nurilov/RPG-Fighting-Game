using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dragon_Slayer
{
    class PlayerInventory
    {
        //Public fields
        public List<Item> PlayerBag = new List<Item>();
        public List<Item> SortedPlayerBag = new List<Item>();


        //Add to inventory
        public void AddtoInventory(Item _item)
        {
            if (PlayerBag.Contains(_item) == true)
            {
                _item.quantity++;
            }
            else
            {
                PlayerBag.Add(_item);
            }
        }


        //Remove from inventory
        public void RemovefromInventory(Item _item)
        {
            if (_item.quantity > 0)
            {
                _item.quantity--;
            }
            else
            {
                PlayerBag.Remove(_item);
            }
        }


        //Display inventory in menu
        public void DisplayInventory(Player _player)
        {
            Console.Clear();

            SortedPlayerBag = PlayerBag.OrderBy(o => o.ID).ToList();

            Console.WriteLine("{0}'s Inventory:", _player.name);
            Console.WriteLine();
            for (int i = 0; i < SortedPlayerBag.Count; i++)
            {
                Console.WriteLine("{0} - {1} - {2}x", SortedPlayerBag[i].name, SortedPlayerBag[i].description,
                                  SortedPlayerBag[i].quantity);
            }
            Console.ReadLine();
        }


        //Displays battle inventory
        public void BattleInventory(Player _player, Enemy _enemy)
        {
            Console.Clear();

            SortedPlayerBag = PlayerBag.OrderBy(o => o.ID).ToList();

            Console.WriteLine("{0}'s Inventory:", _player.name);
            Console.WriteLine("{0}'s Health: {1}", _enemy.name, _enemy.health);
            Console.WriteLine("{0}'s Health: {1}", _player.name, _player.currentHealth);
            _player.DisplaySpecialBar();
            for (int i = 0; i < SortedPlayerBag.Count; i++)
            {
                Console.WriteLine("{0} - {1} - {2} - {3}x", SortedPlayerBag.IndexOf(SortedPlayerBag[i]) + 1, SortedPlayerBag[i].name,
                                  SortedPlayerBag[i].description, SortedPlayerBag[i].quantity);
            }
            Console.WriteLine();
            Console.WriteLine("Type 10 to Exit");
        }
    }
}
