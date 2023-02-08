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
    public class Warrior : Hero
    {
        public Warrior(string name) : base(name)
        {
            _levelAttributes = new HeroAttribute(5, 2, 1);
            _levelAttributesGain = new HeroAttribute(3, 2, 1);
            _damageAttribute = AttributeType.Strength;
            _validWeaponTypes = new WeaponType[] { WeaponType.Axe, WeaponType.Hammer, WeaponType.Sword };
            _validArmorTypes = new ArmorType[] { ArmorType.Mail, ArmorType.Plate };
        }
    }
}
