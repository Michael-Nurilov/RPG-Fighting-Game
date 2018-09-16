using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dragon_Slayer
{
    class Item
    {
        //Public fields
        public int ID;
        public string name;
        public int goldValue;
        public int quantity;
        public string description;


        //Constructor
        public Item(int ID, string name, int goldValue, int quantity, string description)
        {
            this.ID = ID;
            this.name = name;
            this.goldValue = goldValue;
            this.quantity = quantity;
            this.description = description;
        }


        public void RemovefromBag(PlayerInventory _playerInventory, Item _item)
        {
            _item.quantity--;
            if (_item.quantity <= 0)
            {
                _playerInventory.PlayerBag.Remove(_item);
            }
            else
            {

            }
        }
    }
}
