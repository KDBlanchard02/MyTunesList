﻿using MyTunesList.Data;
using MyTunesList.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTunesList.Services
{
    public class SingleRatingService
    {
        private readonly Guid _userId;

        public SingleRatingService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateSingleRating(SingleRatingCreate model)
        {
            var entity = new SingleRating()
            {
                AuthorId = _userId,
                Rating = model.Rating,
                ReviewComment = model.ReviewComment,
                DateCreated = DateTimeOffset.Now
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.SingleRatings.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<SingleRatingListItem> GetSingleRatings()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx
                    .SingleRatings
                    .Where(e => e.AuthorId == _userId)
                    .Select(
                    e =>
                    new SingleRatingListItem
                    {
                        SingleRatingId = e.SingleRatingId,
                        SingleId = e.SingleId,
                        Rating = e.Rating,
                        ReviewComment = e.ReviewComment,
                        DateCreated = e.DateCreated
                    }
                    );
                return query.ToArray();
            }
        }
    }
}
