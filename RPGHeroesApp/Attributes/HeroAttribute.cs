using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGHeroesApp.Attributes
{
    public enum AttributeType
    {
        Strength,
        Dexterity,
        Intelligence
    }

    public class HeroAttribute
    {
        private readonly Dictionary<AttributeType, int> _attributes;

        public int Strength => _attributes[AttributeType.Strength];
        public int Dexterity => _attributes[AttributeType.Dexterity];
        public int Intelligence => _attributes[AttributeType.Intelligence];

        public HeroAttribute(int strength, int dexterity, int intelligence)
        {
            _attributes = new Dictionary<AttributeType, int>()
            {
                { AttributeType.Strength, strength },
                { AttributeType.Dexterity, dexterity },
                { AttributeType.Intelligence, intelligence }
            };
        }

        /// <summary>
        /// Returns the attribute value by its corresponding <paramref name="type"/> key.
        /// </summary>
        /// <param name="type">The type of attribute to get value from.</param>
        /// <returns>Integer value from <see cref="HeroAttribute"/> key/value pair.</returns>
        public int AttributeByType(AttributeType type)
        {
            return _attributes[type];
        }

        /// <summary>
        /// Returns the sum of the calling <see cref="HeroAttribute"/> and a given <paramref name="otherAttribute"/>.
        /// </summary>
        /// <remarks>Note: Doesn't update attributes in the calling <see cref="HeroAttribute"/>.</remarks>
        /// <param name="otherAttribute">The attribute to sum with the given attribute.</param>
        /// <returns>Sum of the two attributes as a <see cref="HeroAttribute"/> object.</returns>
        public HeroAttribute SumWithAttribute(HeroAttribute otherAttribute)
        {
            return new HeroAttribute(
                _attributes[AttributeType.Strength] + otherAttribute.Strength,
                _attributes[AttributeType.Dexterity] + otherAttribute.Dexterity,
                _attributes[AttributeType.Intelligence] + otherAttribute.Intelligence
                );
        }
    }
}
