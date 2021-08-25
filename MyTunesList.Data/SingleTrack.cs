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
        public int SongId { get; set; }
        [MaxLength(50, ErrorMessage = "There are too many characters in this field. (Max 50)")]
        [Required]
        public string Title { get; set; }
        public override string ToString() => Title;
        public Genre Genre { get; set; }
        public double Length { get; set; }
        public string Artist { get; set; }
        [Display(Name = "Date Released")]
        public DateTime ReleaseDate { get; set; }
        [Range(1, 5)]
        public double AverageRating { get; set; }
    }
}
