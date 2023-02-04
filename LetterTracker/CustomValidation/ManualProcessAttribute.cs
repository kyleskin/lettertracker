using System;
using System.ComponentModel.DataAnnotations;
using LetterTracker.Models;

namespace LetterTracker.CustomValidation
{
    public class ManualProcessAttribute : ValidationAttribute
    {
        private readonly ManualProcessEnum BusinessDayAllowedProcesses = ManualProcessEnum.CageInMailRoom | ManualProcessEnum.SecurityDesk | ManualProcessEnum.PostOfficeUspsCollectionBox;
        private readonly ManualProcessEnum SaturdayAllowedProcesses = ManualProcessEnum.SecurityDesk | ManualProcessEnum.PostOfficeUspsCollectionBox;
        private readonly ManualProcessEnum SundayAllowedProcesses = ManualProcessEnum.PostOfficeUspsCollectionBox;
        private readonly ManualProcessEnum HolidayAllowedProcesses = ManualProcessEnum.PostOfficeUspsCollectionBox;


        public ManualProcessAttribute() : base("{0} is required.") { }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value is null)
                return new ValidationResult("A manual process is required");

            var searchModel = validationContext.ObjectInstance as LetterTrackingSearchModel;
            if (searchModel!.ManualProcessDay == ManualProcessDayEnum.BusinessDay)
                if (BusinessDayAllowedProcesses.HasFlag((ManualProcessEnum)value))
                    return ValidationResult.Success;
            if (searchModel!.ManualProcessDay == ManualProcessDayEnum.Saturday)
                if (SaturdayAllowedProcesses.HasFlag((ManualProcessEnum)value))
                    return ValidationResult.Success;
            if (searchModel!.ManualProcessDay == ManualProcessDayEnum.Sunday)
                if (SundayAllowedProcesses.HasFlag((ManualProcessEnum)value))
                    return ValidationResult.Success;
            if (searchModel!.ManualProcessDay == ManualProcessDayEnum.Holiday)
                if (HolidayAllowedProcesses.HasFlag((ManualProcessEnum)value))
                    return ValidationResult.Success;

            return new ValidationResult("Not a valid manual process for the selected day.");
        }
    }
}

