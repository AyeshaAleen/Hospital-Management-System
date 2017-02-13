using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.itinsync.users
{
    public class UserTeam
    {
        public enum columns { userteamid, userid, teamid }
        public int userteamid { get; set; }
        public int userid { get; set; }
        public int teamid { get; set; }
    }
}
