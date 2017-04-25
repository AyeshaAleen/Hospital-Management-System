using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domains.itinsync.icom.annotation
{
    [AttributeUsage(AttributeTargets.Property)]
    public class LookupAttribute : Attribute
    {
        public string lookupName { get; set; }
        public string relatedTag { get; set; }
    }
}
