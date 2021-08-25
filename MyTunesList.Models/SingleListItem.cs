using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTunesList.Models
{

    public class SingleListItem
    {
        [Display(Name = "Single ID")]
        public int SingleId { get; set; }
        public string Title { get; set; }
        [Display(Name = "Created")]
        public DateTimeOffset CreatedUtc { get; set; }
       
    }

}
