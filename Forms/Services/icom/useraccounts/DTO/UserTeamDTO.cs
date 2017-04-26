using domains.itinsync.useraccounts;
using Domains.itinsync.icom.error;
using Domains.itinsync.icom.header;
using Domains.itinsync.icom.interfaces.request;
using Domains.itinsync.icom.interfaces.response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.itinsync.icom.useraccounts.dto
{
    public class UserTeamDTO : IRequestHandler, IResponseHandler
    {
        public string READBY { get; set; }
        public bool delete { get; set; }
        public UserTeam userteam= new UserTeam();
        public List<UserTeam> userTeamList = new List<UserTeam>();
        public ErrorBlock errorBlock = new ErrorBlock();
        public Header header = new Header();
        public ErrorBlock getErrorBlock() { return errorBlock; }
        public Header getHeader() { return header; }
        public object getResponseMessage() { return this; }
    }
}