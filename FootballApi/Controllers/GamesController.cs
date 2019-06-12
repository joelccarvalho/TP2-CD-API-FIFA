using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FootballApi.Errors;
using FootballApi.General;
using FootballApi.Models;
using FootballApi.Repositories;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
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

             bool areAllPropertiesNotNull = g.ArePropertiesNotNull();

            // Any property is null
            if(!areAllPropertiesNotNull) {
                throw new BadRequestException("Properties can not be null");
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

        // POST api/games/{id}/startGame
        [HttpPost("{id}/startGame")]
        public async Task<ActionResult<Int64>> StartGame(int id, [FromBody]Game g)
        {
            // Name is null
            if (g.Play_At == null)
            {
                throw new BadRequestException("Properties can not be null");
            }

            // DateTime startDate = new DateTime;
            DateTime startingDate = g.Play_At;

            // Assign values from the body
            var game     = new Game();
            game.Id      = id;
            game.Play_At = startingDate;

            var updateplayer = await gameRepository.StartGame(id, game);

            // Success
            if (updateplayer == 1)
            {
                Dictionary<string, string> dict = new Dictionary<string, string>();

                // Beauty response
                dict.Add("Status", "Success");
                dict.Add("Results", "Game " + game.Id + " started");
                return Ok(JsonConvert.SerializeObject(dict));
            }
            else
                throw new NotFoundException("Game Id:" + game.Id.ToString()); // Id not found
        }

        // POST api/games/{id}/scoreGoal
        [HttpPost("{id}/scoreGoal")]
        public async Task<ActionResult<Int64>> ScoreGoal(int id, [FromBody]Game g)
        {
            // Score1 is 0 or negative
            if (g.Score1 <= 0)
            {
                throw new BadRequestException("Score1 can not be zero or negative");
            }

            // Assign values from the body
            var game     = new Game();
            game.Id      = id;
            game.Score1  = g.Score1;

            var updateplayer = await gameRepository.ScoreGoal(id, game);

            // Success
            if (updateplayer == 1)
            {
                Dictionary<string, string> dict = new Dictionary<string, string>();

                // Beauty response
                dict.Add("Status", "Success");
                dict.Add("Results", "Team1 score a goal!! Game ID:" + game.Id);
                return Ok(JsonConvert.SerializeObject(dict));
            }
            else
                throw new NotFoundException("Game Id:" + game.Id.ToString()); // Id not found
        }

        // POST api/games/{id}/endGame
        [HttpPost("{id}/endGame")]
        public async Task<ActionResult<Int64>> EndGame(int id, [FromBody]Game g)
        {
            // Winner and Winner90 are null
            if (g.Winner.ToString() == null || g.Winner90.ToString() == null)
            {
                throw new BadRequestException("Winner or Winner90 can not be null");
            }
            else if((g.Winner < 1 || g.Winner > 2)|| (g.Winner90 < 1 || g.Winner90 > 2)){
                throw new BadRequestException("Only exits two teams!");
            }

            // Assign values from the body
            var game       = new Game();
            game.Id        = id;
            game.Winner    = g.Winner;
            game.Winner90  = g.Winner90;

            var updateplayer = await gameRepository.EndGame(id, game);

            // Success
            if (updateplayer == 1)
            {
                Dictionary<string, string> dict = new Dictionary<string, string>();

                // Beauty response
                dict.Add("Status", "Success");
                dict.Add("Results", "Team ID: "+ game.Winner+ " Winner! ");
                return Ok(JsonConvert.SerializeObject(dict));
            }
            else
                throw new NotFoundException("Game Id:" + game.Id.ToString()); // Id not found
        }
    }
}