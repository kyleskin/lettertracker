using System;
using System.ComponentModel.DataAnnotations;
using LetterTracker.CustomValidation;

namespace LetterTracker.Models
{
    public class LetterTrackingSearchModel
    {
        //[Required]
        //[StringLength(10, MinimumLength=10, ErrorMessage = "{0} must be {1} characters long.")]
        public string? EocId { get; set; }
        //[Required]
        public string? MemberId { get; set; }
        public string? AgentUserId  { get; set; }
        public ManualLetterReasonEnum ReasonForManualLetter { get; set; } = ManualLetterReasonEnum.VerbalNotificationUnsuccessful;
        public DateOnly? ManualMailDate { get; set; }
        public TimeOnly? ManualMailTime { get; set; }
        public TimeZoneEnum TimeZone { get; set; } = TimeZoneEnum.Mst;
        public LetterTypeEnum LetterType { get; set; } = LetterTypeEnum.FinalNotification;
        public ManualProcessDayEnum ManualProcessDay { get; set; }
        public ManualProcessEnum? BusinessDayManualProcessUsed { get; set; }
        public ManualProcessEnum? BusinessDayManualProcessCached { get; set; }
        public ManualProcessEnum? SaturdayManualProcessUsed { get; set; }
        public ManualProcessEnum? SaturdayManualProcessCached { get; set; }
        public ManualProcessEnum? SundayManualProcessUsed { get; set; }
        public ManualProcessEnum? SundayManualProcessCached { get; set; }
        public ManualProcessEnum? HolidayManualProcessUsed { get; set; }
        public ManualProcessEnum? HolidayManualProcessCached { get; set; }
        public string? Comments { get; set; }
    }
}

