using Domains.itinsync.icom.header;
using MySql.Data.MySqlClient;

namespace DAO.itinsync.icom.BaseAS.dbcontext
{
    public class DBContext
    {
        private MySqlConnection connection { get; set; }
        private MySqlTransaction sqlTran { get; set; }
        private Header header { get; set; }
        public DBContext()
        {

        }
        public DBContext(MySqlConnection connection, MySqlTransaction sqlTran, Header header)
        {
            this.connection = connection;
            this.sqlTran = sqlTran;
            this.header = header;
        }
        public void setConnection(MySqlConnection connection)
        {
            this.connection = connection;
        }
        public void setsqlTran(MySqlTransaction sqlTran)
        {
            this.sqlTran = sqlTran;
        }
        public void setHeader(Header header)
        {
            this.header = header;
        }
        public MySqlConnection getConnection()
        {
            return this.connection;
        }
        public MySqlTransaction getsqlTran()
        {
            return this.sqlTran;
        }
        public Header getHeader()
        {
            return this.header;
        }
    }
}