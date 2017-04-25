using DAO.itinsync.icom.BaseAS.frame;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domains.itinsync.icom.interfaces.response;
using Services.itinsync.icom.cache.lookup;
using Services.itinsync.icom.cache.pages;
using Services.itinsync.icom.cache.permission;
using Services.itinsync.icom.cache.task.taskdefinition;
using Services.itinsync.icom.cache.lookup.trans;

namespace Services.itinsync.icom.cache
{
    public class CacheManagmentService : FrameAS
    {
        protected override IResponseHandler executeBody(object o)
        {
            //**************Need to cache Lookup***************//
            LookupManagerService lks = new LookupManagerService();
            lks.executeAsSecondary(null,dbContext);

            //**************Need to cache Permissions***************//
            PermissionsService ps = new PermissionsService();
            ps.executeAsSecondary(null,dbContext);

            //**************Need to cache Page Information***************//
            PageManagerService pms = new PageManagerService();
            pms.executeAsSecondary(null,dbContext);

            //**************Need to cache Task Definition***************//
            TaskDefinitionManagerService td = new TaskDefinitionManagerService();
            td.executeAsSecondary(null,dbContext);

            LookupTranslationCacheService tcs = new LookupTranslationCacheService();
            tcs.executeAsSecondary(null,dbContext);

            return new GenaricResponse();
        }
    }
}
