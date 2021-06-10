using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VideoRental.Models
{
    public class Movie
    {

        [DisplayName("#")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Insert a name for the movie!")] // Forces the attribute so it can't be null when created/changed
        [DisplayName("Name")] 
        public string Name { get; set; }

        [DisplayName("Synopsis")]
        public string Synopsis { get; set; }

        [Required(ErrorMessage = "A price must be set!")]
        [DisplayName("Price")]
        public double? Price { get; set; }

        [Required(ErrorMessage = "A release date must be defined!")]
        [DisplayName("Release Date")]
        [DataType(DataType.Date)]
        public DateTime? Release { get; set; }

        [Required(ErrorMessage = "Duration must be defined!")]
        [DisplayName("Duration")]
        public int? Duration { get; set; }

        [Required(ErrorMessage = "A URL must be defined!")] 
        [DisplayName("URL")]
        public string URL { get; set; }

        public List<Rental> Rentals { get; set; }


        public Movie(int _id, string _name, string _synopsis, double _preco, DateTime _release, int _duration)
        {
            Id = _id;
            Name = _name;
            Synopsis = _synopsis;
            Price = _preco;
            Release = _release;
            Duration = _duration;
        }

        public Movie()
        {

        }

    }
}
