﻿using Domains.itinsync.icom.interfaces.request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domains.itinsync.icom.header;
using Domains.itinsync.icom.interfaces.email;
using Domains.itinsync.icom.interfaces.document;
using Domains.itinsync.icom.interfaces.response;
using Domains.itinsync.icom.error;
using Domains.itinsync.icom.store;

namespace Services.icom.document.store.dto
{
    public class StoreDTO : IRequestHandler,IResponseHandler
    {
        
        public List<Store> storelist { get; set; }

        public ErrorBlock errorBlock = new ErrorBlock();
        public Header header = new Header();
        public ErrorBlock getErrorBlock() { return errorBlock; }
        public Header getHeader() { return header; }
        public object getResponseMessage() { return this; }
    }
}