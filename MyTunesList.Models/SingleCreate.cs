using MyTunesList.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTunesList.Models
{
    public class SingleCreate
    {

        [Required]
        [MinLength(1, ErrorMessage = "Please enter at least 1 character.")]
        [MaxLength(100, ErrorMessage = "There are too many characters in this field.")]
        
        public string Title { get; set; }

        [MaxLength(8000)]
        public Genre Genre { get; set; }

        [Display(Name = "Genre Name")]
        public int GenreId { get; set; }
        public string GenreName { get; set; }
        public double Length { get; set; }
        public string Artist_Band { get; set; }
        [Display(Name = "Date Released")]
        public DateTime ReleaseDate { get; set; }
        [Range(1,5)]
        public double AverageRating { get; set; }
    }
}

