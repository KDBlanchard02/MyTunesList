﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTunesList.Models
{
    public class AlbumEdit
    {
        public int AlbumId { get; set; }
        //public string Artist_Band Artist { get; set; }
        public string AlbumTitle { get; set; }
        public double Length { get; set; }
        public List<string> SongList { get; set; }
        public DateTime ReleaseDate { get; set; }
    }
}