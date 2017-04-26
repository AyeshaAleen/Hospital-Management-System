using Domains.itinsync.icom.error;
using Domains.itinsync.icom.header;
using Domains.itinsync.icom.interfaces.request;
using Domains.itinsync.icom.interfaces.response;
using Domains.itinsync.icom.useraccounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.itinsync.icom.useraccounts.dto
{
    public class UserPermissionDTO : IRequestHandler, IResponseHandler
    {
        public string READBY { get; set; }
        public bool delete = new bool();
        public UserPermission userpermission = new UserPermission();
        public List<UserPermission> userpermissionList = new List<UserPermission>();
        public ErrorBlock errorBlock = new ErrorBlock();
        public Header header = new Header();
        public ErrorBlock getErrorBlock() { return errorBlock; }
        public Header getHeader() { return header; }
        public object getResponseMessage() { return this; }
        Header IRequestHandler.getHeader() { return header; }
        ErrorBlock IResponseHandler.getErrorBlock() { return errorBlock; }
    }
}