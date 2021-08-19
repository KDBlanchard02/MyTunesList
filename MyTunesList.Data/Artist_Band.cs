using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTunesList.Data
{
    public class Artist_Band
    {
        [Key]
        public int Artist_BandId { get; set; }

        [Required]
        public string Name { get; set; }

        public List<string> Discography { get; set; }
        
        [Required]
        public DateTime FormationDate { get; set; }

        public double AverageRating { get; set; }

        [Required]
        public string Location { get; set; }

        [Required]
        public string Description { get; set; }

       // [Required]
       // public enum Genre { get; set; }

    }
}
