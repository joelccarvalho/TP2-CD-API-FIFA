using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FootballApi.Models;

namespace FootballApi.Repositories
{
    public interface IGameRepository
    {
        Task<IEnumerable<Game>> GetAll();
        Task<Game> AddGame(Game game); 
    } 
}
