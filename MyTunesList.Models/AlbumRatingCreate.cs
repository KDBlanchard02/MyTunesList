using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTunesList.Models
{
    public class AlbumRatingCreate
    {
        [Required]
        public double Rating { get; set; }
        public string ReviewComment { get; set; }
    }
}
