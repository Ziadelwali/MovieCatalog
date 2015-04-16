using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MovieCatalog.Models;
using System.Data.Entity;
using MovieCatalog.Repositories;
using MovieCatalog.Abstract;

namespace MovieCatalog.Views
{
    public class MoviesController : Controller
    {
        private readonly IMovieRepository _movieRepository;

        public MoviesController(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository; 
        }

        public ActionResult Index()
        {
            IEnumerable<Movie> movies = _movieRepository.GetAll();

            return View(movies.OrderBy(m => m.Title));
        }

        public ActionResult Details(int id)
        {
            Movie movie = _movieRepository.Find(id);
  
            return View(movie);
        }

        public ActionResult MovieLink()
        {
            IEnumerable<Movie> movies = _movieRepository.GetAll();

            return View(movies.OrderBy(m => m.Title));
        }

        public ActionResult DetailsLink(int id)
        {
            Movie movie = _movieRepository.Find(id);

            return View(movie);
        }
        
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Movie movie, HttpPostedFileBase movieImage)
        {
            if (ModelState.IsValid)
            {
                movie.SaveImage(movieImage, Server.MapPath("~"), "/UserUploads/MovieImages/");
                _movieRepository.InsertOrDelete(movie);
                _movieRepository.Save();

                return View("Confirmation");
            }

            return View();
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            Movie movie = _movieRepository.Find(id);
            return View(movie);
        }

        [HttpPost]
        public ActionResult Edit(Movie movie, HttpPostedFileBase movieImage)
        {
            if(ModelState.IsValid)
            {
                movie.SaveImage(movieImage, Server.MapPath("~"), "/UserUploads/MovieImages/");
                _movieRepository.InsertOrDelete(movie);
                _movieRepository.Save();
                return RedirectToAction("Index");
            }
            
            return View(movie);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            Movie movie = _movieRepository.Find(id);
  
            return View(movie);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _movieRepository.Delete(id);

            _movieRepository.Save();

            return RedirectToAction("Index");
        }
    }
}