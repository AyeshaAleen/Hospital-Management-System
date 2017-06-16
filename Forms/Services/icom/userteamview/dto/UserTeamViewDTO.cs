using Domains.itinsync.icom.error;
using Domains.itinsync.icom.header;
using Domains.itinsync.icom.interfaces.request;
using Domains.itinsync.icom.interfaces.response;
using Domains.itinsync.icom.views.user;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.itinsync.icom.userteamview.dto
{
    public class UserTeamViewDTO : IRequestHandler, IResponseHandler
    {
        public string READBY { get; set; }
        public bool delete { get; set; }
        public UserTeamView userteamview = new UserTeamView();
        public List<UserTeamView> userTeamViewList = new List<UserTeamView>();
        public ErrorBlock errorBlock = new ErrorBlock();
        public Header header = new Header();
        public ErrorBlock getErrorBlock() { return errorBlock; }
        public Header getHeader() { return header; }
        public object getResponseMessage() { return this; }
    }
}