using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RPGHeroesApp.Attributes;
using RPGHeroesApp.Heroes.Base;
using RPGHeroesApp.Items;

namespace RPGHeroesApp.Heroes
{
    public class Mage : Hero
    {
        public Mage(string name) : base(name)
        {
            _levelAttributes = new HeroAttribute(1, 1, 8);
            _levelAttributesGain = new HeroAttribute(1, 1, 5);
            _damageAttribute = AttributeType.Intelligence;
            _validWeaponTypes = new WeaponType[] { WeaponType.Staff, WeaponType.Wand };
            _validArmorTypes = new ArmorType[] { ArmorType.Cloth };
        }
    }
}
