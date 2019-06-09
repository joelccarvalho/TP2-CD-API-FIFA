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
            get; set;
        }

        /// <summary>
        /// Gets the Round Id
        /// </summary>
        /// <value>Round of the game</value>
        public int RoundId {
            get; set;
        }

        /// <summary>
        /// Gets the Pos
        /// </summary>
        /// <value>Pos of the game</value>
        public int Pos {
            get; set;
        }

        /// <summary>
        /// Gets the Group Id
        /// </summary>
        /// <value>Group Id of the game</value>
        public long GroupId {
            get; set;
        }

        /// <summary>
        /// Gets the Team_1 Id
        /// </summary>
        /// <value>Team_1 Id of the game</value>
        public int Team_1 {
            get; set;
        }

        /// <summary>
        /// Gets the Team_2 Id
        /// </summary>
        /// <value>Team_2 Id of the game</value>
        public int Team_2 {
            get; set;
        }

        /// <summary>
        /// Gets the Play At
        /// </summary>
        /// <value>Play At of the game</value>
        public DateTime Play_At {
            get; set;
        }
        
        /// <summary>
        /// Gets the Postponed
        /// </summary>
        /// <value>Postponed of the game</value>
        public Boolean Postponed {
            get; set;
        }
        
        /// <summary>
        /// Gets the Knockout
        /// </summary>
        /// <value>Knockout of the game</value>
        public Boolean Knockout {
            get; set;
        }

        /// <summary>
        /// Gets the Home
        /// </summary>
        /// <value>Home of the game</value>
        public Boolean Home {
            get; set;
        }

        /// <summary>
        /// Gets the Score1
        /// </summary>
        /// <value>Score1 of the game</value>
        public int Score1 {
            get; set;
        }

        /// <summary>
        /// Gets the Score2
        /// </summary>
        /// <value>Score2 of the game</value>
        public int Score2 {
            get; set;
        }

        /// <summary>
        /// Gets the Score1i
        /// </summary>
        /// <value>Score1i of the game</value>
        public int Score1i {
            get; set;
        }

        /// <summary>
        /// Gets the Score2i
        /// </summary>
        /// <value>Score2i of the game</value>
        public int Score2i {
            get; set;
        }

        /// <summary>
        /// Gets the Winner
        /// </summary>
        /// <value>Winner of the game</value>
        public int Winner {
            get; set;
        }

        /// <summary>
        /// Gets the Winner90
        /// </summary>
        /// <value>Winner90 of the game</value>
        public int Winner90 {
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