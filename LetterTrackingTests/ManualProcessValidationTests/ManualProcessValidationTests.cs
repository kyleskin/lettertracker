using System;
using System.ComponentModel.DataAnnotations;
using LetterTracker.CustomValidation;
using LetterTracker.Models.PaManualMailTracking;
using LetterTracker.Models;

namespace PaManualMailTrackingTests.ManualProcessValidationTests
{
    public class ManualProcessValidationTests
    {
        private static PaManualMailTrackingSearchModel CreateSearchModelForManualProcesses()
        {
            return new PaManualMailTrackingSearchModel
            {
                EocId = "1111111111",
                MemberId = "MemberId",
                AgentUserId = "kskinne6",
                ReasonForManualLetter = ManualLetterReasonEnum.VerbalNotificationUnsuccessful,
                ManualMailDate = DateTime.Today,
                ManualMailTime = DateTime.UtcNow.TimeOfDay,
                TimeZone = TimeZoneEnum.Est,
                LetterType = LetterTypeEnum.FinalNotification,
            };
        }

        [Theory]
        [InlineData(ManualProcessEnum.CageInMailRoom)]
        [InlineData(ManualProcessEnum.SecurityDesk)]
        [InlineData(ManualProcessEnum.PostOfficeUspsCollectionBox)]
        private void BusinessDayShouldBeValidWithValidProcesses(ManualProcessEnum process)
        {
            //  Arrange
            var sut = CreateSearchModelForManualProcesses();
            sut.ManualProcessDay = ManualProcessDayEnum.BusinessDay;
            sut.BusinessDayManualProcessRadioOption = process.ToString();

            // Act
            var context = new ValidationContext(sut);
            var results = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(sut, context, results, true);

            // Assert
            Assert.True(isValid);
        }

        [Fact]
        private void BusinessDayShouldBeInvalidWithInvalidProcesses()
        {
            // Arrange
            var sut = CreateSearchModelForManualProcesses();
            sut.ManualProcessDay = ManualProcessDayEnum.BusinessDay;
            sut.BusinessDayManualProcessRadioOption = ManualProcessEnum.None.ToString();

            // Act
            var context = new ValidationContext(sut);
            var results = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(sut, context, results, true);

            // Assert
            Assert.False(isValid);
        }

        [Theory]
        [InlineData(ManualProcessEnum.SecurityDesk)]
        [InlineData(ManualProcessEnum.PostOfficeUspsCollectionBox)]
        private void SaturdayShouldBeValidWithValidProcesses(ManualProcessEnum process)
        {
            // Arrange
            var sut = CreateSearchModelForManualProcesses();
            sut.ManualProcessDay = ManualProcessDayEnum.Saturday;
            sut.SaturdayManualProcessRadioOption = process.ToString();

            // Act
            var context = new ValidationContext(sut);
            var results = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(sut, context, results, true);

            // Assert
            Assert.True(isValid);
        }

        [Theory]
        [InlineData(ManualProcessEnum.None)]
        [InlineData(ManualProcessEnum.CageInMailRoom)]
        private void SaturdayShouldBeInvalidWithInvalidProcesses(ManualProcessEnum process)
        {
            // Arrange
            var sut = CreateSearchModelForManualProcesses();
            sut.ManualProcessDay = ManualProcessDayEnum.Saturday;
            sut.SaturdayManualProcessRadioOption = process.ToString();

            // Act
            var context = new ValidationContext(sut);
            var results = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(sut, context, results, true);

            // Assert
            Assert.False(isValid);
        }

        [Fact]
        private void SundayShouldBeValidWithValidProcesses()
        {
            // Arrange
            var sut = CreateSearchModelForManualProcesses();
            sut.ManualProcessDay = ManualProcessDayEnum.Sunday;
            sut.SundayManualProcessRadioOption = ManualProcessEnum.PostOfficeUspsCollectionBox.ToString();

            // Act
            var context = new ValidationContext(sut);
            var results = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(sut, context, results, true);

            // Assert
            Assert.True(isValid);
        }

        [Theory]
        [InlineData(ManualProcessEnum.None)]
        [InlineData(ManualProcessEnum.CageInMailRoom)]
        [InlineData(ManualProcessEnum.SecurityDesk)]
        private void SundayShouldBeInvalidWithInvalidProcesses(ManualProcessEnum process)
        {
            // Arrange
            var sut = CreateSearchModelForManualProcesses();
            sut.ManualProcessDay = ManualProcessDayEnum.Sunday;
            sut.SundayManualProcessRadioOption = process.ToString();

            // Act
            var context = new ValidationContext(sut);
            var results = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(sut, context, results, true);

            // Assert
            Assert.False(isValid);
        }

        [Fact]
        private void HolidayShouldBeValidWithValidProcesses()
        {
            // Arrange
            var sut = CreateSearchModelForManualProcesses();
            sut.ManualProcessDay = ManualProcessDayEnum.Holiday;
            sut.HolidayManualProcessRadioOption = ManualProcessEnum.PostOfficeUspsCollectionBox.ToString();

            // Act
            var context = new ValidationContext(sut);
            var results = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(sut, context, results, true);

            // Assert
            Assert.True(isValid);
        }

        [Theory]
        [InlineData(ManualProcessEnum.None)]
        [InlineData(ManualProcessEnum.CageInMailRoom)]
        [InlineData(ManualProcessEnum.SecurityDesk)]
        private void HolidayShouldBeInvalidWithInvalidProcesses(ManualProcessEnum process)
        {
            // Arrange
            var sut = CreateSearchModelForManualProcesses();
            sut.ManualProcessDay = ManualProcessDayEnum.Sunday;
            sut.SundayManualProcessRadioOption = process.ToString();

            // Act
            var context = new ValidationContext(sut);
            var results = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(sut, context, results, true);

            // Assert
            Assert.False(isValid);
        }
    }
}

