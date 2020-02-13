using FluentValidation;
using System;

namespace Services.Utility
{
    public static class ValidationExtenstions
    {
        public static void SetValidator(this AbstractModel model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model), "Intialize the model before calling GetValidator");
            }

            if (model.Validator != null)
            {
                return;
            }

            var type = model.GetType();
            var validatorAttributes = type.GetCustomAttributes(typeof(ValidatorAttribute), true);

            if (validatorAttributes.Length > 0)
            {
                var validatorAttribute = (ValidatorAttribute)validatorAttributes[0];
                model.Validator = Activator.CreateInstance(validatorAttribute.Validator) as IValidator;
            }
        }
    }
}
