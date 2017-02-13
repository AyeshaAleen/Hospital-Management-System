using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domains.itinsync.icom.views.user
{
    public class UserTeamView
    {

        public enum columns { userteamid, userid, teamname, teamid, status }
        public int userteamid { get; set; }
        public int userid { get; set; }
        public string teamname { get; set; }
        public int teamid { get; set; }
        public string status { get; set; }                                                                                                                          
        public string statusText { get; set; }



    }
}
