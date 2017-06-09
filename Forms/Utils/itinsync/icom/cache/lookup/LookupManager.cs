using Domains.itinsync.icom.lookup;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils.itinsync.icom.cache.global;
using Utils.itinsync.icom.constant.application;

namespace Utils.itinsync.icom.cache.lookup
{
    public static class LookupManager
    {
        public static List<LookUp> readbyLookupName(string lookupName)
        {

            return readbyLookupName(lookupName, null);
        }
        public static List<LookUp> readbyLookupName(string lookupName, string lang)
        {
            if (lang == null || lang.Length == 0)
                lang = ApplicationCodes.DEFAULT_USER_LANG;

            List<LookUp> lookupList = new List<LookUp>();
            if (GlobalStaticCache.LKcacheMap[lang].ContainsKey(lookupName))
            {
                foreach (DictionaryEntry entry in GlobalStaticCache.LKcacheMap[lang][lookupName])
                {
                    LookUp lk = new LookUp();
                    lk.code = Convert.ToString(entry.Key);
                    lk.text = Convert.ToString(entry.Value);
                    lookupList.Add(lk);
                }
            }
            
            lookupList.OrderBy(x => x.text);
            return lookupList;
        }
        public static string readTextByCode(string lookupName, string code)
        {

            return readTextByCode(lookupName, code, null);
        }
        public static string readTextByCode(string lookupName, string code, string lang)
        {

            if (GlobalStaticCache.LKcacheMap.Count == 0)
            {
                //call service to load lookups
            }
            if (lang == null || lang.Length == 0)
                lang = ApplicationCodes.DEFAULT_USER_LANG;

            return Convert.ToString((GlobalStaticCache.LKcacheMap[lang][lookupName])[code]).Length == 0 ? "??" + code + "??" : Convert.ToString((GlobalStaticCache.LKcacheMap[lang][lookupName])[code]);

        }
        public static string readTextByCode(string lookupName, int code)
        {

            return readTextByCode(lookupName, code, null);
        }
        public static string readTextByCode(string lookupName, int code, string lang)
        {
            return readTextByCode(lookupName, Convert.ToString(code), lang);
        }
        public static string readCodeByText(string lookupName, string text)
        {

            return readCodeByText(lookupName, text, null);
        }
        public static string readCodeByText(string lookupName, string text, string lang)
        {
            if (lang == null || lang.Length == 0)
                lang = ApplicationCodes.DEFAULT_USER_LANG;

            if (GlobalStaticCache.LKcacheMap.Count == 0)
            {
                //call service to load lookups
            }

            foreach (DictionaryEntry entry in GlobalStaticCache.LKcacheMap[lang][lookupName])
            {
                if (Convert.ToString(entry.Value).ToUpper() == text.ToUpper())
                    return Convert.ToString(entry.Key);
            }
            return "???" + text + "???";

        }


        public static List<LookUp> readLookups(string lang)
        {
            if (lang == null || lang.Length == 0)
                lang = ApplicationCodes.DEFAULT_USER_LANG;

            List<LookUp> lookupList = new List<LookUp>();


            int count = 0;
            foreach (string key in GlobalStaticCache.LKcacheMap[lang].Keys)
            {

                LookUp lk = new LookUp();
                lk.code = Convert.ToString(count);
                lk.text = Convert.ToString(key);
                lookupList.Add(lk);
                count++;

            }


            lookupList.OrderBy(x => x.text);
            return lookupList;
        }
    }
}
