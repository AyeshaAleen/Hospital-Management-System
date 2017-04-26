using Domains.itinsync.icom.error;
using Domains.itinsync.icom.interfaces.response;
using Domains.itinsync.icom.useraccounts;
using Domains.itinsync.icom.views.user;
using Domains.itinsync.useraccounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domains.itinsync.icom.session.user
{
    public class UserInformation : IResponseHandler
    {
        public ErrorBlock errorBlock = new ErrorBlock();
        public UserAccounts userAccount { get; set; }


        public List<UserPermission> userPermissions { get; set; }

        public List<UserTeamView> userTeams { get; set; }

        public List<UserRegion> userRegion { get; set; }

        public List<UserRole> userRoles { get; set; }

        public bool authorise = false;

        public ErrorBlock getErrorBlock()
        {
            return errorBlock;
        }

        public object getResponseMessage()
        {
            return this;
        }
    }
}
