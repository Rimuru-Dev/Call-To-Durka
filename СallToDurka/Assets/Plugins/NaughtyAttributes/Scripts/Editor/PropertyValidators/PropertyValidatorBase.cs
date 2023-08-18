using System;
using System.Collections.Generic;
using Plugins.NaughtyAttributes.Scripts.Core.ValidatorAttributes;
using UnityEditor;

namespace Plugins.NaughtyAttributes.Scripts.Editor.PropertyValidators
{
    public abstract class PropertyValidatorBase
    {
        public abstract void ValidateProperty(SerializedProperty property);
    }

    public static class ValidatorAttributeExtensions
    {
        private static Dictionary<Type, PropertyValidatorBase> _validatorsByAttributeType;

        static ValidatorAttributeExtensions()
        {
            _validatorsByAttributeType = new Dictionary<Type, PropertyValidatorBase>();
            _validatorsByAttributeType[typeof(MinValueAttribute)] = new MinValuePropertyValidator();
            _validatorsByAttributeType[typeof(MaxValueAttribute)] = new MaxValuePropertyValidator();
            _validatorsByAttributeType[typeof(RequiredAttribute)] = new RequiredPropertyValidator();
            _validatorsByAttributeType[typeof(ValidateInputAttribute)] = new ValidateInputPropertyValidator();
        }

        public static PropertyValidatorBase GetValidator(this ValidatorAttribute attr)
        {
            PropertyValidatorBase validator;
            if (_validatorsByAttributeType.TryGetValue(attr.GetType(), out validator))
            {
                return validator;
            }
            else
            {
                return null;
            }
        }
    }
}
