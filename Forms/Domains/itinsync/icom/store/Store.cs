using Domains.itinsync.icom.annotation;
using Domains.itinsync.interfaces.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domains.itinsync.icom.store
{
    public class Store : IDomain
    {

        public enum columns
        {
            name, zipCode, website, storelink, comments, walmart, fax, storeNo
        }
        public enum primaryKey { storeid }
        public Int32 storeid { get; set; }
        public string name { get; set; }
        public string zipCode { get; set; }
        public string website { get; set; }
        public string storelink { get; set; }
        public string comments { get; set; }
        public string walmart { get; set; }
        public string fax { get; set; }
        public string storeNo { get; set; }
        


        public object getKey() { return storeid; }

        public void setTransID(object transID)
        {
            
        }
    }
}
