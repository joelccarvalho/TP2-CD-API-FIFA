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
            get; set;
        }

        /// <summary>
        /// Gets the Player Name
        /// </summary>
        /// <value>Name of the Player</value>
        public string Name
        {
            get; set;
        }

        /// <summary>
        /// Gets the Player Key
        /// </summary>
        /// <value>Key of the Player</value>
        public string Key
        {
            get; set;
        }

        /// <summary>
        /// Gets the Player Create_At
        /// </summary>
        /// <value>Create_At of the Player</value>
        public string Create_At
        {
            get; set;
        }

        /// <summary>
        /// Gets the Player Updated_At
        /// </summary>
        /// <value>Updated_At of the Player</value>
        public string Updated_At
        {
            get; set;
        }
    }
}