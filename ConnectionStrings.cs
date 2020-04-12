using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Employee.API.Options
{
    public class ConnectionStrings
    {
        /// <summary>
        /// It is pointing local database
        /// </summary>
        public string Local { get; set; }
        /// <summary>
        /// It is pointing live database
        /// </summary>
        public string Live { get; set; }

    }
}
