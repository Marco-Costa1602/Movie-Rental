using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VideoRental.Models;
using VideoRental.Services;

namespace VideoRental.Controllers
{
    public class RentalController : Controller
    {
        IRentalService _service;
        IMovieService _movieService;
        public RentalController(IRentalService service, IMovieService movieService)
        {
            _service = service;
            _movieService = movieService;
        }


        public IActionResult Index(int? id) => View(_service.GetActive());


        #region//Create
        public IActionResult Create() // Whenever the create function is called, a token is generated, and will only accept inputs from the page containing that same token.
        {
            var movies = _movieService.GetAll(); // Checks if the required attributes are NOT valid
            ViewBag.movieList = new SelectList(movies, "Id", "Name"); // Creates an entry in the context based on the boolean returned from within the function
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken] // Whenever the create function is called, a token is generated, and will only accept inputs from the page containing that same token.
        public IActionResult Create(Rental rental)
        {
            if (!ModelState.IsValid) return View(rental); // Checks if the required attributes are NOT valid
            return _service.Create(rental) ? RedirectToAction("Index") : NotFound(); // Creates an entry in the context based on the boolean returned from within the function
        }
        #endregion


        #region//Delete
        public IActionResult DeleteView(int? id) // Receives an ID as a URL parameter
        {
            var movie = _service.Get(id);
            return movie == null ? NotFound() : View(movie); // Returns to the view page an object(rental) with the same Id as the one passed in the URL.
        }

        public IActionResult Delete(int? id) => _service.Delete(id) ? RedirectToAction("Index") : NotFound(); // If the parameter Id corresponds to an Id in the context, the same entry gets removed.

        #endregion


        #region//Update
        public IActionResult Update(int? id) 
        {
            var movies = _movieService.GetAll(); // Assigns all movies from the db to a variable
            ViewBag.movieList = new SelectList(movies, "Id", "Name"); // Creates a viewbag that will fill a select list with a list of all objects
            var rental = _service.Get(id);                           // inside the variable movies, assigning their Id as their value, and their Name as their display.
            return rental == null ? NotFound() : View(rental);
        }

        [HttpPost]
        [ValidateAntiForgeryToken] // Whenever the create function is called, a token is generated, and will only accept inputs from the page containing that same token.
        public IActionResult Update(Rental rental)
        {
            if (!ModelState.IsValid) return View(rental); // Checks if the required attributes are NOT valid
            return _service.Update(rental) ? RedirectToAction("Index") : View(rental);
        }

        #endregion


        #region//Misc

        public IActionResult Details(int? id) // Return the view page of a single item based on its Id. 
        {
            return View(_movieService.Get(id));
        }
        #endregion
    }
}
