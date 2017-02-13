using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.itinsync.audit
{
    public class interfacerequestresponse
    {
        public enum columns
        {
            requestresponseID, requestMessage, responseMessage,
            transDate, transTime, interfaceid, status, comments
        }
        public int requestresponseID { get; set; }
        public string requestMessage { get; set; }
        public string responseMessage { get; set; }
        public string transdate { get; set; }
        public string transtime { get; set; }
        public string interfaceid { get; set; }
        public string status { get; set; }
        public string comments { get; set; }
    }
}
