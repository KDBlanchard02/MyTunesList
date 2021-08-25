using MyTunesList.Data;
using MyTunesList.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTunesList.Services
{
    public class SingleService
    {
        public class SingleCreate
        {
            private readonly Guid _singleId;

            public SingleService(Guid singleId)
            {
                _singleId = singleId;
            }

            public bool CreateSingle(SingleCreate model)
            {
                var entity =
                    new Single()
                    {
                        ArtistId = _singleId,
                        Title = model.Title,
                        Genre = model.Genre,
                        Length = model.Length,
                        Artist = model.Artist,
                        ReleaseDate = DateTimeOffset.Now,
                        AverageRating = model.AverageRating,
                    };

                using (var ctx = new ApplicationDbContext())
                {
                    ctx.Single.Add(entity);
                    return ctx.SaveChanges() == 1;
                }
            }

            public IEnumerable<SingleListItem> GetAllSingles()
            {

                using (var ctx = new ApplicationDbContext())
                {
                    var query =
                        ctx
                            .Singles
                            .Where(e => e.ArtistId == _singleId)
                            .Select(
                                e =>
                                    new SingleListItem
                                    {
                                        SingleId = e.SongId,
                                        Title = e.Title,
                                        Genre = e.Genre,
                                        Length = e.Length,
                                        Artist = e.Artist,
                                        ReleaseDate = e.ReleaseDate,
                                        AverageRating = e.AverageRating,
                                    }

                             );
                    return query.ToArray();

                }
            }
            public SingleDetail GetSingleById(int id)
            {
                using (var ctx = new ApplicationDbContext())
                {
                    var entity =
                        ctx
                            .Singles
                            .Single(e => e.SingleId == id && e.OwnerId == _singleId);
                    return
                        new SingleDetail
                        {
                            SingleId = entity.SingleId,
                            Title = entity.Title,
                            Genre = entity.Genre,
                            Length = entity.Length,
                            Artist = entity.Artist,
                            ReleaseDate = entity.ReleaseDate,
                            AverageRating = entity.AverageRating,
                        };
                }
            }

            public bool UpdateSingle(SingleEdit model)
            {
                using (var ctx = new ApplicationDbContext())
                {
                    var entity =
                        ctx
                            .Singles
                            .Single(e => e.SingleId == model.SingleId && e.SongId == _singleId);

                    entity.SingleId = model.SingleId;
                    entity.Title = model.Title;
                    entity.Genre = model.Genre;
                    entity.Length = model.Length;
                    entity.Artist = model.Artist;
                    entity.ReleaseDate = DateTimeOffset.ReleaseDate;
                    entity.AverageRating = model.AverageRating;

                    return ctx.SaveChanges() == 1;
                }
            }
            public bool DeleteSingle(int songId)
            {
                using (var ctx = new ApplicationDbContext())
                {
                    var entity =
                        ctx
                            .Singles
                            .Single(e => e.SingleId == SingleId && e.SongId == _singleId);

                    ctx.Singles.Remove(entity);

                    return ctx.SaveChanges() == 1;
                }
            }

        }
    }
}
