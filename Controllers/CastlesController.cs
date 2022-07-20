using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using art_and_knights.Models;
using art_and_knights.Services;
using CodeWorks.Auth0Provider;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace art_and_knights.Controllers
{
  [ApiController]
  [Route("api/[controller]")]

  public class CastlesController : ControllerBase
  {
    private readonly CastlesService _cs;

    public CastlesController(CastlesService cas)
    {
      _cs = cas;
    }
    [HttpGet]
    public ActionResult<List<CastlesController>> Get()
    {
      try
      {
        List<Castle> castles = _cs.Get();
        return Ok(castles);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpGet("{id}")]
    public ActionResult<Castle> Get(string id)
    {
      try
      {
        Castle singleCastle = _cs.Get(id);
        return Ok(singleCastle);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpPost]
    [Authorize]
    public async Task<ActionResult<Castle>> Create([FromBody] Artist castleData)
    {
      try
      {
        // CreatorId
        Account userInfo = await HttpContext.GetUserInfoAsync<Account>();

        castleData.CreatorId = userInfo.Id;

        Castle newCastle = _cs.Create(castleData);
        return Ok(newCastle);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }


    [Authorize]
    [HttpPut("{id}")]
    public async Task<ActionResult<Castle>> Edit(string id, [FromBody] Castle CastleData)
    {
      try
      {
        Account userInfo = await HttpContext.GetUserInfoAsync<Account>();

        CastleData.CreatorId = userInfo.Id;
        // 
        // 
        // edit params

        Castle update = _cs.Edit(CastleData);
        return Ok(update);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [Authorize]
    [HttpDelete("{id}")]
    public async Task<ActionResult<Castle>> Delete(string id)
    {
      try
      {
        Account userInfo = await HttpContext.GetUserInfoAsync<Account>();

        Castle deletedCastle = _cs.Delete(id, userInfo.Id);
        return Ok(deletedCastle);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }


  }
}