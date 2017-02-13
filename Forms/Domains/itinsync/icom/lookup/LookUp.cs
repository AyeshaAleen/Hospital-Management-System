using Domains.itinsync.interfaces.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domains.itinsync.icom.lookup
{
    public class LookUp :  System.Attribute, IDomain
    {
        public enum columns
        {
            code, text, name
        }
        public enum primaryKey
        {
            id
        }

        public enum forignKey
        {
        }

        public string code { get; set; }

        public string text { get; set; }

        public string name { get; set; }

        public object getKey()
        {
            return null;
        }
    }
}
