using MovieCatalog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieCatalog.Abstract
{
    public interface IMovieRepository
    {
        IEnumerable<Movie> GetAll();
        Movie Find(int id);
        void Delete(int id);
        void Save();
        void InsertOrDelete(Movie movie);

    }
}
