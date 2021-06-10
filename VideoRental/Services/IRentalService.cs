using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VideoRental.Models;

namespace VideoRental.Services
{
    public interface IRentalService // Defines all functions that a rent service should have
    {
        List<Rental> GetAll(); // Selects all from within the context
        List<Rental> GetActive(); // Selects all entries that are still valid, from within the context
        Rental Get(int? id); // Selects a specific entry from within the context
        bool Update(Rental r); // Updates an existing entry in the context
        bool Create(Rental r); // Creates a new entry in the context
        bool Delete(int? id); // Delete an existing entry in the context
    }
}
