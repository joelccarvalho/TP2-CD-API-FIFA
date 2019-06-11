using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FootballApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FootballApi.Repositories
{
    public interface IGameRepository
    {
        Task<IEnumerable<Game>> GetAll();
        Task<Game> AddGame([FromBody]Game game);
        Task<Int64> StartGame(int id, [FromBody]Game game);

        
    } 
}
