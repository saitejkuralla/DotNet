using FluentValidation;
using FluentValidation.Results;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Services.Utility
{
    public abstract class AbstractModel
    {
        public IList<ValidationFailure> Errors { get; set; }

        [NonSerialized]
        private IValidator _validator;

        [JsonIgnore]
        public IValidator Validator
        {
            get
            {
                return _validator;
            }
            set
            {
                _validator = value;
            }
        }

        public ValidationResult Validate()
        {
            var result = Validator.Validate(this);
            this.Errors = result.Errors;
            return result;
        }
    }
}
