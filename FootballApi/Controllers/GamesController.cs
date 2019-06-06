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

    }
}