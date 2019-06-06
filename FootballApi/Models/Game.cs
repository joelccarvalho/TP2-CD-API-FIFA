using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FootballApi.Models
{
    /// <summary>
    /// Game Model Object
    /// </summary>
    public class Game
    {
        public long Id {
            get; internal set;
        }

        /// <summary>
        /// Gets the Round Id
        /// </summary>
        /// <value>Round of the game</value>
        public int RoundId {
            get; internal set;
        }

        /// <summary>
        /// Gets the Pos
        /// </summary>
        /// <value>Pos of the game</value>
        public int Pos {
            get; internal set;
        }

        /// <summary>
        /// Gets the Group Id
        /// </summary>
        /// <value>Group Id of the game</value>
        public long GroupId {
            get; internal set;
        }

        /// <summary>
        /// Gets the Team_1 Id
        /// </summary>
        /// <value>Team_1 Id of the game</value>
        public int Team_1 {
            get; internal set;
        }

        /// <summary>
        /// Gets the Team_2 Id
        /// </summary>
        /// <value>Team_2 Id of the game</value>
        public int Team_2 {
            get; internal set;
        }

        /// <summary>
        /// Gets the Play At
        /// </summary>
        /// <value>Play At Id of the game</value>
        public DateTime Play_At {
            get; internal set;
        }
    }
}