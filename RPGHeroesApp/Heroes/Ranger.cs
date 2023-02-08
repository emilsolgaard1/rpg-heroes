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
    public class Ranger : Hero
    {
        public Ranger(string name) : base(name)
        {
            _levelAttributes = new HeroAttribute(1, 7, 1);
            _levelAttributesGain = new HeroAttribute(1, 5, 1);
            _damageAttribute = AttributeType.Dexterity;
            _validWeaponTypes = new WeaponType[] { WeaponType.Bow };
            _validArmorTypes = new ArmorType[] { ArmorType.Leather, ArmorType.Mail };
        }
    }
}
