using DAO.itinsync.icom.BaseAS.frame;
using DAO.itinsync.icom.lookuptrans;
using Domains.itinsync.icom.interfaces.response;
using Domains.itinsync.icom.lookup.lookuptrans;
using System.Collections.Generic;
using Utils.itinsync.icom.cache.global;
using Utils.itinsync.icom.cache.translation;

namespace Services.itinsync.icom.cache.lookup.trans
{
    public class LookupTranslationCacheService : FrameAS
    {
        protected override IResponseHandler executeBody(object o)
        {
            TranslationManager.load();

            List<LookupTrans> translations = LookupTransDAO.getInstance(dbContext).readAll();

            foreach (LookupTrans translation in translations)
            {
                //ignore dublicates
                if (!GlobalStaticCache.translationcacheMap[translation.lang].ContainsKey(translation.code))
                    GlobalStaticCache.translationcacheMap[translation.lang].Add(translation.code, translation.value);
                else
                    GlobalStaticCache.translationcacheMap[translation.lang][translation.code] = translation.value;

            }


            return new GenaricResponse();


        }
    }
}