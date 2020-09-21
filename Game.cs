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
        private Item[] shopInventory;
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
            Console.WriteLine("Welcome to my shop! \nWhat would you like to buy?");
            OpenShopMenu();

        }

        //Repeated until the game ends
        public void Update()
        {
            _shop.Sell(_player, 0, 0);
            _gameOver = true;
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
            shield.name = "shield";

            gem.cost = 30;
            gem.name = "Gem";

            shopInventory[0] = arrow;
            shopInventory[1] = shield;
            shopInventory[2] = gem;
        }

        private void OpenShopMenu()
        {
            
        }

        //prints a given inventory
        public Item PrintInventory(Item[] items)
        {
            for (int i = 0; i < items.Length; i++)
            {
                Console.WriteLine(items[i]);
            }
            return items[0];
        }
    }
}