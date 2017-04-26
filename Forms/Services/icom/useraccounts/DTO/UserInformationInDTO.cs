using Domains.itinsync.icom.interfaces.request;
using System;
using Domains.itinsync.icom.header;
using Domains.itinsync.icom.error;

namespace Services.itinsync.icom.useraccounts.DTO
{
    public class UserInformationInDTO : IRequestHandler
    {
        public string userName { get; set; }
        public string password { get; set; }

        public string accessToken { get; set; }
        public string osVersion { get; set; }
        public string DeviceName { get; set; }

        public Header header = new Header();
        public Header getHeader() { return header; }

        public ErrorBlock errorBlock = new ErrorBlock();
        public ErrorBlock getErrorBlock() { return errorBlock; }
    }
}