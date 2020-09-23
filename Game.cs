using System;
using System.Collections.Generic;
using System.Text;

namespace HelloWorld
{

    struct Item
    {
        public int cost;
        public string name;
    }

    class Game
    {
        private Player _player = new Player();
        private Shop _shop = new Shop();
        private Item _arrow;
        private Item _shield;
        private Item _gem;
        private Item[] _shopInventory = new Item[3];
        private bool _gameOver = false;

        //Run the game
        public void Run()
        {
            Start();

            while (_gameOver == false)
            {
                Update();
            }

            End();
        }

        //Performed once when the game begins
        public void Start()
        {
            Console.WriteLine("Welcome to my shop!");
            InitItems();
        }

        //Repeated until the game ends
        public void Update()
        {
            OpenShopMenu();
        }

        //Performed once when the game ends
        public void End()
        {

        }

        //Initializes items
        private void InitItems()
        {
            _arrow.cost = 10;
            _arrow.name = "Arrow";

            _shield.cost = 20;
            _shield.name = "Shield";

            _gem.cost = 30;
            _gem.name = "Gem";

            _shopInventory[0] = _arrow;
            _shopInventory[1] = _shield;
            _shopInventory[2] = _gem;
            _shop = new Shop(_shopInventory);
        }

        private void OpenShopMenu()
        {
            Console.WriteLine("What would you like to buy?");
            Console.WriteLine("\nGold: " + _player.GetGold());
            PrintInventory(_shopInventory);

            //stores what item the player wants.
            Console.Write("> ");
            char itemChoice = Console.ReadKey().KeyChar;
            int itemIndex = -1;
            switch (itemChoice)
            {
                case '1':
                    itemIndex = 0;
                    break;
                case '2':
                    itemIndex = 1;
                    break;
                case '3':
                    itemIndex = 2;
                    break;
            }

            if (_shop.CheckPlayerFunds(_player) == false)
            {
                Console.WriteLine("\nyou don't have any gold left");
                _gameOver = true;
                return;
            }

            //stores which slot the player wants the item in.
            Console.Clear();
            //Console.WriteLine("");
            Console.WriteLine("Which slot would you like to replace?");
            PrintInventory(_player.GetInventory());
            Console.Write("> ");
            char slotChoice = Console.ReadKey().KeyChar;
            int slotIndex = -1;
            switch (slotChoice)
            {
                case '1':
                    slotIndex = 0;
                    break;

                case '2':
                    slotIndex = 1;
                    break;

                case '3':
                    slotIndex = 2;
                    break;
            }

            _shop.Sell(_player, itemIndex, slotIndex);
            Console.WriteLine();
            Console.Clear();

        }

        //prints a given inventory
        public void PrintInventory(Item[] inventory)
        {
            for (int i = 0; i < inventory.Length; i++)
            {
                Console.WriteLine((i + 1) + ". " + inventory[i].name);
            }
        }

        public void GetInput(out char input, string option1, string option2, string option3)
        {
            input = Console.ReadKey().KeyChar;
            Console.WriteLine("1. " + option1);
            Console.WriteLine("2. " + option2);
            Console.WriteLine("3. " + option3);
        }
    }
}