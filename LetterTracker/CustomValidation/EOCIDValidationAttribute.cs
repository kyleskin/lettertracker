using System;
using System.ComponentModel.DataAnnotations;

namespace LetterTracker.CustomValidation
{
    public class EOCIDValidationAttribute : ValidationAttribute
    {
        public EOCIDValidationAttribute()
            : base("{0} is required") { }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (string.IsNullOrEmpty(value?.ToString()))
                return new ValidationResult(FormatErrorMessage(validationContext.DisplayName));

            return value?.ToString()?.Length != 10
                ? new ValidationResult("Invalid EOC ID length")
                : ValidationResult.Success;
        }
    }
}

