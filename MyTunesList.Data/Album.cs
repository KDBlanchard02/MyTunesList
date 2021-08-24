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

        public double AverageRating { get; set; }

        /*[Required]
         * public Artist_Band Artist {get; set;}
         */
    }
}
