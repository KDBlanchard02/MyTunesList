using MyTunesList.Data;
using MyTunesList.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTunesList.Services
{
    public class AuthorizedUserAlbumService
    {
        private readonly Guid _authorizedUserId;

        public AuthorizedUserAlbumService(Guid userId)
        {
            _authorizedUserId = userId;
        }

        public bool CreateAlbum(AlbumCreate model)
        {
            var entity = new Album
            {
                //Artist = model.Artist,
                AlbumTitle = model.AlbumTitle,
                Length = model.Length,
                ReleaseDate = model.ReleaseDate,
                SongList = model.SongList
            };

            using (var context = new ApplicationDbContext())
            {
                context.Albums.Add(entity);
                return context.SaveChanges() == 1;
            }
        }

        public bool UpdateAlbum(AlbumEdit model)
        {
            using(var context = new ApplicationDbContext())
            {
                var entity =
                    context
                        .Albums
                        .Single(e => e.AlbumId == model.AlbumId && e.AuthorizedAlbumCreator == _authorizedUserId);
                entity.AlbumId = model.AlbumId;
                //entity.Artist = model.Artist;
                entity.AlbumTitle = model.AlbumTitle;
                entity.Length = model.Length;
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
                        .Single(e => e.AlbumId == albumId && e.AuthorizedAlbumCreator == _authorizedUserId);
                context.Albums.Remove(entity);
                return context.SaveChanges() == 1;
            }
        }
    }
}
