using MyTunesList.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTunesList.Models
{
    public class SingleRatingDetail
    {
        public int SingleRatingId { get; set; }

        [ForeignKey(nameof(SingleTrack))]
        public int SingleId { get; set; }
        public virtual SingleTrack SingleTrack { get; set; }

        public double Rating { get; set; }

        public string ReviewComment { get; set; }

        public DateTimeOffset DateCreated { get; set; }
    }
}
