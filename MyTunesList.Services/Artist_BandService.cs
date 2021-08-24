using MyTunesList.Data;
using MyTunesList.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTunesList.Services
{
    public class Artist_BandService
    {
        private readonly Guid _userId;

        public Artist_BandService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateArtist_Band(Artist_BandCreate model)
        {
            var entity = new Artist_Band()
            {
                AuthorId = _userId,
                Name = model.Name,
                FormationDate = model.FormationDate,
                Location = model.Location,
                Description = model.Description,
                Genre = model.Genre
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Artist_Bands.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<Artist_BandListItem> GetArtist_Bands()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx
                    .Artist_Bands
                    .Where(e => e.AuthorId == _userId)
                    .Select(
                    e =>
                    new Artist_BandListItem
                    {
                        Artist_BandId = e.Artist_BandId,
                        Name = e.Name,
                        FormationDate = e.FormationDate,
                        Location = e.Location,
                        Description = e.Description,
                        Genre = e.Genre
                    }
                    );
                return query.ToArray();
            }
        }
    }
}
