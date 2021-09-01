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
        private RegularUserAlbumService CreateRegularUserAlbumService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var regularUserAlbumService = new RegularUserAlbumService(userId);
            return regularUserAlbumService;
        }

        private AuthorizedUserAlbumService CreateAuthorizedUserAlbumService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var authorizedUserAlbumService = new AuthorizedUserAlbumService(userId);
            return authorizedUserAlbumService;
        }

        //I decided not to do a "get all" because hypothetically that would just be a huge request that would probably crash normal computers
        public IHttpActionResult Get(Artist_Band artist)
        {
            RegularUserAlbumService regularUserAlbumService = CreateRegularUserAlbumService();
            var albums = regularUserAlbumService.GetAlbumsByArtist(artist);
            return Ok(albums);
        }

        public IHttpActionResult Get(int id)
        {
            RegularUserAlbumService regularUserAlbumService = CreateRegularUserAlbumService();
            var album = regularUserAlbumService.GetAlbumByAlbumId(id);
            return Ok(album);
        }

        public IHttpActionResult Post(AlbumCreate album)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateAuthorizedUserAlbumService();

            if (!service.CreateAlbum(album))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Put(AlbumEdit album)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateAuthorizedUserAlbumService();

            if (!service.UpdateAlbum(album))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Delete(int id)
        {
            var service = CreateAuthorizedUserAlbumService();

            if (!service.DeleteAlbum(id))
                return InternalServerError();

            return Ok();
        }
    }

}
