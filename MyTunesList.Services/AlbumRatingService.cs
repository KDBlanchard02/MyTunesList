using MyTunesList.Data;
using MyTunesList.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTunesList.Services
{
    public class AlbumRatingService
    {
        private readonly Guid _userId;

        public AlbumRatingService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateAlbumRating(AlbumRatingCreate model)
        {
            var entity = new AlbumRating
            {
                
            }
        }
    }
}
