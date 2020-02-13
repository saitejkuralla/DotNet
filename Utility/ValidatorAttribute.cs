using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Services.Utility
{
    [AttributeUsage(AttributeTargets.Class)]
    public class ValidatorAttribute : Attribute
    {
        private readonly Type _validator;

        public ValidatorAttribute(Type validator)
        {
            _validator = validator;
        }

        public Type Validator
        {
            get { return _validator; }
        }
    }
}
