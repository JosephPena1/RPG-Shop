using System;
using System.Collections.Generic;
using System.Text;

namespace HelloWorld
{
    class Shop
    {
        private int _gold;
        private Item[] _inventory;

        public Shop()
        {
            _gold = 50;
            _inventory = new Item[3];
        }

        public Shop(Item[] items)
        {
            _gold = 50;
            _inventory = items;
        }

        public bool Sell(Player player, int shopIndex, int playerIndex)
        {
            Item itemToBuy = _inventory[shopIndex];
            if (player.Buy(itemToBuy, playerIndex))
            {
                _gold += itemToBuy.cost;
                return true;
            }
            return false;
        }

        public bool CheckPlayerFunds(Player player)
        {
            if (player.GetGold() <= 0)
            {
                return false;
            }
            return true;
        }
    }
}