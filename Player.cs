using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace HelloWorld
{
    class Player
    {
        private int gold;
        private Item[] inventory;

        public Player()
        {
            gold = 50;
            inventory = new Item[3];
        }

        public bool Buy(Item item, int playerIndex)
        {
            if (GetGold() <= 0)
            {
                return false;
            }
            else
            {

                return true;
            }
        }

        public Item[] GetInventory()
        {
            return inventory;
        }

        public int GetGold()
        {
            return gold;
        }
    }
}