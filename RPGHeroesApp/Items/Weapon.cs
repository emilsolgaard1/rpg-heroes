using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RPGHeroesApp.Items.Base;

namespace RPGHeroesApp.Items
{
    public enum WeaponType
    {
        Axe,
        Bow,
        Dagger,
        Hammer,
        Staff,
        Sword,
        Wand
    }

    public class Weapon : Item
    {
        private readonly WeaponType _weaponType;
        private readonly int _weaponDamage;

        public WeaponType WeaponType => _weaponType;
        public int WeaponDamage => _weaponDamage;

        public Weapon(WeaponType weaponType, string name, int requiredLevel) : base(name, requiredLevel)
        {
            _slot = Slot.Weapon;
            _weaponType = weaponType;
            _weaponDamage = name.ToString().Length; // Damage is equal to the length of weapon name :D
        }
    }
}
