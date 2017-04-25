using DAO.itinsync.icom.BaseAS.dbcontext;
using DAO.itinsync.icom.businesstransaction;
using domains.itinsync.businesstransaction;
using Domains.itinsync.icom.header;
using Domains.itinsync.icom.interfaces.request;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using Utils.itinsync.icom.date;

namespace DAO.itinsync.icom.BaseAS
{
    public abstract class BaseAS
    {
        public static string Source = "";
        private string cmdText;
        protected DBContext dbContext = new DBContext();
        protected MySqlConnection getConnection()
        {
            if (dbContext.getConnection() == null)
            {
                dbContext.setConnection (new MySqlConnection(Source));
                if (dbContext.getConnection().State == ConnectionState.Closed)
                    dbContext.getConnection().Open();
            }
            return dbContext.getConnection();
        }
        protected MySqlTransaction getTransaction()
        {
            return dbContext.getsqlTran();
        }
        protected DBContext getdbContext()
        {
            return dbContext;
        }
        protected void closeConnection()
        {
            if (dbContext.getConnection().State == ConnectionState.Open)
                dbContext.getConnection().Close();
        }
        protected void commit()
        {
            dbContext.getsqlTran().Commit();
        }
        protected void rollback()
        {
            dbContext.getsqlTran().Rollback();
        }
        protected void startTransaction()
        {
            dbContext.setConnection(getConnection());
            dbContext.setsqlTran(dbContext.getConnection().BeginTransaction());
        }
        protected void endTransaction(bool bCommit)
        {
            if (bCommit)
            {
                // override if there is anything before commit the code
                perCommit();
                commit();
                // to do if there any any change after commit the transcation
                postCommit();
            }
            else
            {
                rollback();
            }
            closeConnection();
        }
        protected virtual void perCommit()
        {
        }
        protected virtual void postCommit()
        {
        }
        protected Int32 getTransID()
        {
            return dbContext.getHeader().transID;
        }
        protected Header getHeader()
        {
            return dbContext.getHeader();
        }
        // once we have done with basic structure then we will record each transcation
        protected Int32 doBusinessTranscation(IRequestHandler o)
        {
            dbContext.setHeader(o.getHeader());
          
            BusinessTranscation bt = new BusinessTranscation();
            bt.transDate = DateFunctions.getCurrentDateAsString();
            bt.transTime = DateFunctions.getCurrentTimeInMillis();
            bt.userID = getHeader().userID;
            bt.pageNo = getHeader().currentPageNo;
            bt.previousPageNo = dbContext.getHeader().previousPageNo;
            getHeader().transID = BusinessTranscationDAO.getInstance(dbContext).create(bt);

            return getHeader().transID;
        }
    }
}