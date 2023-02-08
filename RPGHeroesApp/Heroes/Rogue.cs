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
    public class Rogue : Hero
    {
        public Rogue(string name) : base(name)
        {
            _levelAttributes = new HeroAttribute(2, 6, 1);
            _levelAttributesGain = new HeroAttribute(1, 4, 1);
            _damageAttribute = AttributeType.Dexterity;
            _validWeaponTypes = new WeaponType[] { WeaponType.Dagger, WeaponType.Sword };
            _validArmorTypes = new ArmorType[] { ArmorType.Leather, ArmorType.Mail };
        }
    }
}
