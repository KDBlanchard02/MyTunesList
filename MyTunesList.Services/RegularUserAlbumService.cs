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
                        Artist = entity.Artist_Band,
                        AlbumTitle = entity.AlbumTitle,
                        ReleaseDate = entity.ReleaseDate,
                        SongList = entity.SongList,
                        AverageRating = entity.AverageRating
                    };
            }
        }

        public IEnumerable<AlbumListItem> GetAlbumsByArtist(string artist)
        {

            using (var context = new ApplicationDbContext())
            {
                var query =
                    context
                        .Albums
                        .Where(e => e.Artist_Band == artist)
                        .Select(
                        e =>
                            new AlbumListItem 
                            {
                                AlbumId = e.AlbumId,
                                Title = e.AlbumTitle,
                                Artist = e.Artist_Band,
                                ReleaseDate = e.ReleaseDate
                            }
                            );
                return query.ToArray();
            }
        }
    }
}
