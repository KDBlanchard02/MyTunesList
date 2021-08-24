using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTunesList.Models
{
    public class AlbumRatingDetail
    {
        public int AlbumRatingId { get; set; }
        public Guid AuthorId { get; set; }
        //public Artist_Band Artist {get; set;}
        public double Rating { get; set; }
        public DateTimeOffset DateCreated { get; set; }
        public DateTimeOffset? DateModified { get; set; }
        public string ReviewComment { get; set; }
    }
}
