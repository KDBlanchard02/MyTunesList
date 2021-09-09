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
        private readonly Guid _singleId;

        public SingleService(Guid singleId)
        {
            _singleId = singleId;
        }

        public bool CreateSingle(SingleCreate model)
        {
            var entity =
                new SingleTrack()
                {
                    AuthorId = _singleId,
                    Title = model.Title,
                    Genre = model.Genre,
                    Length = model.Length,
                    Artist_Band = model.Artist_Band,
                    ReleaseDate = DateTimeOffset.Now,
                    AverageRating = model.AverageRating,
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.SingleTracks.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<SingleListItem> GetAllSingles()
        {

            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .SingleTracks
                        .Where(e => e.AuthorId == _singleId)
                        .Select(
                            e =>
                                new SingleListItem
                                {
                                    SingleId = e.SingleId,
                                    Title = e.Title,
                                    CreatedUtc = e.ReleaseDate,
                                    Artist_Band = e.Artist_Band
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
                        .SingleTracks
                        .Single(e => e.SingleId == id && e.AuthorId == _singleId);
                return
                    new SingleDetail
                    {
                        SingleId = entity.SingleId,
                        Title = entity.Title,
                        CreatedUtc = entity.ReleaseDate,
                        ModifiedUtc = entity.ModifiedUtc
                    };
            }
        }

        public bool UpdateSingleTrack(SingleEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .SingleTracks
                        .Single(e => e.SingleId == model.SingleId && e.AuthorId == _singleId);

                entity.Title = model.Title;
                entity.Genre = model.Genre;
                entity.Artist_Band = model.Artist_Band;
                entity.Length = model.Length;
                entity.ModifiedUtc = DateTimeOffset.UtcNow;
                
                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteSingle(int singleId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .SingleTracks
                        .Single(e => e.SingleId == singleId && e.AuthorId == _singleId);

                ctx.SingleTracks.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }

    }
}

