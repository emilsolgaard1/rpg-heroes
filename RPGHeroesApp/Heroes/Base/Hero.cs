using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RPGHeroesApp.Attributes;
using RPGHeroesApp.Exceptions;
using RPGHeroesApp.Items;
using RPGHeroesApp.Items.Base;

namespace RPGHeroesApp.Heroes.Base
{
    public abstract class Hero
    {
        private string _name;
        private int _level;

        private protected Dictionary<Slot, Item> _equipment;
        private protected HeroAttribute _levelAttributes;
        private protected HeroAttribute _levelAttributesGain;
        private protected AttributeType _damageAttribute;
        private protected WeaponType[] _validWeaponTypes;
        private protected ArmorType[] _validArmorTypes;

        public Hero(string name)
        {
            _name = name;
            _level = 1;
            _equipment = new Dictionary<Slot, Item>()
            {
                { Slot.Weapon, null },
                { Slot.Head, null },
                { Slot.Body, null },
                { Slot.Legs, null }
            };
        }

        public virtual void LevelUp()
        {
            _level++;
            _levelAttributes = _levelAttributes.SumWithAttribute(_levelAttributesGain);

            Console.WriteLine($"\n[You are now level {_level}]");
        }

        public virtual void Equip(Item item)
        {
            try
            {
                Weapon weapon = item as Weapon;// ? (Weapon)item : null;
                Armor armor = item as Armor;// ? (Armor)item : null;
                if (weapon != null)
                {
                    Console.WriteLine($"\nYou try to equip the {weapon.Name}...");
                    if (!_validWeaponTypes.Contains(weapon.WeaponType))
                        throw new InvalidWeaponException(EquipmentExceptionType.Class);
                    else if (weapon.RequiredLevel > _level)
                        throw new InvalidWeaponException(EquipmentExceptionType.Level);
                    else
                    {
                        _equipment[weapon.Slot] = weapon;
                        Console.WriteLine($"[The {weapon.Name} feels powerful! Your damage will surely increase with this in hand!]");
                    }

                }
                else if (armor != null)
                {
                    Console.WriteLine($"\nYou try to wear the {armor.Name}...");
                    if (!_validArmorTypes.Contains(armor.ArmorType))
                        throw new InvalidArmorException(EquipmentExceptionType.Class);
                    else if (armor.RequiredLevel > _level)
                        throw new InvalidArmorException(EquipmentExceptionType.Level);
                    else
                    {
                        _equipment[armor.Slot] = armor;
                        Console.WriteLine($"[The {armor.Name} fits perfectly and gives you some nice attributes to boot!]");
                    }
                }
                else
                    Console.WriteLine("... but nothing happened.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[But a failure happened: {ex.Message}]");
            }
        }

        public virtual float Damage()
        {
            Weapon weapon = _equipment[Slot.Weapon] as Weapon;

            return (float)((weapon != null ? weapon.WeaponDamage : 1) * (1 + TotalAttributes().AttributeByType(_damageAttribute) * 0.01));
        }

        public virtual HeroAttribute TotalAttributes()
        {
            Armor head = _equipment[Slot.Head] as Armor;// ? (Armor)_equipment[Slot.Head] : null;
            Armor body = _equipment[Slot.Body] as Armor;// ? (Armor)_equipment[Slot.Body] : null;
            Armor legs = _equipment[Slot.Legs] as Armor;// ? (Armor)_equipment[Slot.Legs] : null;

            HeroAttribute totalAttributes = _levelAttributes;
            if (head != null) totalAttributes = totalAttributes.SumWithAttribute(head.ArmorAttribute);
            if (body != null) totalAttributes = totalAttributes.SumWithAttribute(body.ArmorAttribute);
            if (legs != null) totalAttributes = totalAttributes.SumWithAttribute(legs.ArmorAttribute);

            return totalAttributes;
        }

        public virtual string Display()
        {
            Armor head = _equipment[Slot.Head] as Armor;// ? (Armor)_equipment[Slot.Head] : null;
            string headText = head != null ? $"the ({head.ArmorType}) {head.Name}" : "nothing";
            Armor body = _equipment[Slot.Body] as Armor;// ? (Armor)_equipment[Slot.Body] : null;
            string bodyText = body != null ? $"the ({body.ArmorType}) {body.Name}" : "nothing";
            Armor legs = _equipment[Slot.Legs] as Armor;// ? (Armor)_equipment[Slot.Legs] : null;
            string legsText = legs != null ? $"the ({legs.ArmorType}) {legs.Name}" : "nothing";

            HeroAttribute totalAttributes = TotalAttributes();

            Weapon weapon = _equipment[Slot.Weapon] as Weapon;// ? (Weapon)_equipment[Slot.Weapon] : null;
            string weaponText = weapon != null ? $"{weapon.Name} ({weapon.WeaponType})" : "only your bare hands...";

            return
                $"\n--------------------" +
                $"\nYou are {_name}." +
                $"\nA level {_level} {GetType().Name}" +
                $"\n" +
                $"\nYou are currently wearing:" +
                $"\n{headText} on your head," +
                $"\n{bodyText} on your body," +
                $"\nand {legsText} on your legs." +
                $"\n" +
                $"\nYou are currently wielding: {weaponText}." +
                $"\n" +
                $"\nYour total attributes are:" +
                $"\nStrength:       {totalAttributes.Strength}" +
                $"\nDexterity:      {totalAttributes.Dexterity}" +
                $"\nIntelligence:   {totalAttributes.Intelligence}" +
                $"\n" +
                $"\nYou're dealing {Damage()} points of damage." +
                $"\n--------------------";
        }
    }
}
