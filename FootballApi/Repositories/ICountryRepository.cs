using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FootballApi.Models;

namespace FootballApi.Repositories
{
    public interface ICountryRepository {
        Task<IEnumerable<Country>> GetAll();
        Task<IEnumerable<Country>> GetById(int? continent_id);
        void Add(Country product);
    }
}