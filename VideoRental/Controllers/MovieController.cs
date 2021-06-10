using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VideoRental.Models;
using VideoRental.Services;

namespace VideoRental.Controllers
{
    public class MovieController : Controller
    {
        IMovieService _service;
        public MovieController(IMovieService service) // Calls the Movie Service
        {
            _service = service; // Assigns that service to a local and private variable
        }


        public IActionResult Index(int? Id) => View(_service.GetAll()); // Return a list of all Movies in the context


        #region//Create
        public IActionResult Create() => View(); 

        [HttpPost]
        [ValidateAntiForgeryToken] // Whenever the create function is called, a token is generated, and will only accept inputs from the page containing that same token.
        public IActionResult Create(Movie movie)
        {
            if (!ModelState.IsValid) return View(movie); // Checks if the required attributes are NOT valid
            return _service.Create(movie) ? RedirectToAction("Index") : NotFound(); // Creates an entry in the context based on the boolean returned from within the function
        }
        #endregion


        #region//Delete
        public IActionResult DeleteView(int? id) // Página de confirmação do objeto que recebe o Id como parâmetro para visualização
        {
            var movie = _service.Get(id); // Assigns for the variable, a specific movie in the context that has the same Id as the one passed in the URL
            return movie == null ? NotFound() : View(movie);
        }

        public IActionResult Delete(int? id) => _service.Delete(id) ? RedirectToAction("Index") : NotFound(); //

        #endregion


        #region//Update
        public IActionResult UpdateView(int? id)
        {
            var movie = _service.Get(id);
            return movie == null ? NotFound() : View(movie);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(Movie movie)
        {
            if (!ModelState.IsValid) return View(movie); // Checks if the model is NOT valid, and returns the same data input before if so.
            return _service.Update(movie) ? RedirectToAction("Index") : View(movie); // Updates the movie if the boolean func returns a true value.
        }

        #endregion


        #region//Misc
        public IActionResult Sort() // Alphabetical order function
        {
            var movies = _service.GetAll(); // Assigns all movies from the context to a variable
            movies.Sort((x, y) => x.Name.CompareTo(y.Name)); // Compare alphabetically and puts them in order

            return View(movies); // Passes the now ordered variable back to the view as a model
        }

        public IActionResult Details(int? id) // Parameter from the URl
        {
            var movies = _service.Get(id); // Select a movie with the same Id as the one in the URL
            return View(movies); // Sends it as a model to the view page.
        }
        #endregion



    }
}
