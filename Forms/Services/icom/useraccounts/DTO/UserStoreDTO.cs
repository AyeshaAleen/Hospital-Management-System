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
using Domains.itinsync.useraccounts;

namespace Services.icom.useraccounts.DTO
{
    public class UserStoreDTO : IRequestHandler, IResponseHandler
    {
        public string READBY { get; set; }
        public bool delete { get; set; }

        public UserStore userstore = new UserStore();
        public List<UserStore> userStoreList = new List<UserStore>();

        public ErrorBlock errorBlock = new ErrorBlock();
        public Header header = new Header();
        public ErrorBlock getErrorBlock() { return errorBlock; }
        public Header getHeader() { return header; }
        public object getResponseMessage() { return this; }
    }
}
