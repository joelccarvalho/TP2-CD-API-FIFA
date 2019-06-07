using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FootballApi.Models;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FootballApi.Repositories
{
    public interface IPlayerRepository
    {
        Task<IEnumerable<Player>> GetAll();
        Player GetById(int id);
        void Add(Player product);
    }
}