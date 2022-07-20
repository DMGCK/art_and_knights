using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using art_and_knights.Models;
using art_and_knights.Repositories;

namespace art_and_knights.Services
{
  public class CastlesService
  {

    private readonly CastlesRepository _cr;
    public CastlesService(CastlesRepository cR)
    {
      _cr = cR;
    }
    internal List<Castle> Get()
    {
      return _cr.Get();
    }
    internal Castle Get(string id)
    {
      Castle castle = _cr.Get()
    }

    internal Castle Create(Artist castleData)
    {
      throw new NotImplementedException();
    }

    internal Castle Edit(Castle castleData)
    {
      throw new NotImplementedException();
    }

    internal Castle Delete(string id, string id1)
    {
      throw new NotImplementedException();
    }
  }
}