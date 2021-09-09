using MyTunesList.Data;
using System; 
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTunesList.Models
{
    public class SingleEdit
    {
        public int SingleId { get; set; }
        public string Title { get; set; }
        public Genre Genre { get; set; }
        public string Artist_Band { get; set; }
        public double Length { get; set; }
    }
}
