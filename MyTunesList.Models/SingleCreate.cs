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
        public override string ToString() => Title;
        [MaxLength(8000)]
        [Display(Name = "Genre Name")]
        [Required]
        public Genre Genre { get; set; }
        [Required]
        public double Length { get; set; }
        [Required]
        public string Artist_Band { get; set; }
        [Display(Name = "Date Released")]
        [Required]
        public DateTime ReleaseDate { get; set; }
    }
}

