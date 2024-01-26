using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;  // Lets Us Use .Includes

using MovieProject.Models;
using System.Diagnostics;

namespace MovieProject.Controllers
{
    public class HomeController : Controller
    {
       
        // Connects to the database
        private MovieContextModel Context { get; set; }


        // This Constructor accepts the DB Context objects thats enabled by DI
        // Accepts a movie context that holds a list of movies
        public HomeController(MovieContextModel ctx)
        {
            Context = ctx;
        }




        public IActionResult Index()
        {

            // Sending a list of movies to our view. 
            /*var movies = Context.Movies.OrderBy(m => m.Name).ToList();*/

            // Sending list of both movies and genres
            var movies = Context.Movies.Include(m => m.Genre).OrderBy(m => m.Name).ToList();

            return View(movies);
        }

    }
}
