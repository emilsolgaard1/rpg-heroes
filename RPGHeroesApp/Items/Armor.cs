using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RPGHeroesApp.Attributes;
using RPGHeroesApp.Items.Base;

namespace RPGHeroesApp.Items
{
    public enum ArmorType
    {
        Cloth,
        Leather,
        Mail,
        Plate
    }

    public class Armor : Item
    {
        private readonly ArmorType _armorType;
        private readonly HeroAttribute _armorAttribute;

        public ArmorType ArmorType => _armorType;
        public HeroAttribute ArmorAttribute => _armorAttribute;

        public Armor(ArmorType armorType, Slot slot, string name, int requiredLevel) : base(name, requiredLevel)
        {
            _slot = slot;
            _armorType = armorType;

            // Set values in armor attributes based on armor type.
            switch (armorType)
            {
                case ArmorType.Cloth:
                    _armorAttribute = new HeroAttribute(0, 1, 4);
                    break;
                case ArmorType.Leather:
                    _armorAttribute = new HeroAttribute(2, 3, 2);
                    break;
                case ArmorType.Mail:
                    _armorAttribute = new HeroAttribute(3, 2, 1);
                    break;
                case ArmorType.Plate:
                    _armorAttribute = new HeroAttribute(4, 1, 0);
                    break;
                default:
                    _armorAttribute = new HeroAttribute(0, 0, 0);
                    break;
            }
        }
    }
}
