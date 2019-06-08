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

        //[HttpPost]
        //public async Task<ActionResult<IEnumerable<Player>>> Post()
        //{
        //    string key = "";
        //    string name="" ;
        //    DateTime created_at= DateTime.Now;
        //    DateTime updated_at = DateTime.Now;

        //    var insertplayer = await playerRepository.InsertPlayer("12","12",DateTime.Now, DateTime.Now); da erro

        //    return Created(insertplayer);
        //}


    }
}