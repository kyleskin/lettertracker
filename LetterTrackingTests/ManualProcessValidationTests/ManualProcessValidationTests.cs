using System;
using System.ComponentModel.DataAnnotations;
using LetterTracker.CustomValidation;
using LetterTracker.Models;

namespace PaManualMailTrackingTests.ManualProcessValidationTests
{
    public class ManualProcessValidationTests
    {
        [Theory]
        [InlineData(ManualProcessEnum.CageInMailRoom)]
        [InlineData(ManualProcessEnum.SecurityDesk)]
        [InlineData(ManualProcessEnum.PostOfficeUspsCollectionBox)]
        public void BusinessDayShouldBeValidWithValidProcesses(ManualProcessEnum process)
        {
            var sut = new PaManualMailTrackingSearchModel
            {
                ManualProcessDay = ManualProcessDayEnum.BusinessDay,
                BusinessDayManualProcessRadioOption = process.ToString()
            };
            var context = new ValidationContext(sut);
            var results = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(sut, context, results, true);

            Assert.True(isValid);
        }

        [Fact]
        public void BusinessDayShouldBeInvalidWithInvalidProcesses()
        {
            var sut = new PaManualMailTrackingSearchModel
            {
                ManualProcessDay = ManualProcessDayEnum.BusinessDay,
                BusinessDayManualProcessRadioOption = ManualProcessEnum.None.ToString()
            };
            var context = new ValidationContext(sut);
            var results = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(sut, context, results, true);

            Assert.False(isValid);
        }

        [Theory]
        [InlineData(ManualProcessEnum.SecurityDesk)]
        [InlineData(ManualProcessEnum.PostOfficeUspsCollectionBox)]
        public void SaturdayShouldBeValidWithValidProcesses(ManualProcessEnum process)
        {
            var sut = new PaManualMailTrackingSearchModel
            {
                ManualProcessDay = ManualProcessDayEnum.Saturday,
                SaturdayManualProcessRadioOption = process.ToString()
            };
            var context = new ValidationContext(sut);
            var results = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(sut, context, results, true);

            Assert.True(isValid);
        }

        [Theory]
        [InlineData(ManualProcessEnum.None)]
        [InlineData(ManualProcessEnum.CageInMailRoom)]
        public void SaturdayShouldBeInvalidWithInvalidProcesses(ManualProcessEnum process)
        {
            var sut = new PaManualMailTrackingSearchModel
            {
                ManualProcessDay = ManualProcessDayEnum.Saturday,
                SaturdayManualProcessRadioOption = process.ToString()
            };
            var context = new ValidationContext(sut);
            var results = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(sut, context, results, true);

            Assert.False(isValid);
        }

        [Fact]
        public void SundayShouldBeValidWithValidProcesses()
        {
            var sut = new PaManualMailTrackingSearchModel
            {
                ManualProcessDay = ManualProcessDayEnum.Sunday,
                SundayManualProcessRadioOption = ManualProcessEnum.PostOfficeUspsCollectionBox.ToString()
            };
            var context = new ValidationContext(sut);
            var results = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(sut, context, results, true);

            Assert.True(isValid);
        }

        [Theory]
        [InlineData(ManualProcessEnum.None)]
        [InlineData(ManualProcessEnum.CageInMailRoom)]
        [InlineData(ManualProcessEnum.SecurityDesk)]
        public void SundayShouldBeInvalidWithInvalidProcesses(ManualProcessEnum process)
        {
            var sut = new PaManualMailTrackingSearchModel
            {
                ManualProcessDay = ManualProcessDayEnum.Sunday,
                SundayManualProcessRadioOption = process.ToString()
            };
            var context = new ValidationContext(sut);
            var results = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(sut, context, results, true);

            Assert.False(isValid);
        }

        [Fact]
        public void HolidayShouldBeValidWithValidProcesses()
        {
            var sut = new PaManualMailTrackingSearchModel
            {
                ManualProcessDay = ManualProcessDayEnum.Holiday,
                HolidayManualProcessRadioOption = ManualProcessEnum.PostOfficeUspsCollectionBox.ToString()
            };
            var context = new ValidationContext(sut);
            var results = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(sut, context, results, true);

            Assert.True(isValid);
        }

        [Theory]
        [InlineData(ManualProcessEnum.None)]
        [InlineData(ManualProcessEnum.CageInMailRoom)]
        [InlineData(ManualProcessEnum.SecurityDesk)]
        public void HolidayShouldBeInvalidWithInvalidProcesses(ManualProcessEnum process)
        {
            var sut = new PaManualMailTrackingSearchModel
            {
                ManualProcessDay = ManualProcessDayEnum.Sunday,
                SundayManualProcessRadioOption = process.ToString()
            };
            var context = new ValidationContext(sut);
            var results = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(sut, context, results, true);

            Assert.False(isValid);
        }
    }
}

