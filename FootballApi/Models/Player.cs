using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace FootballApi.Models
{
    public class Player
    {
        public long Id
        {
            get; internal set;
        }

        /// <summary>
        /// Gets the Country Name
        /// </summary>
        /// <value>Name of the Player</value>
        public string Name
        {
            get; internal set;
        }

        /// <summary>
        /// Gets the Country Name
        /// </summary>
        /// <value>key of the Player</value>
        public string key
        {
            get; internal set;
        }
    }
}