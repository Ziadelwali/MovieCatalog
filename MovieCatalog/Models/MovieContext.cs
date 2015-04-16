using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations.Model;
using System.Linq;
using System.Web;

namespace MovieCatalog.Models
{
    public class MovieContext : DbContext
    {
        public DbSet<Movie> Movies { get; set; }

    }
}