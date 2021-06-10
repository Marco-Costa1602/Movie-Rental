using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VideoRental.Data;
using VideoRental.Models;

namespace VideoRental.Services
{
    public class MovieService : IMovieService
    {
        VideoRentalContext _context;
        public MovieService(VideoRentalContext context)
        {
            _context = context;
        }

        public List<Movie> GetAll() => _context.Movie.ToList();
        public Movie Get(int? id) => _context.Movie.Find(id);
        public bool Create(Movie m)

        {
            try
            {
                _context.Add(m);
                _context.SaveChanges();
                return true; 
            }
            catch
            {
                return false;
            }
        }

        public bool Update(Movie m)
        {
            try
            {
                if (m.Name == null) return false;
                _context.Update(m);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Delete(int? id)
        {
            try
            {
                _context.Remove(Get(id));
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }


    }
}
