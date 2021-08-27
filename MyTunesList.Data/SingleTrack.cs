using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTunesList.Data
{
    public class SingleTrack
    {
        [Key]
        public int SingleId { get; set; }
      
        [Required]
        public Guid OwnerId { get; set; }

        [Required]
        public string Title { get; set; }
        
        public override string ToString() => Title;
        [Required]
        public Genre Genre { get; set; }
        [Required]
        public double Length { get; set; }

        [Required]
        public string Artist_Band { get; set; }

        [Display(Name = "Date Released")]
        public DateTimeOffset ReleaseDate { get; set; }
        [Display(Name = "Date Modified")]
        public DateTimeOffset? ModifiedUtc { get; set; }

        public virtual List<SingleRating> Ratings { get; set; } = new List<SingleRating>();
        public double AverageRating 
        { 
            get
            {
                double totalAverageRating = 0;

                //add all ratings
                foreach (var rating in Ratings)
                {
                    totalAverageRating += rating.Rating;
                }

                //get average from total
                return Ratings.Count > 0
                    ? Math.Round(totalAverageRating / Ratings.Count, 2) // if Ratings.Count > 0
                    : 0; // if Ratings.Count not > 0
            }
        }
    }
}
