using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Baby.Models
{
    public class EditMovieViewModel
    {
        public int MovieID { get; set; }

        public string Category { get; set; }

        public string Title { get; set; }

        public int Year { get; set; }

        public string Director { get; set; }
     
        public string Rating { get; set; }

        public bool Edited { get; set; }

        public string Lent { get; set; }

        [StringLength(25)]
        public string Notes { get; set; }
    }
}
