﻿using MyTunesList.Data;
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
                AuthorId = _userId,
                Rating = model.Rating,
                ReviewComment = model.ReviewComment,
                DateCreated = DateTimeOffset.Now
            };

            using (var context = new ApplicationDbContext())
            {
                context.AlbumRatings.Add(entity);
                return context.SaveChanges() == 1;
            }
        }

        public IEnumerable<AlbumRatingListItem> GetAlbumRatingsForAnAlbumByAlbumId(int albumId)
        {
            using (var context = new ApplicationDbContext())
            {
                var query =
                    context
                        .AlbumRatings
                        .Where(e => e.AlbumId == albumId)
                        .Select(
                            e => new AlbumRatingListItem
                            {
                                AlbumRatingId = e.AlbumRatingId,
                                AuthorId = e.AuthorId,
                                Rating = e.Rating,
                                ReviewComment = e.ReviewComment,
                                DateCreated = e.DateCreated,
                                DateModified = e.DateModified
                            });
                return query.ToArray();
            }
        }

        public AlbumRatingDetail GetAlbumRatingByAlbumRatingId(int id)
        {
            using (var context = new ApplicationDbContext())
            {
                var entity =
                    context
                        .AlbumRatings
                        .Single(e => e.AlbumRatingId == id);
                return
                    new AlbumRatingDetail
                    {
                        AlbumRatingId = entity.AlbumRatingId,
                        Rating = entity.Rating,
                        ReviewComment = entity.ReviewComment,
                        DateCreated = entity.DateCreated,
                        DateModified = entity.DateModified,
                        Album = entity.Album
                    };
            }
        }

        public bool EditAlbumRating(AlbumRatingEdit model)
        {
            using(var context = new ApplicationDbContext())
            {
                var entity =
                    context
                        .AlbumRatings
                        .Single(e => e.AlbumRatingId == model.AlbumRatingId && e.AuthorId == _userId);
                entity.AlbumRatingId = model.AlbumRatingId;
                entity.Rating = model.Rating;
                entity.ReviewComment = model.ReviewComment;
                entity.DateModified = DateTimeOffset.UtcNow;

                return context.SaveChanges() == 1;
            }
        }

        public bool DeleteAlbumRating(int albumRatingId)
        {
            using (var context = new ApplicationDbContext())
            {
                var entity =
                    context
                        .AlbumRatings
                        .Single(e => e.AlbumRatingId == albumRatingId && e.AuthorId == _userId);
                context.AlbumRatings.Remove(entity);
                return context.SaveChanges() == 1;
            }
        }
    }
}
