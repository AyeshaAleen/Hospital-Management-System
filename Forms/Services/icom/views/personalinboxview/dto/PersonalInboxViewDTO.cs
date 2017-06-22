using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domains.itinsync.icom.interfaces.request;
using Domains.itinsync.icom.interfaces.response;
using Domains.itinsync.icom.header;
using Domains.itinsync.icom.error;
using Domains.itinsync.icom.views.personalinbox;
using Domains.itinsync.icom.views;

namespace Services.icom.views.personalinboxview.dto
{
    public class PersonalInboxViewDTO : IRequestHandler, IResponseHandler
    {
        public PersonalInboxView personalinboxview = new PersonalInboxView();
        public List<PersonalInboxView> personalinboxviewList = new List<PersonalInboxView>();

        public ErrorBlock errorBlock = new ErrorBlock();
        public Header header = new Header();
        public ErrorBlock getErrorBlock() { return errorBlock; }
        public Header getHeader() { return header; }
        public object getResponseMessage() { return this; }
        Header IRequestHandler.getHeader() { return header; }
        ErrorBlock IResponseHandler.getErrorBlock() { return errorBlock; }
    }
}
