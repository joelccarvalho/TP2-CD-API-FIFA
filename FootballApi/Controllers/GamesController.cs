using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FootballApi.Errors;
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
        public async Task<ActionResult<Game>> Post([FromBody]Game g)
        {
            // Compare current date with date from body
            DateTime localDate = DateTime.Now;
            int result         = DateTime.Compare(localDate, g.Play_At);

            // The date is not later than today
            if(result >= 0) {
                throw new BadRequestException("The date should be later than today");
            }

            var game        = new Game();
            game.RoundId    = g.RoundId;
            game.Pos        = g.Pos;
            game.GroupId    = g.GroupId;
            game.Team_1     = g.Team_1;
            game.Team_2     = g.Team_2;
            game.Play_At    = g.Play_At;
            game.Postponed  = g.Postponed;
            game.Knockout   = g.Knockout;
            game.Home       = g.Home;
            game.Score1     = g.Score1;
            game.Score2     = g.Score2;
            game.Score1i    = g.Score1i;
            game.Score2i    = g.Score2i;
            game.Winner     = g.Winner;
            game.Winner90   = g.Winner90;
            game.Create_At  = g.Create_At;
            game.Updated_At = g.Updated_At;
            
            var insertGame = await gameRepository.AddGame(game);

            return Ok(insertGame);
        }
    }
}