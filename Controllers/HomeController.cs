using Baby.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Baby.Controllers
{
    public class HomeController : Controller
    {
        //Bring in movie context
        private MovieListContext context { get; set; }

        //
        public HomeController(MovieListContext con)
        {
            context = con;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult MyPodcast()
        {
            return View();
        }

        [HttpGet]
        public IActionResult EnterMovies()
        {
               return View();
        }


        [HttpPost]
        public IActionResult EnterMovies(Movie SubmitMovie)
        {
            if (SubmitMovie.Title == "Independence Day")
            {
                return View(); 
            } 
            else if (ModelState.IsValid)
            {
                context.Add(SubmitMovie);
                context.SaveChanges();
                return View("Confirmation", SubmitMovie);
            }
            else
            {
                return View();
            }
        }

        public IActionResult MovieList()
        {
            return View(context.Movies);
        }


        //pass Movie object to EditMovie.cshtml
        [HttpGet]
        public IActionResult EditMovie(int movieid)
        {
           var EditMe = (context.Movies.First(x => x.MovieID == movieid));

            return View(EditMe);
        }

        [HttpPost]
        public IActionResult EditMovie(int movieid, string category, string title, int year, string director,
            string rating, bool edited, string lent, string notes)
        {

            foreach (var x in context.Movies)
            {
                if (x.MovieID == movieid)
                {
                    x.Category = category;
                    x.Title = title;
                    x.Year = year;
                    x.Director = director;
                    x.Rating = rating;
                    x.Edited = edited;
                    x.Lent = lent;
                    x.Notes = notes;
                }
            }
            context.SaveChanges();

            return View("MovieList", context.Movies);
        }

        public IActionResult DeleteMovie(int movieid)
        {

            context.Movies.Remove(context.Movies.First(x => x.MovieID == movieid));
            context.SaveChanges();

            return View("MovieList", context.Movies);
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
