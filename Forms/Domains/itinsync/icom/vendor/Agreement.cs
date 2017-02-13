using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.itinsync.vendor
{
    public class Agreement
    {
        public enum columns
        {
            agreementid, vendorID, activeFrom, activeTo, comments, trandate, trantime,
            creditlimit, userid, vehicleID, type, paymentfrequency, transID, unitType,
            unit, term, odcity, dcity, contactperson, additionalservice, creditdays
        }
        public int agreementid { get; set; }
        public int vendorID { get; set; }
        public int activeFrom { get; set; }
        public int activeTo { get; set; }
        public string comments { get; set; }
        public int unitType { get; set; }
        public string unit { get; set; }
        public string unitText { get; set; }
        public int trandate { get; set; }
        public int trantime { get; set; }
        public int paymentfrequency { get; set; }
        public string paymentfrequencyText { get; set; }
        public double creditlimit { get; set; }
        public int userid { get; set; }
        public int vehicleID { get; set; }
        public int transID { get; set; }
        public string type { get; set; }
        public string typeText { get; set; }
        public string term { get; set; }
        public string termText { get; set; }
        public string odcity { get; set; }
        public string odcityText { get; set; }
        public string dcity { get; set; }
        public string dcityText { get; set; }
        public string text { get; set; }
        public string contactperson { get; set; }
        public string additionalservice { get; set; }
        public string creditdays { get; set; }
    }
}
