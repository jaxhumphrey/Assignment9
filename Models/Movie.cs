using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Baby.Models
{
    public class Movie
    {
        [Key]
        public int MovieID { get; set; }

        [Required(ErrorMessage = "Must enter a Category.")]
        public string Category { get; set; }

        [Required(ErrorMessage = "Must enter a title.")]
        public string Title {get; set;}

        [Required(ErrorMessage = "Must enter a year.")]
        public int Year { get; set; }

        [Required(ErrorMessage = "Must enter a Director.")]
        public string Director { get; set; }

        [Required(ErrorMessage = "Must enter a Rating.")]
        public string Rating { get; set; }

        public bool Edited { get; set; }
        
        public string Lent { get; set; }

        [StringLength(25)]
        public string Notes { get; set; }

    }
}
