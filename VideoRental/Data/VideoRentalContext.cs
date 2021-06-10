using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VideoRental.Models;

namespace VideoRental.Data
{
    public class VideoRentalContext : DbContext
    {

        public VideoRentalContext(DbContextOptions<VideoRentalContext> options) : base(options) {}  
        public DbSet<Movie> Movie { get; set; }
        public DbSet<Rental> Rental { get; set; }
    }
}
