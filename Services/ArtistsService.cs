using System;
using System.Collections.Generic;
using art_and_knights.Models;
using art_and_knights.Repositories;

namespace art_and_knights.Services
{
  public class ArtistsService
  {

    private readonly ArtistsRepository _repo;

    public ArtistsService(ArtistsRepository repo)
    {
      _repo = repo;
    }

    internal List<Artist> Get()
    {
      return _repo.Get();
    }

    internal Artist Get(string id)
    {
      Artist found = _repo.Get(id);
      if(found == null)
      {
        throw new Exception("Invalid ID");
      }
      return found;
    }

    internal Artist Create(Artist artistData)
    {
      throw new NotImplementedException();
    }

    internal Artist Edit(Artist artistData)
    {
      throw new NotImplementedException();
    }

    internal Artist Delete(Artist artistData)
    {
      throw new NotImplementedException();
    }

    internal Artist Delete(string id)
    {
      throw new NotImplementedException();
    }
  }
}