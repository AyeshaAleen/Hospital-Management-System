using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.itinsync.invoice
{
    public class TDROD
    {
        public enum columns
        {
            ID, placeType, invoiceid, contactperson, tellNo,
            cellNo, transID, parentref, address, city
        }
        public int ID { get; set; }
        public int placeType { get; set; }
        public string placeType_text { get; set; }
        public int invoiceid { get; set; }
        public string contactperson { get; set; }
        public string tellNo { get; set; }
        public string cellNo { get; set; }
        public int transID { get; set; }
        public string parentref { get; set; }
        public string address { get; set; }
        public string city { get; set; }
        public string cityText { get; set; }
    }
}
