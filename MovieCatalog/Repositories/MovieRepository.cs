using MovieCatalog.Abstract;
using MovieCatalog.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MovieCatalog.Repositories
{
    public class MovieRepository : IMovieRepository
    {

        MovieContext db = new MovieContext();

        public IEnumerable<Movie> GetAll()
        {
            return db.Movies;
        }

        public Models.Movie Find(int id)
        {
            return db.Movies.Find(id);
        }

        public void Delete(int id)
        {
            Movie m = db.Movies.Find(id);
            db.Movies.Remove(m);
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public void InsertOrDelete(Models.Movie movie)
        {
            if (movie.MovieID == default(int))
            {
                db.Movies.Add(movie);
            }
            else
            {
                db.Entry(movie).State = EntityState.Modified;
            }
        }
    }
}