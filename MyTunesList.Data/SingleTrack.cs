using Microsoft.Azure.Amqp.Framing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTunesList.Data
{
    public class SingleTrack
    {
        [Key]
        public int SingleId { get; set; }
      
        [Required]
        public Guid OwnerId { get; set; }

        [Required]
        public string Title { get; set; }
        
        public override string ToString() => Title;
        [Required]
        public Genre Genre { get; set; }
        [Required]
        public double Length { get; set; }

        [Required]
        public string Artist_Band { get; set; }

        [Display(Name = "Date Released")]
        public DateTime ReleaseDate { get; set; }
        [Display(Name = "Date Modified")]
        public DateTimeOffset? ModifiedUtc { get; set; }
        public double AverageRating { get; set; }
    }
}
