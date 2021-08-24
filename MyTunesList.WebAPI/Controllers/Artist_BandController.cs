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
    public class Artist_BandController : ApiController
    {
        private Artist_BandService CreateArtist_BandService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var artist_BandService = new Artist_BandService(userId);
            return artist_BandService;
        }

        public IHttpActionResult Get()
        {
            Artist_BandService artist_BandService = CreateArtist_BandService();
            var artist_Bands = artist_BandService.GetArtist_Bands();
            return Ok(artist_Bands);
        }

        public IHttpActionResult Post(Artist_BandCreate artist_Band)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateArtist_BandService();

            if (!service.CreateArtist_Band(artist_Band))
                return InternalServerError();

            return Ok();
        }
    }
}
