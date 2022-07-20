using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using art_and_knights.Models;
using Dapper;

namespace art_and_knights.Repositories
{
  public class ArtistsRepository
  {
    private readonly IDbConnection _db;

    public ArtistsRepository(IDbConnection db)
    {
        _db = db;
    }
    internal List<Artist> Get()
    {
        string sql = "SELECT * FROM artists";
        return _db.Query<Artist>(sql).ToList();

    }

    internal Artist Get(string id)
    {
        string sql = $"SELECT * FROM artists WHERE id = @id";
        return _db.QueryFirstOrDefault<Artist>(sql,new {id});

        // DAPPER is the @id in the string, and the , new {col name}
    }
  }
  
}