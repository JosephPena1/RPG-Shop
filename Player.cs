using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace HelloWorld
{
    class Player
    {
        private int _gold;
        private Item[] _inventory;

        public Player()
        {
            _gold = 60;
            _inventory = new Item[3];
        }

        public bool Buy(Item item, int playerIndex)
        {
            if (_gold >= item.cost)
            {
                _gold -= item.cost;
                GetInventory();
                _inventory[playerIndex] = item;
                return true;
            }
            Console.WriteLine("\nNot enough money");
            Console.ReadKey();
            return false;
        }

        public Item[] GetInventory()
        {
            return _inventory;
        }

        public int GetGold()
        {
            return _gold;
        }
    }
}