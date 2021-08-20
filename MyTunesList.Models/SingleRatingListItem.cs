using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTunesList.Models
{
    public class SingleRatingListItem
    {
        public int SingleRatingId { get; set; }

        [ForeignKey(nameof(Single))]
        public int SingleId { get; set; }
        public virtual Single Single { get; set; }

        public double Rating { get; set; }

        public string ReviewComment { get; set; }

        public DateTimeOffset DateCreated { get; set; }
    }
}
