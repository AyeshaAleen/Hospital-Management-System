using DAO.itinsync.icom.BaseAS.frame;
using DAO.itinsync.icom.pages;
using Domains.itinsync.icom.interfaces.response;
using Domains.itinsync.icom.pages;
using System;
using System.Collections.Generic;
using Utils.itinsync.icom.cache.global;

namespace Services.itinsync.icom.cache.pages
{
    public class PageManagerService : FrameAS
    {
        protected override IResponseHandler executeBody(object o)
        {

            IResponseHandler responseHandler = new GenaricResponse();
            List<PageName> pages = PageNameDAO.getInstance(dbContext).readAll();

            foreach (PageName page in pages)
            {
                GlobalStaticCache.PageCacheMap.Add(Convert.ToString(page.pageID), page);
                GlobalStaticCache.PageIDCacheMap.Add(page.pageID);//Need to cache page records
            }
            return responseHandler;
        }
    }
}
