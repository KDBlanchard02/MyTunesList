using MyTunesList.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.AspNet.Identity;
using MyTunesList.Models;

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

        public IHttpActionResult Get()
        {
            RegularUserAlbumService regularUserAlbumService = CreateRegularUserAlbumService();
            var albums = regularUserAlbumService.GetAlbums();
            return Ok(albums);
        }

        public IHttpActionResult Get(int id)
        {
            RegularUserAlbumService regularUserAlbumService = 
        }

        public IHttpActionResult Post(AlbumCreate album)
        {

        }

        public IHttpActionResult Put(AlbumEdit album)
        {

        }

        public IHttpActionResult Delete(int id)
        {

        }
    }

}
