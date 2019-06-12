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

        // GET api/countries || api/countries?continent_id={ID}
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Country>>> Get(int? continent_id)
        {
            IEnumerable<Country> allCountries;

            // Has parameter
            if (continent_id.HasValue)
                allCountries = await countryRepository.GetById(continent_id);
            else // Without parameter
                allCountries = await countryRepository.GetAll();

            // Check is empty
            bool isEmpty     = !allCountries.Any();

            if(isEmpty)
                throw new NotFoundException("Continent ID:" + continent_id);
            else
                return Ok(allCountries);  
        }
    }
}
