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
    }
}
