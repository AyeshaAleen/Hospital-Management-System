using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Utils.itinsync.icom
{
    public static class ServiceUtils
    {
        public static Double negateValue(Double value)
        {
            return value * -1;
        }
        public static Double roundUp(Double value)
        {
            return Math.Ceiling(value);
        }

        public static Double roundUp(string value)
        {
            if (value == null || value.Length == 0 || value == "0")
                return 0.0;
            return roundUp(Convert.ToDouble(value));
        }
        public static Double negateValue(Int32 value)
        {
            return negateValue(Convert.ToDouble(value));
        }
        public static Double negateValue(string value)
        {
            if (value == null || value.Length == 0)
                return 0;
            return negateValue(Convert.ToDouble(value));
        }
        public static string trimWhiteSpaces(String str)
        {
            // remove all spaces
            str = str.Replace(" ", "");
            // remove anything that isn't a word character (including punctuation
            // etc)
            //str = str.replaceAll("\\W", "");

            log("company folder name = " + str);

            return str;
        }
        public static bool isCode(string code)
        {
            try
            {
                Convert.ToInt32(code);

                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }
        public static bool isNotNullOrEmpty(String str)
        {
            return isStringNotEmpty(str);
        }

        public static bool isNullOrEmpty(String str)
        {
            return isStringEmpty(str);
        }
        public static string getBasePath()
        {
            return System.AppDomain.CurrentDomain.BaseDirectory;
        }
        public static bool isNull(Object obj)
        {
            if (obj == null)
            {
                return true;
            }
            else if (obj is long)
            {
                if (((long)obj) == -1)
                    return true;
            }
            else if (obj is Decimal)
            {
                if (((Decimal)obj) == -1)
                    return true;
            }
            /*if (obj instanceof List<?>)
            {
                return ((List<?>) obj).isEmpty ();
            }
            if (obj instanceof String[])
            {
                return (((String[]) obj).length == 0);
            }
            if (obj instanceof BigDecimal)
            {
                return (((BigDecimal) obj) == BigDecimal.ZERO);
            }
            if (obj instanceof String)
            {
                return isNullOrEmpty ((String) obj);
            }*/

            return false;
        }

        public static bool isNotNull(Object obj)
        {
            return !isNull(obj);
        }

        public static bool isStringEmpty(String str)
        {
            return (str == null || str.Equals(""));
        }

        public static bool isStringNotEmpty(String str)
        {
            return !isStringEmpty(str);
        }
        public static string formateEncodeNumber(int amount)
        {
            return formateEncodeNumber(amount);
        }
        public static string formateEncodeNumber(double amount)
        {
            return formateEncodeNumber(amount);
        }
        public static string formateEncodeNumber(string amount)
        {
            return amount.Replace(",", "");
        }
        public static string formateNumber(int amount)
        {
            return formateNumber(Convert.ToDouble(amount));
        }
        public static string formateNumber(string amount)
        {
            if (amount == null || amount.Length == 0)
                return "0";

            return formateNumber(Convert.ToDouble(amount));
        }
        public static string formateNumber(double amount)
        {

            return amount.ToString("0,0.00", CultureInfo.InvariantCulture);
            // return amount.ToString("#,#", CultureInfo.InvariantCulture);

            //return double.TryParse(amount.ToString(), NumberStyles.AllowDecimalPoint, CultureInfo.CurrentUICulture, out amount));
        }

        public static bool isValidEmailAddress(String emailAddress)
        {
            if (isNotNullOrEmpty(emailAddress))
            {
                String EMAIL_REGEX = "^[\\w-_\\.+]*[\\w-_\\.]\\@([\\w-_]+\\.)+[\\w-_]+[\\w]$";
                Regex r = new Regex(EMAIL_REGEX, RegexOptions.IgnoreCase);
                Match m = r.Match(emailAddress);
                return m.Success;
            }
            return false;
        }








        public static void log(String str)
        {
            //Console.WriteLine (str);
        }

        public static bool isChange(object newValue, object OldValue)
        {
            if (newValue != null && !string.IsNullOrWhiteSpace(newValue.ToString()) && newValue != OldValue)
                return true;
            return false;
        }
        public static bool isChange(string newValue, string OldValue)
        {
            if (newValue != null && newValue.Length != 0 && newValue != OldValue)
                return true;
            return false;
        }

        public static bool isChange(int newValue, int OldValue)
        {
            if (newValue.ToString().Length != 0 && newValue != 0 && newValue != OldValue)
                return true;
            return false;
        }

        public static bool isChange(float newValue, float OldValue)
        {
            if (newValue.ToString().Length != 0 && newValue != OldValue)
                return true;
            return false;
        }


        public static bool isChange(double newValue, double OldValue)
        {
            if (newValue.ToString().Length != 0 && newValue != OldValue)
                return true;
            return false;
        }

        public static bool isChange(Decimal newValue, Decimal OldValue)
        {
            if (newValue.ToString().Length != 0 && newValue != OldValue)
                return true;
            return false;
        }
       
        public static string appendQuotes(string key, string value)
        {
            return appendQuotes("", key, value);
        }
        public static string appendQuotes(string key, int value)
        {
            return appendQuotes("", key, value);
        }
        public static string appendQuotes(string whereCaluse, string key, string value)
        {
            return whereCaluse + " " + key + " = '" + value + "' ,";
        }

        public static string appendQuotes(string whereCaluse, string key, int value)
        {
            return whereCaluse + " " + key + "=" + value + " ,";
        }


        public static string appendQuotes(string whereCaluse, string key, Decimal value)
        {
            return whereCaluse + " " + key + " = " + value + " ,";
        }

        public static string appendQuotes(string whereCaluse, string key, float value)
        {
            return whereCaluse + " " + key + " = " + value + " ,";
        }

        public static string appendQuotes(string whereCaluse, string key, double value)
        {
            return whereCaluse + " " + key + " = " + value + " ,";
        }
        public static string finilizedQueryWhere(string value)
        {
            return " where " + finilizedQuery(value);

        }
        public static string finilizedQuery(string value)
        {
            return value.TrimEnd(',');

        }


        public static string appendCreateQuotes(string whereCaluse, string value)
        {
            return whereCaluse + " " + "'" + value + "' ,";
        }
        public static string appendCreateQuotes(string whereCaluse, int value)
        {
            return whereCaluse + " " +  value + " ,";
        }
        public static string appendCreateQuotes(string whereCaluse, Int64 value)
        {
            return whereCaluse + " " + value + " ,";
        }
        public static string appendCreateQuotes(string whereCaluse, double value)
        {
            return whereCaluse + " " + value + " ,";
        }
        public static string appendCreateQuotes(string whereCaluse, float value)
        {
            return whereCaluse + " " + value + " ,";
        }

        public static string appendCreateQuotes(string whereCaluse, Decimal value)
        {
            return whereCaluse + " " + value + " ,";
        }
    }
}
