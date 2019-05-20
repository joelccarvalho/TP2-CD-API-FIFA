using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FootballApi.Models;

namespace FootballApi.Repositories
{
    public interface ICountryRepository {
        Task<IEnumerable<Country>> GetAll();
        Country GetById(int id);
        void Add(Country product);
    }
}