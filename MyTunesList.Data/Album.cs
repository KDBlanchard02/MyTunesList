using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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

        //Removed length, I don't really see it being necessary but may add it back in as a stretch goal, time permitting

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
                foreach (var rating in Ratings)
                {
                    totalAverageRating += rating.Rating;
                }
                return Ratings.Count > 0
                    ? Math.Round(totalAverageRating / Ratings.Count, 2) // if Ratings.Count > 0
                    : 0; // if Ratings.Count not > 0
            }
        }

        //[ForeignKey(nameof(Artist_Band))]
        //public int ArtistId { get; set; }

        [Required]
        public string Artist_Band {get; set;}

        //Only the creators of albums should be able to delete them, so this needed to be added
        [Required]
        public Guid AuthorizedAlbumCreator { get; set; }
    }
}
