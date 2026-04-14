using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace EventEase.Models
{
    // location where events can be hosted
    public class Venue
    {
        [Key]
        public int VenueId { get; set; }

        [Required(ErrorMessage = "Venue Name is required")]
        [Display(Name = "Venue Name")]
        [StringLength(100, ErrorMessage = "Venue Name cannot exceed 100 characters")]
        public string VenueName { get; set; }

        [Required(ErrorMessage = "Location is required")]
        [StringLength(200, ErrorMessage = "Location cannot exceed 200 characters")]
        public string Location { get; set; }

        [Required(ErrorMessage = "Capacity is required")]
        [Range(1, 10000, ErrorMessage = "Capacity must be between 1 and 10,000")]
        [Display(Name = "Capacity")]
        public int Capacity { get; set; }

        [Display(Name = "Image URL")]
        [Url(ErrorMessage = "Please enter a valid URL")]
        [StringLength(500, ErrorMessage = "Image URL cannot exceed 500 characters")]
        public string ImageUrl { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Name = "Created Date")]
        public DateTime? CreatedDate { get; set; }

      
        [ValidateNever]
        public virtual ICollection<Booking> Bookings { get; set; }
    }
}