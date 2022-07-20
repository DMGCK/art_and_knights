using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using art_and_knights.Models;
using System;
using art_and_knights.Services;
using Microsoft.AspNetCore.Authorization;
using CodeWorks.Auth0Provider;
using System.Threading.Tasks;

namespace art_and_knights.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class ArtistsController : ControllerBase
  {
    private readonly ArtistsService _as;
    // constructor that instantiates the service
    public ArtistsController(ArtistsService artistsService)
    {
      _as = artistsService;
    }

    [HttpGet]
    public ActionResult<List<Artist>> Get()
    {
      try
      {
        List<Artist> artists = _as.Get();
        return Ok(artists);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpGet("{id}")]
    public ActionResult<Artist> Get(string id)
    {
      try
      {
        Artist singleArtist = _as.Get(id);
        return Ok(singleArtist);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpPost]
    [Authorize]
    public async Task<ActionResult<Artist>> Create([FromBody] Artist artistData)
    {
      try
      {
        // CreatorId
        Account userInfo = await HttpContext.GetUserInfoAsync<Account>();

        artistData.CreatorId = userInfo.Id;

        Artist newArtist = _as.Create(artistData);
        return Ok(newArtist);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [Authorize]
    [HttpPut("{id}")]
    public ActionResult<Artist> Edit(string id, [FromBody] Artist artistData)
    {
      try
      {
        // 
        // 
        // edit params

        Artist update = _as.Edit(artistData);
        return Ok(update);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    [Authorize]
    [HttpDelete("{id}")]
    public ActionResult<Artist> Delete(string id)
    {
      try
      {
        Artist deletedArtist = _as.Delete(id);
        return Ok(deletedArtist);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

  }
}