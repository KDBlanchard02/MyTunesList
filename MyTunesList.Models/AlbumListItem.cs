using MyTunesList.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTunesList.Models
{
    public class AlbumListItem
    {
        public int AlbumId { get; set; }
        public string Title { get; set; }
        public Artist_Band Artist { get; set; }
        public DateTime ReleaseDate { get; set; }
    }
}
