using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FootballApi.Errors;
using FootballApi.Models;
using FootballApi.Repositories;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace FootballApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayersController : ControllerBase
    {
        private IPlayerRepository playerRepository;
        public PlayersController(IPlayerRepository playerRepository)
        {
            this.playerRepository = playerRepository;
        }

        // GET api/players
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Player>>> Get()
        {
            var allPlayers = await playerRepository.GetAll();

            return Ok(allPlayers);
        }

        // POST api/players
        [HttpPost]
        public async Task<ActionResult<Player>> Post()
        {
            var player        = new Player();
            player.Name       = "New Player";
            player.Key        = "new player";
            player.Create_At  = "2019-05-11 08:35:44.724566";
            player.Updated_At = "2019-05-11 08:35:44.724566";
            
            var insertplayer = await playerRepository.AddPlayer(player);

            return Ok(insertplayer);
        }

        // PATCH api/players/{id}
        [HttpPatch("{id}")]
        public async Task<ActionResult<Int64>> Patch(int id)
        {
            var player  = new Player();
            player.Id   = id;
            player.Name = "Player updated";
            
            var updateplayer = await playerRepository.UpdatePlayer(player);
            
            if(updateplayer == 1)
            {
                Dictionary<string, string> dict = new Dictionary<string, string>();

                // Beauty response
                dict.Add("Status", "Success");
                dict.Add("Results", "Player "+ player.Id + " updated");
                return Ok(JsonConvert.SerializeObject(dict));
            }
            else
                throw new NotFoundException("Player Id:" + player.Id.ToString()); // Id not found
        }

        // DELETE api/players/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult<Int64>> Delete(int id)
        {            
            var updateplayer = await playerRepository.DeletePlayer(id);
            
            if(updateplayer == 1)
            {
                Dictionary<string, string> dict = new Dictionary<string, string>();

                // Beauty response
                dict.Add("Status", "Success");
                dict.Add("Results", "Player "+ id + " deleted");
                return Ok(JsonConvert.SerializeObject(dict));
            }
            else
                throw new NotFoundException("Player Id:" + id.ToString()); // Id not found
        }
    }
}