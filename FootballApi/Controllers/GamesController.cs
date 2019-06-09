using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FootballApi.Models;
using FootballApi.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace FootballApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GamesController : ControllerBase
    {
        private IGameRepository gameRepository;
        public GamesController(IGameRepository gameRepository) {
            this.gameRepository = gameRepository;
        }

        // GET api/games
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Game>>> Get()
        {
            var allGames = await gameRepository.GetAll();

            return Ok(allGames);
        }

        // POST api/games
        [HttpPost]
        public async Task<ActionResult<Game>> Post()
        {
            DateTime date = new DateTime(2019, 7, 7, 5, 0, 0);

            var game        = new Game();
            game.RoundId    = 1;
            game.Pos        = 1;
            game.GroupId    = 1;
            game.Team_1     = 1;
            game.Team_2     = 2;
            game.Play_At    = date;
            game.Postponed  = false;
            game.Knockout   = false;
            game.Home       = false;
            game.Score1     = 3;
            game.Score2     = 4;
            game.Score1i    = 1;
            game.Score2i    = 1;
            game.Winner     = 1;
            game.Winner90   = 1;
            game.Create_At  = "2019-05-11 08:35:44.688751";
            game.Updated_At = "2019-05-11 08:35:44.688751";
            
            var insertGame = await gameRepository.AddGame(game);

            return Ok(insertGame);
        }
    }
}