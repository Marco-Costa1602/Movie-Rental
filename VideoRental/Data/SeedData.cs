using VideoRental.Data;
using VideoRental.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VideoRental.Data
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            string[] fNames = new string[] {"Adventures of", "The tale of", "Monkeys and", "Pride and","The mistery of","Learning with","The second","Once upon a time,"}; // List of random names
            string[] sNames = new string[] { "Gorila", "Marley", "Annabelle", "Tilambu", "Endless Fish", "Those who haven't gone", "a Hacker", "Kwai Land" }; // Another list of random names
            string synopsis = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Praesent faucibus enim id nibh pharetra feugiat. Suspendisse diam lectus, mollis non quam ac, tempor imperdiet mi. Praesent dapibus leo urna, at.";
            
            int quantity = 20; // Amount of movies to be generated in case the DB doesn't have any already.

            using (var context = new VideoRentalContext(
                    serviceProvider.GetRequiredService<DbContextOptions<VideoRentalContext>>()
                ))
            {
                if (context.Movie.Any()) // If the context isn't empty, do nothing and returns it.
                {
                    return;
                }

                for (int i = 0; i < quantity; i++) // Else, creates new movies in the context
                {
                    Random rnd = new();
                    var initial_release = new DateTime(1955, 1, 1); // Smallest date possible
                    int range = (DateTime.Today - initial_release).Days; // From the smallest date to today's date.

                    context.Movie.Add(
                        new Movie()
                        {
                            Name = $"{fNames[rnd.Next(fNames.Length)]} {sNames[rnd.Next(sNames.Length)]}",
                            Synopsis = synopsis,
                            Price = rnd.Next(7, 25),
                            Release = initial_release.AddDays(rnd.Next(range)),
                            Duration = rnd.Next(55, 240),
                            URL = "XXXX"
                        }
                    );
                }


                context.SaveChanges(); // Saves changes in the context
            }

        }
    }
}
