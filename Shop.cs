using System;
using System.Collections.Generic;
using System.Text;

namespace HelloWorld
{
    class Shop
    {
        private int gold;
        private Item[] inventory;

        public Shop()
        {
            gold = 50;
            inventory = new Item[3];
        }

        public Shop(Item[] items)
        {
            for (int i = 0; i < items.Length; i++)
            {
                inventory[i] = items[i];
            }
        }

        public bool Sell(Player player, int shopIndex, int playerIndex)
        {
            return player.Buy(inventory[shopIndex], playerIndex);
        }

        public void CheckPlayerFunds(Player player)
        {
            Console.WriteLine();
        }
    }
}