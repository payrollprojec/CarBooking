using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarBooking.Models
{
    public class CarBookingz
    {
        public int Id { get; set; }
        [Required]
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        
        [Required]
        public int CarId { get; set; }
        public Car Car { get; set; }

        [Display(Name = "Start Date")]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }
        [Display(Name = "End Date")]
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }

        [DataType(DataType.Currency)]
        [Display(Name = "Total Price")]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal TotalPrice { get; set; }

        [Display(Name = "Created Date")]
        [DataType(DataType.Date)]
        public DateTime CreatedDate { get; set; }

        [Required]
        public int StatusId { get; set; }
        public Status Status { get; set; }
    }
}
