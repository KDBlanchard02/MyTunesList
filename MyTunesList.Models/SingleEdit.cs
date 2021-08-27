using MyTunesList.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTunesList.Models
{
    public class SingleEdit
    {
        public int SingleId { get; set; }
        public string Title { get; set; }
        public override string ToString() => Title;
        [Display(Name = "Genre")]
        public Genre Genre { get; set; }
        public double Length { get; set; }
        public string Artist_Band { get; set; }
        [Display(Name = "Date Released")]
        public DateTime ReleaseDate { get; set; }
    }
}
