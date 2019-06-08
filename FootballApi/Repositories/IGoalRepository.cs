using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FootballApi.Models;
namespace FootballApi.Repositories
{
    public interface IGoalRepository
    {
        Task<IEnumerable<Goal>> GetAll();
        Goal GetByName(string name);
        void Add(Goal product);
    }
}
