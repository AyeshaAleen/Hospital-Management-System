using AjaxControlToolkit;
using Domains.itinsync.icom.interfaces.response;
using Domains.itinsync.icom.permission;
using Domains.itinsync.icom.session.user;
using Domains.itinsync.icom.useraccounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Utils.itinsync.icom;
using Utils.itinsync.icom.cache.global;
using Utils.itinsync.icom.cache.permission;
using Utils.itinsync.icom.cache.translation;
using Utils.itinsync.icom.constant.application;
using Utils.itinsync.icom.constant.page;
using Utils.itinsync.icom.date;
using Utils.itinsync.icom.xml;
using static Forms.itinsync.src.session.Session;

namespace Forms.itinsync.src.session
{
    public class BasePage : System.Web.UI.Page
    {
        public void InjectSession(UserInformation ui)
        {

            if (ui.authorise)
            {
                //place loginpage id here
                setSubjectID("");
                Sessions.getSession().Set(SessionKey.CURRENTPAGE, 0);
                Sessions.getSession().Set(SessionKey.USERINFORMATION, ui);
                Sessions.getSession().Set(SessionKey.PAGEVISTSTACK, new List<Int32>());
                Sessions.getSession().Set(SessionKey.SESSIONEXIST, true);

                Sessions.getSession().Set(SessionKey.DICTONARYKEY, new Dictionary<string, string>());


                Response.Redirect(PageConstant.PAGE_PERSONAL_INBOX);

            }
            else
            {
                Response.Redirect("Login.aspx");
            }
        }


        public string xmlConversion(Control parent, string outPut)
        {
            foreach (Control c in parent.Controls)
            {
                if ((c.GetType() == typeof(TextBox)))
                    outPut = outPut + XMLUtils.appendTag(((TextBox)(c)).ID, ((TextBox)(c)).Text);

                else if ((c.GetType() == typeof(HtmlInputText)))
                    outPut = outPut + XMLUtils.appendTag(((HtmlInputText)(c)).ID, ((HtmlInputText)(c)).Value);

                else if ((c.GetType() == typeof(DropDownList)))
                    outPut = outPut + XMLUtils.appendTag(((DropDownList)(c)).ID, ((DropDownList)(c)).SelectedValue);

                else if ((c.GetType() == typeof(HtmlInputRadioButton)))
                    outPut = outPut + XMLUtils.appendTag(((HtmlInputRadioButton)(c)).Name, ((HtmlInputRadioButton)(c)).Value);

                else if ((c.GetType() == typeof(HtmlSelect)))
                    outPut = outPut + XMLUtils.appendTag(((HtmlSelect)(c)).Name, ((HtmlSelect)(c)).Value);

                else if ((c.GetType() == typeof(CheckBox)))
                {
                    if(((CheckBox)(c)).Checked)
                        outPut = outPut + XMLUtils.appendTag(((CheckBox)(c)).ID, true);
                    else
                        outPut = outPut + XMLUtils.appendTag(((CheckBox)(c)).ID, false);
                }
                   

                
                   
                if (c.HasControls())
                     outPut = xmlConversion(c, outPut);
                
            }


            return outPut;
        }
        public string getDateFormate()
        {
            return DateFunctions.EXTERNADATEFORMATE;
        }
        public void logOut()
        {
            Sessions.getSession().ClearSessionKeys();
        }
        public string trasnlation(string key)
        {
            return TranslationManager.trans(key, getUserInformation() == null ? "" : getUserInformation().userAccount.lang);
        }

        public void DateFormatter(Control parent)
        {
            foreach (Control c in parent.Controls)
            {
                if ((c.GetType() == typeof(CalendarExtender)))
                {
                    ((CalendarExtender)(c)).Format = getDateFormate();
                }


                if (c.HasControls())
                {
                    DateFormatter(c);
                }
            }
        }


        public bool isReadonly()
        {
            string readonlystate = getRequestedMap(ApplicationCodes.READONLYSTATE);
            return readonlystate == "1";
        }
        public void enableReadonly()
        {
            setRequestedMap(ApplicationCodes.READONLYSTATE, ApplicationCodes.FALSE_INDICATOR);
        }
        public void setdtoObject(IResponseHandler response)
        {

            Sessions.getSession().Set(SessionKey.DTOOBJECT, response);
        }
        public IResponseHandler getdtoObject()
        {

            return (IResponseHandler)Sessions.getSession().Get(SessionKey.DTOOBJECT);
        }

        public void setReadonlyFrame(Control parent)
        {
            foreach (Control c in parent.Controls)
            {
                if ((c.GetType() == typeof(TextBox)))
                {
                    ((TextBox)(c)).Enabled = false;
                }

                else if ((c.GetType() == typeof(HtmlInputText)))
                {
                    ((HtmlInputText)(c)).Disabled = true;
                }
                else if ((c.GetType() == typeof(DropDownList)))
                {
                    ((DropDownList)(c)).Enabled = false;
                }
                else if ((c.GetType() == typeof(CalendarExtender)))
                {
                    ((CalendarExtender)(c)).Enabled = false;
                }
                else if ((c.GetType() == typeof(Button)))
                {

                    if (((Button)(c)).Text != "Edit")
                        ((Button)(c)).Enabled = false;
                }
                else if ((c.GetType() == typeof(HtmlInputRadioButton)))
                {
                    ((HtmlInputRadioButton)(c)).Disabled = true;
                }
                else if ((c.GetType() == typeof(HtmlSelect)))
                {
                    ((HtmlSelect)(c)).Disabled = true;
                }
                else if ((c.GetType() == typeof(Repeater)))
                {
                    //  ((Repeater)(c)).dis = true;
                }





                if (c.HasControls())
                {
                    setReadonlyFrame(c);
                }
            }
        }


        public void formatterNumber(Control parent)
        {
            foreach (Control c in parent.Controls)
            {
                if ((c.GetType() == typeof(HtmlInputText)))
                {
                    if (isNumber(((HtmlInputText)(c)).Value))
                    {
                        string name = ((HtmlInputText)(c)).Name;

                        if (((HtmlInputText)(c)).Value.Length > 3 && Regex.IsMatch(name, "amount", RegexOptions.IgnoreCase))
                            ((HtmlInputText)(c)).Value = ServiceUtils.formateNumber(((HtmlInputText)(c)).Value);
                    }

                }
                else if ((c.GetType() == typeof(TextBox)))
                {
                    if (isNumber(((TextBox)(c)).Text))
                    {
                        string name = ((HtmlInputText)(c)).Name;

                        if (((TextBox)(c)).Text.Length > 3 && Regex.IsMatch(name, "amount", RegexOptions.IgnoreCase))
                            ((TextBox)(c)).Text = ServiceUtils.formateNumber(((TextBox)(c)).Text);
                    }

                }


                if (c.HasControls())
                {
                    formatterNumber(c);
                }
            }
        }

        private bool isNumber(string code)
        {
            try
            {
                Convert.ToDouble(code);

                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }
        protected void showSuccessMessage(IResponseHandler response)
        {
            HtmlGenericControl alertSuccess = (HtmlGenericControl)this.Master.FindControl("alertSuccess");
            alertSuccess.Visible = true;
            alertSuccess.InnerHtml = ApplicationCodes.SUCCESS_TEXT;
        }
        protected void showSuccessMessage(string response)
        {
            HtmlGenericControl alertSuccess = (HtmlGenericControl)this.Master.FindControl("alertSuccess");
            alertSuccess.Visible = true;
            alertSuccess.InnerHtml = ApplicationCodes.SUCCESS_TEXT;
        }
        protected void showErrorMessage(string response)
        {
            HtmlGenericControl alertFailure = (HtmlGenericControl)this.Master.FindControl("alertFailure");
            alertFailure.Visible = true;
            alertFailure.InnerHtml = ApplicationCodes.ERROR_TEXT + response;
        }
        protected void showErrorMessage(IResponseHandler response)
        {
            HtmlGenericControl alertFailure = (HtmlGenericControl)this.Master.FindControl("alertFailure");
            alertFailure.Visible = true;
            alertFailure.InnerHtml = ApplicationCodes.ERROR_TEXT + response.getErrorBlock().ErrorText;
        }
        public string getRequestedParams(string key)
        {
            return Request[key];
        }
        public void goBack()
        {
            setSubjectID("");
            Sessions.getSession().Set(SessionKey.DICTONARYKEY, new Dictionary<string, string>());
            Response.Redirect(getLastURL());
        }
        public Int32 getUserID()
        {
            return getUserInformation() == null ? -1 : getUserInformation().userAccount.userid;
        }


        public HtmlGenericControl getPreviousPageDivContentValue(string divid)
        {
            return ((HtmlGenericControl)PreviousPage.FindControl(divid));
        }
        public string getPreviousPageDropDownValue(string dropdown)
        {
            return ((DropDownList)PreviousPage.FindControl(dropdown)).SelectedValue;
        }
        public string getPreviousPageTextBoxValue(string textBoxid)
        {

            return ((TextBox)PreviousPage.FindControl(textBoxid)).Text;

        }
        public string getPreviousPageHTMLInputValue(string textBoxid)
        {

            return ((HtmlInputText)Page.PreviousPage.FindControl(textBoxid)).Value;

        }
        public void InjectSession(UserInformation ui, string xPath)
        {
            if (ui.authorise)
            {
                //place loginpage id here
                Sessions.getSession().Set(SessionKey.CURRENTPAGE, 0);
                Sessions.getSession().Set(SessionKey.USERINFORMATION, ui);
                Sessions.getSession().Set(SessionKey.PAGEVISTSTACK, new List<Int32>());
                Sessions.getSession().Set(SessionKey.SESSIONEXIST, true);
                Sessions.getSession().Set(SessionKey.DICTONARYKEY, new Dictionary<string, string>());

            }
            else
            {
                Response.Redirect(xPath + "/Login.aspx");
            }
        }


        public void setRequestedMap(string key, string value)
        {
            if (((Dictionary<string, string>)Sessions.getSession().Get(SessionKey.DICTONARYKEY)).ContainsKey(key))
                ((Dictionary<string, string>)Sessions.getSession().Get(SessionKey.DICTONARYKEY)).Remove(key);

            ((Dictionary<string, string>)Sessions.getSession().Get(SessionKey.DICTONARYKEY)).Add(key, value);
        }
        public void setRequestedMap(string key, Int32 value)
        {
            setRequestedMap(key, value.ToString());
        }
        public void setRequestedMap(string key, long value)
        {
            setRequestedMap(key, value.ToString());
        }
        public void setRequestedMap(string key, float value)
        {
            setRequestedMap(key, value.ToString());
        }

        public string getRequestedMap(string key)
        {
            if (!((Dictionary<string, string>)Sessions.getSession().Get(SessionKey.DICTONARYKEY)).ContainsKey(key))
                return "";
            return ((Dictionary<string, string>)Sessions.getSession().Get(SessionKey.DICTONARYKEY))[key];
        }

        public void unAuthorisedAccess()
        {
            Response.Redirect("UnAuthorisePage.aspx");
        }
        public void setCookiesValue(string key, string value)
        {
            HttpCookie cookName = new HttpCookie(key);
            cookName.Value = value;
        }
        public string getCookiesValue(string key)
        {
            return Request.Cookies[key].Value;
        }

        public void setApplicationValue(string key, string value)
        {
            Application[key] = value;
        }
        public string getApplicationValue(string key)
        {
            return Application[key].ToString();
        }

        public void setSubjectID(string value)
        {
            Sessions.getSession().Set(SessionKey.SUBJECTID, value);
        }
        public string getSubjectID()
        {
            return Convert.ToString(Sessions.getSession().Get(SessionKey.SUBJECTID));
        }

        public void clearSession()
        {
            Sessions.getSession().ClearSessionKeys();
        }

        public string getWebPageName(Int32 pageNo)
        {
            return GlobalStaticCache.PageCacheMap[pageNo.ToString()].webName;


        }
        public bool hasPermission(Int32 pageNo)
        {

            if (!isSessionExist())
            {
                Response.Redirect("Login.aspx");
                return false;
            }


            Sessions.getSession().Set(SessionKey.CURRENTPAGE, pageNo);

            UserInformation userinfo = getUserInformation();


            List<Permission> pagePermissions = PermissionManager.readbyPageID(pageNo.ToString());

            foreach (Permission permission in pagePermissions)
            {
                foreach (UserPermission up in userinfo.userPermissions)
                {
                    if (up.Code == permission.Code)
                    {
                        addVisitURLStack(pageNo);

                        return true;
                    }

                }
            }

            unAuthorisedAccess();
            return false;
        }
        public Int32 getCurrentPage()
        {
            return Convert.ToInt32(Sessions.getSession().Get(SessionKey.CURRENTPAGE));
        }

        public UserInformation getUserInformation()
        {
            return (UserInformation)Sessions.getSession().Get(SessionKey.USERINFORMATION);
        }
        public void addVisitURLStack(Int32 pageNo)
        {
            List<Int32> pageVisitedStack = (List<Int32>)Sessions.getSession().Get(SessionKey.PAGEVISTSTACK);
            if (pageVisitedStack == null)
                pageVisitedStack = new List<Int32>();

            pageVisitedStack.Add(pageNo);

            Sessions.getSession().Set(SessionKey.PAGEVISTSTACK, pageVisitedStack);
        }
        public string getLastURL()
        {
            return (GlobalStaticCache.PageCacheMap[getLastVisitedURLCode().ToString()]).webName;
        }

        public Int32 getLastVisitedURLCode()
        {
            if (((List<Int32>)Sessions.getSession().Get(SessionKey.PAGEVISTSTACK)).Count == 0)
                return 0;
            else if (((List<Int32>)Sessions.getSession().Get(SessionKey.PAGEVISTSTACK)).Count == 1)
                return ((List<Int32>)Sessions.getSession().Get(SessionKey.PAGEVISTSTACK))[0];

            return ((List<Int32>)Sessions.getSession().Get(SessionKey.PAGEVISTSTACK))[((List<Int32>)Sessions.getSession().Get(SessionKey.PAGEVISTSTACK)).Count - 1];

        }
        public List<Int32> getVisitedStack()
        {
            return (List<Int32>)Sessions.getSession().Get(SessionKey.PAGEVISTSTACK);
        }
        public bool isSessionExist()
        {
            if (Sessions.getSession().Get(SessionKey.SESSIONEXIST) != null && Sessions.getSession().getSessionID() != null && Sessions.getSession().getSessionID().Length > 0)
                return Convert.ToBoolean(Sessions.getSession().Get(SessionKey.SESSIONEXIST));

            return false;
        }
    }
}