using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.itinsync.team
{
    public class Team
    {
        public enum columns { teamid, teamname, status }
        public int teamid { get; set; }
        public string teamname { get; set; }
        public string status { get; set; }
        public string statusText { get; set; }

    }
}
