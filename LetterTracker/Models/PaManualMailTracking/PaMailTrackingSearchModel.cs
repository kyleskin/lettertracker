using System;
using System.ComponentModel.DataAnnotations;
using LetterTracker.CustomValidation;

namespace LetterTracker.Models.PaManualMailTracking
{
    public class PaManualMailTrackingSearchModel
    {
        [Required]
        [StringLength(10, MinimumLength=10, ErrorMessage = "{0} must be {1} characters long.")]
        public string? EocId { get; set; }
        [Required]
        public string? MemberId { get; set; }
        [Required]
        public string? AgentUserId { get; set; }
        [Required]
        public ManualLetterReasonEnum ReasonForManualLetter { get; set; }
        [Required]
        public DateTime? ManualMailDate { get; set; }
        [Required]
        public TimeSpan? ManualMailTime { get; set; }
        [Required]
        public TimeZoneEnum TimeZone { get; set; }
        [Required]
        public LetterTypeEnum LetterType { get; set; }
        public string? Comments { get; set; }
        [Required]
        public ManualProcessDayEnum ManualProcessDay { get; set; }
        private ManualProcessEnum? _manualProcess;
        [ManualProcessAttribute]
        public ManualProcessEnum? ManualProcessUsed
        {
            get
            {
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
            set
            {
                _manualProcess = value;
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
    }
}

