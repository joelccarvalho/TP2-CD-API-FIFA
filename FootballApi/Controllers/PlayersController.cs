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
            var player = new Player();
            player.Name = "Novo Jogador";
            player.Key = "novo jogador";
            player.Create_At = "2019-05-11 08:35:44.724566";
            player.Updated_At = "2019-05-11 08:35:44.724566";
            
            var insertplayer = await playerRepository.AddPlayer(player);

            return Ok(insertplayer);
        }
    }
}