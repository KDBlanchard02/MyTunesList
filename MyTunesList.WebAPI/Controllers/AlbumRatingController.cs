using Microsoft.AspNet.Identity;
using MyTunesList.Data;
using MyTunesList.Models;
using MyTunesList.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MyTunesList.WebAPI.Controllers
{
    public class AlbumRatingController : ApiController
    {
        private AlbumRatingService CreateAlbumRatingService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var albumRatingService = new AlbumRatingService(userId);
            return albumRatingService;
        }

        public IHttpActionResult Get(int id)
        {
            AlbumRatingService albumRatingService = CreateAlbumRatingService();
            var albumRatings = albumRatingService.GetAlbumRatingByAlbumRatingId(id);
            return Ok(albumRatings);
        }

        public IHttpActionResult Post(AlbumRatingCreate albumRating)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateAlbumRatingService();

            if (!service.CreateAlbumRating(albumRating))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Put(AlbumRatingEdit albumRatingEdit)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateAlbumRatingService();

            if (!service.EditAlbumRating(albumRatingEdit))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Delete(int id)
        {
            var service = CreateAlbumRatingService();

            if (!service.DeleteAlbumRating(id))
                return InternalServerError();

            return Ok();
        }
    }
}
