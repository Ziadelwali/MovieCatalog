using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using MovieCatalog.Helpers;

namespace MovieCatalog.Models
{
    public class Movie
    {
        public int MovieID { get; set; }

        [Required]
        public String Title { get; set; }

        [Required]
        public String Starring { get; set; }

        [Required]
        public String Director { get; set; }

        [Range (1900, 2050)]
        public int Year { get; set; }

        [Required]
        public String Genre { get; set; }

        public String MovieImagePath { get; set; }

        public void SaveImage(HttpPostedFileBase image, String serverPath, String pathToFile)
        {
            if (image == null) return;

            string fileName = Guid.NewGuid().ToString();
            ImageModel.ResizeAndSave(serverPath + pathToFile, fileName, image.InputStream, 400);

            MovieImagePath = pathToFile + fileName + ".jpg";
        }
    }
}