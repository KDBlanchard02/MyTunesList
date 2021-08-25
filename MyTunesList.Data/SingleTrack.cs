using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTunesList.Data
{
    public class SingleTrack
    {
        [Key]
        public int SingleId { get; set; }
        [MaxLength(50, ErrorMessage = "There are too many characters in this field. (Max 50)")]
        [Required]
        public Guid OwnerId { get; set; }
        public string Title { get; set; }
        public override string ToString() => Title;
        public string Genre { get; set; }
        //Would not allow me to put public genre Genre { get; set; }
        public double Length { get; set; }
        public string Artist { get; set; }
        [Display(Name = "Date Released")]
        public DateTimeOffset ReleaseDate { get; set; }
        [Display(Name = "Date Modified")]
        public DateTimeOffset? ModifiedUtc { get; set; }
        [Range(1, 5)]
        public double AverageRating { get; set; }
    }
}
