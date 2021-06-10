using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VideoRental.Models;

namespace VideoRental.Services
{
    public interface IMovieService // Defines all functions that a movie service should have
    {
        List<Movie> GetAll(); // Selects all from within the context
        Movie Get(int? id); // Selects a specific entry from within the context
        bool Update(Movie m); // Updates an existing entry in the context
        bool Create(Movie m); // Creates a new entry in the context
        bool Delete(int? id); // Delete an existing entry in the context
    }
}
