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
        // GET api/countries
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Player>>> Get()
        {
            var allPlayers = await playerRepository.GetAll();

            return Ok(allPlayers);
        }


    }
}