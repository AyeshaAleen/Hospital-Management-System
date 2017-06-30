using DAO.itinsync.icom.BaseAS.dbcontext;
using Domains.itinsync.icom.annotation;
using Domains.itinsync.icom.header;
using Domains.itinsync.interfaces.domain;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Reflection;
using Utils.itinsync.icom;
using Utils.itinsync.icom.cache.lookup;
using Utils.itinsync.icom.constant.lookup;
using Utils.itinsync.icom.date;
using Utils.itinsync.icom.exceptions;

namespace DAO.itinsync.icom.BaseAS.CRUDBase
{
    public abstract class CRUDBase
    {
        private MySqlConnection connection;
        private MySqlTransaction sqlTran;
        private Header header;
        private string TRANSID = "";
        protected DBContext currentDBContext;

        protected abstract string createQuery(object o);
        protected abstract string updateQuery(object o, string where);
        protected abstract IDomain setResult(DataTable dt, int i);
        public void init(DBContext dbContext)
        {
            currentDBContext = dbContext;
            if (dbContext.getConnection() == null)
                throw new ItinsyncException();
            connection = dbContext.getConnection();
            sqlTran = dbContext.getsqlTran();
            header = dbContext.getHeader();
        }
        protected Header getHeader()
        {
            return header;
        }
        protected virtual List<IDomain> processResults(string SQL)
        {
            List<IDomain> resultList = new List<IDomain>();
            DataTable dt = FillDataTable(SQL);
            for (int i = 0; i < dt.Rows.Count; i++)
                resultList.Add(setResult(dt, i));
            return resultList;
        }
        protected virtual IDomain processSingleResult(string SQL)
        {
            DataTable dt = FillDataTable(SQL);
            if (dt.Rows.Count > 0)
                return (setResult(dt, 0));
            else
                return null;
        }
        protected virtual DataTable FillDataTable(string commandText)
        {
            DataTable dt = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter();
            da.SelectCommand = new MySqlCommand(commandText, connection);
            da.Fill(dt);
            return dt;

        }
        public int create(IDomain o)
        {
            if (connection != null)
            {

                if (o != null && typeof(IDomain).IsAssignableFrom(o.GetType()))
                    o.setTransID(getHeader().transID);

                MySqlCommand ccmd = new MySqlCommand(createQuery(o), connection);
                ccmd.Transaction = sqlTran;
                ccmd.ExecuteNonQuery();


                return Convert.ToInt32(ccmd.LastInsertedId);
            }
            return 0;
        }

        public int create(IDomain o, string aa)
        {
            if (connection != null)
            {

                if (o != null && typeof(IDomain).IsAssignableFrom(o.GetType()))
                    o.setTransID(getHeader().transID);

                MySqlCommand ccmd = new MySqlCommand(createQuery(o), connection);
                ccmd.Transaction = sqlTran;
                ccmd.ExecuteNonQuery();


                return Convert.ToInt32(ccmd.LastInsertedId);
            }
            return 0;
        }

        public void update(object o, string where)
        {
            updateQuery(o, where);
        }
        protected int update(string commandtext)
        {
            if (connection != null)
            {
                MySqlCommand ccmd = new MySqlCommand(commandtext, connection);
                ccmd.Transaction = sqlTran;
                int rowsAffected = Convert.ToInt32(ccmd.ExecuteNonQuery());
                return rowsAffected;
            }
            return 0;
        }
        protected string preparedUpdateQuery(object previousObj, object newObj, Type enumType)
        {
            string whereClause = "";
            FieldInfo[] infos = domainColumns(enumType);
            foreach (FieldInfo fi in infos)
            {
                object previousValue = getPropertyValue(previousObj, fi.Name);
                object newValue = getPropertyValue(newObj, fi.Name);
                if (ServiceUtils.isChange(newValue, previousValue))
                    whereClause = ServiceUtils.appendQuotes(whereClause, fi.Name, newValue.ToString());
            }
            return whereClause;
        }
        protected string preparedCreateQuery(object domainObj, Type enumType)
        {
            string query = "(";
            FieldInfo[] infos = domainColumns(enumType);
            foreach (FieldInfo fi in infos)
                query = query + fi.Name + ",";

            query = ServiceUtils.finilizedQuery(query);
            query = query + ") VALUES (";
            foreach (FieldInfo fi in infos)
            {
                object value = getPropertyValue(domainObj, fi.Name);
                if (value == null || value.ToString().Length == 0)
                    query = query + "'',";
                else if (value != null && typeof(string).IsAssignableFrom(value.GetType()))
                    query = ServiceUtils.appendCreateQuotes(query, value.ToString());
                else if (value != null && typeof(int).IsAssignableFrom(value.GetType()))
                    query = ServiceUtils.appendCreateQuotes(query, Convert.ToInt32(value));
                else if (value != null && typeof(double).IsAssignableFrom(value.GetType()))
                    query = ServiceUtils.appendCreateQuotes(query, Convert.ToDouble(value));
                else if (value != null && typeof(long).IsAssignableFrom(value.GetType()))
                    query = ServiceUtils.appendCreateQuotes(query, Convert.ToInt64(value));
                else
                    query = ServiceUtils.appendCreateQuotes(query, Convert.ToString(value));
            }
            query = ServiceUtils.finilizedQuery(query);
            query = query + ")";
            return query;
        }
        protected int executeCount(string sql)
        {
            if (connection != null)
            {
                MySqlCommand ccmd = new MySqlCommand(sql, connection);
                ccmd.Transaction = sqlTran;
                int rowsAffected = Convert.ToInt32(ccmd.ExecuteScalar());
                return rowsAffected;
            }
            return 0;
        }

        protected Int32 maxResult(string sql)
        {
            if (connection != null)
            {
                MySqlCommand ccmd = new MySqlCommand(sql, connection);
                ccmd.Transaction = sqlTran;
                DataTable dt = FillDataTable(sql);

                if (!string.IsNullOrEmpty(dt.Rows[0]["maxResult"].ToString()))
                {
                    
                   return  Convert.ToInt32(dt.Rows[0]["maxResult"]);
                }
                else
                    return 0;
            }
            return 0;
        }

        protected bool delete(string commandtext)
        {
            if (connection != null)
            {
                MySqlCommand ccmd = new MySqlCommand(commandtext, connection);
                ccmd.Transaction = sqlTran;
                ccmd.ExecuteNonQuery();
                return true;
            }
            return false;
        }
        protected FieldInfo[] domainColumns(Type enumType)
        {
            FieldInfo[] infos;
            infos = enumType.GetFields();
            return enumType.GetFields(BindingFlags.Public | BindingFlags.Static);
        }
        protected object getPropertyValue(object src, string propertyName)
        {
            return src.GetType().GetProperty(propertyName).GetValue(src, null);
        }

        protected void setPropertyValue(IDomain src, string propertyName, int i, DataTable dt)
        {
            object value = dt.Rows[i][propertyName];
            setPropertyValue(src, propertyName, i, dt, value);
        }
        protected void setPropertyValue(IDomain src, string propertyName, int i, DataTable dt, object value)
        {
            if (value == DBNull.Value)
                return;
            //find out the type
            Type type = src.GetType();

            //get the property information based on the type
            PropertyInfo propertyInfo = type.GetProperty(propertyName);

            //find the property type
            Type propertyType = propertyInfo.PropertyType;

            //Convert.ChangeType does not handle conversion to nullable types
            //if the property type is nullable, we need to get the underlying type of the property
            var targetType = IsNullableType(propertyInfo.PropertyType) ? Nullable.GetUnderlyingType(propertyInfo.PropertyType) : propertyInfo.PropertyType;

            //Returns an System.Object with the specified System.Type and whose value is
            //equivalent to the specified object.
            value = Convert.ChangeType(value, targetType);

            DateTimeAttribute attributeType = (DateTimeAttribute)propertyInfo.GetCustomAttribute(typeof(DateTimeAttribute));

            LookupAttribute lookupattributeType = (LookupAttribute)propertyInfo.GetCustomAttribute(typeof(LookupAttribute));

            if (lookupattributeType != null)
                lookupTranslation(propertyInfo, src, propertyName, i, dt, lookupattributeType);
            else
            if (attributeType != null)
                timeZoneConversion(propertyInfo, src, propertyName, i, dt, attributeType);
            else

                //Set the value of the property
                propertyInfo.SetValue(src, value, null);

        }


        private void timeZoneConversion(PropertyInfo propertyInfo, IDomain src, string propertyName, int i, DataTable dt, DateTimeAttribute attributeType)
        {
            object relatedTagValue = dt.Rows[i][attributeType.relatedTag];
            object value = dt.Rows[i][propertyName];

            if (value == null || value.ToString().Length == 0 || relatedTagValue == null || relatedTagValue.ToString().Length == 0 || relatedTagValue.ToString() == DateFunctions.EMPTYDATESTRING)
                return;

            DateTime dateTime = DateTime.ParseExact(relatedTagValue + " " + value, DateFunctions.INTERNALDATETIMEFORMATE, new CultureInfo(DateFunctions.DEFAULTTIMEZONECULTURE, true));
            dateTime = DateFunctions.getDateTimeByTimeZone(getHeader().userinformation.userAccount.timeZone, dateTime);

            propertyInfo.SetValue(src, dateTime.ToString(DateFunctions.INTERNALTIMEFORMATE), null);

            dt.Rows[i][attributeType.relatedTag] = dateTime.ToString(DateFunctions.INTERNALDATEFORMATE);
            setPropertyValue(src, attributeType.relatedTag, i, dt);

        }

        private void lookupTranslation(PropertyInfo propertyInfo, IDomain src, string propertyName, int i, DataTable dt, LookupAttribute attributeType)
        {
            string relatedTagValue = attributeType.relatedTag.ToString();
            string lokkupName = attributeType.lookupName.ToString();
            object value = dt.Rows[i][propertyName];

            if (relatedTagValue == null || relatedTagValue.ToString().Length == 0 || relatedTagValue.ToString() == string.Empty)
                return;

            string lookupText = LookupManager.readTextByCode(lokkupName, Convert.ToString(value), getHeader().lang);

            propertyInfo.SetValue(src, value, null);



            setPropertyValue(src, relatedTagValue, i, dt, lookupText);

        }
        protected void setPropertiesValue(IDomain src, DataTable dt, int i, Type enumType)
        {
            foreach (FieldInfo fi in domainColumns(enumType))
                setPropertyValue(src, fi.Name, i, dt);
        }


        private bool IsNullableType(Type type)
        {
            return type.IsGenericType && type.GetGenericTypeDefinition().Equals(typeof(Nullable<>));
        }
    }
}