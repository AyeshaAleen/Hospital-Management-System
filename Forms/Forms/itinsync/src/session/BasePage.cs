using AjaxControlToolkit;
using Domains.itinsync.icom.header;
using Domains.itinsync.icom.idocument;
using Domains.itinsync.icom.idocument.definition;
using Domains.itinsync.icom.idocument.section;
using Domains.itinsync.icom.idocument.table;
using Domains.itinsync.icom.idocument.table.calculation;
using Domains.itinsync.icom.idocument.table.content;
using Domains.itinsync.icom.idocument.table.td;
using Domains.itinsync.icom.idocument.table.tr;
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
using System.Xml;
using Utils.itinsync.icom;
using Utils.itinsync.icom.cache.global;
using Utils.itinsync.icom.cache.lookup;
using Utils.itinsync.icom.cache.permission;
using Utils.itinsync.icom.cache.translation;
using Utils.itinsync.icom.constant.application;
using Utils.itinsync.icom.constant.page;
using Utils.itinsync.icom.date;
using Utils.itinsync.icom.idoument.table.calculation;
using Utils.itinsync.icom.xml;
using static Forms.itinsync.src.session.Session;
using HtmlAgilityPack;
using System.IO;

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


                Response.Redirect(PageConstant.PAGE_USER_DASHBOARD);

            }
            else
            {
                Response.Redirect("Login.aspx");
            }
        }
        protected void Page_SaveStateComplete(object sender, EventArgs e)
        {
            setIMessage(this);

            //processDynamicContent
           // processDynamicContent(this);

        }
        private void addLabel(TableCell tc, string trans)
        {
            if (string.IsNullOrEmpty(trans))
                return;
            else
            {
                Label lbl = new Label();
                lbl.Text = TranslationManager.trans(trans);
                tc.Controls.Add(lbl);
            }
        }

        protected Table processDynamicContent(Table parentTable, Douments documents, Int32 sectionID)
        {
            
            foreach (XDocumentSection section in documents.xdocumentDefinition.documentSections)
            {
                if (section.documentsectionid != sectionID)
                    continue;

                foreach (XDocumentTable table in section.documentTable)
                {

                    foreach (XDocumentTableTR tr in table.trs)
                    {
                        TableRow tabletr = new TableRow();

                        tabletr.CssClass = tr.cssClass;
                        tabletr.BorderWidth = 10;


                        foreach (XDocumentTableTD td in tr.tds)
                        {

                            foreach (XDocumentTableContent content in td.fields)
                            {
                                List<XDocumentCalculation> calculations = content.fieldcalculations;

                                if (td.tdType == ApplicationCodes.FORMS_TABLE_HEADER_TYPE)
                                {
                                    TableHeaderCell tableHeader = new TableHeaderCell();

                                    Label lbl = new Label();
                                    lbl.ID = content.controlID;
                                    //lbl.CssClass = content.cssClass;
                                    tableHeader.HorizontalAlign = HorizontalAlign.Center;
                                    tableHeader.VerticalAlign = VerticalAlign.Middle;
                                    tableHeader.BackColor = System.Drawing.Color.WhiteSmoke;
                                    tableHeader.ColumnSpan = content.colspan;
                                    lbl.Text = TranslationManager.trans(content.translation);
                                    tableHeader.Controls.Add(lbl);
                                    tabletr.Cells.Add(tableHeader);


                                }
                                else
                                {
                                    TableCell tc = new TableCell();
                                    if (!string.IsNullOrEmpty(content.colspan.ToString()))
                                        tc.ColumnSpan = content.colspan;
                                    else
                                        tc.ColumnSpan = Convert.ToInt32(td.colSpan);
                                    //tc.CssClass = content.cssClass;
                                    //tc.BorderStyle = BorderStyle.Solid;
                                    tc.BorderWidth = 10;

                                    if (content.controlType == ApplicationCodes.FORMS_CONTROL_LABEL)
                                    {
                                        Label lbl = new Label();
                                        lbl.ID = content.controlID;
                                        //lbl.CssClass = content.cssClass;
                                        lbl.Text = TranslationManager.trans(content.translation);
                                        lbl.Attributes.Add("points", content.points);
                                        tc.Controls.Add(lbl);
                                        tabletr.Cells.Add(tc);
                                    }

                                    if (content.controlType == ApplicationCodes.FORMS_CONTROL_TAXTBOX)
                                    {
                                        addLabel(tc, content.translation);
                                        TextBox txtBox = new TextBox();
                                        txtBox.ID = content.controlID;
                                        txtBox.CssClass = content.cssClass;
                                        txtBox.Attributes.Add("irequired", content.isRequired);
                                        txtBox.Attributes.Add("imask", content.mask);
                                        txtBox.Attributes.Add("points", content.points);
                                        if (calculations.Count > 0)
                                        {
                                            txtBox.Attributes.Add("onchange", "calculation();");
                                            txtBox.Attributes.Add("resultantID", calculations[0].resultContent.controlID);
                                            txtBox.Attributes.Add("operation", calculations[0].operation);

                                        }
                                        txtBox.Text = content.defaultValue;


                                        tc.Controls.Add(txtBox);
                                        tabletr.Cells.Add(tc);

                                    }
                                    else if (content.controlType == ApplicationCodes.FORMS_CONTROL_RADIOBUTTON)
                                    {
                                        addLabel(tc, content.translation);
                                        HtmlInputRadioButton radio = new HtmlInputRadioButton();
                                        radio.Name = content.controlName;
                                        //radio.Checked += new radiocheckedvent(your method);
                                        radio.ID = content.controlID;
                                        radio.Attributes.Add("irequired", content.isRequired);
                                        radio.Attributes.Add("imask", content.mask);
                                        radio.Attributes.Add("points", content.points);
                                        if (calculations.Count > 0)
                                        {
                                            radio.Attributes.Add("onchange", "calculation();");
                                            radio.Attributes.Add("resultantID", calculations[0].resultContent.controlID);
                                            radio.Attributes.Add("operation", calculations[0].operation);
                                        }
                                        radio.Value = content.defaultValue;

                                        tc.Controls.Add(radio);
                                        tabletr.Cells.Add(tc);
                                    }

                                    else if (content.controlType == ApplicationCodes.FORMS_CONTROL_CHECKBOX)
                                    {
                                        addLabel(tc, content.translation);
                                        HtmlInputCheckBox check = new HtmlInputCheckBox();
                                        check.Name = content.controlName;
                                        check.ID = content.controlID;
                                        check.Attributes.Add("irequired", content.isRequired);
                                        check.Attributes.Add("imask", content.mask);
                                        check.Attributes.Add("points", content.points);
                                        if (calculations.Count > 0)
                                        {
                                            check.Attributes.Add("onchange", "calculation();");
                                            check.Attributes.Add("resultantID", calculations[0].resultContent.controlID);
                                            check.Attributes.Add("operation", calculations[0].operation);
                                        }

                                        check.Value = content.defaultValue;
                                        tc.Controls.Add(check);
                                        tabletr.Cells.Add(tc);
                                    }
                                    else if (content.controlType == ApplicationCodes.FORMS_CONTROL_COMBObOX)
                                    {
                                        addLabel(tc, content.translation);
                                        DropDownList ddl = new DropDownList();
                                        ddl.ID = content.controlID;
                                        ddl.DataValueField = "Code";
                                        ddl.DataTextField = "Text";
                                        ddl.Attributes.Add("irequired", content.isRequired);
                                        ddl.Attributes.Add("imask", content.mask);
                                        ddl.Attributes.Add("points", content.points);
                                        if (calculations.Count > 0)
                                        {
                                            ddl.Attributes.Add("onchange", "calculation();");
                                            ddl.Attributes.Add("resultantID", calculations[0].resultContent.controlID);
                                            ddl.Attributes.Add("operation", calculations[0].operation);
                                        }

                                        ddl.DataSource = LookupManager.readbyLookupName(content.lookupName, getHeader().lang);

                                        ddl.DataBind();
                                        tc.Controls.Add(ddl);
                                        tabletr.Cells.Add(tc);
                                    }
                                }


                            }
                        }

                        parentTable.Rows.Add(tabletr);
                    }

                }
            }




            return parentTable;
        }
        protected void processDynamicContent(Control parent, Douments documents,Int32 sectionID)
        {

            Control tableControl = parent.FindControl("tableDynamic");
            Table parentTable = ((Table)(tableControl));
            processDynamicContent(parentTable, documents, sectionID);

        }
        private void performedCalculation(Control parent, Douments documents, Int32 sectionID)
        {
            DocumentCalculationHelper hepler = new DocumentCalculationHelper();
            foreach (XDocumentSection section in documents.xdocumentDefinition.documentSections)
            {
                if (section.documentsectionid != sectionID)
                    continue;

                foreach (XDocumentTable table in section.documentTable)
                {

                    foreach (XDocumentTableTR tr in table.trs)
                    {
                        
                        foreach (XDocumentTableTD td in tr.tds)
                        {

                            foreach (XDocumentTableContent content in td.fields)
                            {
                               // hepler.fieldCalculation(content, parent);

                              


                            }
                        }

                        
                    }

                }
            }


        }

        public void setIMessage(Control parent)
        {
            foreach (Control c in parent.Controls)
            {
                if ((c.GetType() == typeof(TextBox)))
                {
                    ((TextBox)(c)).Attributes["imessage"] = trasnlation(((TextBox)(c)).Attributes["imessage"]);

                    ((TextBox)(c)).Attributes["placeholder"] = trasnlation(((TextBox)(c)).Attributes["placeholder"]);


                }

                else if ((c.GetType() == typeof(HtmlInputText)))
                {
                    ((HtmlInputText)(c)).Attributes["imessage"] = trasnlation(((HtmlInputText)(c)).Attributes["imessage"]);

                }
                else if ((c.GetType() == typeof(DropDownList)))
                {

                    ((DropDownList)(c)).Attributes["imessage"] = trasnlation(((DropDownList)(c)).Attributes["imessage"]);
                }
                else if ((c.GetType() == typeof(CalendarExtender)))
                {


                }
                else if ((c.GetType() == typeof(Button)))
                {
                    ((Button)(c)).Text = trasnlation(((Button)(c)).Text);
                }
                else if ((c.GetType() == typeof(HtmlInputRadioButton)))
                {

                    ((HtmlInputRadioButton)(c)).Attributes["imessage"] = trasnlation(((HtmlInputRadioButton)(c)).Attributes["imessage"]);
                }
                else if ((c.GetType() == typeof(HtmlSelect)))
                {

                    ((HtmlSelect)(c)).Attributes["imessage"] = trasnlation(((HtmlSelect)(c)).Attributes["imessage"]);
                }
                else if ((c.GetType() == typeof(Repeater)))
                {
                    //  ((Repeater)(c)).dis = true;
                }


                if (c.HasControls())
                {
                    setIMessage(c);
                }
            }

        }

        public string xmlConversion(Control parent, string outPut)
        {
            Control tableControl = parent.FindControl("tableDynamic");
            Table parentTable = ((Table)(tableControl));

            foreach (Control c in parent.Controls)
            {
                if ((c.GetType() == typeof(TextBox)))
                    outPut = outPut + XMLUtils.appendTag(((TextBox)(c)).ID, ((TextBox)(c)).Text);

                else if ((c.GetType() == typeof(HtmlInputText)))
                    outPut = outPut + XMLUtils.appendTag(((HtmlInputText)(c)).ID, ((HtmlInputText)(c)).Value);

                else if ((c.GetType() == typeof(DropDownList)))
                    outPut = outPut + XMLUtils.appendTag(((DropDownList)(c)).ID, ((DropDownList)(c)).SelectedValue);

                else if ((c.GetType() == typeof(HtmlInputRadioButton)))
                {
                    if (((HtmlInputRadioButton)(c)).Checked)
                        outPut = outPut + XMLUtils.appendTag(((HtmlInputRadioButton)(c)).ID, true);
                    else
                        outPut = outPut + XMLUtils.appendTag(((HtmlInputRadioButton)(c)).ID, false);
                }

                //else if ((c.GetType() == typeof(HtmlInputRadioButton)))
                //    outPut = outPut + XMLUtils.appendTag(((HtmlInputRadioButton)(c)).ID, ((HtmlInputRadioButton)(c)).Checked);

                else if ((c.GetType() == typeof(HtmlSelect)))
                    outPut = outPut + XMLUtils.appendTag(((HtmlSelect)(c)).ID, ((HtmlSelect)(c)).Value);

                else if ((c.GetType() == typeof(CheckBox)))
                {
                    string[] id = c.ClientID.Split('_');
                    if (((CheckBox)(c)).Checked)
                        outPut = outPut + XMLUtils.appendTag(id[2], true);
                    else
                        outPut = outPut + XMLUtils.appendTag(id[2], false);
                }

                else if ((c.GetType() == typeof(HtmlInputCheckBox)))
                {
                    if (((HtmlInputCheckBox)(c)).Checked)
                        outPut = outPut + XMLUtils.appendTag(((HtmlInputCheckBox)(c)).ID, true);
                    else
                        outPut = outPut + XMLUtils.appendTag(((HtmlInputCheckBox)(c)).ID, false);
                }




                if (c.HasControls())
                     outPut = xmlConversion(c, outPut);
                
            }


            return outPut;
        }

        public void processXML(Control parent, string xml, string root)
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xml);
            XmlNodeList elemList = doc.GetElementsByTagName(root);
            if (elemList != null)
            {
                XmlNode mynode = elemList.Item(0);
                foreach (XmlNode childnode in mynode.ChildNodes)
                {
                   // setControlValues(parent, childnode.Name, childnode.InnerText);

                   findSetControl( parent.FindControl(childnode.Name), childnode.InnerText);
                }
            }
        }

        private void findSetControl(Control control,string value)
        {
            if (control == null)
                return;

            if (control.GetType() == typeof(TextBox) )
            {
                ((TextBox)control).Text = value;
             
            }

            else if (control.GetType() == typeof(HtmlInputText) )
            {
                ((HtmlInputText)control).Value = value;
               
            }

            else if (control.GetType() == typeof(HtmlInputText) )
            {
                ((DropDownList)control).SelectedValue = value;
               
            }

            else if (control.GetType() == typeof(HtmlInputRadioButton) )
            {
                if (value == "1" || value == "Y" || value == "y" || value == "True" || value == "true")
                    ((HtmlInputRadioButton)control).Checked = true;
                else
                    ((HtmlInputRadioButton)control).Checked = false;

            }
            else if (control.GetType() == typeof(HtmlSelect) )
            {
                ((HtmlSelect)control).Value = value;
               
            }
            else if (control.GetType() == typeof(CheckBox) )
            {
                if (value == "1" || value == "Y" || value == "y" || value == "True" || value == "true")
                    ((CheckBox)control).Checked = true;
                else
                    ((CheckBox)control).Checked = false;
                
            }
        }

        //never use this function as it has performance issue 
        public void setControlValues(Control parent, string inputName,string value)
        {
            foreach (Control control in parent.Controls)
            {

                if (control.GetType() == typeof(TextBox) && ((TextBox)control).ID == inputName)
                {
                    ((TextBox)control).Text = value;
                    break;
                }

                else if (control.GetType() == typeof(HtmlInputText) && ((HtmlInputText)control).ID == inputName)
                {
                    ((HtmlInputText)control).Value = value;
                    break;
                }

                else if (control.GetType() == typeof(HtmlInputText) && ((HtmlInputText)control).ID == inputName)
                {
                    ((DropDownList)control).SelectedValue= value;
                    break;
                }

                else if (control.GetType() == typeof(HtmlInputRadioButton) && ((HtmlInputRadioButton)control).ID == inputName)
                {
                    if (value == "1" || value == "Y" || value == "y" || value == "True" || value == "true")
                        ((HtmlInputRadioButton)control).Checked = true;
                    else
                        ((HtmlInputRadioButton)control).Checked = false;
                    
                    
                    break;
                }
                else if (control.GetType() == typeof(HtmlSelect) && ((HtmlSelect)control).ID == inputName)
                {
                    ((HtmlSelect)control).Value = value;
                    break;
                }
                else if (control.GetType() == typeof(CheckBox) && ((CheckBox)control).ID == inputName)
                {
                    if (value == "1" || value== "Y" || value== "y" || value== "True" || value == "true")
                        ((CheckBox)control).Checked = true;
                    else
                        ((CheckBox)control).Checked = false;
                    break;
                }
                if (control.HasControls())
                    setControlValues(control, inputName, value);
            }


            
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
            HtmlGenericControl alertSuccess = (HtmlGenericControl)this.Master.Master.FindControl("alertSuccess");
            alertSuccess.Visible = true;
            //alertSuccess.InnerHtml = ApplicationCodes.SUCCESS_TEXT;
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
            return getUserInformation() == null ? -1 : getUserInformation().userAccount.userID;
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
        public void setSubjectID(int value)
        {
            Sessions.getSession().Set(SessionKey.SUBJECTID, value);
        }
        public Int32 getSubjectIDInt()
        {
            string Subject_ID = Convert.ToString(Sessions.getSession().Get(SessionKey.SUBJECTID));
            if (!string.IsNullOrEmpty(Subject_ID))
                return Convert.ToInt32(Subject_ID);
            else
                return 0;
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
                    if (up.code == permission.Code)
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
            if (Sessions.getSession().Get(SessionKey.PAGEVISTSTACK) != null)
            {
                if (((List<Int32>)Sessions.getSession().Get(SessionKey.PAGEVISTSTACK)).Count == 0)
                    return 0;
                else if (((List<Int32>)Sessions.getSession().Get(SessionKey.PAGEVISTSTACK)).Count == 1)
                    return ((List<Int32>)Sessions.getSession().Get(SessionKey.PAGEVISTSTACK))[0];

                return ((List<Int32>)Sessions.getSession().Get(SessionKey.PAGEVISTSTACK))[((List<Int32>)Sessions.getSession().Get(SessionKey.PAGEVISTSTACK)).Count - 1];
            }
            return 0;
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

        public Header getHeader()
        {
            Header header = new Header();
            header.userID = getUserID();
            header.currentPageNo = getCurrentPage();
            header.previousPageNo = getLastVisitedURLCode();
            header.userinformation = getUserInformation();
            header.lang = getUserInformation() == null || getUserInformation().userAccount == null ? ApplicationCodes.DEFAULT_USER_LANG : getUserInformation().userAccount.lang;

            return header;
        }


        public void setXMLSession(string value)
        {
            Sessions.getSession().Set(SessionKey.XML, value);

        }
        public string getXMLSession()
        {
            return Convert.ToString(Sessions.getSession().Get(SessionKey.XML));
        }

        public XDocumentTable HtmlParse(string html,int section_id)
        {
            #region add Load Html
            object[] emptyStringArray = new object[0];

            HtmlDocument resultat = new HtmlDocument();
            resultat.LoadHtml(html);

            #endregion

            XDocumentTable documentTable = new XDocumentTable();

            #region add Table dto values


            HtmlNode table = resultat.DocumentNode.Descendants("table").SingleOrDefault();

            if (table != null)
            {
                documentTable.documentsectionid = section_id;
            }

            #endregion

            #region add Table Row dto values

            List<HtmlNode> rowcount = table.Descendants("tr").ToList();


            foreach (HtmlNode Rownode in rowcount)
            {

                XDocumentTableTR tableTR = new XDocumentTableTR();


                tableTR.cssClass = "table-border";


                #endregion

                #region add Table Column dto values
                if (Rownode.HasChildNodes)
                {
                    documentTable.trs.Add(tableTR);



                    foreach (HtmlNode colnode in Rownode.Descendants("td"))
                    {
                        if (colnode.HasChildNodes && !(colnode.GetAttributeValue("last", false)))
                        {
                            XDocumentTableTD tableTD = new XDocumentTableTD();


                            tableTD.tdType = "600";
                            tableTD.cssClass = colnode.GetAttributeValue("Class", "");
                            tableTR.tds.Add(tableTD);

                            #endregion

                            #region add Table Column Content dto values




                            foreach (var fieldnode in colnode.ChildNodes)
                            {
                                if (!string.IsNullOrWhiteSpace(fieldnode.OuterHtml))
                                {
                                    string type = fieldnode.FirstChild.GetAttributeValue("type", string.Empty);


                                    if (!string.IsNullOrEmpty(type))
                                    {
                                        XDocumentTableContent tableContent = new XDocumentTableContent();


                                        if (type == "checkbox")
                                        {
                                            tableContent.controlType = "1";
                                        }
                                        if (type == "radio")
                                        {
                                            tableContent.controlType = "2";
                                        }
                                        if (type == "text")
                                        {
                                            tableContent.controlType = "3";
                                        }
                                        //if (type=="select")
                                        //{
                                        //    dto.documentTableContent.controlType = "4";
                                        //}
                                        //if (fieldnode.FirstChild.GetType() == typeof(Label))
                                        //{
                                        //    dto.documentTableContent.controlType = "5";
                                        //}

                                        tableContent.controlName = fieldnode.GetAttributeValue("name", "");
                                        tableContent.controlID = fieldnode.GetAttributeValue("id", "") + section_id + "formname";
                                        tableContent.isRequired = fieldnode.GetAttributeValue("irequired", "1");
                                        tableContent.mask = fieldnode.GetAttributeValue("imask", "");
                                        tableContent.cssClass = fieldnode.GetAttributeValue("Class", "");
                                        tableContent.colspan = Convert.ToInt32(colnode.GetAttributeValue("Colspan", null));

                                        //dto.documentTableContentlist.Add(dto.documentTableContent);

                                        tableTD.fields.Add(tableContent);
                                    }
                                }

                            }
                            #endregion
                        }
                        //}
                    }
                }
            }


            return documentTable;

        }
    }
}