using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utils.itinsync.icom.xml
{
    public static class XMLUtils
    {
        public static readonly string XML_START_TAG = "<";
        public static readonly string XML_END_TAG = ">";
        
        public static string appendTag(string key,string value)
        {

            return XML_START_TAG + key + XML_END_TAG + value + XML_START_TAG + "/" + key + XML_END_TAG;
        }

        public static string appendTag(string key, Int32 value)
        {
            return appendTag(key, Convert.ToString(value));
        }

        public static string appendTag(string key, double value)
        {
            return appendTag(key, Convert.ToString(value));
        }

        public static string appendTag(string key, Decimal value)
        {
            return appendTag(key, Convert.ToString(value));
        }

        public static string appendTag(string key, float value)
        {
            return appendTag(key, Convert.ToString(value));
        }
        public static string appendTag(string key, bool value)
        {
            return appendTag(key, Convert.ToString(value));
        }
    }
}
