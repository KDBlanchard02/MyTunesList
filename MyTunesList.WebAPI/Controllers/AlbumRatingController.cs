using Microsoft.AspNet.Identity;
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
    [Authorize]
    public class AlbumRatingController : ApiController
    {
        private AlbumRatingService CreateAlbumRatingService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var albumService = new AlbumRatingService(userId);
            return albumService;
        }

        public IHttpActionResult GetRatingsByAlbumID(int id)
        {
            AlbumRatingService albumService = CreateAlbumRatingService();
            var albums = albumService.GetAlbumRatingsForAnAlbumByAlbumId(id);
            return Ok(albums);
        }

        public IHttpActionResult GetRatingByRatingID(int id)
        {
            AlbumRatingService albumService = CreateAlbumRatingService();
            var albums = albumService.GetAlbumRatingByAlbumRatingId(id);
            return Ok(albums);
        }

        public IHttpActionResult Post(AlbumRatingCreate model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateAlbumRatingService();

            if (!service.CreateAlbumRating(model))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Put(AlbumRatingEdit model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateAlbumRatingService();

            if (!service.EditAlbumRating(model))
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
