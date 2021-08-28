using MyTunesList.Data;
using MyTunesList.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTunesList.Services
{
    public class RegularUserAlbumService
    {
        private readonly Guid _userId;

        public RegularUserAlbumService(Guid userId)
        {
            _userId = userId;
        }

        public AlbumDetail GetAlbumByAlbumId(int id)
        {
            using (var context = new ApplicationDbContext())
            {
                var entity =
                    context
                        .Albums
                        .Single(e => e.AlbumId == id);
                return
                    new AlbumDetail
                    {
                        AlbumId = entity.AlbumId,
                        Artist = entity.Artist,
                        AlbumTitle = entity.AlbumTitle,
                        Length = entity.Length,
                        ReleaseDate = entity.ReleaseDate,
                        SongList = entity.SongList,
                        AverageRating = entity.AverageRating
                    };
            }
        }

        public IEnumerable<AlbumListItem> GetAlbumsByArtist(Artist_Band artist)
        {
            using (var context = new ApplicationDbContext())
            {
                var query =
                    context
                        .Albums
                        .Where(e => e.Artist == artist)
                        .Select(
                        e =>
                            new AlbumListItem 
                            {
                                AlbumId = e.AlbumId,
                                Title = e.AlbumTitle,
                                Artist = e.Artist,
                                ReleaseDate = e.ReleaseDate
                            }
                            );
                return query.ToArray();
            }
        }
    }
}
