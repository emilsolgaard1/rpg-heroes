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
        //private int _strength;
        //private int _dexterity;
        //private int _intelligence;
        private readonly Dictionary<AttributeType, int> _attributes;

        public int Strength => _attributes[AttributeType.Strength];
        public int Dexterity => _attributes[AttributeType.Dexterity];
        public int Intelligence => _attributes[AttributeType.Intelligence];

        public HeroAttribute(int strength, int dexterity, int intelligence)
        {
            //_strength = strength;
            //_dexterity = dexterity;
            //_intelligence = intelligence;
            _attributes = new Dictionary<AttributeType, int>()
            {
                { AttributeType.Strength, strength },
                { AttributeType.Dexterity, dexterity },
                { AttributeType.Intelligence, intelligence }
            };
        }

        public int AttributeByType(AttributeType type)
        {
            return _attributes[type];
        }

        public HeroAttribute SumWithAttribute(HeroAttribute otherAttribute)
        {
            return new HeroAttribute(
                //_strength + otherAttribute.Strength,
                //_dexterity + otherAttribute.Dexterity,
                //_intelligence + otherAttribute.Intelligence
                _attributes[AttributeType.Strength] + otherAttribute.Strength,
                _attributes[AttributeType.Dexterity] + otherAttribute.Dexterity,
                _attributes[AttributeType.Intelligence] + otherAttribute.Intelligence
                );
        }
    }
}
