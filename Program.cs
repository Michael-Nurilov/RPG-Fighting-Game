using System;
using System.Collections.Generic;
using System.Linq;

namespace _RPG_Fighting_Game
{
	class Player
	{
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
				if (value < 0){
					_currentHealth = 0;
				} else if (value > 10000000){
					_currentHealth = 10000000;
				} else{
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
				if (value < 0){
					_topHealth = 0;
				} else if (value > 10000000){
					_topHealth = 10000000;
				} else{
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
				if (value < 0){
					_attack = 0;
				} else if (value > 1500000){
					_attack = 1500000;
				} else{
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
				if (value < 0){
					_defense = 0;
				} else if (value > 1000000){
					_defense = 1000000;
				} else{
					_defense = value;
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
				if (value < 0){
					_gold = 0;
				} else{
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
				if (value < 0){
					_experience = 0;
				} else{
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
				if (value < 1){
					_level = 1;
				} else if (value > 100){
					_level = 100;
				}
				else{
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
				if (value < 0){
					_specialBar = 0;
				} else if (value > 4){
					_specialBar = 4;
				} else{
					_specialBar = value;
				}
			}
		}
		public Player()
		{
			level = 1;
			experience = 0;
			currentHealth = 500;
			topHealth = 500;
			attack = 10;
			defense = 3;
			gold = 10000;
		}
		public void DisplayStats()
		{
			Console.Clear();
			Console.WriteLine("Level is: " + level);
			Console.WriteLine("Experience is: " + experience);
			Console.WriteLine("Health is: " + currentHealth);
			Console.WriteLine("Top health is: " + _topHealth);
			Console.WriteLine("Attack is: " + attack);
			Console.WriteLine("Defense is: " + defense);
			Console.WriteLine("Exp Needed: " + expNeeded);
			Console.ReadKey();
		}
		public void DisplaySpecialBar()
		{
			if (specialBar == 0){
				Console.WriteLine("Special Bar: ░░░░░░░░");
			} else if (specialBar == 1){
				Console.WriteLine("Special Bar: ██░░░░░░");
			} else if (specialBar == 2){
				Console.WriteLine("Special Bar: ████░░░░");
			} else if (specialBar == 3){
				Console.WriteLine("Special Bar: ██████░░");
			} else if (specialBar == 4){
				Console.WriteLine("Special Bar: ████████");
			} else{
				Console.WriteLine("Error");
			}
		}
		public void LevelUp()
		{
			if (level >= 100){
				experience = expNeeded;
			} else{
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
		public string name = "Enemy";

		public int health
		{
			get
			{
				return _health;
			} 
			set 
			{
				if (value < 0){
					_health = 0;
				} else if (value > 10000000){
					_health = 10000000;
				} else{
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
				if (value < 0){
					_attack = 0;
				} else if (value > 1500000){
					_attack = 1500000;
				} else{
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
				if (value < 0){
					_defense = 0;
				} else if (value > 1000000){
					_defense = 1000000;
				} else{
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
				if (value < 0){
					_experience = 0;
				} else{
					_experience = value;
				}
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
			chargeAttack = attack * 3;

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
			chargeDamage = attack * 3;

			int damage = chargeDamage - defense; 
			if (damage < 0)
			{
				damage = 0;
			}
			return damage;
		}
		public int SpecialAttackInterruption(int defense)
		{
			int specialAttackInterruption = (attack * 6) - defense;

			if (specialAttackInterruption < 0){
				specialAttackInterruption = 0;
			}
			return specialAttackInterruption;
		}
	}

	class Goblin : Enemy
	{
		public Goblin()
		{
			name = "Goblin";
			health = 500;
			attack = 10;
			defense = 2;
			experience = 50;
		}
	}

	class Item
	{
		public int ID;
		public string name;
		public int goldValue;
		public int quantity;
		public string description;
	}

	class Potion : Item
	{
		public int healingValue;

		public Potion(int _ID, string _name, int _goldValue, int _healingValue, int _quantity, string _description)
		{
			ID = _ID;
			name = _name;
			goldValue = _goldValue;
			healingValue = -_healingValue;
			quantity = _quantity;
			description = _description;
		}
	}

	class Store
	{
		public Potion BasicPotion = new Potion(1, "Basic Potion", 100, 50, 5, "Restores 50 Health");
		public Potion MegaPotion = new Potion(2, "Mega Potion", 500, 200, 5, "Restores 200 Health");
		public Potion GigaPotion = new Potion(3, "Giga Potion", 2000, 500, 5, "Restores 500 Health");

		public Potion BasicPotion1 = new Potion(1, "Basic Potion", 100, 50, 1, "Restores 50 Health");
		public Potion MegaPotion1 = new Potion(2, "Mega Potion", 500, 200, 1, "Restores 200 Health");
		public Potion GigaPotion1 = new Potion(3, "Giga Potion", 2000, 500, 1, "Restores 500 Health");

		public List<Item> StoreInventory = new List<Item>();

		public List<Item> BaseStoreInventory = new List<Item>();

		public void StoreSetup()
		{
			StoreInventory.Add(BasicPotion);
			StoreInventory.Add(MegaPotion);
			StoreInventory.Add(GigaPotion);
			BaseStoreInventory.Add(BasicPotion1);
			BaseStoreInventory.Add(MegaPotion1);
			BaseStoreInventory.Add(GigaPotion1);
		}
		public void DisplayStore(Player _Player)
		{
			Console.Clear();
			Console.WriteLine("Welcome to the store {0} what would you like to buy", _Player.name);
			Console.WriteLine("{0}'s Gold: {1}", _Player.name, _Player.gold);
			for (int i = 0; i < StoreInventory.Count; i++)
			{
				Console.WriteLine("{0} - {1} - {2} Gold - {3} - {4}x Quantity", StoreInventory[i].ID, StoreInventory[i].name, StoreInventory[i].goldValue,
				                  StoreInventory[i].description, StoreInventory[i].quantity);
			}
			Console.WriteLine();
			Console.WriteLine("Type 10 to Exit");
		}
		public void AddtoStore(Item item)
		{
			StoreInventory.Add(item);
		}
		public void RemovefromStore(Item item)
		{
			if (item.quantity > 0){
				item.quantity--;
			} else{
			}
		}
		public void RemovefromList(Item item)
		{
			StoreInventory.Remove(item);
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

		public void DisplayItems(Player _Player)
		{
			Console.Clear();

			List<Item> SortedPlayerBag = PlayerBag.OrderBy(o => o.ID).ToList();

			Console.WriteLine("{0}'s Inventory:", _Player.name);
			for (int i = 0; i < SortedPlayerBag.Count; i++)
			{
				Console.WriteLine("{0}x - {1} - {2}", SortedPlayerBag[i].quantity, SortedPlayerBag[i].name, SortedPlayerBag[i].description);
			}
			Console.ReadKey();
		}
		public void AddtoInventory(Player _player, Item _item)
		{
			_player.gold -= _item.goldValue;
			if (PlayerBag.Contains(_item) == true){
				_item.quantity++;
			} else{
				PlayerBag.Add(_item);
			}
		}
		public void RemovefromInventory(Player _player, Item _item)
		{
			if (_item.quantity > 0){
				_item.quantity--;
			} else{
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
		public void BattleInventory()
		{
			Console.Clear();

			List<Item> SortedPlayerBag = PlayerBag.OrderBy(o => o.ID).ToList();

			for (int i = 0; i < SortedPlayerBag.Count; i++)
			{
				Console.WriteLine("{0}x - {1} - {2}", SortedPlayerBag[i].quantity, SortedPlayerBag[i].name, SortedPlayerBag[i].description);
			}
			Console.ReadKey();
		}
	}

	class Battle
	{
		public void StartBattle(string name, int hp, string enemyName, int enemyHp, Player _player)
		{
			Console.Clear();
			Console.WriteLine("You have encountered a {0}, what will you do?", enemyName);
			Console.WriteLine("{0}'s Health: {1}", enemyName, enemyHp);
			Console.WriteLine("{0}'s Health: {1}", name, hp);
			_player.DisplaySpecialBar();
			Console.WriteLine("1 to Attack                          2 to Guard");
			Console.WriteLine("3 to use an Item                     4 to Run");
		}
		public void DuringBattle(string name, int hp, string enemyName, int enemyHp, Player _player)
		{
			Console.Clear();
			Console.WriteLine("What is your next move?");
			Console.WriteLine("{0}'s Health: {1}", enemyName, enemyHp);
			Console.WriteLine("{0}'s Health: {1}", name, hp);
			_player.DisplaySpecialBar();
			Console.WriteLine("1 to Attack                          2 to Guard");
			Console.WriteLine("3 to use an Item                     4 to Charge a Special Attack");
		}
		public void PlayerAttack(string name, int hp, string enemyName, int enemyHp, Goblin _goblin, Player _player)
		{
			Console.Clear();
			Console.WriteLine("{0} strikes the {1} for {2} damage", name, enemyName, _player.DamageDone(_goblin.defense));
			Console.WriteLine("{0}'s Health: {1}", enemyName, _player.Attack(_goblin.health, _goblin.defense));
			Console.WriteLine("{0}'s Health: {1}", name, hp);
			_player.DisplaySpecialBar();
			_goblin.health -= _player.DamageDone(_goblin.defense);
			Console.ReadKey();
		}
		public void PlayerSpecialAttackCharge(string name, int hp, string enemyName, int enemyHp, Player _player)
		{
			Console.Clear();
			Console.WriteLine("{0} begins charging for a special attack", name);
			Console.WriteLine("{0}'s Health: {1}", enemyName, enemyHp);
			Console.WriteLine("{0}'s Health: {1}", name, hp);
			_player.specialBar -= 4;
			_player.DisplaySpecialBar();
			Console.ReadKey();
		}
		public void PlayerSpecialBarNotEnough(string name, int hp, string enemyName, int enemyHp, Player _player)
		{
			Console.Clear();
			Console.WriteLine("{0} does not have enough special power built up", name);
			Console.WriteLine("{0}'s Health: {1}", enemyName, enemyHp);
			Console.WriteLine("{0}'s Health: {1}", name, hp);
			_player.DisplaySpecialBar();
			Console.ReadKey();
		}
		public void PlayerSpecialAttackInterrupted(string name, int hp, string enemyName, int enemyHp, Goblin _goblin, Player _player)
		{
			Console.Clear();
			Console.WriteLine("The {0} unleashes a massive attack on an unprepared {1} and deals {2} damage", enemyName, name, _goblin.SpecialAttackInterruption(_player.defense));
			Console.WriteLine("{0}'s Health: {1}", enemyName, enemyHp);
			Console.WriteLine("{0}'s Health: {1}", name, _player.currentHealth - _goblin.SpecialAttackInterruption(_player.defense));
			_player.DisplaySpecialBar();
			_player.currentHealth -= _goblin.SpecialAttackInterruption(_player.defense);
			Console.ReadKey();
		}
		public void PlayerSpecialAttack(string name, int hp, string enemyName, int enemyHp, Goblin _goblin, Player _player)
		{
			Console.Clear();
			Console.WriteLine("{0} unleashes a charged special power and strikes the {1} for {2} damage", name, enemyName, _player.SpecialAttack(_goblin.defense));
			Console.WriteLine("{0}'s Health: {1}", enemyName, _goblin.health - _player.SpecialAttack(_goblin.defense));
			Console.WriteLine("{0}'s Health: {1}", name, hp);
			_player.DisplaySpecialBar();
			_goblin.health -= _player.SpecialAttack(_goblin.defense);
			Console.ReadKey();
		}
		public void PlayerSpecialAttackInterrupt(string name, int hp, string enemyName, int enemyHp, Goblin _goblin, Player _player)
		{
			Console.Clear();
			Console.WriteLine("{0} unleashes a charged special power on an unprepared {1} and deals {2} damage", name, enemyName, _player.SpecialAttackInterrupt(_goblin.defense));
			Console.WriteLine("{0}'s Health: {1}", enemyName, _goblin.health - _player.SpecialAttackInterrupt(_goblin.defense));
			Console.WriteLine("{0}'s Health: {1}", name, hp);
			_player.DisplaySpecialBar();
			_goblin.health -= _player.SpecialAttackInterrupt(_goblin.defense);
			Console.ReadKey();
		}
		public void EnemyAttack(string name, int hp, string enemyName, int enemyHp, Goblin _goblin, Player _player)
		{
			Console.Clear();
			Console.WriteLine("The {0} strikes {1} for {2} damage", enemyName, name, _goblin.DamageDone(_player.defense));
			Console.WriteLine("{0}'s Health: {1}", enemyName, enemyHp);
			Console.WriteLine("{0}'s Health: {1}", name, _goblin.Attack(_player.currentHealth, _player.defense));
			_player.DisplaySpecialBar();
			_player.currentHealth -= _goblin.DamageDone(_player.defense); 
			Console.ReadKey();
		}
		public void EnemyCharge(string name, int hp, string enemyName, int enemyHp, Player _player)
		{
			Console.Clear();
			Console.WriteLine("The {0} is charging up for a massive attack", enemyName);
			Console.WriteLine("{0}'s Health: {1}", enemyName, enemyHp);
			Console.WriteLine("{0}'s Health: {1}", name, hp);
			_player.DisplaySpecialBar();
			Console.ReadKey();
		}
		public void EnemyChargeAttack(string name, int hp, string enemyName, int enemyHp, Goblin _goblin, Player _player)
		{
			Console.Clear();
			Console.WriteLine("The {0} unleashes a stored energy and strikes {1} for {2} damage", enemyName, name, _goblin.ChargeDamage(_player.defense));
			Console.WriteLine("{0}'s Health: {1}", enemyName, enemyHp);
			Console.WriteLine("{0}'s Health: {1}", name, _goblin.ChargeAttack(_player.currentHealth, _player.defense));
			_player.DisplaySpecialBar();
			_player.currentHealth -= _goblin.ChargeDamage(_player.defense); 
			Console.ReadKey();
		}
		public void Guard(string name, int hp, string enemyName, int enemyHp, Player _player)
		{
			Console.Clear();
			Console.WriteLine("{0} puts up a shield and prepares for an incoming attack", name);
			Console.WriteLine("{0}'s Health: {1}", enemyName, enemyHp);
			Console.WriteLine("{0}'s Health: {1}", name, hp);
			_player.specialBar--;
			_player.DisplaySpecialBar();
			Console.ReadKey();
		}
		public void GuardNormalBlock(string name, int hp, string enemyName, int enemyHp, Goblin _goblin, Player _player)
		{
			Console.Clear();
			Console.WriteLine("{0} guards against the {1}'s attack and takes {2} damage", name, enemyName, _player.Guard(_goblin.attack));
			Console.WriteLine("{0}'s Health: {1}", enemyName, enemyHp);
			Console.WriteLine("{0}'s Health: {1}", name, _player.currentHealth - _player.Guard(_goblin.attack));
			_player.DisplaySpecialBar();
			_player.currentHealth -= _player.Guard(_goblin.attack);
			Console.ReadKey();
		}
		public void GuardChargedBlock(string name, int hp, string enemyName, int enemyHp, Goblin _goblin, Player _player)
		{
			Console.Clear();
			Console.WriteLine("{0} guards against the {1}'s charged attack and takes {2} damage", name, enemyName, _player.Guard(_goblin.attack * 3));
			Console.WriteLine("{0}'s Health: {1}", enemyName, enemyHp);
			Console.WriteLine("{0}'s Health: {1}", name, _player.currentHealth - _player.Guard(_goblin.attack * 3));
			_player.DisplaySpecialBar();
			_player.currentHealth -= _player.Guard(_goblin.attack * 3);
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
			Console.WriteLine("Press 4 to view your inventory");
			Console.WriteLine("Press 5 to fight a goblin");
		}
		public static string Greeting()
		{
			Console.WriteLine("Welcome to the RPG fighting game your goal is to slay the evil dragon!");
			Console.WriteLine("Fight enemies, become stronger, and kill the dragon!");
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
			bool dragonAlive = true;
			Random choiceGen = new Random();

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
					Console.Clear();
					Player.currentHealth = Player.topHealth;
					Console.WriteLine("The nice maiden at the town inn tends to your wounds");
					Console.WriteLine("You health is restored!");
					Console.ReadKey();
				}
				else if (choice == "3")
				{
					bool goback = false;
					while(goback == false)
					{
						Store.DisplayStore(Player);
						string storeChoice = Console.ReadLine();
						for (int i = 0; i < Store.StoreInventory.Count; i++)
						{
							if (storeChoice == (Store.StoreInventory[i].ID.ToString()))
							{
								if (Store.StoreInventory[i].quantity > 0){
									if (Player.gold >= Store.StoreInventory[i].goldValue){
										PlayerInventory.SuccessfulPurchase(Store.BaseStoreInventory[i]);
										PlayerInventory.AddtoInventory(Player, Store.BaseStoreInventory[i]);
										Store.RemovefromStore(Store.StoreInventory[i]);
									} else if (Player.gold < Store.StoreInventory[i].goldValue){
										PlayerInventory.FailedPurchase();
									} else{
										Console.WriteLine("Error");
									}
								} else{
									Store.OutOfStock();
								}
							} else if (storeChoice == "10")
							{
								goback = true;
							}
						}
					}
				}
				else if (choice == "4")
				{
					PlayerInventory.DisplayItems(Player);
				}
				else if (choice == "5")
				{
					Goblin Goblin = new Goblin();
					int loop = 0;
					int runAway = 0;
					int loopCharge = 0;
					int specialCharge = 0;
					int goback = 0;
					while (Player.currentHealth > 0 && Goblin.health > 0)
					{
						if (loop == 0)
						{
							Battle.StartBattle(Player.name, Player.currentHealth, Goblin.name, Goblin.health, Player);
							loop++;
						} else
						{
							Battle.DuringBattle(Player.name, Player.currentHealth, Goblin.name, Goblin.health, Player);
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
							Battle.PlayerAttack(Player.name, Player.currentHealth, Goblin.name, Goblin.health, Goblin, Player);
							if (Goblin.health <= 0)
							{
								Console.Clear();
								Console.WriteLine("You have defeated the {0} and have gained {1} experience", Goblin.name, Goblin.experience);
								Player.ExperienceGain(Goblin.experience);
								Console.ReadKey();
								break;
							}
							if (loopCharge == 1)
							{
								Battle.EnemyChargeAttack(Player.name, Player.currentHealth, Goblin.name, Goblin.health, Goblin, Player);
								loopCharge = 0;
								if (Player.currentHealth <= 0)
								{
									Console.Clear();
									break;
								}
							}
							else 
							{
								int battleGen = choiceGen.Next(1,5);
								switch (battleGen)
								{
									case 1:
										Battle.EnemyAttack(Player.name, Player.currentHealth, Goblin.name, Goblin.health, Goblin, Player);
										if (Player.currentHealth <= 0)
										{
											Console.Clear();
											break;
										}
										break;
									case 2:
										Battle.EnemyAttack(Player.name, Player.currentHealth, Goblin.name, Goblin.health, Goblin, Player);
										if (Player.currentHealth <= 0)
										{
											Console.Clear();
											break;
										}
										break;
									case 3:
										Battle.EnemyAttack(Player.name, Player.currentHealth, Goblin.name, Goblin.health, Goblin, Player);
										if (Player.currentHealth <= 0)
										{
											Console.Clear();
											break;
										}
										break;
									case 4:
										Battle.EnemyCharge(Player.name, Player.currentHealth, Goblin.name, Goblin.health, Player);
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
							Battle.Guard(Player.name, Player.currentHealth, Goblin.name, Goblin.health, Player);
							if (loopCharge == 1)
							{
								Battle.GuardChargedBlock(Player.name, Player.currentHealth, Goblin.name, Goblin.health, Goblin, Player);
								loopCharge = 0;
								if (Player.currentHealth <= 0)
								{
									Console.Clear();
									break;
								}
							}
							else 
							{
								int battleGen = choiceGen.Next(1,5);
								switch (battleGen)
								{
									case 1:
										Battle.GuardNormalBlock(Player.name, Player.currentHealth, Goblin.name, Goblin.health, Goblin, Player);
										if (Player.currentHealth <= 0)
										{
											Console.Clear();
											break;
										}
										break;
									case 2:
										Battle.GuardNormalBlock(Player.name, Player.currentHealth, Goblin.name, Goblin.health, Goblin, Player);
										if (Player.currentHealth <= 0)
										{
											Console.Clear();
											break;
										}
										break;
									case 3:
										Battle.GuardNormalBlock(Player.name, Player.currentHealth, Goblin.name, Goblin.health, Goblin, Player);
										if (Player.currentHealth <= 0)
										{
											Console.Clear();
											break;
										}
										break;
									case 4:
										Battle.EnemyCharge(Player.name, Player.currentHealth, Goblin.name, Goblin.health, Player);
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
							
						}
						else if (battleChoice == "4")
						{
							if (Player.specialBar == 4)
							{
								Battle.PlayerSpecialAttackCharge(Player.name, Player.currentHealth, Goblin.name, Goblin.health, Player);
								specialCharge++;
								if (loopCharge == 1)
								{
									Battle.PlayerSpecialAttackInterrupted(Player.name, Player.currentHealth, Goblin.name, Goblin.health, Goblin, Player);
									specialCharge--;
									if (Player.currentHealth < 0)
									{
										Console.Clear();
										break;
									}
									loopCharge--;
									goback++;
								} 
							} else
							{
								Battle.PlayerSpecialBarNotEnough(Player.name, Player.currentHealth, Goblin.name, Goblin.health, Player);
								goback++;
							}
							if (goback == 0)
							{
								int battleGen = choiceGen.Next(1,5);
								switch (battleGen)
								{
									case 1:
										Battle.EnemyAttack(Player.name, Player.currentHealth, Goblin.name, Goblin.health, Goblin, Player);
										if (Player.currentHealth <= 0)
										{
											Console.Clear();
											break;
										}
										break;
									case 2:
										Battle.EnemyAttack(Player.name, Player.currentHealth, Goblin.name, Goblin.health, Goblin, Player);
										if (Player.currentHealth <= 0)
										{
											Console.Clear();
											break;
										}
										break;
									case 3:
										Battle.EnemyAttack(Player.name, Player.currentHealth, Goblin.name, Goblin.health, Goblin, Player);
										if (Player.currentHealth <= 0)
										{
											Console.Clear();
											break;
										}
										break;
									case 4:
										Battle.EnemyCharge(Player.name, Player.currentHealth, Goblin.name, Goblin.health, Player);
										loopCharge++;
										break;
									default:
										Console.WriteLine("Error");
										break;
								}
								if (loopCharge == 1)
								{
									Battle.PlayerSpecialAttackInterrupt(Player.name, Player.currentHealth, Goblin.name, Goblin.health, Goblin, Player);
									loopCharge--;
									if (Goblin.health <= 0)
									{
										Console.Clear();
										Console.WriteLine("You have defeated the {0} and have gained {1} experience", Goblin.name, Goblin.experience);
										Player.ExperienceGain(Goblin.experience);
										Console.ReadKey();
										break;
									}
								}
								else
								{
									Battle.PlayerSpecialAttack(Player.name, Player.currentHealth, Goblin.name, Goblin.health, Goblin, Player);
									specialCharge--;
									battleGen = choiceGen.Next(1,5);
									switch (battleGen)
									{
										case 1:
											Battle.EnemyAttack(Player.name, Player.currentHealth, Goblin.name, Goblin.health, Goblin, Player);
											if (Player.currentHealth <= 0)
											{
												Console.Clear();
												break;
											}
											break;
										case 2:
											Battle.EnemyAttack(Player.name, Player.currentHealth, Goblin.name, Goblin.health, Goblin, Player);
											if (Player.currentHealth <= 0)
											{
												Console.Clear();
												break;
											}
											break;
										case 3:
											Battle.EnemyAttack(Player.name, Player.currentHealth, Goblin.name, Goblin.health, Goblin, Player);
											if (Player.currentHealth <= 0)
											{
												Console.Clear();
												break;
											}
											break;
										case 4:
											Battle.EnemyCharge(Player.name, Player.currentHealth, Goblin.name, Goblin.health, Player);
											loopCharge++;
											break;
										default:
											Console.WriteLine("Error");
											break;
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
							Console.Clear();
							Console.WriteLine("Invalid Command");
							Console.ReadKey();
						}
					}
				} 
				else
				{
					Console.Clear();
					Console.WriteLine("Invalid Command");
					Console.ReadKey();
				}
			}
			Console.WriteLine("You have died in combat, Game Over!");
			Console.ReadKey();
		}
	}
}