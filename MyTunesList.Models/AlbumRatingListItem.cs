using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTunesList.Models
{
    public class AlbumRatingListItem
    {
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
