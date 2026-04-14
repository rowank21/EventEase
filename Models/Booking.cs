using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EventEase.Models
{
    // Represents a reservation linking a specific venue with a specific event
    public class Booking
    {
        [Key]
        public int BookingId { get; set; }

        [Required(ErrorMessage = "Venue is required")]
        [Display(Name = "Venue")]
        public int VenueId { get; set; }

        [Required(ErrorMessage = "Event is required")]
        [Display(Name = "Event")]
        public int EventId { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Name = "Booking Date")]
        public DateTime BookingDate { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "Start Date & Time is required")]
        [DataType(DataType.DateTime)]
        [Display(Name = "Start Date & Time")]
        public DateTime StartDateTime { get; set; }

        [Required(ErrorMessage = "End Date & Time is required")]
        [DataType(DataType.DateTime)]
        [Display(Name = "End Date & Time")]
        [CustomValidation(typeof(Booking), "ValidateEndDateTime")]
        public DateTime EndDateTime { get; set; }

        // Current state of the booking (Confirmed, Cancelled, Completed)
        [Display(Name = "Status")]
        [StringLength(20, ErrorMessage = "Status cannot exceed 20 characters")]
        public string BookingStatus { get; set; } = "Confirmed";

        [DataType(DataType.DateTime)]
        [Display(Name = "Created Date")]
        public DateTime? CreatedDate { get; set; }

        // Navigation properties
        [ValidateNever]
        [ForeignKey("VenueId")]
        public virtual Venue Venue { get; set; }

        [ValidateNever]
        [ForeignKey("EventId")]
        public virtual Event Event { get; set; }

        //  validation to ensure EndDateTime is after StartDateTime
        public static ValidationResult ValidateEndDateTime(DateTime endDateTime, ValidationContext context)
        {
            var bookingInstance = (Booking)context.ObjectInstance;
            if (endDateTime <= bookingInstance.StartDateTime)
            {
                return new ValidationResult("End Date & Time must be after Start Date & Time");
            }
            return ValidationResult.Success;
        }
    }
}