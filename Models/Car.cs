using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarBooking.Models
{
    public class Car
    {
        public int Id { get; set; }
        [Display(Name = "Car Manufacturer")]
        public string Manufacturer { get; set; }

        [Display(Name = "Model")]
        public string CarModel { get; set; }

        [Display(Name = "Daily Rate (RM)")]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal DailyRate { get; set; }

        [Display(Name = "Image Url")]
        public string ImgUrl { get; set; }

        [Display(Name = "Number Of Seats")]
        public int NoOfSeats { get; set; }

        public ICollection<CarBookingz> CarBookingz { get; set; }
    }
}
