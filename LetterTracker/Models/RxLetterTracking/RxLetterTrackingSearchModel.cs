using System;
namespace LetterTracker.Models.RxLetterTracking
{
    public class RxLetterTrackingSearchModel
    {
        
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }
        public IdType IdType { get; set; }
        public string? Id { get; set; }
        public string? FacilityName { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public SearchType SearchType { get; set; }
        public string? DrugName { get; set; }
        public string? DocumentControlNum { get; set; }
        public string? PriorAuthNum { get; set; }

    }
}

