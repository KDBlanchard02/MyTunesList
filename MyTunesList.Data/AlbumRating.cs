using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTunesList.Data
{
    public class AlbumRating
    {
        [Key]
        public int AlbumRatingId { get; set; }
        //todo: add foreign key to album

        public Guid AuthorId { get; set; }

        /*[Required]
         * public Artist_Band Artist {get; set;}
         */

        [Required]
        public double Rating { get; set; }

        public DateTimeOffset DateCreated { get; set; }
        public DateTimeOffset? DateModified { get; set; }

        public string ReviewComment { get; set; }
    }
}
