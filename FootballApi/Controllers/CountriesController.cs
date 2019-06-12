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
    public class CountriesController : ControllerBase
    {
        private ICountryRepository countryRepository;
        public CountriesController(ICountryRepository countryRepository) {
            this.countryRepository = countryRepository;
        }

        // GET api/countries
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Country>>> Get()
        {
            var allCountries = await countryRepository.GetAll();

            return Ok(allCountries);
        }

        // GET api/countries/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<Country>>> Get(int id)
        {
            var allCountries = await countryRepository.GetById(id);

            // Check is empty
            bool isEmpty     = !allCountries.Any();

            if(isEmpty)
                throw new NotFoundException("Continent ID:" + id);
            else
                return Ok(allCountries);  
        }
    }
}
