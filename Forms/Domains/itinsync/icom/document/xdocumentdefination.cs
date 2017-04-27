using Domains.itinsync.interfaces.domain;
using System;

namespace domains.itinsync.document
{
    public class xDocumentDefination : System.Attribute, IDomain
    {
        public enum columns { name, rdlcPath, dataTable, parameters }
        public enum primaryKey { xDocumentDefinationID }
        public Int32 xDocumentDefinationID { get; set; }
        public String name { get; set; }
        public String rdlcPath { get; set; }
        public String dataTable { get; set; }
        public String parameters { get; set; }
        public object getKey() { return xDocumentDefinationID;  }

        public void setTransID(object transID)
        {
           
        }
    }
}
