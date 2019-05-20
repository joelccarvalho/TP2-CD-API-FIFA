using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FootballApi.Models
{
    /// <summary>
    /// Country Model Object
    /// </summary>
    public class Country {

        public long Id {
            get; internal set;
        }

        /// <summary>
        /// Gets the Country Name
        /// </summary>
        /// <value>Name of the country</value>
        public string Name {
            get; internal set;
        }

        /// <summary>
        /// Gets the Country Slug (all lowercase without spaces name)
        /// </summary>
        /// <value>Slug of the country</value>
        public string Slug {
            get; internal set;
        }

        /// <summary>
        /// Gets the Country ISO code
        /// </summary>
        /// <value>ISO Code of the country</value>
        public string Code {
            get; internal set;
        }

        /// <summary>
        /// Gets the Country's Population
        /// </summary>
        /// <value>Number of inhabitants of the country</value>
        public long Population {
            get; internal set;
        }

        /// <summary>
        /// Gets the Country's Area
        /// </summary>
        /// <value>Area in KM^2</value>
        public long Area {
            get; internal set;
        }
    }
}