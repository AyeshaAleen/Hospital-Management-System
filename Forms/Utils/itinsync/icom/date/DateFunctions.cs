using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utils.itinsync.icom.date
{
    public static class DateFunctions
    {
        public static readonly Int32 EMPTYDATE = 99999999;
        public static readonly string EMPTYDATESTRING = "99999999";
        public const string INTERNALDATEFORMATE = "yyyyMMdd";
        public const string EXTERNADATEFORMATE = "dd-MM-yyyy";


        public static string weekEndDate()
        {

            return DateTime.Now.AddDays(7 - (int)DateTime.Now.DayOfWeek).Date.AddDays(1D).ToString(INTERNALDATEFORMATE);
        }

        public static string addDays(Int32 days)
        {

            return DateTime.Now.AddDays(days).ToString(INTERNALDATEFORMATE);
        }
        public static string addDays(string date, Int32 days)
        {
            if (date == null || date.Length == 0 || date == "0" || date == EMPTYDATE.ToString())
                return "0";

            DateTime dResult = DateTime.ParseExact(date, INTERNALDATEFORMATE, System.Globalization.CultureInfo.InvariantCulture);

            return dResult.AddDays(days).ToString(INTERNALDATEFORMATE);

        }
        public static string addDays(Int32 date, Int32 days)
        {
            return addDays(date.ToString(), days);
        }

        public static DateTime convetDate(string date)
        {
            return DateTime.ParseExact(date, INTERNALDATEFORMATE, System.Globalization.CultureInfo.InvariantCulture);
        }

        public static string MONTHEndDate()
        {

            DateTime startDate = DateTime.Now;
            if (startDate.Month == 12) // its end of year , we need to add another year to new date:
            {
                startDate = new DateTime((startDate.Year + 1), 1, 1);
            }
            else
            {
                startDate = new DateTime(startDate.Year, (startDate.Month + 1), 1);
            }
            return startDate.ToString(INTERNALDATEFORMATE);
        }
        public static string AddMONTHEndDate(int monthCount)
        {

            DateTime startDate = DateTime.Now;
            if (startDate.Month == 12) // its end of year , we need to add another year to new date:
            {
                startDate = new DateTime((startDate.Year + 1), monthCount, 1);
            }
            else
            {
                startDate = new DateTime(startDate.Year, (startDate.Month + monthCount), 1);
            }
            return startDate.ToString(INTERNALDATEFORMATE);
        }

        public static string formatDate(string[] date)
        {
            if (date != null && date.Count() != 3)
                return EMPTYDATE.ToString();

            String outputDate = "";

            outputDate = outputDate + date[2].Trim() + date[0].Trim() + date[1].Trim();

            return outputDate;
        }

        public static string formatDateAsString(string datestr)
        {
            return formatDate(datestr).ToString();
        }
        public static Int32 formatDate(string datestr)
        {

            string[] date = datestr.Split('-');
            if (date != null && date.Count() != 3)
                return EMPTYDATE;

            String outputDate = "";

            outputDate = outputDate + date[2].Trim() + date[0].Trim() + date[1].Trim();

            return Convert.ToInt32(outputDate);
        }

        public static string formatDateExternalToInternal(Int32 date)
        {
            return formatDateExternalToInternal(date);
        }


        public static Int32 formatDateExternalToInternalASInt(string date)
        {
            string sdate = formatDateExternalToInternal(date);
            if (sdate.Length == 0)
                return 0;
            return Convert.ToInt32(sdate);
        }

        public static string formatDateInternalToExternal(Int32 date)
        {
            return formatDateInternalToExternal(date.ToString());
        }
        public static string formatDateInternalToExternal(string date)
        {
            if (date == null || date.Length == 0 || date == EMPTYDATE.ToString() || date == "0")
                return "";

            DateTime externalDate = DateTime.ParseExact(date, INTERNALDATEFORMATE, System.Globalization.CultureInfo.InvariantCulture);

            return externalDate.ToString(EXTERNADATEFORMATE);
        }
        public static string formatDateExternalToInternal(string date)
        {
            if (date == null || date.Length == 0 || date == EMPTYDATE.ToString() || date == "0")
                return EMPTYDATE.ToString();

            DateTime externalDate = DateTime.ParseExact(date, EXTERNADATEFORMATE, System.Globalization.CultureInfo.InvariantCulture);

            return externalDate.ToString(INTERNALDATEFORMATE);
        }

        public static string formatDateDDMMYYY(string[] date)
        {
            if (date != null && date.Count() != 3)
                return null;

            string outputDate = "";

            outputDate = outputDate + date[2].Trim() + date[1].Trim() + date[0].Trim();

            return outputDate;
        }
        public static string formatDateMMDDYYY(string[] date)
        {
            if (date != null && date.Count() != 3)
                return null;

            String outputDate = "";

            outputDate = outputDate + date[2].Trim() + date[0].Trim() + date[1].Trim();

            return outputDate;
        }
        public static string formatDateMMDDYYY(int datein)
        {
            if (datein == EMPTYDATE)
                return "";

            string date = Convert.ToString(datein);
            if (date != null && date.Length < 8)
                return null;

            return formatDateMMDDYYY(date);
        }

        public static string formatDateMMDDYYY(string date)
        {
            if (date == null || date.Length < 8)
                return "";

            String outputDate = "";

            char[] spldate = date.ToCharArray();
            string year = "" + spldate[0] + spldate[1] + spldate[2] + spldate[3];

            string month = "" + spldate[4] + spldate[5];
            string day = "" + spldate[6] + spldate[7];


            outputDate = outputDate + month + "-" + day + "-" + year;

            return outputDate;
        }


        public static int getCurrentDateAsInteger()
        {

            DateTime theDate = DateTime.Now;
            return Convert.ToInt32(theDate.ToString(INTERNALDATEFORMATE));
        }

        public static string getCurrentDateAsString()
        {
            DateTime theDate = DateTime.Now;
            return theDate.ToString(INTERNALDATEFORMATE);
        }
        public static DateTime getCurrentDateAsDate()
        {


            return DateTime.ParseExact(getCurrentDateAsString(), INTERNALDATEFORMATE, System.Globalization.CultureInfo.InvariantCulture);
        }

        public static Double getDaysDifference(string startDate, string enddate)
        {
            DateTime dstartDate = DateTime.ParseExact(startDate, INTERNALDATEFORMATE, System.Globalization.CultureInfo.InvariantCulture);
            DateTime dendDate = DateTime.ParseExact(enddate, INTERNALDATEFORMATE, System.Globalization.CultureInfo.InvariantCulture);
            TimeSpan tdifference = dstartDate - dendDate;


            return tdifference.TotalDays;
        }

        public static string getCurrentTimeInMillis()
        {
            return DateTime.Now.ToString("HHmmss");
        }
    }
}
