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
    public class GoalsController : ControllerBase
    {
        private IGoalRepository goalRepository;
        public GoalsController(IGoalRepository goalRepository)
        {
            this.goalRepository = goalRepository;
        }
        // GET api/goals
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Player>>> Get()
        {
            var allPlayers = await goalRepository.GetAll();

            return Ok(allPlayers);
        }

        // GET api/goals/{name}
        [HttpGet("{name}")]
        public ActionResult<string> Get(string name)
        {
            var goal = goalRepository.GetByName(name);

            if (goal != null)
                return Ok(goal);
            else
                throw new NoContentException("goal");
        }



    }
}