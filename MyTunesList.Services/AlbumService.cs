using MyTunesList.Data;
using MyTunesList.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTunesList.Services
{
    public class AlbumService
    {
        private readonly Guid _userId;

        public AlbumService(Guid userId)
        {
            _userId = userId;
        }
        public bool CreateAlbum(AlbumCreate model)
        {
            var entity = new Album
            {
                AlbumCreator = _userId,
                Artist_Band = model.Artist,
                AlbumTitle = model.AlbumTitle,
                ReleaseDate = model.ReleaseDate,
                SongList = model.SongList
            };

            using (var context = new ApplicationDbContext())
            {
                context.Albums.Add(entity);
                return context.SaveChanges() == 1;
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



        public bool UpdateAlbum(AlbumEdit model)
        {
            using(var context = new ApplicationDbContext())
            {
                var entity =
                    context
                        .Albums
                        .Single(e => e.AlbumId == model.AlbumId && e.AlbumCreator == _userId);
                entity.AlbumId = model.AlbumId;
                entity.Artist_Band = model.Artist;
                entity.AlbumTitle = model.AlbumTitle;
                entity.SongList = model.SongList;
                entity.ReleaseDate = model.ReleaseDate;

                return context.SaveChanges() == 1;
            }
        }

        public bool DeleteAlbum(int albumId)
        {
            using (var context = new ApplicationDbContext())
            {
                var entity =
                    context
                        .Albums
                        .Single(e => e.AlbumId == albumId && e.AlbumCreator == _userId);
                context.Albums.Remove(entity);
                return context.SaveChanges() == 1;
            }
        }
    }
}
