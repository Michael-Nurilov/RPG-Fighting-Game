using System;
using System.Collections.Generic;
using System.Linq;

namespace _RPG_Fighting_Game
{
    class Player
    {
        public List<Item> Equipment = new List<Item>();
        Sword Sword = new Sword(4, "Sword", 0, "A weapon which augments your attack", 1, 1);
        Armor Armor = new Armor(5, "Armor", 0, "A weapon which augments your defense", 1, 1);

        public bool swordChecker = true;
        public bool armorChecker = true;

        private int _currentHealth;
        private int _topHealth;
        private int _attack;
        private int _defense;
        private int _gold;
        private int _experience;
        private int _level;
        private int expNeeded = 100;
        private int _specialBar = 0;
        public string name;

        public int currentHealth
        {
            get
            {
                return _currentHealth;
            }
            set
            {
                if (value < 0)
                {
                    _currentHealth = 0;
                }
                else if (value > _topHealth)
                {
                    _currentHealth = _topHealth;
                }
                else
                {
                    _currentHealth = value;
                }
            }
        }
        public int topHealth
        {
            get
            {
                return _topHealth;
            }
            set
            {
                if (value < 0)
                {
                    _topHealth = 0;
                }
                else if (value > 10000000)
                {
                    _topHealth = 10000000;
                }
                else
                {
                    _topHealth = value;
                }
            }
        }
        public int attack
        {
            get
            {
                return _attack;
            }
            set
            {
                if (value < 0)
                {
                    _attack = 0;
                }
                else if (value > 1500000)
                {
                    _attack = 1500000;
                }
                else
                {
                    if (swordChecker == false)
                    {
                        if (Sword.level == 0)
                        {
                            _attack = value;
                        }
                        else if (Sword.level == 1)
                        {
                            _attack = value + Sword.attackValue;
                        }
                        else if (Sword.level == 2)
                        {
                            _attack = value + Sword.attackValue - 10;
                        }
                        else if (Sword.level == 3)
                        {
                            _attack = value + Sword.attackValue - 30;
                        }
                        else if (Sword.level == 4)
                        {
                            _attack = value + Sword.attackValue - 70;
                        }
                    }
                    else
                    {
                        _attack = value;
                    }
                }
            }
        }
        public int defense
        {
            get
            {
                return _defense;
            }
            set
            {
                if (value < 0)
                {
                    _defense = 0;
                }
                else if (value > 1000000)
                {
                    _defense = 1000000;
                }
                else
                {
                    if (armorChecker == false)
                    {
                        if (Armor.level == 0)
                        {
                            _defense = value;
                        }
                        else if (Armor.level == 1)
                        {
                            _defense = value + Armor.defenseValue;
                        }
                        else if (Armor.level == 2)
                        {
                            _defense = value + Armor.defenseValue - 5;
                        }
                        else if (Armor.level == 3)
                        {
                            _defense = value + Armor.defenseValue - 15;
                        }
                        else if (Armor.level == 4)
                        {
                            _defense = value + Armor.defenseValue - 35;
                        }
                    }
                    else
                    {
                        _defense = value;
                    }
                }
            }
        }
        public int gold
        {
            get
            {
                return _gold;
            }
            set
            {
                if (value < 0)
                {
                    _gold = 0;
                }
                else
                {
                    _gold = value;
                }
            }
        }
        public int experience
        {
            get
            {
                return _experience;
            }
            set
            {
                if (value < 0)
                {
                    _experience = 0;
                }
                else
                {
                    _experience = value;
                }
            }
        }
        public int level
        {
            get
            {
                return _level;
            }
            set
            {
                if (value < 1)
                {
                    _level = 1;
                }
                else if (value > 15)
                {
                    _level = 15;
                }
                else
                {
                    _level = value;
                }
            }
        }
        public int specialBar
        {
            get
            {
                return _specialBar;
            }
            set
            {
                if (value < 0)
                {
                    _specialBar = 0;
                }
                else if (value > 4)
                {
                    _specialBar = 4;
                }
                else
                {
                    _specialBar = value;
                }
            }
        }
        public Player()
        {
            level = 1;
            experience = 0;
            topHealth = 100;
            currentHealth = 100;
            attack = 10;
            defense = 3;
            gold = 0;
        }
        public void Equip()
        {
            Equipment.Add(Sword);
            Equipment.Add(Armor);
        }
        public void DisplayArmory()
        {
            Console.Clear();
            Console.WriteLine("Welcome to the armory where you can upgrade your sword and shield!");
            Console.WriteLine("{0}'s Gold: {1}", name, gold);
            Console.WriteLine();
            Sword.DisplaySword(Sword);
            if (Sword.level < 4)
            {
                Console.WriteLine("Cost to Upgrade: {0}", Sword.goldValue);
            }
            Console.WriteLine("Attack Value: {0}", Sword.attackValue);
            Console.WriteLine("Press 1 to Upgrade");
            Console.WriteLine();
            Armor.DisplayArmor(Armor);
            if (Armor.level < 4)
            {
                Console.WriteLine("Cost to Upgrade: {0}", Armor.goldValue);
            }
            Console.WriteLine("Defense Value: {0}", Armor.defenseValue);
            Console.WriteLine("Press 2 to Upgrade");
            Console.WriteLine();
            Console.WriteLine("Type 10 to Exit");
        }
        public void DisplayStats()
        {
            Console.Clear();
            Console.WriteLine("Level:          " + level);
            Console.WriteLine("Experience:     {0}/{1}", experience, expNeeded);
            Console.WriteLine("Health:         {0}/{1}", currentHealth, topHealth);
            Console.WriteLine("Attack:         " + attack + "(+{0})", Sword.attackValue);
            Console.WriteLine("Defense:        " + defense + "(+{0})", Armor.defenseValue);
            Console.WriteLine("Gold:           " + gold);
            Console.ReadKey();
        }
        public void DisplaySpecialBar()
        {
            if (specialBar == 0)
            {
                Console.WriteLine("Special Bar: ░░░░░░░░");
            }
            else if (specialBar == 1)
            {
                Console.WriteLine("Special Bar: ██░░░░░░");
            }
            else if (specialBar == 2)
            {
                Console.WriteLine("Special Bar: ████░░░░");
            }
            else if (specialBar == 3)
            {
                Console.WriteLine("Special Bar: ██████░░");
            }
            else if (specialBar == 4)
            {
                Console.WriteLine("Special Bar: ████████");
            }
            else
            {
                Console.WriteLine("Error");
            }
        }
        public void LevelUp()
        {
            if (level >= 15)
            {
                experience = expNeeded;
            }
            else
            {
                level++;
                topHealth += (int)(Math.Pow(level, 1.3) / 0.10);
                attack += (int)(Math.Pow(level, 1.3) / 0.8);
                defense += (int)(Math.Pow(level, 1.3) / 1.5);
                currentHealth = topHealth;
                Console.WriteLine("You have leveled up!");
                Console.WriteLine("You have gained {0} health", (int)(Math.Pow(level, 1.3) / 0.10));
                Console.WriteLine("You have gained {0} attack", (int)(Math.Pow(level, 1.3) / 0.8));
                Console.WriteLine("You have gained {0} defense", (int)(Math.Pow(level, 1.3) / 1.5));
            }
        }
        public void ExperienceGain(int amount)
        {
            experience += amount;
            while (experience >= expNeeded)
            {
                LevelUp();
                experience -= expNeeded;
                expNeeded += (int)(Math.Pow(level, 1.3) / 0.06);
            }
        }
        public int Attack(int hp, int defense)
        {
            int damage = attack - defense;
            if (damage < 0)
            {
                damage = 0;
            }
            hp -= damage;
            if (hp < 0)
            {
                hp = 0;
            }
            specialBar++;
            return hp;
        }
        public int DamageDone(int defense)
        {
            int damage = attack - defense;
            if (damage < 0)
            {
                damage = 0;
            }
            return damage;
        }
        public int SpecialAttack(int defense)
        {
            int specialAttack = (attack * 5) - defense;
            if (specialAttack < 0)
            {
                specialAttack = 0;
            }
            return specialAttack;
        }
        public int SpecialAttackInterrupt(int defense)
        {
            int specialAttackInterrupt = (attack * 8) - defense;
            if (specialAttackInterrupt < 0)
            {
                specialAttackInterrupt = 0;
            }
            return specialAttackInterrupt;
        }
        public int Guard(int attack)
        {
            int GuardBlock = 0;
            GuardBlock = attack - (defense * 5);
            if (GuardBlock < 0)
            {
                GuardBlock = 0;
            }
            return GuardBlock;
        }
    }

    class Enemy
    {
        private int _health;
        private int _attack;
        private int _defense;
        private int _experience;
        private int _gold;
        private double _chargeModifier;
        private double _chargeInterruptModifier;
        private double _guardModifier;
        public string name = "Enemy";

        public int health
        {
            get
            {
                return _health;
            }
            set
            {
                if (value < 0)
                {
                    _health = 0;
                }
                else if (value > 10000000)
                {
                    _health = 10000000;
                }
                else
                {
                    _health = value;
                }
            }
        }
        public int attack
        {
            get
            {
                return _attack;
            }
            set
            {
                if (value < 0)
                {
                    _attack = 0;
                }
                else if (value > 1500000)
                {
                    _attack = 1500000;
                }
                else
                {
                    _attack = value;
                }
            }
        }
        public int defense
        {
            get
            {
                return _defense;
            }
            set
            {
                if (value < 0)
                {
                    _defense = 0;
                }
                else if (value > 1000000)
                {
                    _defense = 1000000;
                }
                else
                {
                    _defense = value;
                }
            }
        }
        public int experience
        {
            get
            {
                return _experience;
            }
            set
            {
                if (value < 0)
                {
                    _experience = 0;
                }
                else
                {
                    _experience = value;
                }
            }
        }
        public int gold
        {
            get
            {
                return _gold;
            }
            set
            {
                if (value < 0)
                {
                    _gold = 0;
                }
                else
                {
                    _gold = value;
                }
            }
        }
        public double chargeModifier
        {
            get
            {
                return _chargeModifier;
            }
            set
            {
                _chargeModifier = value;
            }
        }
        public double chargeInterruptModifier
        {
            get
            {
                return _chargeInterruptModifier;
            }
            set
            {
                _chargeInterruptModifier = value;
            }
        }
        public double guardModifier
        {
            get
            {
                return _guardModifier;
            }
            set
            {
                _guardModifier = value;
            }
        }
        public int Attack(int hp, int defense)
        {
            int damage = attack - defense;
            if (damage < 0)
            {
                damage = 0;
            }
            hp -= damage;
            if (hp < 0)
            {
                hp = 0;
            }
            return hp;
        }
        public int DamageDone(int defense)
        {
            int damage = attack - defense;
            if (damage < 0)
            {
                damage = 0;
            }
            return damage;
        }
        public int ChargeAttack(int hp, int defense)
        {
            int chargeAttack = 0;
            chargeAttack = (int)(attack * chargeModifier);

            int damage = chargeAttack - defense;
            if (damage < 0)
            {
                damage = 0;
            }
            hp -= damage;
            if (hp < 0)
            {
                hp = 0;
            }
            return hp;
        }
        public int ChargeDamage(int defense)
        {
            int chargeDamage = 0;
            chargeDamage = (int)(attack * chargeModifier);

            int damage = chargeDamage - defense;
            if (damage < 0)
            {
                damage = 0;
            }
            return damage;
        }
        public int SpecialAttackInterruption(int defense)
        {
            int specialAttackInterruption = (int)(attack * chargeInterruptModifier) - defense;

            if (specialAttackInterruption < 0)
            {
                specialAttackInterruption = 0;
            }
            return specialAttackInterruption;
        }
        public int SpecialAttackGuarded(int attack)
        {
            int specialAttackGuarded;

            specialAttackGuarded = (attack * 5) - (int)(defense * guardModifier);

            if (specialAttackGuarded <= 0)
            {
                specialAttackGuarded = 0;        
            }
            return specialAttackGuarded;
        }

    }

    class Goblin : Enemy
    {
        public Goblin()
        {
            name = "Goblin";
            health = 100;
            attack = 10;
            defense = 2;
            experience = 50;
            gold = 100;
            chargeModifier = 3;
            chargeInterruptModifier = 6;
            guardModifier = 15;
        }
    }

    class Frog : Enemy
    {
        public Frog()
        {
            name = "Frog";
            health = 200;
            attack = 30;
            defense = 8;
            experience = 200;
            gold = 500;
            chargeModifier = 3;
            chargeInterruptModifier = 6;
            guardModifier = 10;
        }
    }

    class Bear : Enemy
    {
        public Bear()
        {
            name = "Bear";
            health = 700;
            attack = 90;
            defense = 50;
            experience = 500;
            gold = 1000;
            chargeModifier = 3;
            chargeInterruptModifier = 6;
            guardModifier = 20;
        }
    }

    class Troll : Enemy
    {
        public Troll()
        {
            name = "Troll";
            health = 1500;
            attack = 230;
            defense = 50;
            experience = 1500;
            gold = 5000;
            chargeModifier = 5;
            chargeInterruptModifier = 10;
            guardModifier = 15;
        }
    }

    class Golem : Enemy
    {
        public Golem()
        {
            name = "Golem";
            health = 3000;
            attack = 350;
            defense = 100;
            experience = 3000;
            gold = 1000;
            chargeModifier = 3;
            chargeInterruptModifier = 6;
            guardModifier = 15;
        }
    }

    class Dragon : Enemy
    {
        public Dragon()
        {
            name = "Dragon";
            health = 7000;
            attack = 430;
            defense = 230;
            experience = 0;
            gold = 0;
            chargeModifier = 4;
            chargeInterruptModifier = 7;
            guardModifier = 15;
        }
    }

    class Item
    {
        public int ID;
        public string name;
        public int goldValue;
        public int quantity;
        public string description;

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

    class Potion : Item
    {
        public int healingValue;

        public Potion(int _ID, string _name, int _goldValue, int _healingValue, int _quantity, string _description)
        {
            ID = _ID;
            name = _name;
            goldValue = _goldValue;
            healingValue = _healingValue;
            quantity = _quantity;
            description = _description;
        }
        public void potionHeal(Player _player, Potion _potion, Battle _battle, Enemy _enemy, PlayerInventory _playerInventory)
        {
            if (_potion.quantity > 0)
            {
                _player.currentHealth += _potion.healingValue;
                _potion.RemovefromBag(_playerInventory, _potion);
                _battle.PotionHeal(_player, _enemy, _potion);
            }
            else
            {

            }
        }
    }

    class Sword : Item
    {
        private int _level;

        public int level
        {
            get
            {
                return _level;
            }
            set
            {
                if (value < 0)
                {
                    _level = 0;
                }
                else if (value > 4)
                {
                    _level = 4;
                }
                else
                {
                    _level = value;
                }
            }
        }
        private int _attackValue;

        public int attackValue
        {
            get
            {
                return _attackValue;
            }
            set
            {
                if (level == 0)
                {
                    _attackValue = 0;
                }
                else if (level == 1)
                {
                    _attackValue = 10;
                }
                else if (level == 2)
                {
                    _attackValue = 30;
                }
                else if (level == 3)
                {
                    _attackValue = 70;
                }
                else if (level == 4)
                {
                    _attackValue = 150;
                }
            }
        }

        private int _goldValue;

        new public int goldValue
        {
            get
            {
                return _goldValue;
            }
            set
            {
                if (level == 0)
                {
                    _goldValue = 200;
                }
                else if (level == 1)
                {
                    _goldValue = 1000;
                }
                else if (level == 2)
                {
                    _goldValue = 2500;
                }
                else if (level == 3)
                {
                    _goldValue = 10000;
                }
            }
        }

        public Sword(int _ID, string _name, int _level, string _description, int _AttackValue, int _goldValue)
        {
            ID = _ID;
            name = _name;
            description = _description;
            level = _level;
            attackValue = _AttackValue;
            goldValue = _goldValue;
        }
        public void DisplaySword(Sword _sword)
        {
            if (_sword.level == 0)
            {
                Console.WriteLine("Sword Level: ░ ░ ░ ░");
            }
            else if (_sword.level == 1)
            {
                Console.WriteLine("Sword Level: █ ░ ░ ░");
            }
            else if (_sword.level == 2)
            {
                Console.WriteLine("Sword Level: █ █ ░ ░");
            }
            else if (_sword.level == 3)
            {
                Console.WriteLine("Sword Level: █ █ █ ░");
            }
            else if (_sword.level == 4)
            {
                Console.WriteLine("Sword Level: █ █ █ █");
            }
        }
        public void Upgrade(Player _player, Sword _sword)
        {
            _sword.level++;
            _sword.attackValue++;
            _sword.goldValue++;
            _player.attack += 0;
        }
    }

    class Armor : Item
    {
        private int _level;

        public int level
        {
            get
            {
                return _level;
            }
            set
            {
                if (value < 0)
                {
                    _level = 0;
                }
                else if (value > 4)
                {
                    _level = 4;
                }
                else
                {
                    _level = value;
                }
            }
        }
        private int _defenseValue;

        public int defenseValue
        {
            get
            {
                return _defenseValue;
            }
            set
            {
                if (level == 0)
                {
                    _defenseValue = 0;
                }
                else if (level == 1)
                {
                    _defenseValue = 5;
                }
                else if (level == 2)
                {
                    _defenseValue = 15;
                }
                else if (level == 3)
                {
                    _defenseValue = 35;
                }
                else if (level == 4)
                {
                    _defenseValue = 75;
                }
            }
        }

        private int _goldValue;

        new public int goldValue
        {
            get
            {
                return _goldValue;
            }
            set
            {
                if (level == 0)
                {
                    _goldValue = 200;
                }
                else if (level == 1)
                {
                    _goldValue = 1000;
                }
                else if (level == 2)
                {
                    _goldValue = 2500;
                }
                else if (level == 3)
                {
                    _goldValue = 10000;
                }
            }
        }

        public Armor(int _ID, string _name, int _level, string _description, int _DefenseValue, int _goldValue)
        {
            ID = _ID;
            name = _name;
            description = _description;
            level = _level;
            defenseValue = _DefenseValue;
            goldValue = _goldValue;
        }
        public void DisplayArmor(Armor _armor)
        {
            if (_armor.level == 0)
            {
                Console.WriteLine("Armor Level: ░ ░ ░ ░");
            }
            else if (_armor.level == 1)
            {
                Console.WriteLine("Armor Level: █ ░ ░ ░");
            }
            else if (_armor.level == 2)
            {
                Console.WriteLine("Armor Level: █ █ ░ ░");
            }
            else if (_armor.level == 3)
            {
                Console.WriteLine("Armor Level: █ █ █ ░");
            }
            else if (_armor.level == 4)
            {
                Console.WriteLine("Armor Level: █ █ █ █");
            }
        }
        public void Upgrade(Player _player, Armor _armor)
        {
            _armor.level++;
            _armor.defenseValue++;
            _armor.goldValue++;
            _player.defense += 0;
        }
    }

    class Store
    {
        public Potion BasicPotion = new Potion(1, "Basic Potion", 100, 100, 10, "Restores 100 Health");
        public Potion MegaPotion = new Potion(2, "Mega Potion", 1500, 300, 10, "Restores 300 Health");
        public Potion GigaPotion = new Potion(3, "Giga Potion", 5000, 1000, 10, "Restores 1000 Health");

        public Potion BaseBasicPotion = new Potion(1, "Basic Potion", 100, 100, 1, "Restores 100 Health");
        public Potion BaseMegaPotion = new Potion(2, "Mega Potion", 1500, 300, 1, "Restores 300 Health");
        public Potion BaseGigaPotion = new Potion(3, "Giga Potion", 5000, 1000, 1, "Restores 1000 Health");

        public List<Item> StoreInventory = new List<Item>();

        public List<Item> BaseStoreInventory = new List<Item>();

        public List<Item> SortedStoreInventory = new List<Item>();

        public void StoreSetup()
        {
            StoreInventory.Add(BasicPotion);
            StoreInventory.Add(GigaPotion);
            StoreInventory.Add(MegaPotion);
            BaseStoreInventory.Add(BaseBasicPotion);
            BaseStoreInventory.Add(BaseMegaPotion);
            BaseStoreInventory.Add(BaseGigaPotion);
        }
        public void DisplayStore(Player _Player)
        {
            Console.Clear();
            SortedStoreInventory = StoreInventory.OrderBy(o => o.ID).ToList();
            Console.WriteLine("Welcome to the store {0} what would you like to buy", _Player.name);
            Console.WriteLine("{0}'s Gold: {1}", _Player.name, _Player.gold);
            Console.WriteLine();
            for (int i = 0; i < SortedStoreInventory.Count; i++)
            {
                Console.WriteLine("{0} - {1} - {2} Gold - {3} - {4}x Quantity", SortedStoreInventory.IndexOf(SortedStoreInventory[i]) + 1,
                                  SortedStoreInventory[i].name, SortedStoreInventory[i].goldValue,
                                  SortedStoreInventory[i].description, SortedStoreInventory[i].quantity);
            }
            Console.WriteLine();
            Console.WriteLine("Type 10 to Exit");
        }
        public void AddtoStore(Item item, Item baseItem)
        {
            StoreInventory.Add(item);
            BaseStoreInventory.Add(baseItem);
        }
        public void RemovefromStore(Item item)
        {
            if (item.quantity > 0)
            {
                item.quantity--;
            }
            else
            {
            }
        }
        public void RemovefromList(Item item, Item baseItem)
        {
            StoreInventory.Remove(item);
            BaseStoreInventory.Remove(baseItem);
        }
        public void OutOfStock()
        {
            Console.Clear();
            Console.WriteLine("We don't have any of that item left, sorry");
            Console.ReadKey();
        }
    }

    class PlayerInventory
    {
        public List<Item> PlayerBag = new List<Item>();
        public List<Item> SortedPlayerBag = new List<Item>();

        public void DisplayItems(Player _player)
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
        public void AddtoInventory(Player _player, Item _item)
        {
            _player.gold -= _item.goldValue;
            if (PlayerBag.Contains(_item) == true)
            {
                _item.quantity++;
            }
            else
            {
                PlayerBag.Add(_item);
            }
        }
        public void RemovefromInventory(Player _player, Item _item)
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
        public void SuccessfulPurchase(Item _item)
        {
            Console.Clear();
            Console.WriteLine("You have bought {0} for {1} gold", _item.name, _item.goldValue);
            Console.ReadKey();
        }
        public void FailedPurchase()
        {
            Console.Clear();
            Console.WriteLine("You do not have enough gold to purchase this item");
            Console.ReadKey();
        }
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

    class Inn
    {
        public int goldCost = 100;

        public void InnGreeting(Player _player)
        {
            string choice;
      
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Welcome to the inn would you like to heal your wounds?");
                Console.WriteLine("All it will cost is {0} gold", goldCost);
                Console.WriteLine();
                Console.WriteLine("Press 1 to stay at the inn");
                Console.WriteLine();
                Console.WriteLine("Type 10 to exit");
                choice = Console.ReadLine();

                if (choice == "1")
                {
                    if (_player.gold >= goldCost)
                    {
                        _player.currentHealth = _player.topHealth;
                        _player.gold -= goldCost;
                        Console.Clear();
                        Console.WriteLine("You have been healed, stay safe!");
                        Console.ReadKey();
                        break;
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("You do not have enough gold sorry we won't take you in");
                        Console.ReadKey();
                        break;
                    }
                }
                else if (choice == "10")
                {
                    break;
                }
                else
                {
                    
                }
            }
        }
    }

    class Battle
    {
        public void StartBattle(Player _player, Enemy _enemy)
        {
            Console.Clear();
            Console.WriteLine("You have encountered a {0}, what will you do?", _enemy.name);
            Console.WriteLine("{0}'s Health: {1}", _enemy.name, _enemy.health);
            Console.WriteLine("{0}'s Health: {1}", _player.name, _player.currentHealth);
            _player.DisplaySpecialBar();
            Console.WriteLine("1 to Attack                          2 to Guard");
            Console.WriteLine("3 to use an Item                     4 to Run");
        }
        public void StartCastleBattle(Player _player, Enemy _enemy)
        {
            Console.Clear();
            Console.WriteLine("You have encountered a {0}, what will you do?", _enemy.name);
            Console.WriteLine("{0}'s Health: {1}", _enemy.name, _enemy.health);
            Console.WriteLine("{0}'s Health: {1}", _player.name, _player.currentHealth);
            _player.DisplaySpecialBar();
            Console.WriteLine("1 to Attack                          2 to Guard");
            Console.WriteLine("3 to use an Item                     4 to Charge a Special Attack");
        }
        public void DuringBattle(Player _player, Enemy _enemy)
        {
            Console.Clear();
            Console.WriteLine("What is your next move?");
            Console.WriteLine("{0}'s Health: {1}", _enemy.name, _enemy.health);
            Console.WriteLine("{0}'s Health: {1}", _player.name, _player.currentHealth);
            _player.DisplaySpecialBar();
            Console.WriteLine("1 to Attack                          2 to Guard");
            Console.WriteLine("3 to use an Item                     4 to Charge a Special Attack");
        }
        public void PlayerAttack(Player _player, Enemy _enemy)
        {
            Console.Clear();
            Console.WriteLine("{0} strikes the {1} for {2} damage", _player.name, _enemy.name, _player.DamageDone(_enemy.defense));
            Console.WriteLine("{0}'s Health: {1}", _enemy.name, _player.Attack(_enemy.health, _enemy.defense));
            Console.WriteLine("{0}'s Health: {1}", _player.name, _player.currentHealth);
            _player.DisplaySpecialBar();
            _enemy.health -= _player.DamageDone(_enemy.defense);
            Console.ReadKey();
        }
        public void PlayerSpecialAttackCharge(Player _player, Enemy _enemy)
        {
            Console.Clear();
            Console.WriteLine("{0} begins charging for a special attack", _player.name);
            Console.WriteLine("{0}'s Health: {1}", _enemy.name, _enemy.health);
            Console.WriteLine("{0}'s Health: {1}", _player.name, _player.currentHealth);
            _player.specialBar -= 4;
            _player.DisplaySpecialBar();
            Console.ReadKey();
        }
        public void PlayerSpecialBarNotEnough(Player _player, Enemy _enemy)
        {
            Console.Clear();
            Console.WriteLine("{0} does not have enough special power built up", _player.name);
            Console.WriteLine("{0}'s Health: {1}", _enemy.name, _enemy.health);
            Console.WriteLine("{0}'s Health: {1}", _player.name, _player.currentHealth);
            _player.DisplaySpecialBar();
            Console.ReadKey();
        }
        public void PlayerSpecialAttackInterrupted(Player _player, Enemy _enemy)
        {
            _player.currentHealth -= _enemy.SpecialAttackInterruption(_player.defense);
            Console.Clear();
            Console.WriteLine("The {0} unleashes a massive attack on an unprepared {1} and deals {2} damage", _enemy.name, _player.name, _enemy.SpecialAttackInterruption(_player.defense));
            Console.WriteLine("{0}'s Health: {1}", _enemy.name, _enemy.health);
            Console.WriteLine("{0}'s Health: {1}", _player.name, _player.currentHealth);
            _player.DisplaySpecialBar();
            Console.ReadKey();
        }
        public void PlayerSpecialAttack(Player _player, Enemy _enemy)
        {
            _enemy.health -= _player.SpecialAttack(_enemy.defense);
            Console.Clear();
            Console.WriteLine("{0} unleashes a charged special power and strikes the {1} for {2} damage", _player.name, _enemy.name, _player.SpecialAttack(_enemy.defense));
            Console.WriteLine("{0}'s Health: {1}", _enemy.name, _enemy.health);
            Console.WriteLine("{0}'s Health: {1}", _player.name, _player.currentHealth);
            _player.DisplaySpecialBar();
            Console.ReadKey();
        }
        public void PlayerSpecialAttackInterrupt(Player _player, Enemy _enemy)
        {
            _enemy.health -= _player.SpecialAttackInterrupt(_enemy.defense);
            Console.Clear();
            Console.WriteLine("{0} unleashes a charged special power on an unprepared {1} and deals {2} damage", _player.name, _enemy.name, _player.SpecialAttackInterrupt(_enemy.defense));
            Console.WriteLine("{0}'s Health: {1}", _enemy.name, _enemy.health);
            Console.WriteLine("{0}'s Health: {1}", _player.name, _player.currentHealth);
            _player.DisplaySpecialBar();
            Console.ReadKey();
        }
        public void EnemyAttack(Player _player, Enemy _enemy)
        {
            _player.currentHealth -= _enemy.DamageDone(_player.defense);
            Console.Clear();
            Console.WriteLine("The {0} strikes {1} for {2} damage", _enemy.name, _player.name, _enemy.DamageDone(_player.defense));
            Console.WriteLine("{0}'s Health: {1}", _enemy.name, _enemy.health);
            Console.WriteLine("{0}'s Health: {1}", _player.name, _player.currentHealth);
            _player.DisplaySpecialBar();
            Console.ReadKey();
        }
        public void EnemyCharge(Player _player, Enemy _enemy)
        {
            Console.Clear();
            Console.WriteLine("The {0} is charging up for a massive attack", _enemy.name);
            Console.WriteLine("{0}'s Health: {1}", _enemy.name, _enemy.health);
            Console.WriteLine("{0}'s Health: {1}", _player.name, _player.currentHealth);
            _player.DisplaySpecialBar();
            Console.ReadKey();
        }
        public void EnemyChargeAttack(Player _player, Enemy _enemy)
        {
            _player.currentHealth -= _enemy.ChargeDamage(_player.defense);
            Console.Clear();
            Console.WriteLine("The {0} unleashes a stored energy and strikes {1} for {2} damage", _enemy.name, _player.name, _enemy.ChargeDamage(_player.defense));
            Console.WriteLine("{0}'s Health: {1}", _enemy.name, _enemy.health);
            Console.WriteLine("{0}'s Health: {1}", _player.name, _player.currentHealth);
            _player.DisplaySpecialBar();
            Console.ReadKey();
        }
        public void Guard(Player _player, Enemy _enemy)
        {
            Console.Clear();
            Console.WriteLine("{0} puts up a shield and prepares for an incoming attack", _player.name);
            Console.WriteLine("{0}'s Health: {1}", _enemy.name, _enemy.health);
            Console.WriteLine("{0}'s Health: {1}", _player.name, _player.currentHealth);
            _player.specialBar--;
            _player.DisplaySpecialBar();
            Console.ReadKey();
        }
        public void GuardNormalBlock(Player _player, Enemy _enemy)
        {
            _player.currentHealth -= _player.Guard(_enemy.attack);
            Console.Clear();
            Console.WriteLine("{0} guards against the {1}'s attack and takes {2} damage", _player.name, _enemy.name, _player.Guard(_enemy.attack));
            Console.WriteLine("{0}'s Health: {1}", _enemy.name, _enemy.health);
            Console.WriteLine("{0}'s Health: {1}", _player.name, _player.currentHealth);
            _player.DisplaySpecialBar();
            Console.ReadKey();
        }
        public void GuardChargedBlock(Player _player, Enemy _enemy)
        {
            _player.currentHealth -= _player.Guard(_enemy.attack * 3);
            Console.Clear();
            Console.WriteLine("{0} guards against the {1}'s charged attack and takes {2} damage", _player.name, _enemy.name, _player.Guard(_enemy.attack * 3));
            Console.WriteLine("{0}'s Health: {1}", _enemy.name, _enemy.health);
            Console.WriteLine("{0}'s Health: {1}", _player.name, _player.currentHealth);
            _player.DisplaySpecialBar();
            Console.ReadKey();
        }
        public void EnemyGuard(Player _player, Enemy _enemy)
        {
            Console.Clear();
            Console.WriteLine("The {0} takes a defense stance and prepares for your incoming attack", _enemy.name);
            Console.WriteLine("{0}'s Health: {1}", _enemy.name, _enemy.health);
            Console.WriteLine("{0}'s Health: {1}", _player.name, _player.currentHealth);
            _player.DisplaySpecialBar();
            Console.ReadKey();
        }
        public void EnemyGuardAttack(Player _player, Enemy _enemy)
        {
            _enemy.health -= _enemy.SpecialAttackGuarded(_player.attack);
            Console.Clear();
            Console.WriteLine("{0} unleashes a special attack on the prepared {1} and deals {2} damage", _player.name, _enemy.name, _enemy.SpecialAttackGuarded(_player.attack));
            Console.WriteLine("{0}'s Health: {1}", _enemy.name, _enemy.health);
            Console.WriteLine("{0}'s Health: {1}", _player.name, _player.currentHealth);
            _player.DisplaySpecialBar();
            Console.ReadKey();
        }
        public void PotionHeal(Player _player, Enemy _enemy, Potion _potion)
        {
            Console.Clear();
            Console.WriteLine("{0} drinks a {1} and gains {2} health", _player.name, _potion.name, _potion.healingValue);
            Console.WriteLine("{0}'s Health: {1}", _enemy.name, _enemy.health);
            Console.WriteLine("{0}'s Health: {1}", _player.name, _player.currentHealth);
            _player.DisplaySpecialBar();
            Console.ReadKey();
        }
    }

    class MainClass
    {
        public static void Choices()
        {
            Console.Clear();
            Console.WriteLine("Press 1 to view your stats");
            Console.WriteLine("Press 2 to heal");
            Console.WriteLine("Press 3 to view the store");
            Console.WriteLine("Press 4 to view the armory");
            Console.WriteLine("Press 5 to view your inventory");
            Console.WriteLine("Press 6 to enter the plains");
            Console.WriteLine("Press 7 to enter the river");
            Console.WriteLine("Press 8 to enter the forest");
            Console.WriteLine("Press 9 to enter the bridge");
            Console.WriteLine("Press 10 to enter the castle!");
        }
        public static string Greeting()
        {
            Console.WriteLine("Welcome to the RPG fighting game your goal is to slay the evil dragon!");
            Console.WriteLine("Equipped with a sword and shield you will fight many enemies.");
            Console.WriteLine("What would you like to name your hero!");
            string name = Console.ReadLine();
            return name;
        }
        public static void Main(string[] args)
        {
            Console.Title = "RPG Fighting Game";

            Player Player = new Player();
            Battle Battle = new Battle();
            Store Store = new Store();
            PlayerInventory PlayerInventory = new PlayerInventory();
            Inn Inn = new Inn();
            Random choiceGen = new Random();
            bool dragonAlive = true;
            bool plainCleared = false;
            bool riverCleared = false;
            bool forestCleared = false;
            bool bridgeCleared = false;

            Player.Equip();

            Store.StoreSetup();

            Player.name = Greeting();

            while (Player.currentHealth > 0 && dragonAlive == true)
            {
                Choices();
                string choice = Console.ReadLine();
                if (choice == "1")
                {
                    Player.DisplayStats();
                }
                else if (choice == "2")
                {
                    Inn.InnGreeting(Player);
                }
                else if (choice == "3")
                {
                    bool goback = false;
                    while (goback == false)
                    {
                        Store.DisplayStore(Player);
                        string storeChoice = Console.ReadLine();
                        for (int i = 0; i < Store.SortedStoreInventory.Count; i++)
                        {
                            if (storeChoice == ((Store.SortedStoreInventory.IndexOf(Store.SortedStoreInventory[i]) + 1).ToString()))
                            {
                                if (Store.SortedStoreInventory[i].quantity > 0)
                                {
                                    if (Player.gold >= Store.SortedStoreInventory[i].goldValue)
                                    {
                                        PlayerInventory.SuccessfulPurchase(Store.BaseStoreInventory[i]);
                                        PlayerInventory.AddtoInventory(Player, Store.BaseStoreInventory[i]);
                                        Store.RemovefromStore(Store.SortedStoreInventory[i]);
                                    }
                                    else if (Player.gold < Store.SortedStoreInventory[i].goldValue)
                                    {
                                        PlayerInventory.FailedPurchase();
                                    }
                                    else
                                    {
                                        Console.WriteLine("Error");
                                    }
                                }
                                else
                                {
                                    Store.OutOfStock();
                                }
                            }
                            else if (storeChoice == "10")
                            {
                                goback = true;
                            }
                        }
                    }
                }
                else if (choice == "4")
                {
                    bool armorygoback = false;
                    while (armorygoback == false)
                    {
                        Player.DisplayArmory();
                        string armorychoice = Console.ReadLine();

                        if (armorychoice == "1")
                        {
                            if (Player.gold >= ((Sword)Player.Equipment[0]).goldValue)
                            {
                                if (((Sword)Player.Equipment[0]).level >= 4)
                                {
                                    Console.Clear();
                                    Console.WriteLine("You have upgraded the sword to the maximum level");
                                    Console.ReadKey();
                                }
                                else
                                {
                                    Player.swordChecker = false;
                                    Player.gold -= ((Sword)Player.Equipment[0]).goldValue;
                                    ((Sword)Player.Equipment[0]).Upgrade(Player, ((Sword)Player.Equipment[0]));
                                    Player.swordChecker = true;
                                    Console.Clear();
                                    Player.DisplayArmory();
                                }
                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine("You do not have enough gold");
                                Console.ReadKey();
                            }
                        }
                        else if (armorychoice == "2")
                        {
                            if (Player.gold >= ((Armor)Player.Equipment[1]).goldValue)
                            {
                                if (((Armor)Player.Equipment[1]).level >= 4)
                                {
                                    Console.Clear();
                                    Console.WriteLine("You have upgraded the armor to the maximum level");
                                    Console.ReadKey();
                                }
                                else
                                {
                                    Player.armorChecker = false;
                                    Player.gold -= ((Armor)Player.Equipment[1]).goldValue;
                                    ((Armor)Player.Equipment[1]).Upgrade(Player, ((Armor)Player.Equipment[1]));
                                    Player.armorChecker = true;
                                    Console.Clear();
                                    Player.DisplayArmory();
                                }
                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine("You do not have enough gold");
                                Console.ReadKey();
                            }
                        }
                        else if (armorychoice == "10")
                        {
                            armorygoback = true;
                        }
                    }
                }
                else if (choice == "5")
                {
                    PlayerInventory.DisplayItems(Player);
                }
                else if (choice == "6")
                {
                    Goblin Goblin = new Goblin();
                    int loop = 0;
                    int runAway = 0;
                    int loopCharge = 0;
                    int guardCharge = 0;
                    int specialCharge = 0;
                    int goback = 0;
                    int dead = 0;
                    Player.specialBar = 0;
                    Console.Clear();
                    Console.WriteLine("You travel through the plains when all of a sudden");
                    Console.ReadKey();
                    Console.WriteLine("A goblin attacks!");
                    Console.ReadKey();
                    while (Player.currentHealth > 0 && Goblin.health > 0)
                    {
                        if (loop == 0)
                        {
                            Battle.StartBattle(Player, Goblin);
                            loop++;
                        }
                        else
                        {
                            Battle.DuringBattle(Player, Goblin);
                        }
                        string battleChoice = Console.ReadLine();
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
                        if (battleChoice == "1")
                        {
                            Battle.PlayerAttack(Player, Goblin);
                            if (Goblin.health <= 0)
                            {
                                Console.Clear();
                                Console.WriteLine("You have defeated the {0} and have gained {1} experience and {2} gold", Goblin.name, Goblin.experience, Goblin.gold);
                                Player.ExperienceGain(Goblin.experience);
                                Player.gold += Goblin.gold;
                                plainCleared = true;
                                Console.ReadKey();
                                break;
                            }
                            if (loopCharge == 1)
                            {
                                Battle.EnemyChargeAttack(Player, Goblin);
                                loopCharge = 0;
                                if (Player.currentHealth <= 0)
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
                                        Battle.EnemyAttack(Player, Goblin);
                                        if (Player.currentHealth <= 0)
                                        {
                                            Console.Clear();
                                            break;
                                        }
                                        break;
                                    case 2:
                                        Battle.EnemyAttack(Player, Goblin);
                                        if (Player.currentHealth <= 0)
                                        {
                                            Console.Clear();
                                            break;
                                        }
                                        break;
                                    case 3:
                                        Battle.EnemyAttack(Player, Goblin);
                                        if (Player.currentHealth <= 0)
                                        {
                                            Console.Clear();
                                            break;
                                        }
                                        break;
                                    case 4:
                                        Battle.EnemyCharge(Player, Goblin);
                                        loopCharge++;
                                        break;
                                    default:
                                        Console.WriteLine("Error");
                                        break;
                                }
                            }
                        }
                        else if (battleChoice == "2")
                        {
                            Battle.Guard(Player, Goblin);
                            if (loopCharge == 1)
                            {
                                Battle.GuardChargedBlock(Player, Goblin);
                                loopCharge = 0;
                                if (Player.currentHealth <= 0)
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
                                        Battle.GuardNormalBlock(Player, Goblin);
                                        if (Player.currentHealth <= 0)
                                        {
                                            Console.Clear();
                                            break;
                                        }
                                        break;
                                    case 2:
                                        Battle.GuardNormalBlock(Player, Goblin);
                                        if (Player.currentHealth <= 0)
                                        {
                                            Console.Clear();
                                            break;
                                        }
                                        break;
                                    case 3:
                                        Battle.GuardNormalBlock(Player, Goblin);
                                        if (Player.currentHealth <= 0)
                                        {
                                            Console.Clear();
                                            break;
                                        }
                                        break;
                                    case 4:
                                        Battle.EnemyCharge(Player, Goblin);
                                        loopCharge++;
                                        break;
                                    default:
                                        Console.WriteLine("Error");
                                        break;
                                }
                            }
                        }
                        else if (battleChoice == "3")
                        {
                            bool battleGoBack = false;
                            bool itemUsed = false;
                            while (battleGoBack == false)
                            {
                                PlayerInventory.BattleInventory(Player, Goblin);
                                string inventoryChoice = Console.ReadLine();
                                if (inventoryChoice == "10")
                                {
                                    battleGoBack = true;
                                }
                                for (int i = 0; i < PlayerInventory.SortedPlayerBag.Count; i++)
                                {

                                    if (inventoryChoice == ((PlayerInventory.SortedPlayerBag.IndexOf(PlayerInventory.SortedPlayerBag[i]) + 1).ToString()))
                                    {
                                        if (PlayerInventory.SortedPlayerBag[i] is Potion)
                                        {
                                            ((Potion)PlayerInventory.SortedPlayerBag[i]).potionHeal(Player,
                                                                                                    ((Potion)PlayerInventory.SortedPlayerBag[i]),
                                                                                                    Battle, Goblin, PlayerInventory);
                                            itemUsed = true;
                                        }
                                    }
                                }
                                if (itemUsed == true)
                                {
                                    if (loopCharge == 1)
                                    {
                                        Battle.EnemyChargeAttack(Player, Goblin);
                                        loopCharge = 0;
                                        itemUsed = false;
                                        if (Player.currentHealth <= 0)
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
                                                Battle.EnemyAttack(Player, Goblin);
                                                if (Player.currentHealth <= 0)
                                                {
                                                    Console.Clear();
                                                    break;
                                                }
                                                break;
                                            case 2:
                                                Battle.EnemyAttack(Player, Goblin);
                                                if (Player.currentHealth <= 0)
                                                {
                                                    Console.Clear();
                                                    break;
                                                }
                                                break;
                                            case 3:
                                                Battle.EnemyAttack(Player, Goblin);
                                                if (Player.currentHealth <= 0)
                                                {
                                                    Console.Clear();
                                                    break;
                                                }
                                                break;
                                            case 4:
                                                Battle.EnemyCharge(Player, Goblin);
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
                        else if (battleChoice == "4")
                        {
                            if (Player.specialBar == 4)
                            {
                                Battle.PlayerSpecialAttackCharge(Player, Goblin);
                                specialCharge++;
                                if (loopCharge == 1)
                                {
                                    Battle.PlayerSpecialAttackInterrupted(Player, Goblin);
                                    specialCharge--;
                                    if (Player.currentHealth < 0)
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
                                Battle.PlayerSpecialBarNotEnough(Player, Goblin);
                                goback++;
                            }
                            if (goback == 0)
                            {
                                int battleGen = choiceGen.Next(1, 5);
                                switch (battleGen)
                                {
                                    case 1:
                                        Battle.EnemyAttack(Player, Goblin);
                                        if (Player.currentHealth <= 0)
                                        {
                                            Console.Clear();
                                            dead = 1;
                                            break;
                                        }
                                        break;
                                    case 2:
                                        Battle.EnemyAttack(Player, Goblin);
                                        if (Player.currentHealth <= 0)
                                        {
                                            Console.Clear();
                                            dead = 1;
                                            break;
                                        }
                                        break;
                                    case 3:
                                        Battle.EnemyGuard(Player, Goblin);
                                        guardCharge++;
                                        break;
                                    case 4:
                                        Battle.EnemyCharge(Player, Goblin);
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
                                        Battle.EnemyGuardAttack(Player, Goblin);
                                        guardCharge--;
                                        if (Goblin.health <= 0)
                                        {
                                            Console.Clear();
                                            Console.WriteLine("You have defeated the {0} and have gained {1} experience and {2} gold", Goblin.name, Goblin.experience, Goblin.gold);
                                            Player.ExperienceGain(Goblin.experience);
                                            Player.gold += Goblin.gold;
                                            plainCleared = true;
                                            Console.ReadKey();
                                            break;
                                        }
                                        battleGen = choiceGen.Next(1, 5);
                                        switch (battleGen)
                                        {
                                            case 1:
                                                Battle.EnemyAttack(Player, Goblin);
                                                if (Player.currentHealth <= 0)
                                                {
                                                    Console.Clear();
                                                    break;
                                                }
                                                break;
                                            case 2:
                                                Battle.EnemyAttack(Player, Goblin);
                                                if (Player.currentHealth <= 0)
                                                {
                                                    Console.Clear();
                                                    break;
                                                }
                                                break;
                                            case 3:
                                                Battle.EnemyAttack(Player, Goblin);
                                                if (Player.currentHealth <= 0)
                                                {
                                                    Console.Clear();
                                                    break;
                                                }
                                                break;
                                            case 4:
                                                Battle.EnemyCharge(Player, Goblin);
                                                loopCharge++;
                                                break;
                                            default:
                                                Console.WriteLine("Error");
                                                break;
                                        }
                                    }
                                    else if (loopCharge == 1)
                                    {
                                        Battle.PlayerSpecialAttackInterrupt(Player, Goblin);
                                        loopCharge--;
                                        if (Goblin.health <= 0)
                                        {
                                            Console.Clear();
                                            Console.WriteLine("You have defeated the {0} and have gained {1} experience and {2} gold", Goblin.name, Goblin.experience, Goblin.gold);
                                            Player.ExperienceGain(Goblin.experience);
                                            Player.gold += Goblin.gold;
                                            plainCleared = true;
                                            Console.ReadKey();
                                            break;
                                        }
                                    }
                                    else
                                    {
                                        Battle.PlayerSpecialAttack(Player, Goblin);
                                        if (Goblin.health <= 0)
                                        {
                                            Console.Clear();
                                            Console.WriteLine("You have defeated the {0} and have gained {1} experience and {2} gold", Goblin.name, Goblin.experience, Goblin.gold);
                                            Player.ExperienceGain(Goblin.experience);
                                            Player.gold += Goblin.gold;
                                            plainCleared = true;
                                            Console.ReadKey();
                                            break;
                                        }
                                        specialCharge--;
                                        battleGen = choiceGen.Next(1, 5);
                                        switch (battleGen)
                                        {
                                            case 1:
                                                Battle.EnemyAttack(Player, Goblin);
                                                if (Player.currentHealth <= 0)
                                                {
                                                    Console.Clear();
                                                    break;
                                                }
                                                break;
                                            case 2:
                                                Battle.EnemyAttack(Player, Goblin);
                                                if (Player.currentHealth <= 0)
                                                {
                                                    Console.Clear();
                                                    break;
                                                }
                                                break;
                                            case 3:
                                                Battle.EnemyAttack(Player, Goblin);
                                                if (Player.currentHealth <= 0)
                                                {
                                                    Console.Clear();
                                                    break;
                                                }
                                                break;
                                            case 4:
                                                Battle.EnemyCharge(Player, Goblin);
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
                else if (choice == "7")
                {
                    if (plainCleared == true)
                    {
                        Frog Frog = new Frog();
                        int loop = 0;
                        int runAway = 0;
                        int loopCharge = 0;
                        int guardCharge = 0;
                        int specialCharge = 0;
                        int goback = 0;
                        int dead = 0;
                        Player.specialBar = 0;
                        Console.Clear();
                        Console.WriteLine("You travel to a gleaming river when all of a sudden");
                        Console.ReadKey();
                        Console.WriteLine("A frog attacks!");
                        Console.ReadKey();
                        while (Player.currentHealth > 0 && Frog.health > 0)
                        {
                            if (loop == 0)
                            {
                                Battle.StartBattle(Player, Frog);
                                loop++;
                            }
                            else
                            {
                                Battle.DuringBattle(Player, Frog);
                            }
                            string battleChoice = Console.ReadLine();
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
                            if (battleChoice == "1")
                            {
                                Battle.PlayerAttack(Player, Frog);
                                if (Frog.health <= 0)
                                {
                                    Console.Clear();
                                    Console.WriteLine("You have defeated the {0} and have gained {1} experience and {2} gold", Frog.name, Frog.experience, Frog.gold);
                                    Player.ExperienceGain(Frog.experience);
                                    Player.gold += Frog.gold;
                                    riverCleared = true;
                                    Console.ReadKey();
                                    break;
                                }
                                if (loopCharge == 1)
                                {
                                    Battle.EnemyChargeAttack(Player, Frog);
                                    loopCharge = 0;
                                    if (Player.currentHealth <= 0)
                                    {
                                        Console.Clear();
                                        break;
                                    }
                                }
                                else
                                {
                                    int battleGen = choiceGen.Next(1, 6);
                                    switch (battleGen)
                                    {
                                        case 1:
                                            Battle.EnemyAttack(Player, Frog);
                                            if (Player.currentHealth <= 0)
                                            {
                                                Console.Clear();
                                                break;
                                            }
                                            break;
                                        case 2:
                                            Battle.EnemyAttack(Player, Frog);
                                            if (Player.currentHealth <= 0)
                                            {
                                                Console.Clear();
                                                break;
                                            }
                                            break;
                                        case 3:
                                            Battle.EnemyAttack(Player, Frog);
                                            if (Player.currentHealth <= 0)
                                            {
                                                Console.Clear();
                                                break;
                                            }
                                            break;
                                        case 4:
                                            Battle.EnemyCharge(Player, Frog);
                                            loopCharge++;
                                            break;
                                        case 5:
                                            Battle.EnemyCharge(Player, Frog);
                                            loopCharge++;
                                            break;
                                        default:
                                            Console.WriteLine("Error");
                                            break;
                                    }
                                }
                            }
                            else if (battleChoice == "2")
                            {
                                Battle.Guard(Player, Frog);
                                if (loopCharge == 1)
                                {
                                    Battle.GuardChargedBlock(Player, Frog);
                                    loopCharge = 0;
                                    if (Player.currentHealth <= 0)
                                    {
                                        Console.Clear();
                                        break;
                                    }
                                }
                                else
                                {
                                    int battleGen = choiceGen.Next(1, 6);
                                    switch (battleGen)
                                    {
                                        case 1:
                                            Battle.GuardNormalBlock(Player, Frog);
                                            if (Player.currentHealth <= 0)
                                            {
                                                Console.Clear();
                                                break;
                                            }
                                            break;
                                        case 2:
                                            Battle.GuardNormalBlock(Player, Frog);
                                            if (Player.currentHealth <= 0)
                                            {
                                                Console.Clear();
                                                break;
                                            }
                                            break;
                                        case 3:
                                            Battle.GuardNormalBlock(Player, Frog);
                                            if (Player.currentHealth <= 0)
                                            {
                                                Console.Clear();
                                                break;
                                            }
                                            break;
                                        case 4:
                                            Battle.EnemyCharge(Player, Frog);
                                            loopCharge++;
                                            break;
                                        case 5:
                                            Battle.EnemyCharge(Player, Frog);
                                            loopCharge++;
                                            break;
                                        default:
                                            Console.WriteLine("Error");
                                            break;
                                    }
                                }
                            }
                            else if (battleChoice == "3")
                            {
                                bool battleGoBack = false;
                                bool itemUsed = false;
                                while (battleGoBack == false)
                                {
                                    PlayerInventory.BattleInventory(Player, Frog);
                                    string inventoryChoice = Console.ReadLine();
                                    if (inventoryChoice == "10")
                                    {
                                        battleGoBack = true;
                                    }
                                    for (int i = 0; i < PlayerInventory.SortedPlayerBag.Count; i++)
                                    {

                                        if (inventoryChoice == ((PlayerInventory.SortedPlayerBag.IndexOf(PlayerInventory.SortedPlayerBag[i]) + 1).ToString()))
                                        {
                                            if (PlayerInventory.SortedPlayerBag[i] is Potion)
                                            {
                                                ((Potion)PlayerInventory.SortedPlayerBag[i]).potionHeal(Player,
                                                                                                        ((Potion)PlayerInventory.SortedPlayerBag[i]),
                                                                                                        Battle, Frog, PlayerInventory);
                                                itemUsed = true;
                                            }
                                        }
                                    }
                                    if (itemUsed == true)
                                    {
                                        if (loopCharge == 1)
                                        {
                                            Battle.EnemyChargeAttack(Player, Frog);
                                            loopCharge = 0;
                                            itemUsed = false;
                                            if (Player.currentHealth <= 0)
                                            {
                                                Console.Clear();
                                                break;
                                            }
                                        }
                                        else
                                        {
                                            int battleGen = choiceGen.Next(1, 6);
                                            switch (battleGen)
                                            {
                                                case 1:
                                                    Battle.EnemyAttack(Player, Frog);
                                                    if (Player.currentHealth <= 0)
                                                    {
                                                        Console.Clear();
                                                        break;
                                                    }
                                                    break;
                                                case 2:
                                                    Battle.EnemyAttack(Player, Frog);
                                                    if (Player.currentHealth <= 0)
                                                    {
                                                        Console.Clear();
                                                        break;
                                                    }
                                                    break;
                                                case 3:
                                                    Battle.EnemyAttack(Player, Frog);
                                                    if (Player.currentHealth <= 0)
                                                    {
                                                        Console.Clear();
                                                        break;
                                                    }
                                                    break;
                                                case 4:
                                                    Battle.EnemyCharge(Player, Frog);
                                                    loopCharge++;
                                                    break;
                                                case 5:
                                                    Battle.EnemyCharge(Player, Frog);
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
                            else if (battleChoice == "4")
                            {
                                if (Player.specialBar == 4)
                                {
                                    Battle.PlayerSpecialAttackCharge(Player, Frog);
                                    specialCharge++;
                                    if (loopCharge == 1)
                                    {
                                        Battle.PlayerSpecialAttackInterrupted(Player, Frog);
                                        specialCharge--;
                                        if (Player.currentHealth < 0)
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
                                    Battle.PlayerSpecialBarNotEnough(Player, Frog);
                                    goback++;
                                }
                                if (goback == 0)
                                {
                                    int battleGen = choiceGen.Next(1, 6);
                                    switch (battleGen)
                                    {
                                        case 1:
                                            Battle.EnemyAttack(Player, Frog);
                                            if (Player.currentHealth <= 0)
                                            {
                                                Console.Clear();
                                                dead = 1;
                                                break;
                                            }
                                            break;
                                        case 2:
                                            Battle.EnemyAttack(Player, Frog);
                                            if (Player.currentHealth <= 0)
                                            {
                                                Console.Clear();
                                                dead = 1;
                                                break;
                                            }
                                            break;
                                        case 3:
                                            Battle.EnemyGuard(Player, Frog);
                                            guardCharge++;
                                            break;
                                        case 4:
                                            Battle.EnemyCharge(Player, Frog);
                                            loopCharge++;
                                            break;
                                        case 5:
                                            Battle.EnemyCharge(Player, Frog);
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
                                            Battle.EnemyGuardAttack(Player, Frog);
                                            guardCharge--;
                                            if (Frog.health <= 0)
                                            {
                                                Console.Clear();
                                                Console.WriteLine("You have defeated the {0} and have gained {1} experience and {2} gold", Frog.name, Frog.experience, Frog.gold);
                                                Player.ExperienceGain(Frog.experience);
                                                Player.gold += Frog.gold;
                                                riverCleared = true;
                                                Console.ReadKey();
                                                break;
                                            }
                                            battleGen = choiceGen.Next(1, 6);
                                            switch (battleGen)
                                            {
                                                case 1:
                                                    Battle.EnemyAttack(Player, Frog);
                                                    if (Player.currentHealth <= 0)
                                                    {
                                                        Console.Clear();
                                                        break;
                                                    }
                                                    break;
                                                case 2:
                                                    Battle.EnemyAttack(Player, Frog);
                                                    if (Player.currentHealth <= 0)
                                                    {
                                                        Console.Clear();
                                                        break;
                                                    }
                                                    break;
                                                case 3:
                                                    Battle.EnemyAttack(Player, Frog);
                                                    if (Player.currentHealth <= 0)
                                                    {
                                                        Console.Clear();
                                                        break;
                                                    }
                                                    break;
                                                case 4:
                                                    Battle.EnemyCharge(Player, Frog);
                                                    loopCharge++;
                                                    break;
                                                case 5:
                                                    Battle.EnemyCharge(Player, Frog);
                                                    loopCharge++;
                                                    break;
                                                default:
                                                    Console.WriteLine("Error");
                                                    break;
                                            }
                                        }
                                        else if (loopCharge == 1)
                                        {
                                            Battle.PlayerSpecialAttackInterrupt(Player, Frog);
                                            loopCharge--;
                                            if (Frog.health <= 0)
                                            {
                                                Console.Clear();
                                                Console.WriteLine("You have defeated the {0} and have gained {1} experience and {2} gold", Frog.name, Frog.experience, Frog.gold);
                                                Player.ExperienceGain(Frog.experience);
                                                Player.gold += Frog.gold;
                                                riverCleared = true;
                                                Console.ReadKey();
                                                break;
                                            }
                                        }
                                        else
                                        {
                                            Battle.PlayerSpecialAttack(Player, Frog);
                                            if (Frog.health <= 0)
                                            {
                                                Console.Clear();
                                                Console.WriteLine("You have defeated the {0} and have gained {1} experience and {2} gold", Frog.name, Frog.experience, Frog.gold);
                                                Player.ExperienceGain(Frog.experience);
                                                Player.gold += Frog.gold;
                                                riverCleared = true;
                                                Console.ReadKey();
                                                break;
                                            }
                                            specialCharge--;
                                            battleGen = choiceGen.Next(1, 6);
                                            switch (battleGen)
                                            {
                                                case 1:
                                                    Battle.EnemyAttack(Player, Frog);
                                                    if (Player.currentHealth <= 0)
                                                    {
                                                        Console.Clear();
                                                        break;
                                                    }
                                                    break;
                                                case 2:
                                                    Battle.EnemyAttack(Player, Frog);
                                                    if (Player.currentHealth <= 0)
                                                    {
                                                        Console.Clear();
                                                        break;
                                                    }
                                                    break;
                                                case 3:
                                                    Battle.EnemyAttack(Player, Frog);
                                                    if (Player.currentHealth <= 0)
                                                    {
                                                        Console.Clear();
                                                        break;
                                                    }
                                                    break;
                                                case 4:
                                                    Battle.EnemyCharge(Player, Frog);
                                                    loopCharge++;
                                                    break;
                                                case 5:
                                                    Battle.EnemyCharge(Player, Frog);
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
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("You have not yet traversed through the plains");
                        Console.ReadKey();
                    }
                }
                else if (choice == "8")
                {
                    if (plainCleared == true && riverCleared == true)
                    {
                        Bear Bear = new Bear();
                        int loop = 0;
                        int runAway = 0;
                        int loopCharge = 0;
                        int guardCharge = 0;
                        int specialCharge = 0;
                        int goback = 0;
                        int dead = 0;
                        Player.specialBar = 0;
                        Console.Clear();
                        Console.WriteLine("You travel through the forest when all of a sudden");
                        Console.ReadKey();
                        Console.WriteLine("A bear attacks!");
                        Console.ReadKey();
                        while (Player.currentHealth > 0 && Bear.health > 0)
                        {
                            if (loop == 0)
                            {
                                Battle.StartBattle(Player, Bear);
                                loop++;
                            }
                            else
                            {
                                Battle.DuringBattle(Player, Bear);
                            }
                            string battleChoice = Console.ReadLine();
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
                            if (battleChoice == "1")
                            {
                                Battle.PlayerAttack(Player, Bear);
                                if (Bear.health <= 0)
                                {
                                    Console.Clear();
                                    Console.WriteLine("You have defeated the {0} and have gained {1} experience and {2} gold", Bear.name, Bear.experience, Bear.gold);
                                    Player.ExperienceGain(Bear.experience);
                                    Player.gold += Bear.gold;
                                    forestCleared = true;
                                    Console.ReadKey();
                                    break;
                                }
                                if (loopCharge == 1)
                                {
                                    Battle.EnemyChargeAttack(Player, Bear);
                                    loopCharge = 0;
                                    if (Player.currentHealth <= 0)
                                    {
                                        Console.Clear();
                                        break;
                                    }
                                }
                                else
                                {
                                    int battleGen = choiceGen.Next(1, 6);
                                    switch (battleGen)
                                    {
                                        case 1:
                                            Battle.EnemyAttack(Player, Bear);
                                            if (Player.currentHealth <= 0)
                                            {
                                                Console.Clear();
                                                break;
                                            }
                                            break;
                                        case 2:
                                            Battle.EnemyAttack(Player, Bear);
                                            if (Player.currentHealth <= 0)
                                            {
                                                Console.Clear();
                                                break;
                                            }
                                            break;
                                        case 3:
                                            Battle.EnemyAttack(Player, Bear);
                                            if (Player.currentHealth <= 0)
                                            {
                                                Console.Clear();
                                                break;
                                            }
                                            break;
                                        case 4:
                                            Battle.EnemyAttack(Player, Bear);
                                            if (Player.currentHealth <= 0)
                                            {
                                                Console.Clear();
                                                break;
                                            }
                                            break;
                                        case 5:
                                            Battle.EnemyCharge(Player, Bear);
                                            loopCharge++;
                                            break;
                                        default:
                                            Console.WriteLine("Error");
                                            break;
                                    }
                                }
                            }
                            else if (battleChoice == "2")
                            {
                                Battle.Guard(Player, Bear);
                                if (loopCharge == 1)
                                {
                                    Battle.GuardChargedBlock(Player, Bear);
                                    loopCharge = 0;
                                    if (Player.currentHealth <= 0)
                                    {
                                        Console.Clear();
                                        break;
                                    }
                                }
                                else
                                {
                                    int battleGen = choiceGen.Next(1, 6);
                                    switch (battleGen)
                                    {
                                        case 1:
                                            Battle.GuardNormalBlock(Player, Bear);
                                            if (Player.currentHealth <= 0)
                                            {
                                                Console.Clear();
                                                break;
                                            }
                                            break;
                                        case 2:
                                            Battle.GuardNormalBlock(Player, Bear);
                                            if (Player.currentHealth <= 0)
                                            {
                                                Console.Clear();
                                                break;
                                            }
                                            break;
                                        case 3:
                                            Battle.GuardNormalBlock(Player, Bear);
                                            if (Player.currentHealth <= 0)
                                            {
                                                Console.Clear();
                                                break;
                                            }
                                            break;
                                        case 4:
                                            Battle.GuardNormalBlock(Player, Bear);
                                            if (Player.currentHealth <= 0)
                                            {
                                                Console.Clear();
                                                break;
                                            }
                                            break;
                                        case 5:
                                            Battle.EnemyCharge(Player, Bear);
                                            loopCharge++;
                                            break;
                                        default:
                                            Console.WriteLine("Error");
                                            break;
                                    }
                                }
                            }
                            else if (battleChoice == "3")
                            {
                                bool battleGoBack = false;
                                bool itemUsed = false;
                                while (battleGoBack == false)
                                {
                                    PlayerInventory.BattleInventory(Player, Bear);
                                    string inventoryChoice = Console.ReadLine();
                                    if (inventoryChoice == "10")
                                    {
                                        battleGoBack = true;
                                    }
                                    for (int i = 0; i < PlayerInventory.SortedPlayerBag.Count; i++)
                                    {

                                        if (inventoryChoice == ((PlayerInventory.SortedPlayerBag.IndexOf(PlayerInventory.SortedPlayerBag[i]) + 1).ToString()))
                                        {
                                            if (PlayerInventory.SortedPlayerBag[i] is Potion)
                                            {
                                                ((Potion)PlayerInventory.SortedPlayerBag[i]).potionHeal(Player,
                                                                                                        ((Potion)PlayerInventory.SortedPlayerBag[i]),
                                                                                                        Battle, Bear, PlayerInventory);
                                                itemUsed = true;
                                            }
                                        }
                                    }
                                    if (itemUsed == true)
                                    {
                                        if (loopCharge == 1)
                                        {
                                            Battle.EnemyChargeAttack(Player, Bear);
                                            loopCharge = 0;
                                            itemUsed = false;
                                            if (Player.currentHealth <= 0)
                                            {
                                                Console.Clear();
                                                break;
                                            }
                                        }
                                        else
                                        {
                                            int battleGen = choiceGen.Next(1, 6);
                                            switch (battleGen)
                                            {
                                                case 1:
                                                    Battle.EnemyAttack(Player, Bear);
                                                    if (Player.currentHealth <= 0)
                                                    {
                                                        Console.Clear();
                                                        break;
                                                    }
                                                    break;
                                                case 2:
                                                    Battle.EnemyAttack(Player, Bear);
                                                    if (Player.currentHealth <= 0)
                                                    {
                                                        Console.Clear();
                                                        break;
                                                    }
                                                    break;
                                                case 3:
                                                    Battle.EnemyAttack(Player, Bear);
                                                    if (Player.currentHealth <= 0)
                                                    {
                                                        Console.Clear();
                                                        break;
                                                    }
                                                    break;
                                                case 4:
                                                    Battle.EnemyAttack(Player, Bear);
                                                    if (Player.currentHealth <= 0)
                                                    {
                                                        Console.Clear();
                                                        break;
                                                    }
                                                    break;
                                                case 5:
                                                    Battle.EnemyCharge(Player, Bear);
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
                            else if (battleChoice == "4")
                            {
                                if (Player.specialBar == 4)
                                {
                                    Battle.PlayerSpecialAttackCharge(Player, Bear);
                                    specialCharge++;
                                    if (loopCharge == 1)
                                    {
                                        Battle.PlayerSpecialAttackInterrupted(Player, Bear);
                                        specialCharge--;
                                        if (Player.currentHealth < 0)
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
                                    Battle.PlayerSpecialBarNotEnough(Player, Bear);
                                    goback++;
                                }
                                if (goback == 0)
                                {
                                    int battleGen = choiceGen.Next(1, 11);
                                    switch (battleGen)
                                    {
                                        case 1:
                                            Battle.EnemyAttack(Player, Bear);
                                            if (Player.currentHealth <= 0)
                                            {
                                                Console.Clear();
                                                dead = 1;
                                                break;
                                            }
                                            break;
                                        case 2:
                                            Battle.EnemyAttack(Player, Bear);
                                            if (Player.currentHealth <= 0)
                                            {
                                                Console.Clear();
                                                dead = 1;
                                                break;
                                            }
                                            break;
                                        case 3:
                                            Battle.EnemyAttack(Player, Bear);
                                            if (Player.currentHealth <= 0)
                                            {
                                                Console.Clear();
                                                dead = 1;
                                                break;
                                            }
                                            break;
                                        case 4:
                                            Battle.EnemyGuard(Player, Bear);
                                            guardCharge++;
                                            break;
                                        case 5:
                                            Battle.EnemyGuard(Player, Bear);
                                            guardCharge++;
                                            break;
                                        case 6:
                                            Battle.EnemyGuard(Player, Bear);
                                            guardCharge++;
                                            break;
                                        case 7:
                                            Battle.EnemyGuard(Player, Bear);
                                            guardCharge++;
                                            break;
                                        case 8:
                                            Battle.EnemyGuard(Player, Bear);
                                            guardCharge++;
                                            break;
                                        case 9:
                                            Battle.EnemyCharge(Player, Bear);
                                            loopCharge++;
                                            break;
                                        case 10:
                                            Battle.EnemyCharge(Player, Bear);
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
                                            Battle.EnemyGuardAttack(Player, Bear);
                                            guardCharge--;
                                            if (Bear.health <= 0)
                                            {
                                                Console.Clear();
                                                Console.WriteLine("You have defeated the {0} and have gained {1} experience and {2} gold", Bear.name, Bear.experience, Bear.gold);
                                                Player.ExperienceGain(Bear.experience);
                                                Player.gold += Bear.gold;
                                                forestCleared = true;
                                                Console.ReadKey();
                                                break;
                                            }
                                            battleGen = choiceGen.Next(1, 6);
                                            switch (battleGen)
                                            {
                                                case 1:
                                                    Battle.EnemyAttack(Player, Bear);
                                                    if (Player.currentHealth <= 0)
                                                    {
                                                        Console.Clear();
                                                        break;
                                                    }
                                                    break;
                                                case 2:
                                                    Battle.EnemyAttack(Player, Bear);
                                                    if (Player.currentHealth <= 0)
                                                    {
                                                        Console.Clear();
                                                        break;
                                                    }
                                                    break;
                                                case 3:
                                                    Battle.EnemyAttack(Player, Bear);
                                                    if (Player.currentHealth <= 0)
                                                    {
                                                        Console.Clear();
                                                        break;
                                                    }
                                                    break;
                                                case 4:
                                                    Battle.EnemyAttack(Player, Bear);
                                                    if (Player.currentHealth <= 0)
                                                    {
                                                        Console.Clear();
                                                        break;
                                                    }
                                                    break;
                                                case 5:
                                                    Battle.EnemyCharge(Player, Bear);
                                                    loopCharge++;
                                                    break;
                                                default:
                                                    Console.WriteLine("Error");
                                                    break;
                                            }
                                        }
                                        else if (loopCharge == 1)
                                        {
                                            Battle.PlayerSpecialAttackInterrupt(Player, Bear);
                                            loopCharge--;
                                            if (Bear.health <= 0)
                                            {
                                                Console.Clear();
                                                Console.WriteLine("You have defeated the {0} and have gained {1} experience and {2} gold", Bear.name, Bear.experience, Bear.gold);
                                                Player.ExperienceGain(Bear.experience);
                                                Player.gold += Bear.gold;
                                                forestCleared = true;
                                                Console.ReadKey();
                                                break;
                                            }
                                        }
                                        else
                                        {
                                            Battle.PlayerSpecialAttack(Player, Bear);
                                            if (Bear.health <= 0)
                                            {
                                                Console.Clear();
                                                Console.WriteLine("You have defeated the {0} and have gained {1} experience and {2} gold", Bear.name, Bear.experience, Bear.gold);
                                                Player.ExperienceGain(Bear.experience);
                                                Player.gold += Bear.gold;
                                                forestCleared = true;
                                                Console.ReadKey();
                                                break;
                                            }
                                            specialCharge--;
                                            battleGen = choiceGen.Next(1, 5);
                                            switch (battleGen)
                                            {
                                                case 1:
                                                    Battle.EnemyAttack(Player, Bear);
                                                    if (Player.currentHealth <= 0)
                                                    {
                                                        Console.Clear();
                                                        break;
                                                    }
                                                    break;
                                                case 2:
                                                    Battle.EnemyAttack(Player, Bear);
                                                    if (Player.currentHealth <= 0)
                                                    {
                                                        Console.Clear();
                                                        break;
                                                    }
                                                    break;
                                                case 3:
                                                    Battle.EnemyAttack(Player, Bear);
                                                    if (Player.currentHealth <= 0)
                                                    {
                                                        Console.Clear();
                                                        break;
                                                    }
                                                    break;
                                                case 4:
                                                    Battle.EnemyCharge(Player, Bear);
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
                    else if (plainCleared == true)
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
                else if (choice == "9")
                {
                    if (plainCleared == true && riverCleared == true && forestCleared == true)
                    {
                        Troll Troll = new Troll();
                        int loop = 0;
                        int runAway = 0;
                        int loopCharge = 0;
                        int guardCharge = 0;
                        int specialCharge = 0;
                        int goback = 0;
                        int dead = 0;
                        Player.specialBar = 0;
                        Console.Clear();
                        Console.WriteLine("You travel across the bridge when all of a sudden");
                        Console.ReadKey();
                        Console.WriteLine("A troll attacks!");
                        Console.ReadKey();
                        while (Player.currentHealth > 0 && Troll.health > 0)
                        {
                            if (loop == 0)
                            {
                                Battle.StartBattle(Player, Troll);
                                loop++;
                            }
                            else
                            {
                                Battle.DuringBattle(Player, Troll);
                            }
                            string battleChoice = Console.ReadLine();
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
                            if (battleChoice == "1")
                            {
                                Battle.PlayerAttack(Player, Troll);
                                if (Troll.health <= 0)
                                {
                                    Console.Clear();
                                    Console.WriteLine("You have defeated the {0} and have gained {1} experience and {2} gold", Troll.name, Troll.experience, Troll.gold);
                                    Player.ExperienceGain(Troll.experience);
                                    Player.gold += Troll.gold;
                                    bridgeCleared = true;
                                    Console.ReadKey();
                                    break;
                                }
                                if (loopCharge == 1)
                                {
                                    Battle.EnemyChargeAttack(Player, Troll);
                                    loopCharge = 0;
                                    if (Player.currentHealth <= 0)
                                    {
                                        Console.Clear();
                                        break;
                                    }
                                }
                                else
                                {
                                    int battleGen = choiceGen.Next(1, 6);
                                    switch (battleGen)
                                    {
                                        case 1:
                                            Battle.EnemyAttack(Player, Troll);
                                            if (Player.currentHealth <= 0)
                                            {
                                                Console.Clear();
                                                break;
                                            }
                                            break;
                                        case 2:
                                            Battle.EnemyAttack(Player, Troll);
                                            if (Player.currentHealth <= 0)
                                            {
                                                Console.Clear();
                                                break;
                                            }
                                            break;
                                        case 3:
                                            Battle.EnemyAttack(Player, Troll);
                                            if (Player.currentHealth <= 0)
                                            {
                                                Console.Clear();
                                                break;
                                            }
                                            break;
                                        case 4:
                                            Battle.EnemyAttack(Player, Troll);
                                            if (Player.currentHealth <= 0)
                                            {
                                                Console.Clear();
                                                break;
                                            }
                                            break;
                                        case 5:
                                            Battle.EnemyCharge(Player, Troll);
                                            loopCharge++;
                                            break;
                                        default:
                                            Console.WriteLine("Error");
                                            break;
                                    }
                                }
                            }
                            else if (battleChoice == "2")
                            {
                                Battle.Guard(Player, Troll);
                                if (loopCharge == 1)
                                {
                                    Battle.GuardChargedBlock(Player, Troll);
                                    loopCharge = 0;
                                    if (Player.currentHealth <= 0)
                                    {
                                        Console.Clear();
                                        break;
                                    }
                                }
                                else
                                {
                                    int battleGen = choiceGen.Next(1, 6);
                                    switch (battleGen)
                                    {
                                        case 1:
                                            Battle.GuardNormalBlock(Player, Troll);
                                            if (Player.currentHealth <= 0)
                                            {
                                                Console.Clear();
                                                break;
                                            }
                                            break;
                                        case 2:
                                            Battle.GuardNormalBlock(Player, Troll);
                                            if (Player.currentHealth <= 0)
                                            {
                                                Console.Clear();
                                                break;
                                            }
                                            break;
                                        case 3:
                                            Battle.GuardNormalBlock(Player, Troll);
                                            if (Player.currentHealth <= 0)
                                            {
                                                Console.Clear();
                                                break;
                                            }
                                            break;
                                        case 4:
                                            Battle.GuardNormalBlock(Player, Troll);
                                            if (Player.currentHealth <= 0)
                                            {
                                                Console.Clear();
                                                break;
                                            }
                                            break;
                                        case 5:
                                            Battle.EnemyCharge(Player, Troll);
                                            loopCharge++;
                                            break;
                                        default:
                                            Console.WriteLine("Error");
                                            break;
                                    }
                                }
                            }
                            else if (battleChoice == "3")
                            {
                                bool battleGoBack = false;
                                bool itemUsed = false;
                                while (battleGoBack == false)
                                {
                                    PlayerInventory.BattleInventory(Player, Troll);
                                    string inventoryChoice = Console.ReadLine();
                                    if (inventoryChoice == "10")
                                    {
                                        battleGoBack = true;
                                    }
                                    for (int i = 0; i < PlayerInventory.SortedPlayerBag.Count; i++)
                                    {

                                        if (inventoryChoice == ((PlayerInventory.SortedPlayerBag.IndexOf(PlayerInventory.SortedPlayerBag[i]) + 1).ToString()))
                                        {
                                            if (PlayerInventory.SortedPlayerBag[i] is Potion)
                                            {
                                                ((Potion)PlayerInventory.SortedPlayerBag[i]).potionHeal(Player,
                                                                                                        ((Potion)PlayerInventory.SortedPlayerBag[i]),
                                                                                                        Battle, Troll, PlayerInventory);
                                                itemUsed = true;
                                            }
                                        }
                                    }
                                    if (itemUsed == true)
                                    {
                                        if (loopCharge == 1)
                                        {
                                            Battle.EnemyChargeAttack(Player, Troll);
                                            loopCharge = 0;
                                            itemUsed = false;
                                            if (Player.currentHealth <= 0)
                                            {
                                                Console.Clear();
                                                break;
                                            }
                                        }
                                        else
                                        {
                                            int battleGen = choiceGen.Next(1, 6);
                                            switch (battleGen)
                                            {
                                                case 1:
                                                    Battle.EnemyAttack(Player, Troll);
                                                    if (Player.currentHealth <= 0)
                                                    {
                                                        Console.Clear();
                                                        break;
                                                    }
                                                    break;
                                                case 2:
                                                    Battle.EnemyAttack(Player, Troll);
                                                    if (Player.currentHealth <= 0)
                                                    {
                                                        Console.Clear();
                                                        break;
                                                    }
                                                    break;
                                                case 3:
                                                    Battle.EnemyAttack(Player, Troll);
                                                    if (Player.currentHealth <= 0)
                                                    {
                                                        Console.Clear();
                                                        break;
                                                    }
                                                    break;
                                                case 4:
                                                    Battle.EnemyAttack(Player, Troll);
                                                    if (Player.currentHealth <= 0)
                                                    {
                                                        Console.Clear();
                                                        break;
                                                    }
                                                    break;
                                                case 5:
                                                    Battle.EnemyCharge(Player, Troll);
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
                            else if (battleChoice == "4")
                            {
                                if (Player.specialBar == 4)
                                {
                                    Battle.PlayerSpecialAttackCharge(Player, Troll);
                                    specialCharge++;
                                    if (loopCharge == 1)
                                    {
                                        Battle.PlayerSpecialAttackInterrupted(Player, Troll);
                                        specialCharge--;
                                        if (Player.currentHealth < 0)
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
                                    Battle.PlayerSpecialBarNotEnough(Player, Troll);
                                    goback++;
                                }
                                if (goback == 0)
                                {
                                    int battleGen = choiceGen.Next(1, 6);
                                    switch (battleGen)
                                    {
                                        case 1:
                                            Battle.EnemyAttack(Player, Troll);
                                            if (Player.currentHealth <= 0)
                                            {
                                                Console.Clear();
                                                dead = 1;
                                                break;
                                            }
                                            break;
                                        case 2:
                                            Battle.EnemyAttack(Player, Troll);
                                            if (Player.currentHealth <= 0)
                                            {
                                                Console.Clear();
                                                dead = 1;
                                                break;
                                            }
                                            break;
                                        case 3:
                                            Battle.EnemyAttack(Player, Troll);
                                            if (Player.currentHealth <= 0)
                                            {
                                                Console.Clear();
                                                dead = 1;
                                                break;
                                            }
                                            break;
                                        case 4:
                                            Battle.EnemyGuard(Player, Troll);
                                            guardCharge++;
                                            break;
                                        case 5:
                                            Battle.EnemyCharge(Player, Troll);
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
                                            Battle.EnemyGuardAttack(Player, Troll);
                                            guardCharge--;
                                            if (Troll.health <= 0)
                                            {
                                                Console.Clear();
                                                Console.WriteLine("You have defeated the {0} and have gained {1} experience and {2} gold", Troll.name, Troll.experience, Troll.gold);
                                                Player.ExperienceGain(Troll.experience);
                                                Player.gold += Troll.gold;
                                                bridgeCleared = true;
                                                Console.ReadKey();
                                                break;
                                            }
                                            battleGen = choiceGen.Next(1, 6);
                                            switch (battleGen)
                                            {
                                                case 1:
                                                    Battle.EnemyAttack(Player, Troll);
                                                    if (Player.currentHealth <= 0)
                                                    {
                                                        Console.Clear();
                                                        break;
                                                    }
                                                    break;
                                                case 2:
                                                    Battle.EnemyAttack(Player, Troll);
                                                    if (Player.currentHealth <= 0)
                                                    {
                                                        Console.Clear();
                                                        break;
                                                    }
                                                    break;
                                                case 3:
                                                    Battle.EnemyAttack(Player, Troll);
                                                    if (Player.currentHealth <= 0)
                                                    {
                                                        Console.Clear();
                                                        break;
                                                    }
                                                    break;
                                                case 4:
                                                    Battle.EnemyAttack(Player, Troll);
                                                    if (Player.currentHealth <= 0)
                                                    {
                                                        Console.Clear();
                                                        break;
                                                    }
                                                    break;
                                                case 5:
                                                    Battle.EnemyCharge(Player, Troll);
                                                    loopCharge++;
                                                    break;
                                                default:
                                                    Console.WriteLine("Error");
                                                    break;
                                            }
                                        }
                                        else if (loopCharge == 1)
                                        {
                                            Battle.PlayerSpecialAttackInterrupt(Player, Troll);
                                            loopCharge--;
                                            if (Troll.health <= 0)
                                            {
                                                Console.Clear();
                                                Console.WriteLine("You have defeated the {0} and have gained {1} experience and {2} gold", Troll.name, Troll.experience, Troll.gold);
                                                Player.ExperienceGain(Troll.experience);
                                                Player.gold += Troll.gold;
                                                bridgeCleared = true;
                                                Console.ReadKey();
                                                break;
                                            }
                                        }
                                        else
                                        {
                                            Battle.PlayerSpecialAttack(Player, Troll);
                                            if (Troll.health <= 0)
                                            {
                                                Console.Clear();
                                                Console.WriteLine("You have defeated the {0} and have gained {1} experience and {2} gold", Troll.name, Troll.experience, Troll.gold);
                                                Player.ExperienceGain(Troll.experience);
                                                Player.gold += Troll.gold;
                                                bridgeCleared = true;
                                                Console.ReadKey();
                                                break;
                                            }
                                            specialCharge--;
                                            battleGen = choiceGen.Next(1, 6);
                                            switch (battleGen)
                                            {
                                                case 1:
                                                    Battle.EnemyAttack(Player, Troll);
                                                    if (Player.currentHealth <= 0)
                                                    {
                                                        Console.Clear();
                                                        break;
                                                    }
                                                    break;
                                                case 2:
                                                    Battle.EnemyAttack(Player, Troll);
                                                    if (Player.currentHealth <= 0)
                                                    {
                                                        Console.Clear();
                                                        break;
                                                    }
                                                    break;
                                                case 3:
                                                    Battle.EnemyAttack(Player, Troll);
                                                    if (Player.currentHealth <= 0)
                                                    {
                                                        Console.Clear();
                                                        break;
                                                    }
                                                    break;
                                                case 4:
                                                    Battle.EnemyAttack(Player, Troll);
                                                    if (Player.currentHealth <= 0)
                                                    {
                                                        Console.Clear();
                                                        break;
                                                    }
                                                    break;
                                                case 5:
                                                    Battle.EnemyCharge(Player, Troll);
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
                    else if (plainCleared == true && riverCleared == true)
                    {
                        Console.Clear();
                        Console.WriteLine("You have not yet traversed through the forest");
                        Console.ReadKey();
                    }
                    else if (plainCleared == true)
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
                else if (choice == "10")
                {
                    string castleChoice = "";
                    if (plainCleared == true && riverCleared == true && forestCleared == true && bridgeCleared == true)
                    {
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
                        if (castleChoice == "1")
                        {
                            Golem Golem = new Golem();
                            int loop = 0;
                            int loopCharge = 0;
                            int guardCharge = 0;
                            int specialCharge = 0;
                            int goback = 0;
                            int dead = 0;
                            Player.specialBar = 0;

                            Console.Clear();
                            Console.WriteLine("You decide to enter the castle and face the dragon");
                            Console.ReadKey();
                            Console.WriteLine("You enter the castle and come to the main hall when suddenly");
                            Console.ReadKey();
                            Console.WriteLine("A golem attacks!");
                            Console.ReadKey();
                            while (Player.currentHealth > 0 && Golem.health > 0)
                            {
                                if (loop == 0)
                                {
                                    Battle.StartCastleBattle(Player, Golem);
                                    loop++;
                                }
                                else
                                {
                                    Battle.DuringBattle(Player, Golem);
                                }
                                string battleChoice = Console.ReadLine();

                                if (battleChoice == "1")
                                {
                                    Battle.PlayerAttack(Player, Golem);
                                    if (Golem.health <= 0)
                                    {
                                        Console.Clear();
                                        Console.WriteLine("You have defeated the {0} and have gained {1} experience", Golem.name, Golem.experience);
                                        Player.ExperienceGain(Golem.experience);
                                        Console.ReadKey();
                                        break;
                                    }
                                    if (loopCharge == 1)
                                    {
                                        Battle.EnemyChargeAttack(Player, Golem);
                                        loopCharge = 0;
                                        if (Player.currentHealth <= 0)
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
                                                Battle.EnemyAttack(Player, Golem);
                                                if (Player.currentHealth <= 0)
                                                {
                                                    Console.Clear();
                                                    break;
                                                }
                                                break;
                                            case 2:
                                                Battle.EnemyAttack(Player, Golem);
                                                if (Player.currentHealth <= 0)
                                                {
                                                    Console.Clear();
                                                    break;
                                                }
                                                break;
                                            case 3:
                                                Battle.EnemyAttack(Player, Golem);
                                                if (Player.currentHealth <= 0)
                                                {
                                                    Console.Clear();
                                                    break;
                                                }
                                                break;
                                            case 4:
                                                Battle.EnemyCharge(Player, Golem);
                                                loopCharge++;
                                                break;
                                            default:
                                                Console.WriteLine("Error");
                                                break;
                                        }
                                    }
                                }
                                else if (battleChoice == "2")
                                {
                                    Battle.Guard(Player, Golem);
                                    if (loopCharge == 1)
                                    {
                                        Battle.GuardChargedBlock(Player, Golem);
                                        loopCharge = 0;
                                        if (Player.currentHealth <= 0)
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
                                                Battle.GuardNormalBlock(Player, Golem);
                                                if (Player.currentHealth <= 0)
                                                {
                                                    Console.Clear();
                                                    break;
                                                }
                                                break;
                                            case 2:
                                                Battle.GuardNormalBlock(Player, Golem);
                                                if (Player.currentHealth <= 0)
                                                {
                                                    Console.Clear();
                                                    break;
                                                }
                                                break;
                                            case 3:
                                                Battle.GuardNormalBlock(Player, Golem);
                                                if (Player.currentHealth <= 0)
                                                {
                                                    Console.Clear();
                                                    break;
                                                }
                                                break;
                                            case 4:
                                                Battle.EnemyCharge(Player, Golem);
                                                loopCharge++;
                                                break;
                                            default:
                                                Console.WriteLine("Error");
                                                break;
                                        }
                                    }
                                }
                                else if (battleChoice == "3")
                                {
                                    bool battleGoBack = false;
                                    bool itemUsed = false;
                                    while (battleGoBack == false)
                                    {
                                        PlayerInventory.BattleInventory(Player, Golem);
                                        string inventoryChoice = Console.ReadLine();
                                        if (inventoryChoice == "10")
                                        {
                                            battleGoBack = true;
                                        }
                                        for (int i = 0; i < PlayerInventory.SortedPlayerBag.Count; i++)
                                        {

                                            if (inventoryChoice == ((PlayerInventory.SortedPlayerBag.IndexOf(PlayerInventory.SortedPlayerBag[i]) + 1).ToString()))
                                            {
                                                if (PlayerInventory.SortedPlayerBag[i] is Potion)
                                                {
                                                    ((Potion)PlayerInventory.SortedPlayerBag[i]).potionHeal(Player,
                                                                                                            ((Potion)PlayerInventory.SortedPlayerBag[i]),
                                                                                                            Battle, Golem, PlayerInventory);
                                                    itemUsed = true;
                                                }
                                            }
                                        }
                                        if (itemUsed == true)
                                        {
                                            if (loopCharge == 1)
                                            {
                                                Battle.EnemyChargeAttack(Player, Golem);
                                                loopCharge = 0;
                                                itemUsed = false;
                                                if (Player.currentHealth <= 0)
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
                                                        Battle.EnemyAttack(Player, Golem);
                                                        if (Player.currentHealth <= 0)
                                                        {
                                                            Console.Clear();
                                                            break;
                                                        }
                                                        break;
                                                    case 2:
                                                        Battle.EnemyAttack(Player, Golem);
                                                        if (Player.currentHealth <= 0)
                                                        {
                                                            Console.Clear();
                                                            break;
                                                        }
                                                        break;
                                                    case 3:
                                                        Battle.EnemyAttack(Player, Golem);
                                                        if (Player.currentHealth <= 0)
                                                        {
                                                            Console.Clear();
                                                            break;
                                                        }
                                                        break;
                                                    case 4:
                                                        Battle.EnemyCharge(Player, Golem);
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
                                else if (battleChoice == "4")
                                {
                                    if (Player.specialBar == 4)
                                    {
                                        Battle.PlayerSpecialAttackCharge(Player, Golem);
                                        specialCharge++;
                                        if (loopCharge == 1)
                                        {
                                            Battle.PlayerSpecialAttackInterrupted(Player, Golem);
                                            specialCharge--;
                                            if (Player.currentHealth < 0)
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
                                        Battle.PlayerSpecialBarNotEnough(Player, Golem);
                                        goback++;
                                    }
                                    if (goback == 0)
                                    {
                                        int battleGen = choiceGen.Next(1, 4);
                                        switch (battleGen)
                                        {
                                            case 1:
                                                Battle.EnemyAttack(Player, Golem);
                                                if (Player.currentHealth <= 0)
                                                {
                                                    Console.Clear();
                                                    dead = 1;
                                                    break;
                                                }
                                                break;
                                            case 2:
                                                Battle.EnemyGuard(Player, Golem);
                                                guardCharge++;
                                                break;
                                            case 3:
                                                Battle.EnemyCharge(Player, Golem);
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
                                                Battle.EnemyGuardAttack(Player, Golem);
                                                guardCharge--;
                                                if (Golem.health <= 0)
                                                {
                                                    Console.Clear();
                                                    Console.WriteLine("You have defeated the {0} and have gained {1} experience", Golem.name, Golem.experience);
                                                    Player.ExperienceGain(Golem.experience);
                                                    Console.ReadKey();
                                                    break;
                                                }
                                                battleGen = choiceGen.Next(1, 5);
                                                switch (battleGen)
                                                {
                                                    case 1:
                                                        Battle.EnemyAttack(Player, Golem);
                                                        if (Player.currentHealth <= 0)
                                                        {
                                                            Console.Clear();
                                                            break;
                                                        }
                                                        break;
                                                    case 2:
                                                        Battle.EnemyAttack(Player, Golem);
                                                        if (Player.currentHealth <= 0)
                                                        {
                                                            Console.Clear();
                                                            break;
                                                        }
                                                        break;
                                                    case 3:
                                                        Battle.EnemyAttack(Player, Golem);
                                                        if (Player.currentHealth <= 0)
                                                        {
                                                            Console.Clear();
                                                            break;
                                                        }
                                                        break;
                                                    case 4:
                                                        Battle.EnemyCharge(Player, Golem);
                                                        loopCharge++;
                                                        break;
                                                    default:
                                                        Console.WriteLine("Error");
                                                        break;
                                                }
                                            }
                                            else if (loopCharge == 1)
                                            {
                                                Battle.PlayerSpecialAttackInterrupt(Player, Golem);
                                                loopCharge--;
                                                if (Golem.health <= 0)
                                                {
                                                    Console.Clear();
                                                    Console.WriteLine("You have defeated the {0} and have gained {1} experience", Golem.name, Golem.experience);
                                                    Player.ExperienceGain(Golem.experience);
                                                    Console.ReadKey();
                                                    break;
                                                }
                                            }
                                            else
                                            {
                                                Battle.PlayerSpecialAttack(Player, Golem);
                                                if (Golem.health <= 0)
                                                {
                                                    Console.Clear();
                                                    Console.WriteLine("You have defeated the {0} and have gained {1} experience", Golem.name, Golem.experience);
                                                    Player.ExperienceGain(Golem.experience);
                                                    Console.ReadKey();
                                                    break;
                                                }
                                                specialCharge--;
                                                battleGen = choiceGen.Next(1, 5);
                                                switch (battleGen)
                                                {
                                                    case 1:
                                                        Battle.EnemyAttack(Player, Golem);
                                                        if (Player.currentHealth <= 0)
                                                        {
                                                            Console.Clear();
                                                            break;
                                                        }
                                                        break;
                                                    case 2:
                                                        Battle.EnemyAttack(Player, Golem);
                                                        if (Player.currentHealth <= 0)
                                                        {
                                                            Console.Clear();
                                                            break;
                                                        }
                                                        break;
                                                    case 3:
                                                        Battle.EnemyAttack(Player, Golem);
                                                        if (Player.currentHealth <= 0)
                                                        {
                                                            Console.Clear();
                                                            break;
                                                        }
                                                        break;
                                                    case 4:
                                                        Battle.EnemyCharge(Player, Golem);
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

                            Golem = new Golem();
                            loop = 0;
                            loopCharge = 0;
                            guardCharge = 0;
                            specialCharge = 0;
                            goback = 0;
                            dead = 0;
                            Player.specialBar = 0;

                            Console.Clear();
                            Console.WriteLine("After defeating the golem you proceed further into the castle when suddenly");
                            Console.ReadKey();
                            Console.WriteLine("Another golem attacks!");
                            Console.ReadKey();
                            while (Player.currentHealth > 0 && Golem.health > 0)
                            {
                                if (loop == 0)
                                {
                                    Battle.StartCastleBattle(Player, Golem);
                                    loop++;
                                }
                                else
                                {
                                    Battle.DuringBattle(Player, Golem);
                                }
                                string battleChoice = Console.ReadLine();

                                if (battleChoice == "1")
                                {
                                    Battle.PlayerAttack(Player, Golem);
                                    if (Golem.health <= 0)
                                    {
                                        Console.Clear();
                                        Console.WriteLine("You have defeated the {0} and have gained {1} experience", Golem.name, Golem.experience);
                                        Player.ExperienceGain(Golem.experience);
                                        Console.ReadKey();
                                        break;
                                    }
                                    if (loopCharge == 1)
                                    {
                                        Battle.EnemyChargeAttack(Player, Golem);
                                        loopCharge = 0;
                                        if (Player.currentHealth <= 0)
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
                                                Battle.EnemyAttack(Player, Golem);
                                                if (Player.currentHealth <= 0)
                                                {
                                                    Console.Clear();
                                                    break;
                                                }
                                                break;
                                            case 2:
                                                Battle.EnemyAttack(Player, Golem);
                                                if (Player.currentHealth <= 0)
                                                {
                                                    Console.Clear();
                                                    break;
                                                }
                                                break;
                                            case 3:
                                                Battle.EnemyAttack(Player, Golem);
                                                if (Player.currentHealth <= 0)
                                                {
                                                    Console.Clear();
                                                    break;
                                                }
                                                break;
                                            case 4:
                                                Battle.EnemyCharge(Player, Golem);
                                                loopCharge++;
                                                break;
                                            default:
                                                Console.WriteLine("Error");
                                                break;
                                        }
                                    }
                                }
                                else if (battleChoice == "2")
                                {
                                    Battle.Guard(Player, Golem);
                                    if (loopCharge == 1)
                                    {
                                        Battle.GuardChargedBlock(Player, Golem);
                                        loopCharge = 0;
                                        if (Player.currentHealth <= 0)
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
                                                Battle.GuardNormalBlock(Player, Golem);
                                                if (Player.currentHealth <= 0)
                                                {
                                                    Console.Clear();
                                                    break;
                                                }
                                                break;
                                            case 2:
                                                Battle.GuardNormalBlock(Player, Golem);
                                                if (Player.currentHealth <= 0)
                                                {
                                                    Console.Clear();
                                                    break;
                                                }
                                                break;
                                            case 3:
                                                Battle.GuardNormalBlock(Player, Golem);
                                                if (Player.currentHealth <= 0)
                                                {
                                                    Console.Clear();
                                                    break;
                                                }
                                                break;
                                            case 4:
                                                Battle.EnemyCharge(Player, Golem);
                                                loopCharge++;
                                                break;
                                            default:
                                                Console.WriteLine("Error");
                                                break;
                                        }
                                    }
                                }
                                else if (battleChoice == "3")
                                {
                                    bool battleGoBack = false;
                                    bool itemUsed = false;
                                    while (battleGoBack == false)
                                    {
                                        PlayerInventory.BattleInventory(Player, Golem);
                                        string inventoryChoice = Console.ReadLine();
                                        if (inventoryChoice == "10")
                                        {
                                            battleGoBack = true;
                                        }
                                        for (int i = 0; i < PlayerInventory.SortedPlayerBag.Count; i++)
                                        {

                                            if (inventoryChoice == ((PlayerInventory.SortedPlayerBag.IndexOf(PlayerInventory.SortedPlayerBag[i]) + 1).ToString()))
                                            {
                                                if (PlayerInventory.SortedPlayerBag[i] is Potion)
                                                {
                                                    ((Potion)PlayerInventory.SortedPlayerBag[i]).potionHeal(Player,
                                                                                                            ((Potion)PlayerInventory.SortedPlayerBag[i]),
                                                                                                            Battle, Golem, PlayerInventory);
                                                    itemUsed = true;
                                                }
                                            }
                                        }
                                        if (itemUsed == true)
                                        {
                                            if (loopCharge == 1)
                                            {
                                                Battle.EnemyChargeAttack(Player, Golem);
                                                loopCharge = 0;
                                                itemUsed = false;
                                                if (Player.currentHealth <= 0)
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
                                                        Battle.EnemyAttack(Player, Golem);
                                                        if (Player.currentHealth <= 0)
                                                        {
                                                            Console.Clear();
                                                            break;
                                                        }
                                                        break;
                                                    case 2:
                                                        Battle.EnemyAttack(Player, Golem);
                                                        if (Player.currentHealth <= 0)
                                                        {
                                                            Console.Clear();
                                                            break;
                                                        }
                                                        break;
                                                    case 3:
                                                        Battle.EnemyAttack(Player, Golem);
                                                        if (Player.currentHealth <= 0)
                                                        {
                                                            Console.Clear();
                                                            break;
                                                        }
                                                        break;
                                                    case 4:
                                                        Battle.EnemyCharge(Player, Golem);
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
                                else if (battleChoice == "4")
                                {
                                    if (Player.specialBar == 4)
                                    {
                                        Battle.PlayerSpecialAttackCharge(Player, Golem);
                                        specialCharge++;
                                        if (loopCharge == 1)
                                        {
                                            Battle.PlayerSpecialAttackInterrupted(Player, Golem);
                                            specialCharge--;
                                            if (Player.currentHealth < 0)
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
                                        Battle.PlayerSpecialBarNotEnough(Player, Golem);
                                        goback++;
                                    }
                                    if (goback == 0)
                                    {
                                        int battleGen = choiceGen.Next(1, 4);
                                        switch (battleGen)
                                        {
                                            case 1:
                                                Battle.EnemyAttack(Player, Golem);
                                                if (Player.currentHealth <= 0)
                                                {
                                                    Console.Clear();
                                                    dead = 1;
                                                    break;
                                                }
                                                break;
                                            case 2:
                                                Battle.EnemyGuard(Player, Golem);
                                                guardCharge++;
                                                break;
                                            case 3:
                                                Battle.EnemyCharge(Player, Golem);
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
                                                Battle.EnemyGuardAttack(Player, Golem);
                                                guardCharge--;
                                                if (Golem.health <= 0)
                                                {
                                                    Console.Clear();
                                                    Console.WriteLine("You have defeated the {0} and have gained {1} experience", Golem.name, Golem.experience);
                                                    Player.ExperienceGain(Golem.experience);
                                                    Console.ReadKey();
                                                    break;
                                                }
                                                battleGen = choiceGen.Next(1, 5);
                                                switch (battleGen)
                                                {
                                                    case 1:
                                                        Battle.EnemyAttack(Player, Golem);
                                                        if (Player.currentHealth <= 0)
                                                        {
                                                            Console.Clear();
                                                            break;
                                                        }
                                                        break;
                                                    case 2:
                                                        Battle.EnemyAttack(Player, Golem);
                                                        if (Player.currentHealth <= 0)
                                                        {
                                                            Console.Clear();
                                                            break;
                                                        }
                                                        break;
                                                    case 3:
                                                        Battle.EnemyAttack(Player, Golem);
                                                        if (Player.currentHealth <= 0)
                                                        {
                                                            Console.Clear();
                                                            break;
                                                        }
                                                        break;
                                                    case 4:
                                                        Battle.EnemyCharge(Player, Golem);
                                                        loopCharge++;
                                                        break;
                                                    default:
                                                        Console.WriteLine("Error");
                                                        break;
                                                }
                                            }
                                            else if (loopCharge == 1)
                                            {
                                                Battle.PlayerSpecialAttackInterrupt(Player, Golem);
                                                loopCharge--;
                                                if (Golem.health <= 0)
                                                {
                                                    Console.Clear();
                                                    Console.WriteLine("You have defeated the {0} and have gained {1} experience", Golem.name, Golem.experience);
                                                    Player.ExperienceGain(Golem.experience);
                                                    Console.ReadKey();
                                                    break;
                                                }
                                            }
                                            else
                                            {
                                                Battle.PlayerSpecialAttack(Player, Golem);
                                                if (Golem.health <= 0)
                                                {
                                                    Console.Clear();
                                                    Console.WriteLine("You have defeated the {0} and have gained {1} experience", Golem.name, Golem.experience);
                                                    Player.ExperienceGain(Golem.experience);
                                                    Console.ReadKey();
                                                    break;
                                                }
                                                specialCharge--;
                                                battleGen = choiceGen.Next(1, 5);
                                                switch (battleGen)
                                                {
                                                    case 1:
                                                        Battle.EnemyAttack(Player, Golem);
                                                        if (Player.currentHealth <= 0)
                                                        {
                                                            Console.Clear();
                                                            break;
                                                        }
                                                        break;
                                                    case 2:
                                                        Battle.EnemyAttack(Player, Golem);
                                                        if (Player.currentHealth <= 0)
                                                        {
                                                            Console.Clear();
                                                            break;
                                                        }
                                                        break;
                                                    case 3:
                                                        Battle.EnemyAttack(Player, Golem);
                                                        if (Player.currentHealth <= 0)
                                                        {
                                                            Console.Clear();
                                                            break;
                                                        }
                                                        break;
                                                    case 4:
                                                        Battle.EnemyCharge(Player, Golem);
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

                            Dragon Dragon = new Dragon();
                            loop = 0;
                            loopCharge = 0;
                            guardCharge = 0;
                            specialCharge = 0;
                            goback = 0;
                            dead = 0;
                            Player.specialBar = 0;

                            Console.Clear();
                            Console.WriteLine("After defeating the second golem you are able to proceed through the castle");
                            Console.ReadKey();
                            Console.WriteLine("You climb the steps and reach the top of the castle where you hear the dragon");
                            Console.ReadKey();
                            Console.WriteLine("You lock eyes with the dragon");
                            Console.ReadKey();
                            Console.WriteLine("The dragon attacks!");
                            Console.ReadKey();
                            while (Player.currentHealth > 0 && Dragon.health > 0)
                            {
                                if (loop == 0)
                                {
                                    Battle.StartCastleBattle(Player, Dragon);
                                    loop++;
                                }
                                else
                                {
                                    Battle.DuringBattle(Player, Dragon);
                                }
                                string battleChoice = Console.ReadLine();

                                if (battleChoice == "1")
                                {
                                    Battle.PlayerAttack(Player, Dragon);
                                    if (Dragon.health <= 0)
                                    {
                                        Console.Clear();
                                        Console.WriteLine("You have slain the {0}!", Dragon.name);
                                        Console.ReadKey();
                                        dragonAlive = false;
                                        break;
                                    }
                                    if (loopCharge == 1)
                                    {
                                        Battle.EnemyChargeAttack(Player, Dragon);
                                        loopCharge = 0;
                                        if (Player.currentHealth <= 0)
                                        {
                                            Console.Clear();
                                            break;
                                        }
                                    }
                                    else
                                    {
                                        int battleGen = choiceGen.Next(1, 4);
                                        switch (battleGen)
                                        {
                                            case 1:
                                                Battle.EnemyAttack(Player, Dragon);
                                                if (Player.currentHealth <= 0)
                                                {
                                                    Console.Clear();
                                                    break;
                                                }
                                                break;
                                            case 2:
                                                Battle.EnemyAttack(Player, Dragon);
                                                if (Player.currentHealth <= 0)
                                                {
                                                    Console.Clear();
                                                    break;
                                                }
                                                break;
                                            case 3:
                                                Battle.EnemyCharge(Player, Dragon);
                                                loopCharge++;
                                                break;
                                            default:
                                                Console.WriteLine("Error");
                                                break;
                                        }
                                    }
                                }
                                else if (battleChoice == "2")
                                {
                                    Battle.Guard(Player, Dragon);
                                    if (loopCharge == 1)
                                    {
                                        Battle.GuardChargedBlock(Player, Dragon);
                                        loopCharge = 0;
                                        if (Player.currentHealth <= 0)
                                        {
                                            Console.Clear();
                                            break;
                                        }
                                    }
                                    else
                                    {
                                        int battleGen = choiceGen.Next(1, 4);
                                        switch (battleGen)
                                        {
                                            case 1:
                                                Battle.GuardNormalBlock(Player, Dragon);
                                                if (Player.currentHealth <= 0)
                                                {
                                                    Console.Clear();
                                                    break;
                                                }
                                                break;
                                            case 2:
                                                Battle.GuardNormalBlock(Player, Dragon);
                                                if (Player.currentHealth <= 0)
                                                {
                                                    Console.Clear();
                                                    break;
                                                }
                                                break;
                                            case 3:
                                                Battle.EnemyCharge(Player, Dragon);
                                                loopCharge++;
                                                break;
                                            default:
                                                Console.WriteLine("Error");
                                                break;
                                        }
                                    }
                                }
                                else if (battleChoice == "3")
                                {
                                    bool battleGoBack = false;
                                    bool itemUsed = false;
                                    while (battleGoBack == false)
                                    {
                                        PlayerInventory.BattleInventory(Player, Dragon);
                                        string inventoryChoice = Console.ReadLine();
                                        if (inventoryChoice == "10")
                                        {
                                            battleGoBack = true;
                                        }
                                        for (int i = 0; i < PlayerInventory.SortedPlayerBag.Count; i++)
                                        {

                                            if (inventoryChoice == ((PlayerInventory.SortedPlayerBag.IndexOf(PlayerInventory.SortedPlayerBag[i]) + 1).ToString()))
                                            {
                                                if (PlayerInventory.SortedPlayerBag[i] is Potion)
                                                {
                                                    ((Potion)PlayerInventory.SortedPlayerBag[i]).potionHeal(Player,
                                                                                                            ((Potion)PlayerInventory.SortedPlayerBag[i]),
                                                                                                            Battle, Dragon, PlayerInventory);
                                                    itemUsed = true;
                                                }
                                            }
                                        }
                                        if (itemUsed == true)
                                        {
                                            if (loopCharge == 1)
                                            {
                                                Battle.EnemyChargeAttack(Player, Dragon);
                                                loopCharge = 0;
                                                itemUsed = false;
                                                if (Player.currentHealth <= 0)
                                                {
                                                    Console.Clear();
                                                    break;
                                                }
                                            }
                                            else
                                            {
                                                int battleGen = choiceGen.Next(1, 4);
                                                switch (battleGen)
                                                {
                                                    case 1:
                                                        Battle.EnemyAttack(Player, Dragon);
                                                        if (Player.currentHealth <= 0)
                                                        {
                                                            Console.Clear();
                                                            break;
                                                        }
                                                        break;
                                                    case 2:
                                                        Battle.EnemyAttack(Player, Dragon);
                                                        if (Player.currentHealth <= 0)
                                                        {
                                                            Console.Clear();
                                                            break;
                                                        }
                                                        break;
                                                    case 3:
                                                        Battle.EnemyCharge(Player, Dragon);
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
                                else if (battleChoice == "4")
                                {
                                    if (Player.specialBar == 4)
                                    {
                                        Battle.PlayerSpecialAttackCharge(Player, Dragon);
                                        specialCharge++;
                                        if (loopCharge == 1)
                                        {
                                            Battle.PlayerSpecialAttackInterrupted(Player, Dragon);
                                            specialCharge--;
                                            if (Player.currentHealth < 0)
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
                                        Battle.PlayerSpecialBarNotEnough(Player, Dragon);
                                        goback++;
                                    }
                                    if (goback == 0)
                                    {
                                        int battleGen = choiceGen.Next(1, 4);
                                        switch (battleGen)
                                        {
                                            case 1:
                                                Battle.EnemyAttack(Player, Dragon);
                                                if (Player.currentHealth <= 0)
                                                {
                                                    Console.Clear();
                                                    dead = 1;
                                                    break;
                                                }
                                                break;
                                            case 2:
                                                Battle.EnemyAttack(Player, Dragon);
                                                if (Player.currentHealth <= 0)
                                                {
                                                    Console.Clear();
                                                    dead = 1;
                                                    break;
                                                }
                                                break;
                                            case 3:
                                                Battle.EnemyGuard(Player, Dragon);
                                                guardCharge++;
                                                break;
                                            default:
                                                Console.WriteLine("Error");
                                                break;
                                        }
                                        if (dead == 0)
                                        {
                                            if (guardCharge == 1)
                                            {
                                                Battle.EnemyGuardAttack(Player, Dragon);
                                                guardCharge--;
                                                if (Dragon.health <= 0)
                                                {
                                                    Console.Clear();
                                                    Console.WriteLine("You have slain the {0}", Dragon.name);
                                                    Console.ReadKey();
                                                    dragonAlive = false;
                                                    break;
                                                }
                                                battleGen = choiceGen.Next(1, 5);
                                                switch (battleGen)
                                                {
                                                    case 1:
                                                        Battle.EnemyAttack(Player, Dragon);
                                                        if (Player.currentHealth <= 0)
                                                        {
                                                            Console.Clear();
                                                            break;
                                                        }
                                                        break;
                                                    case 2:
                                                        Battle.EnemyAttack(Player, Dragon);
                                                        if (Player.currentHealth <= 0)
                                                        {
                                                            Console.Clear();
                                                            break;
                                                        }
                                                        break;
                                                    case 3:
                                                        Battle.EnemyAttack(Player, Dragon);
                                                        if (Player.currentHealth <= 0)
                                                        {
                                                            Console.Clear();
                                                            break;
                                                        }
                                                        break;
                                                    case 4:
                                                        Battle.EnemyCharge(Player, Dragon);
                                                        loopCharge++;
                                                        break;
                                                    default:
                                                        Console.WriteLine("Error");
                                                        break;
                                                }
                                            }
                                            else if (loopCharge == 1)
                                            {
                                                Battle.PlayerSpecialAttackInterrupt(Player, Dragon);
                                                loopCharge--;
                                                if (Dragon.health <= 0)
                                                {
                                                    Console.Clear();
                                                    Console.WriteLine("You have slain the {0}!", Dragon.name);
                                                    Console.ReadKey();
                                                    dragonAlive = false;
                                                    break;
                                                }
                                            }
                                            else
                                            {
                                                Battle.PlayerSpecialAttack(Player, Dragon);
                                                if (Dragon.health <= 0)
                                                {
                                                    Console.Clear();
                                                    Console.WriteLine("You have slain the {0}!", Dragon.name);
                                                    Console.ReadKey();
                                                    dragonAlive = false;
                                                    break;
                                                }
                                                specialCharge--;
                                                battleGen = choiceGen.Next(1, 5);
                                                switch (battleGen)
                                                {
                                                    case 1:
                                                        Battle.EnemyAttack(Player, Dragon);
                                                        if (Player.currentHealth <= 0)
                                                        {
                                                            Console.Clear();
                                                            break;
                                                        }
                                                        break;
                                                    case 2:
                                                        Battle.EnemyAttack(Player, Dragon);
                                                        if (Player.currentHealth <= 0)
                                                        {
                                                            Console.Clear();
                                                            break;
                                                        }
                                                        break;
                                                    case 3:
                                                        Battle.EnemyAttack(Player, Dragon);
                                                        if (Player.currentHealth <= 0)
                                                        {
                                                            Console.Clear();
                                                            break;
                                                        }
                                                        break;
                                                    case 4:
                                                        Battle.EnemyCharge(Player, Dragon);
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
                        else if (castleChoice == "2")
                        {
                            Console.Clear();
                            Console.WriteLine("You decide not to enter the castle");
                            Console.ReadKey();
                        }
                    }
                    else if (plainCleared == true && riverCleared == true && forestCleared == true)
                    {
                        Console.Clear();
                        Console.WriteLine("You have not yet traversed past the bridge");
                        Console.ReadKey();
                    }
                    else if (plainCleared == true && riverCleared == true)
                    {
                        Console.Clear();
                        Console.WriteLine("You have not yet traversed through the forest");
                        Console.ReadKey();
                    }
                    else if (plainCleared == true)
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
                else if (choice == "500")
                {
                    Player.ExperienceGain(500);
                    Player.gold += 500;
                }
                else if (choice == "Level Frog")
                {
                    Player.ExperienceGain(300);
                    Player.gold += 400;
                    plainCleared = true;
                }
                else if (choice == "Level Bear")
                {
                    Player.ExperienceGain(2100);
                    Player.gold += 2500;
                    plainCleared = true;
                    riverCleared = true;
                }
                else if (choice == "Level Troll")
                {
                    Player.ExperienceGain(4500);
                    Player.gold += 10000;
                    plainCleared = true;
                    riverCleared = true;
                    forestCleared = true;
                }
                else if (choice == "Level Dragon")
                {
                    Player.ExperienceGain(100000);
                    Player.gold += 100000;
                    plainCleared = true;
                    riverCleared = true;
                    forestCleared = true;
                    bridgeCleared = true;
                }
                else if (choice == "10000 Gold")
                {
                    Player.gold += 10000;
                }
                else if (choice == "100000")
                {
                    Player.ExperienceGain(100000);
                    Player.gold += 100000;
                }
                else
                {

                }
            }
            if (Player.currentHealth <= 0)
            {
                Console.Clear();
                Console.WriteLine("You have died in combat, Game Over!");
                Console.ReadKey();
            }
            else if (dragonAlive == false)
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