using RPGHeroesApp.Attributes;
using RPGHeroesApp.Exceptions;
using RPGHeroesApp.Heroes;
using RPGHeroesApp.Items;
using RPGHeroesApp.Items.Base;

namespace RPGHeroesTests.Heroes
{
    public class HeroTests
    {
        [Fact]
        public void Hero_Constructor_CorrectName()
        {
            // Arrange
            Warrior warrior = new Warrior("Tester");

            // Act & Assert
            Assert.Equal("Tester", warrior.Name);
        }

        [Fact]
        public void Warrior_Contructor_CorrectAttributes()
        {
            // Arrange
            HeroAttribute expected = new HeroAttribute(5, 2, 1);

            // Act
            HeroAttribute actual = new Warrior("Tester").LevelAttributes;

            // Assert
            Assert.Equal(expected.Strength, actual.Strength);
            Assert.Equal(expected.Dexterity, actual.Dexterity);
            Assert.Equal(expected.Intelligence, actual.Intelligence);
        }
        [Fact]
        public void Mage_Contructor_CorrectAttributes()
        {
            // Arrange
            HeroAttribute expected = new HeroAttribute(1, 1, 8);

            // Act
            HeroAttribute actual = new Mage("Tester").LevelAttributes;

            // Assert
            Assert.Equal(expected.Strength, actual.Strength);
            Assert.Equal(expected.Dexterity, actual.Dexterity);
            Assert.Equal(expected.Intelligence, actual.Intelligence);
        }
        [Fact]
        public void Ranger_Contructor_CorrectAttributes()
        {
            // Arrange
            HeroAttribute expected = new HeroAttribute(1, 7, 1);

            // Act
            HeroAttribute actual = new Ranger("Tester").LevelAttributes;

            // Assert
            Assert.Equal(expected.Strength, actual.Strength);
            Assert.Equal(expected.Dexterity, actual.Dexterity);
            Assert.Equal(expected.Intelligence, actual.Intelligence);
        }
        [Fact]
        public void Rogue_Contructor_CorrectAttributes()
        {
            // Arrange
            HeroAttribute expected = new HeroAttribute(2, 6, 1);

            // Act
            HeroAttribute actual = new Rogue("Tester").LevelAttributes;

            // Assert
            Assert.Equal(expected.Strength, actual.Strength);
            Assert.Equal(expected.Dexterity, actual.Dexterity);
            Assert.Equal(expected.Intelligence, actual.Intelligence);
        }

        [Fact]
        public void LevelUp_CallOnce_LevelIncrementedByOne()
        {
            // Arrange
            Warrior warrior = new Warrior("Tester");

            // Act & Assert
            Assert.Equal(2, warrior.LevelUp());
        }

        [Fact]
        public void Warrior_LevelUp_GainCorrectAttributes()
        {
            // Arrange
            HeroAttribute expected = new HeroAttribute(5 + 3, 2 + 2, 1 + 1);
            Warrior warrior = new Warrior("Tester");

            // Act
            warrior.LevelUp();
            HeroAttribute actual = warrior.LevelAttributes;

            // Assert
            Assert.Equal(expected.Strength, actual.Strength);
            Assert.Equal(expected.Dexterity, actual.Dexterity);
            Assert.Equal(expected.Intelligence, actual.Intelligence);
        }
        [Fact]
        public void Mage_LevelUp_GainCorrectAttributes()
        {
            // Arrange
            HeroAttribute expected = new HeroAttribute(1 + 1, 1 + 1, 8 + 5);
            Mage mage = new Mage("Tester");

            // Act
            mage.LevelUp();
            HeroAttribute actual = mage.LevelAttributes;

            // Assert
            Assert.Equal(expected.Strength, actual.Strength);
            Assert.Equal(expected.Dexterity, actual.Dexterity);
            Assert.Equal(expected.Intelligence, actual.Intelligence);
        }
        [Fact]
        public void Ranger_LevelUp_CorrectAttributes()
        {
            // Arrange
            HeroAttribute expected = new HeroAttribute(1 + 1, 7 + 5, 1 + 1);
            Ranger ranger = new Ranger("Tester");

            // Act
            ranger.LevelUp();
            HeroAttribute actual = ranger.LevelAttributes;

            // Assert
            Assert.Equal(expected.Strength, actual.Strength);
            Assert.Equal(expected.Dexterity, actual.Dexterity);
            Assert.Equal(expected.Intelligence, actual.Intelligence);
        }
        [Fact]
        public void Rogue_LevelUp_CorrectAttributes()
        {
            // Arrange
            HeroAttribute expected = new HeroAttribute(2 + 1, 6 + 4, 1 + 1);
            Rogue rogue = new Rogue("Tester");

            // Act
            rogue.LevelUp();
            HeroAttribute actual = rogue.LevelAttributes;

            // Assert
            Assert.Equal(expected.Strength, actual.Strength);
            Assert.Equal(expected.Dexterity, actual.Dexterity);
            Assert.Equal(expected.Intelligence, actual.Intelligence);
        }

        [Fact]
        public void Equip_ArmorTypeAndLevelAppropriate_CorrectArmorEquipped()
        {
            // Arrange
            Warrior warrior = new Warrior("Tester");
            Armor armor = new Armor(ArmorType.Plate, Slot.Body, "TestArmor", 1);

            // Act & Assert
            Assert.Equal(armor, warrior.Equip(armor));
        }
        [Fact]
        public void Equip_WrongArmorType_InvalidArmorException()
        {
            // Arrange
            Warrior warrior = new Warrior("Tester");
            Armor armor = new Armor(ArmorType.Cloth, Slot.Body, "TestArmor", 1);

            // Act & Assert
            InvalidArmorException exception = Assert.Throws<InvalidArmorException>(() => warrior.Equip(armor));
            Assert.Equal(EquipmentExceptionType.Class, exception.ExceptionType);
        }
        [Fact]
        public void Equip_WrongArmorLevel_InvalidArmorException()
        {
            // Arrange
            Warrior warrior = new Warrior("Tester");
            Armor armor = new Armor(ArmorType.Plate, Slot.Body, "TestArmor", 2);

            // Act & Assert
            InvalidArmorException exception = Assert.Throws<InvalidArmorException>(() => warrior.Equip(armor));
            Assert.Equal(EquipmentExceptionType.Level, exception.ExceptionType);
        }

        [Fact]
        public void Equip_WeaponTypeAndLevelAppropriate_WeaponEquipped()
        {
            // Arrange
            Warrior warrior = new Warrior("Tester");
            Weapon weapon = new Weapon(WeaponType.Axe, "TestWeapon", 1);

            // Act & Assert
            Assert.Equal(weapon, warrior.Equip(weapon));
        }
        [Fact]
        public void Equip_WrongWeaponType_InvalidWeaponException()
        {
            // Arrange
            Warrior warrior = new Warrior("Tester");
            Weapon weapon = new Weapon(WeaponType.Staff, "TestWeapon", 1);

            // Act & Assert
            InvalidWeaponException exception = Assert.Throws<InvalidWeaponException>(() => warrior.Equip(weapon));
            Assert.Equal(EquipmentExceptionType.Class, exception.ExceptionType);
        }
        [Fact]
        public void Equip_WrongWeaponLevel_InvalidWeaponException()
        {
            // Arrange
            Warrior warrior = new Warrior("Tester");
            Weapon weapon = new Weapon(WeaponType.Axe, "TestWeapon", 2);

            // Act & Assert
            InvalidWeaponException exception = Assert.Throws<InvalidWeaponException>(() => warrior.Equip(weapon));
            Assert.Equal(EquipmentExceptionType.Level, exception.ExceptionType);
        }

        [Fact]
        public void TotalAttributes_NoArmor()
        {
            // Arrange
            Warrior warrior = new Warrior("Tester");

            HeroAttribute expected = new HeroAttribute(5, 2, 1);

            // Act
            HeroAttribute actual = warrior.TotalAttributes();

            // Assert
            Assert.Equal(expected.Strength, actual.Strength);
            Assert.Equal(expected.Dexterity, actual.Dexterity);
            Assert.Equal(expected.Intelligence, actual.Intelligence);
        }
        [Fact]
        public void TotalAttributes_OnePieceOfArmor()
        {
            // Arrange
            Warrior warrior = new Warrior("Tester");

            HeroAttribute expected = new HeroAttribute(5 + 4, 2 + 1, 1 + 0);

            // Act
            warrior.Equip(new Armor(ArmorType.Plate, Slot.Body, "TestBody", 1));
            HeroAttribute actual = warrior.TotalAttributes();

            // Assert
            Assert.Equal(expected.Strength, actual.Strength);
            Assert.Equal(expected.Dexterity, actual.Dexterity);
            Assert.Equal(expected.Intelligence, actual.Intelligence);
        }
        [Fact]
        public void TotalAttributes_TwoPiecesOfArmor()
        {
            // Arrange
            Warrior warrior = new Warrior("Tester");

            HeroAttribute expected = new HeroAttribute(5 + 4 + 4, 2 + 1 + 1, 1 + 0 + 0);

            // Act
            warrior.Equip(new Armor(ArmorType.Plate, Slot.Body, "TestBody", 1));
            warrior.Equip(new Armor(ArmorType.Plate, Slot.Legs, "TestLegs", 1));
            HeroAttribute actual = warrior.TotalAttributes();

            // Assert
            Assert.Equal(expected.Strength, actual.Strength);
            Assert.Equal(expected.Dexterity, actual.Dexterity);
            Assert.Equal(expected.Intelligence, actual.Intelligence);
        }
        [Fact]
        public void TotalAttributes_ReplacedPieceOfArmor()
        {
            // Arrange
            Warrior warrior = new Warrior("Tester");

            HeroAttribute expected = new HeroAttribute(5 + 4, 2 + 1, 1 + 0);

            // Act
            warrior.Equip(new Armor(ArmorType.Plate, Slot.Body, "TestBodyA", 1));
            warrior.Equip(new Armor(ArmorType.Plate, Slot.Body, "TestBodyB", 1));
            HeroAttribute actual = warrior.TotalAttributes();

            // Assert
            Assert.Equal(expected.Strength, actual.Strength);
            Assert.Equal(expected.Dexterity, actual.Dexterity);
            Assert.Equal(expected.Intelligence, actual.Intelligence);
        }

        [Fact]
        public void Damage_NoWeapon()
        {
            // Arrange
            Warrior warrior = new Warrior("Tester");

            decimal expected = 1 * (1 + warrior.TotalAttributes().AttributeByType(AttributeType.Strength) * 0.01m);

            // Act & Assert
            Assert.Equal(expected, warrior.Damage());
        }
        [Fact]
        public void Damage_WithWeapon()
        {
            // Arrange
            Warrior warrior = new Warrior("Tester");

            decimal expected = 10 * (1 + 5 * 0.01m);

            // Act
            warrior.Equip(new Weapon(WeaponType.Axe, "TestWeapon", 1));
            decimal actual = warrior.Damage();

            // Assert
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void Damage_WithReplacedWeapon()
        {
            // Arrange
            Warrior warrior = new Warrior("Tester");

            decimal expected = 11 * (1 + 5 * 0.01m);

            // Act
            warrior.Equip(new Weapon(WeaponType.Axe, "TestWeaponA", 1));
            warrior.Equip(new Weapon(WeaponType.Axe, "TestWeaponB", 1));
            decimal actual = warrior.Damage();

            // Assert
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void Damage_WithWeaponAndArmor()
        {
            // Arrange
            Warrior warrior = new Warrior("Tester");

            decimal expected = 10 * (1 + (5 + 4) * 0.01m);

            // Act
            warrior.Equip(new Weapon(WeaponType.Axe, "TestWeapon", 1));
            warrior.Equip(new Armor(ArmorType.Plate, Slot.Body, "TestBody", 1));
            decimal actual = warrior.Damage();

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
