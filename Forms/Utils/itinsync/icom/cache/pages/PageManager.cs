using Domains.itinsync.icom.pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils.itinsync.icom.cache.global;

namespace Utils.itinsync.icom.cache.pages
{
    public static class PageManager
    {
        public static PageName readbyPageID(Int32 pageID)
        {
            

            return GlobalStaticCache.PageCacheMap[pageID.ToString()];

        }

        public static PageName getPageName(Int32 pageID)
        {
            if (GlobalStaticCache.PageCacheMap.ContainsKey(pageID.ToString()))
                return GlobalStaticCache.PageCacheMap[pageID.ToString()];
            else
            {
                // write code to reload data
                return null;
            }

        }

        public static List<PageName> getPages()
        {

            List<PageName> pagesList = new List<PageName>();


            foreach (string key in GlobalStaticCache.PageCacheMap.Keys)
            {

                pagesList.Add(GlobalStaticCache.PageCacheMap[key]);
            }

            return pagesList;
        }
    }
}
