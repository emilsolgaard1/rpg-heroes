using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGHeroesApp.Exceptions
{
    public enum EquipmentExceptionType
    {
        Class,
        Level
    }

    public class InvalidWeaponException : Exception
    {
        private readonly EquipmentExceptionType _exceptionType;

        public EquipmentExceptionType ExceptionType => _exceptionType;

        public override string Message
        {
            get
            {
                if (_exceptionType == EquipmentExceptionType.Class)
                    return "The weapon is incompatible with your class.";
                else if (_exceptionType == EquipmentExceptionType.Level)
                    return "Level requirement for the weapon is too high.";
                else
                    return "(Error!) EquipmentExceptionType is not valid.";
            }
        }

        public InvalidWeaponException(EquipmentExceptionType exceptionType)
        {
            _exceptionType = exceptionType;
        }
    }

    public class InvalidArmorException : Exception
    {
        private readonly EquipmentExceptionType _exceptionType;

        public EquipmentExceptionType ExceptionType => _exceptionType;

        public override string Message
        {
            get
            {
                if (_exceptionType == EquipmentExceptionType.Class)
                    return "The armor is incompatible with your class.";
                else if (_exceptionType == EquipmentExceptionType.Level)
                    return "Level requirement for the armor is too high.";
                else
                    return "(Error!) EquipmentExceptionType is not valid.";
            }
        }

        public InvalidArmorException(EquipmentExceptionType exceptionType)
        {
            _exceptionType = exceptionType;
        }
    }
}
