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
        public string? AgentUserId { get; set; }
        public ManualLetterReasonEnum ReasonForManualLetter { get; set; }
        public DateTime? ManualMailDate { get; set; }
        public TimeSpan? ManualMailTime { get; set; }
        public TimeZoneEnum TimeZone { get; set; }
        public LetterTypeEnum LetterType { get; set; }
        public ManualProcessDayEnum ManualProcessDay { get; set; }
        [Required]
        public ManualProcessEnum? ManualProcessUsed
        {
            get
            {
                ManualProcessEnum? _manualProcess;
                if (ManualProcessDay == ManualProcessDayEnum.BusinessDay)
                {
                    _manualProcess = Enum.TryParse(BusinessDayManualProcessRadioOption, out ManualProcessEnum manualProcess)
                        ? manualProcess
                        : null;
                }
                else if (ManualProcessDay == ManualProcessDayEnum.Saturday)
                {
                    _manualProcess = Enum.TryParse(SaturdayManualProcessRadioOption, out ManualProcessEnum manualProcess)
                        ? manualProcess
                        : null;
                }
                else if (ManualProcessDay == ManualProcessDayEnum.Sunday)
                {
                    _manualProcess = Enum.TryParse(SundayManualProcessRadioOption, out ManualProcessEnum manualProcess)
                        ? manualProcess
                        : null;
                }
                else
                {
                    _manualProcess = Enum.TryParse(HolidayManualProcessRadioOption, out ManualProcessEnum manualProcess)
                        ? manualProcess
                        : null;
                }
                return _manualProcess;
            }
        }
        public ManualProcessEnum? BusinessDayManualProcessUsed { get; set; }
        public string? BusinessDayManualProcessRadioOption { get; set; }
        public ManualProcessEnum? SaturdayManualProcessUsed { get; set; }
        public string? SaturdayManualProcessRadioOption { get; set; }
        public ManualProcessEnum? SundayManualProcessUsed { get; set; }
        public string? SundayManualProcessRadioOption { get; set; }
        public ManualProcessEnum? HolidayManualProcessUsed { get; set; }
        public string? HolidayManualProcessRadioOption { get; set; }
        public string? Comments { get; set; }
    }
}

