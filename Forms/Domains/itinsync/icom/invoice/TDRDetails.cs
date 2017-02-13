using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.itinsync.invoice
{
   public class TDRDetails
    {
        public enum columns
        {
            tdrdetailsid, VRN, driverName, shipmentquantity, shipmentweight, cellNo,
            License, receivedquantity, receivedweight, receiverName, receiverCellNo,
            Shortage, invoiceid, remarks, transID, receiveon, sourceterminal, parentref

        }
        public int tdrdetailsid { get; set; }
        public string VRN { get; set; }
        public string driverName { get; set; }
        public string shipmentquantity { get; set; }
        public string shipmentweight { get; set; }
        public string cellNo { get; set; }
        public string License { get; set; }
        public string receivedquantity { get; set; }
        public string receivedweight { get; set; }
        public string receiverName { get; set; }
        public string receiverCellNo { get; set; }
        public string Shortage { get; set; }
        public int invoiceid { get; set; }
        public string remarks { get; set; }
        public int transID { get; set; }
        public int receiveon { get; set; }
        public string sourceterminal { get; set; }
        public string parentref { get; set; }

    }
}
