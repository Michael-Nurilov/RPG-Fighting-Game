using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dragon_Slayer
{
    class Potion : Item
    {
        //Public fields
        public int healingValue;


        //Constructor
        public Potion(int _ID, string _name, int _goldValue, int _healingValue, int _quantity, string _description) : 
            base(_ID, _name, _goldValue, _quantity, _description)
        {
            healingValue = _healingValue;
        }


        //Heals the player based on the potions healing value
        public void potionHeal(Player _player, Enemy _enemy)
        {
            if (quantity > 0)
            {
                _player.currentHealth += healingValue;
                BattleText.PotionHeal(_player, _enemy, this);
            }
            else
            {

            }
        }
    }
}
