using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Employee.API.Options
{
    public class ApplicationSettings
    {
        /// <summary>
        /// It tells which database pointing currently 1-Local 2-Live
        /// </summary>
        public string SiteId { get; set; }
    }
}
