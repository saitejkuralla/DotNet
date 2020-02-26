using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Services.Validations
{
    public class UserModelValidator:AbstractValidator<UserModel>
    {

        public UserModelValidator()
        {
            RuleFor(x => x.Username).NotEmpty().WithMessage("Username Required");

            RuleFor(x => x.EmailAddress).NotEmpty().WithMessage("EmailAddress Required");

            
        }
    }
}
