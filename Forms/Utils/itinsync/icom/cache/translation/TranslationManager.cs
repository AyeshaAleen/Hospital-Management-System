using Domains.itinsync.icom.lookup;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils.itinsync.icom.cache.global;
using Utils.itinsync.icom.cache.lookup;
using Utils.itinsync.icom.constant.application;
using Utils.itinsync.icom.constant.lookup;

namespace Utils.itinsync.icom.cache.translation
{
    public static class TranslationManager
    {
        private static string language = ApplicationCodes.DEFAULT_USER_LANG;



        public static void load()
        {


            List<LookUp> languages = LookupManager.readbyLookupName(LookupsConstant.LKUserLang);
            foreach (LookUp lk in languages)
            {
                Dictionary<string, string> langcacheMap = new Dictionary<string, string>();

                string filepath = ServiceUtils.getBasePath() + "/itinsync/translations/lang_" + lk.code + ".properties";

                foreach (String line in System.IO.File.ReadAllLines(filepath))
                {
                    if ((!string.IsNullOrEmpty(line)) &&
                        (!line.StartsWith(";")) &&
                        (!line.StartsWith("#")) &&
                        (!line.StartsWith("'")) &&
                        (line.Contains('=')))
                    {
                        int index = line.IndexOf('=');
                        string key = line.Substring(0, index).Trim();
                        string value = line.Substring(index + 1).Trim();

                        if ((value.StartsWith("\"") && value.EndsWith("\"")) ||
                            (value.StartsWith("'") && value.EndsWith("'")))
                        {
                            value = value.Substring(1, value.Length - 2);
                        }

                        try
                        {
                            //ignore dublicates
                            if (!langcacheMap.ContainsKey(key))
                                langcacheMap.Add(key, value);


                        }
                        catch { }
                    }
                }
                GlobalStaticCache.translationcacheMap.Add(lk.code, langcacheMap);
            }


        }
        public static string trans(string key)
        {
            return trans(key, ApplicationCodes.DEFAULT_USER_LANG);
        }
        public static string trans(string key, string lang)
        {
            if (GlobalStaticCache.LKcacheMap.Count == 0)
                load();



            if (GlobalStaticCache.translationcacheMap.ContainsKey(lang))
            {
                if (GlobalStaticCache.translationcacheMap[lang].ContainsKey(key))
                    return GlobalStaticCache.translationcacheMap[lang][key];
                else
                    return "???" + key + "???";
            }
            else
                return "???" + key + "???";
        }
    }
}
