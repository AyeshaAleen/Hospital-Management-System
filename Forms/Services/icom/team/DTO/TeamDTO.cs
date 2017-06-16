//Created By Qundeel Ch

using Domains.itinsync.icom.interfaces.request;
using Domains.itinsync.icom.interfaces.response;
using System.Collections.Generic;
using Domains.itinsync.icom.header;
using Domains.itinsync.icom.error;
using Domains.itinsync.icom.team;

namespace Services.itinsync.icom.team.dto
{
   public class TeamDTO : IRequestHandler, IResponseHandler
    {
        public string READBY { get; set; }
        public Team team = new Team();
        public List<Team> teamList = new List<Team>();
        public ErrorBlock errorBlock = new ErrorBlock();
        public Header header = new Header();
        public ErrorBlock getErrorBlock() { return errorBlock; }
        public Header getHeader() { return header; }
        public object getResponseMessage() { return this; }
    }
}