using RPGHeroesApp.Attributes;
using RPGHeroesApp.Items;
using RPGHeroesApp.Items.Base;

namespace RPGHeroesTests.Items
{
    public class ItemTests
    {
        [Fact]
        public void Item_Constructor_CorrectName()
        {
            // Arrange
            Armor armor = new Armor(ArmorType.Cloth, Slot.Body, "TestBody", 1);

            // Act & Assert
            Assert.Equal("TestBody", armor.Name);
        }
        [Fact]
        public void Item_Constructor_CorrectRequiredLevel()
        {
            // Arrange
            Armor armor = new Armor(ArmorType.Cloth, Slot.Body, "TestBody", 1);

            // Act & Assert
            Assert.Equal(1, armor.RequiredLevel);
        }
        [Fact]
        public void Item_Constructor_CorrectSlot()
        {
            // Arrange
            Armor armor = new Armor(ArmorType.Cloth, Slot.Body, "TestBody", 1);

            // Act & Assert
            Assert.Equal(Slot.Body, armor.Slot);
        }

        [Fact]
        public void Armor_Constructor_CorrectType()
        {
            // Arrange
            Armor armor = new Armor(ArmorType.Cloth, Slot.Body, "TestBody", 1);

            // Act & Assert
            Assert.Equal(ArmorType.Cloth, armor.ArmorType);
        }
        [Fact]
        public void Armor_Constructor_CorrectAttributes()
        {
            // Arrange
            Armor armor = new Armor(ArmorType.Cloth, Slot.Body, "TestBody", 1);

            HeroAttribute expected = new HeroAttribute(0, 1, 4);

            // Act
            HeroAttribute actual = armor.ArmorAttribute;

            // Assert
            Assert.Equal(expected.Strength, actual.Strength);
            Assert.Equal(expected.Dexterity, actual.Dexterity);
            Assert.Equal(expected.Intelligence, actual.Intelligence);
        }

        [Fact]
        public void Weapon_Constructor_CorrectType()
        {
            // Arrange
            Weapon weapon = new Weapon(WeaponType.Axe, "TestWeapon", 1);

            // Act & Assert
            Assert.Equal(WeaponType.Axe, weapon.WeaponType);
        }
        [Fact]
        public void Weapon_Constructor_CorrectDamage()
        {
            // Arrange
            Weapon weapon = new Weapon(WeaponType.Axe, "TestWeapon", 1);

            int expected = 10;

            // Act
            int actual = weapon.WeaponDamage;

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
