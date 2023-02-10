using RPGHeroesApp.Attributes;

namespace RPGHeroesTests.Attributes
{
    public class HeroAttributeTests
    {
        [Theory]
        [InlineData(AttributeType.Strength, 1)]
        [InlineData(AttributeType.Dexterity, 2)]
        [InlineData(AttributeType.Intelligence, 3)]
        public void AttributeByType_GetByDifferentTypes_ValuesOfTypes(AttributeType type, int expected)
        {
            // Arrange
            HeroAttribute attribute = new HeroAttribute(1, 2, 3);

            // Act & Assert
            Assert.Equal(expected, attribute.AttributeByType(type));
        }

        [Theory]
        [InlineData(AttributeType.Strength, 2)]
        [InlineData(AttributeType.Dexterity, 4)]
        [InlineData(AttributeType.Intelligence, 6)]
        public void SumWithAttribute_SumTwoAttributes_Sum(AttributeType type, int expected)
        {
            // Arrange
            HeroAttribute attribute = new HeroAttribute(1, 2, 3);
            HeroAttribute otherAttribute = new HeroAttribute(1, 2, 3);

            // Act & Assert
            Assert.Equal(expected, attribute.SumWithAttribute(otherAttribute).AttributeByType(type));
        }
    }
}
