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
        private Item arrow;
        private Item shield;
        private Item gem;
        private Item[] shopInventory = new Item[3];
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
            arrow.cost = 10;
            arrow.name = "Arrow";

            shield.cost = 20;
            shield.name = "Shield";

            gem.cost = 30;
            gem.name = "Gem";

            shopInventory[0] = arrow;
            shopInventory[1] = shield;
            shopInventory[2] = gem;
            _shop = new Shop(shopInventory);
        }

        private void OpenShopMenu()
        {

            Console.WriteLine("Welcome to my shop! \nWhat would you like to buy?");
            Console.WriteLine("\nGold: " + _player.GetGold());
            PrintInventory(shopInventory);

            //stores what item the player wants.
            Console.Write("> ");
            char itemChoice = Console.ReadKey().KeyChar;
            int itemIndex = 0;
            switch(itemChoice)
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
            Console.WriteLine("");
            PrintInventory(_player.GetInventory());

            Console.WriteLine("Which slot would you like to replace?");
            Console.Write("> ");
            char slotChoice = Console.ReadKey().KeyChar;
            int slotIndex = 0;
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
        public void PrintInventory(Item[] items)
        {
            for (int i = 0; i < items.Length; i++)
            {
                Console.WriteLine((i + 1) + ". " + items[i].name);
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