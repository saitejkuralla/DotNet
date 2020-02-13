using Services.Utility;
using Services.Validations;

namespace Services
{
    [Validator(typeof(UserModelValidator))]
    public class UserModel: AbstractModel
    {
        public string Username { get; set; }

        public string password { get; set; }

        public string EmailAddress { get; set; }
    }
}
