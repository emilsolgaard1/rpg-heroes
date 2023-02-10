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
        private readonly string _name;
        private int _level;
        private readonly Dictionary<Slot, Item?> _equipment;

        private protected HeroAttribute _levelAttributes;
        private protected HeroAttribute _levelAttributesGain;
        private protected AttributeType _damageAttribute;
        private protected WeaponType[] _validWeaponTypes;
        private protected ArmorType[] _validArmorTypes;

        public string Name => _name;
        public HeroAttribute LevelAttributes => _levelAttributes;

        public Hero(string name)
        {
            _name = name;
            _level = 1;
            _equipment = new Dictionary<Slot, Item?>()
            {
                { Slot.Weapon, null },
                { Slot.Head, null },
                { Slot.Body, null },
                { Slot.Legs, null }
            };
        }

        /// <summary>
        /// Increments <see cref="Hero"/> level by one.
        /// Adds attributes to <see cref="Hero"/> based on level attribute gain.
        /// Writes "level" message to console.
        /// </summary>
        /// <returns>The new level value as integer.</returns>
        public int LevelUp()
        {
            _level++;
            _levelAttributes = _levelAttributes.SumWithAttribute(_levelAttributesGain);

            Console.WriteLine($"\n[You are now level {_level}]");

            return _level;
        }

        /// <summary>
        /// Tries to add a given <paramref name="item"/> to <see cref="Hero"/> equipment.
        /// </summary>
        /// <param name="item">The <see cref="Item"/> object to add.</param>
        /// <remarks>Note: Try/Catch is disabled for testing requirements.</remarks>
        /// <returns>The <see cref="Item"/> object if successful, or null if equip failed.</returns>
        /// <exception cref="InvalidWeaponException">Gets thrown if <see cref="Item"/> is neither in valid <see cref="Weapon"/> array or level requirement is not met.</exception>
        /// <exception cref="InvalidArmorException">Gets thrown if <see cref="Item"/> is neither in valid <see cref="Armor"/> array or level requirement is not met.</exception>
        public Item? Equip(Item item)
        {
            //try
            //{
                if (item is Weapon weapon)
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
                        return _equipment[weapon.Slot];
                    }

                }
                else if (item is Armor armor)
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
                        return _equipment[armor.Slot];
                    }
                }
                else
                {
                    Console.WriteLine("... but nothing happened.");
                    return null;
                }
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine($"[But a failure happened: {ex.Message}]");
            //    return null;
            //}
        }

        /// <summary>
        /// Calculates the damage done by the <see cref="Hero"/> based on their "damage attribute" with equipped <see cref="Armor"/> aswell as "weapon damage" of equipped <see cref="Weapon"/>.
        /// </summary>
        /// <returns>The damage done as a <see cref="decimal"/> value.</returns>
        public decimal Damage()
        {
            return (_equipment[Slot.Weapon] is Weapon weapon ? weapon.WeaponDamage : 1) * (1 + TotalAttributes().AttributeByType(_damageAttribute) * 0.01m);
        }

        /// <summary>
        /// Calculates the sum of attributes from <see cref="Hero"/> and equipped <see cref="Armor"/>.
        /// </summary>
        /// <returns>The sum of attributes as a <see cref="HeroAttribute"/> object.</returns>
        public HeroAttribute TotalAttributes()
        {
            HeroAttribute totalAttributes = _levelAttributes;
            if (_equipment[Slot.Head] is Armor head) totalAttributes = totalAttributes.SumWithAttribute(head.ArmorAttribute);
            if (_equipment[Slot.Body] is Armor body) totalAttributes = totalAttributes.SumWithAttribute(body.ArmorAttribute);
            if (_equipment[Slot.Legs] is Armor legs) totalAttributes = totalAttributes.SumWithAttribute(legs.ArmorAttribute);

            return totalAttributes;
        }

        /// <summary>
        /// Creates a <see cref="string"/> of all info about <see cref="Hero"/>.
        /// </summary>
        /// <returns>A <see cref="string"/> for writing to console.</returns>
        public string Display()
        {
            string headText = _equipment[Slot.Head] is Armor head ? $"the ({head.ArmorType}) {head.Name}" : "nothing";
            string bodyText = _equipment[Slot.Body] is Armor body ? $"the ({body.ArmorType}) {body.Name}" : "nothing";
            string legsText = _equipment[Slot.Legs] is Armor legs ? $"the ({legs.ArmorType}) {legs.Name}" : "nothing";

            HeroAttribute totalAttributes = TotalAttributes();

            string weaponText = _equipment[Slot.Weapon] is Weapon weapon ? $"{weapon.Name} ({weapon.WeaponType})" : "only your bare hands...";

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
