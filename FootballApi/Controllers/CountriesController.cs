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
        public ActionResult<string> Get(int id)
        {
            var country = countryRepository.GetById(id);
            
            if (country != null)
                return Ok(country);
            else
                throw new NotFoundException("Country Id:" + id.ToString()); // Id not found    
        }
    }
}
