using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTunesList.Data
{
    public class Album
    {
        [Key]
        public int AlbumId { get; set; }

        [Required]
        public string AlbumTitle { get; set; }

        [Required]
        public double Length { get; set; }

        [Required]
        public DateTime ReleaseDate { get; set; }

        public List<string> SongList { get; set; }

        public virtual List<AlbumRating> Ratings { get; set; } = new List<AlbumRating>();
        [Range(1, 5)]
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

        /*[Required]
         * public Artist_Band Artist {get; set;}
         */

        public Guid AuthorizedAlbumCreator { get; set; }
    }
}
