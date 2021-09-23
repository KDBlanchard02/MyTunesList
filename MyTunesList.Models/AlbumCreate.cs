using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTunesList.Models
{
    public class AlbumCreate
    {
        [Required]
        public string Artist_Band { get; set; }

        [Required]
        public string AlbumTitle { get; set; }

        [Required]
        public int ReleaseYear { get; set; }

        public string SongList { get; set; }
    }
}
