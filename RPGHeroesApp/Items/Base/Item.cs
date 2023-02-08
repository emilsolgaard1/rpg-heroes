using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGHeroesApp.Items.Base
{
    public enum Slot
    {
        Weapon,
        Head,
        Body,
        Legs
    }

    public abstract class Item
    {
        private string _name;
        private int _requiredLevel;
        private protected Slot _slot;

        public string Name => _name;
        public Slot Slot => _slot;
        public int RequiredLevel => _requiredLevel;

        public Item(string name, int requiredLevel)
        {
            _name = name;
            _requiredLevel = requiredLevel;
        }
    }
}
