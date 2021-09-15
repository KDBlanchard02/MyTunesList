using MyTunesList.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.AspNet.Identity;
using MyTunesList.Models;
using MyTunesList.Data;

namespace MyTunesList.WebAPI.Controllers
{

    public class AlbumController : ApiController
    {
        private AlbumService CreateAlbumService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var regularUserAlbumService = new AlbumService(userId);
            return regularUserAlbumService;
        }

        //I decided not to do a "get all" because hypothetically that would just be a huge request that would probably crash normal computers
        public IHttpActionResult Get(string artist)
        {
            AlbumService regularUserAlbumService = CreateAlbumService();
            var albums = regularUserAlbumService.GetAlbumsByArtist(artist);
            return Ok(albums);
        }

        public IHttpActionResult Get(int id)
        {
            AlbumService regularUserAlbumService = CreateAlbumService();
            var album = regularUserAlbumService.GetAlbumByAlbumId(id);
            return Ok(album);
        }

        public IHttpActionResult Post(AlbumCreate album)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateAlbumService();

            if (!service.CreateAlbum(album))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Put(AlbumEdit album)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateAlbumService();

            if (!service.UpdateAlbum(album))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Delete(int id)
        {
            var service = CreateAlbumService();

            if (!service.DeleteAlbum(id))
                return InternalServerError();

            return Ok();
        }
    }

}
