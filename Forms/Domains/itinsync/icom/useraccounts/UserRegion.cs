using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.itinsync.users
{
    public class UserRegion
    {
        public enum columns { id, code, userid }
        public int id { get; set; }
        public string code { get; set; }
        public string codeText { get; set; }
        public int userid { get; set; }
    }
}
