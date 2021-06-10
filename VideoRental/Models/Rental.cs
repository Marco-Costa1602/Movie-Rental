using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VideoRental.Models
{
    public class Rental
    {

        [DisplayName("#")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Invalid amount of days!")] // Forces the attribute so it can't be null when created/changed
        [DisplayName("Rent Time")]
        public int? rentedDays { get; set; }

        [DisplayName("Rented at")]
        public DateTime rDay { get { return DateTime.Now; } set { ;} }

        [DisplayName("Movie")]
        [Required(ErrorMessage = "A movie must be chosen.")]
        public int movieId { get; set; }

        public Movie movie { get; set; }

    }
}
