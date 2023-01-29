using System;
using System.ComponentModel.DataAnnotations;

namespace LetterTracker.CustomValidation
{
    public class ManualProcessAttribute : ValidationAttribute
    {
        public ManualProcessAttribute() : base("{0} is required.") { }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            return base.IsValid(value, validationContext);
        }
    }
}

