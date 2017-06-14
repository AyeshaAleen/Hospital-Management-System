using Domains.itinsync.icom.interfaces.request;
using Domains.itinsync.icom.interfaces.response;
using System;
using System.Collections.Generic;
using Domains.itinsync.icom.header;
using Domains.itinsync.icom.error;
using Domains.itinsync.icom.permission;

namespace Services.icom.permission.dto
{
    public class PermissionDTO : IRequestHandler, IResponseHandler
    {
        public string READBY { get; set; }
        public Permission permission = new Permission();
        public List<Permission> permissionList = new List<Permission>();
        public ErrorBlock errorBlock = new ErrorBlock();
        public Header header = new Header();
        public ErrorBlock getErrorBlock() { return errorBlock; }
        public Header getHeader() { return header; }
        public object getResponseMessage() { return this; }
        Header IRequestHandler.getHeader() { return header; }
        ErrorBlock IResponseHandler.getErrorBlock() { return errorBlock; }
    }
}