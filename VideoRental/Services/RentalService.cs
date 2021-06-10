using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VideoRental.Data;
using VideoRental.Models;

namespace VideoRental.Services
{
    public class RentalService : IRentalService
    {
        VideoRentalContext _context;
        public RentalService(VideoRentalContext context)
        {
            _context = context;
        }

        public List<Rental> GetAll() => _context.Rental.Include(x => x.movie).ToList(); // Select all entries from the context and include an external element from another table
        public List<Rental> GetActive()
        {
            return _context.Rental.Where(z => DateTime.Compare(z.rDay.AddDays((int)z.rentedDays), DateTime.Now) >0).Include(x => x.movie).ToList() ;
            //return _context.Rental.Where(x => x.lastDay >= DateTime.Now).Include(x => x.movie).ToList(); // Select all entries from the context that the DateTime is greater the "Now",
        }                                                                                               // and also includes an external element from another table.

        public Rental Get(int? id) => _context.Rental.Find(id); // Finds an entry in the context that has the same Id as the URL parameter.
        public bool Create(Rental r) // Receives an object as a parameter

        {
            try
            {
                if (r.rentedDays <= 0) return false;
                _context.Add(r); // Adds the object to the context
                _context.SaveChanges(); // Saves the changes in the context
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Update(Rental r) // Receives an object as a parameter
        {
            try
            {
                if (r.rentedDays <= 0) return false;
                _context.Update(r); // Updates in the context the entry with the same Id as the parameter
                _context.SaveChanges(); // Saves the changes in the context
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Delete(int? id) // Receive an Id as a parameter
        {
            try
            {
                _context.Remove(Get(id)); // Finds in the context an entry that has the same Id as the parameter
                _context.SaveChanges(); // Save the changes made in the context.
                return true;
            }
            catch
            {
                return false; // If it doesn't find, returns false.
            }
        }


    }
}
