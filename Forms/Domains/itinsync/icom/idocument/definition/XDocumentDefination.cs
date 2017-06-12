﻿using Domains.itinsync.icom.idocument.section;
using Domains.itinsync.icom.interfaces.document;
using Domains.itinsync.interfaces.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domains.itinsync.icom.idocument.definition
{
    public class XDocumentDefination : System.Attribute, IDomain, IDocument
    {
        public enum columns { name, rdlcPath, dataTable, parameters, vendorid, storage, email }
        public enum primaryKey { xDocumentDefinationID }
        public Int64 xDocumentDefinationID { get; set; }
        public String name { get; set; }
        public String rdlcPath { get; set; }
        public String dataTable { get; set; }
        public String parameters { get; set; }
        public Int64 vendorid { get; set; }
        public String storage { get; set; }
        public String email { get; set; }
        public string QMode { get; set; }
        public object getKey() { return xDocumentDefinationID; }

        public void setTransID(object transID)
        {

        }


        //*************Relational Mapping Objects*******************//////
        public List<XDocumentSection> documentSections = new List<XDocumentSection>();
    }
}
