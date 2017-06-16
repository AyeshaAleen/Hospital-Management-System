//Created By Qundeel Ch

using Domains.itinsync.icom.interfaces.request;
using System;
using Domains.itinsync.icom.header;

namespace Services.itinsync.icom.team.dto
{
    public class TeamnformationInDTO : IRequestHandler
    {
        public string teamName { get; set; }
        public string status { get; set; }
        public Header header = new Header();
        public Header getHeader() { return header; }
    }
}