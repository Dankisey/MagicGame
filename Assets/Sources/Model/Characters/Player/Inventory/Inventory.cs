using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Game.Model
{
    public sealed class Inventory
    {
        private readonly List<Cell> _cells;

        public Inventory()
        {
            _cells = new List<Cell>();
        }

        public void AddItem(ICollectable item, int amount)
        {
            Cell cell = _cells.FirstOrDefault(cell => cell.Item.GetType() == item.GetType());

            if (cell == null)
                _cells.Add(new Cell(item, amount));
            else
                cell.AddItem(amount);
        }
    }

    public sealed class Cell
    {
        public ICollectable Item { get; private set; }
        public int Amount { get; private set; }

        public Cell(ICollectable item, int amount)
        {
            Item = item;
            Amount = amount;
        }

        public void Use()
        {
            if (Amount <= 0)
                return;

            if (Item is IUsable usable)
            {
                usable.Use();
                Amount--;
            }
        }

        public void AddItem(int amount)
        {
            Amount += amount;
        }
    }
}