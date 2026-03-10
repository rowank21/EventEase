using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace EventEase.Models
{
    public class Event
    {
        [Key]
        public int EventId { get; set; }

        [Required(ErrorMessage = "Event Name is required")]
        [Display(Name = "Event Name")]
        [StringLength(100, ErrorMessage = "Event Name cannot exceed 100 characters")]
        public string EventName { get; set; }

        [Display(Name = "Description")]
        [StringLength(500, ErrorMessage = "Description cannot exceed 500 characters")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Event Date is required")]
        [DataType(DataType.Date)]
        [Display(Name = "Event Date")]
        public DateTime EventDate { get; set; }

        [Required(ErrorMessage = "Start Time is required")]
        [DataType(DataType.Time)]
        [Display(Name = "Start Time")]
        public TimeSpan StartTime { get; set; }

        [Required(ErrorMessage = "End Time is required")]
        [DataType(DataType.Time)]
        [Display(Name = "End Time")]
        [CustomValidation(typeof(Event), "ValidateEndTime")]
        public TimeSpan EndTime { get; set; }

        [Display(Name = "Image URL")]
        [Url(ErrorMessage = "Please enter a valid URL")]
        [StringLength(500, ErrorMessage = "Image URL cannot exceed 500 characters")]
        public string ImageUrl { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Name = "Created Date")]
        public DateTime? CreatedDate { get; set; }

        
        [ValidateNever]
        public virtual ICollection<Booking> Bookings { get; set; }

        // validation to ensure EndTime is after StartTime
        public static ValidationResult ValidateEndTime(TimeSpan endTime, ValidationContext context)
        {
            var eventInstance = (Event)context.ObjectInstance;
            if (endTime <= eventInstance.StartTime)
            {
                return new ValidationResult("End Time must be after Start Time");
            }
            return ValidationResult.Success;
        }
    }
}