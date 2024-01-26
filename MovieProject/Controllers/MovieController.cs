using Microsoft.AspNetCore.Mvc;
using MovieProject.Models;

namespace MovieProject.Controllers
{
    public class MovieController : Controller
    {


        // Connects to the database
        private MovieContextModel Context { get; set; }

        // This Constructor accepts the DB Context objects thats enabled by DI
        // Accepts a movie context that holds a list of movies
        public MovieController(MovieContextModel ctx)
        {
            Context = ctx;
        }




        [HttpGet]
        // ++++++ ADDING A MOVIE ++++++ \\
        public IActionResult Add()
        {
            ViewBag.Action = "Add New Movie";

            // Puts the genres of the movies in a list to be able to be edited
            ViewBag.Genres = Context.Genres.OrderBy(g => g.Name).ToList();

            return View("Edit", new MovieModel());
        }
        // ++++++ ADDING A MOVIE ++++++ \\





        // ------ EDITING A MOVIE ------ \\
        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Action = "Edit Movie";

            // Puts the genres back in after the load to be added and show Validation Errors
            ViewBag.Genres = Context.Genres.OrderBy(g => g.Name).ToList();

            //LINQ Queery to find the movie with the given id - PK Search
            var movie = Context.Movies.Find(id);
            return View(movie); // sends the movie to the edit page to auto fill the info
        }
        // ------ EDITING A MOVIE ------ \\





        // xxxxxx DELETE A MOVIE xxxxxx \\
        [HttpGet]
        public IActionResult Delete(int id) // id parameter is sent from the url
        {
            ViewBag.Action = "Delete Movie";

            var movie = Context.Movies.Find(id);
            return View(movie); // sends the movie to the edit page to auto fill the info
        }
        // xxxxxx DELETE A MOVIE xxxxxx \\






        // ++++++ ADDING A MOVIE ++++++ \\
        [HttpPost]
        public IActionResult Edit(MovieModel movie) 
        {
            if(ModelState.IsValid)
            {
                // Either add a new movie or edit a movie
                if(movie.MovieModelId == 0)
                {
                    Context.Movies.Add(movie);
                }
                else
                {
                    Context.Movies.Update(movie);
                }

                Context.SaveChanges();

                return RedirectToAction("Index", "Home");
            }
            else
            {
                // Show our Validation errors
                ViewBag.Action = (movie.MovieModelId == 0) ? "Add" : "Edit";

                // Puts the genres back in after the load to be added and show Validation Errors
                ViewBag.Genres = Context.Genres.OrderBy(g => g.Name).ToList();

                return View(movie);
            }
        }
        // ++++++ ADDING A MOVIE ++++++ \\






        // xxxxxx DELETE A MOVIE xxxxxx \\
        [HttpPost]
        public IActionResult Delete(MovieModel movie)
        {
            ViewBag.Action = "Delete Movie";

            Context.Movies.Remove(movie);
            Context.SaveChanges();

            return RedirectToAction("Index", "Home");
        }
        // xxxxxx DELETE A MOVIE xxxxxx \\











        /*        public IActionResult Index()
                {
                    return View();
                }*/










    }
}
