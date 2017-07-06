using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.HtmlControls;
using Domains.itinsync.icom.interfaces.document;
using Utils.itinsync.icom.constant.application;
using Domains.itinsync.icom.header;

namespace Forms.itinsync.src.session
{
    public class MasterBasePage : System.Web.UI.MasterPage
    {
        protected BasePage bp = new BasePage();
        public void goBack()
        {
            bp.goBack();
        }
        public Int32 getUserID()
        {
            return bp.getUserID();
        }


        public HtmlGenericControl getPreviousPageDivContentValue(string divid)
        {
            return bp.getPreviousPageDivContentValue(divid);
        }
        protected string trasnlation(string key)
        {
            return bp.trasnlation(key);
        }

        protected IDocument getParentRef()
        {
            return bp.getParentRef();
        }

        public void logOut()
        {
            bp.logOut();
        }


        public void unAuthorisedAccess()
        {
            bp.unAuthorisedAccess();
        }
        public void setCookiesValue(string key, string value)
        {
            bp.setCookiesValue(key, value);

        }
        public string getCookiesValue(string key)
        {
            return bp.getCookiesValue(key);
        }

        public void setApplicationValue(string key, string value)
        {
            bp.setApplicationValue(key, value);
        }
        public string getApplicationValue(string key)
        {
            return bp.getApplicationValue(key);
        }

        public void setSubjectID(string value)
        {
            bp.setSubjectID(value);
        }
        public string getSubjectID()
        {
            return bp.getSubjectID();
        }

        public void clearSession()
        {
            bp.clearSession();
        }

        public string getWebPageName(Int32 pageNo)
        {
            return bp.getWebPageName(pageNo);


        }


       
        public string getLastURL()
        {
            return bp.getLastURL();
        }

        public Int32 getLastVisitedURLCode()
        {
            return bp.getLastVisitedURLCode();


        }
        public List<Int32> getVisitedStack()
        {
            return bp.getVisitedStack();
        }
        public bool isSessionExist()
        {
            return bp.isSessionExist();
        }
        

        public Header getHeader()
        {
            Header header = new Header();
            header.userID = getUserID();
            header.currentPageNo = bp.getCurrentPage();
            header.previousPageNo = getLastVisitedURLCode();
            header.userinformation = bp.getUserInformation();
            header.parentRef = getParentRef();
            header.lang = bp.getUserInformation() == null || bp.getUserInformation().userAccount == null ? ApplicationCodes.DEFAULT_USER_LANG : bp.getUserInformation().userAccount.lang;

            return header;
        }
    }
}