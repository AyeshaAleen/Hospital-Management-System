using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.itinsync.vehicle
{
    public class Vehicle
    {
        public enum columns { vehicleTypeID, vehicleCode, vendorID, transID };
        public int vehicleTypeID { get; set; }
        public int vehicleCode { get; set; }
        public int vendorID { get; set; }
        public int transID { get; set; }
        public string vehicleCodeText { get; set; }
    }
}
