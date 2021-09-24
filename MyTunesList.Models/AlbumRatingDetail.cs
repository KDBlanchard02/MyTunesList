using MyTunesList.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTunesList.Models
{
    public class AlbumRatingDetail
    {
        [ForeignKey(nameof(Album))]
        public int AlbumId { get; set; }
        public virtual Album Album { get; set; }


        [ForeignKey(nameof(Artist_Band))]
        public int ArtistId { get; set; }
        public virtual Artist_Band Artist_Band { get; set; }


        public int AlbumRatingId { get; set; }
        public Guid AuthorId { get; set; }

        public double Rating { get; set; }
        public string ReviewComment { get; set; }
        

        [Display(Name = "Created")]
        public DateTimeOffset DateCreated { get; set; }

        [Display(Name = "Edited")]
        public DateTimeOffset? DateModified { get; set; }

    }
}
