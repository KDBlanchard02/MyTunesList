using MyTunesList.Data;
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
        public string Artist { get; set; }

        [Required]
        public string AlbumTitle { get; set; }

        [Required]
        public DateTime ReleaseDate { get; set; }

        public List<string> SongList { get; set; }

    }
}
