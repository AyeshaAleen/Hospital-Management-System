using Domains.itinsync.icom.idocument.table.content;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Utils.itinsync.icom.cache.lookup;
using Utils.itinsync.icom.cache.translation;
using Utils.itinsync.icom.constant.application;
using Utils.itinsync.icom.cache.document;

namespace Utils.itinsync.icom.controls
{
    public  class ControlsHelper
    {
        public  TextBox  createTextBox(XDocumentTableContent content)
        {
            TextBox txtBox = new TextBox();
            txtBox.ID = content.controlID;
            txtBox.CssClass = content.cssClass;
            txtBox.Attributes.Add("irequired", content.isRequired);
            txtBox.Attributes.Add("imask", content.mask);
            if (!string.IsNullOrEmpty(content.isReadonly))
                txtBox.Attributes.Add("disabled", content.isReadonly);
            txtBox.Attributes.Add("points", content.points);
            if (content.fieldcalculations.Count > 0)
            {
                txtBox.Attributes.Add("onchange", "calculation();");
                if (content.fieldcalculations[0].resultContent != null)
                {
                    if (content.fieldcalculations[0].resultContent.controlID != null)
                        //bcoz i form calculator required proper id
                        AddResultantID(txtBox, content);
                    if (content.fieldcalculations[0].operation != null)
                        txtBox.Attributes.Add("operation", content.fieldcalculations[0].operation);
                }
            }
            if (!string.IsNullOrEmpty(content.defaultValue))
                txtBox.Text = content.defaultValue;

            return txtBox;
        }

        public  Label createLabel(XDocumentTableContent content)
        {
            if (string.IsNullOrEmpty(content.translation))
                return null;
            else
            {
                Label lbl = new Label();
                lbl.Attributes.Add("translation", content.translation);
                lbl.Attributes.Add("id", content.controlID);
                lbl.Attributes.Add("name", content.controlName);
                lbl.Attributes.Add("type", "label");
                lbl.Attributes.Add("defaultValue", TranslationManager.trans(content.translation));
                lbl.Text = TranslationManager.trans(content.translation);
                

                return lbl;
            }
        }

        public  TableHeaderCell createTableHeader(XDocumentTableContent content)
        {
            TableHeaderCell tableHeader = new TableHeaderCell();

            Label lbl = new Label();
            lbl.ID = content.controlID;
            //lbl.CssClass = content.cssClass;
            tableHeader.HorizontalAlign = HorizontalAlign.Center;
            tableHeader.VerticalAlign = VerticalAlign.Middle;
            tableHeader.BackColor = Color.WhiteSmoke;
            tableHeader.ColumnSpan = content.colspan;
            lbl.Text = TranslationManager.trans(content.translation);
            tableHeader.Controls.Add(lbl);
            return tableHeader;
        }



        public  HtmlInputRadioButton createRadioButton(XDocumentTableContent content)
        {
            HtmlInputRadioButton radio = new HtmlInputRadioButton();
            radio.Name = content.controlName;
            //radio.Checked += new radiocheckedvent(your method);
            radio.ID = content.controlID;
            radio.Attributes.Add("irequired", content.isRequired);
            radio.Attributes.Add("imask", content.mask);
            radio.Attributes.Add("points", content.points);
            if(!string.IsNullOrEmpty(content.isReadonly))
            radio.Attributes.Add("disabled", content.isReadonly);

            if (content.fieldcalculations.Count > 0)
            {
                radio.Attributes.Add("onchange", "calculation();");

                //bcoz i form calculator required proper id
                AddResultantID(radio,content);
                
                radio.Attributes.Add("operation", content.fieldcalculations[0].operation);
            }
            if(!string.IsNullOrEmpty(content.defaultValue))
            radio.Value = content.defaultValue;

            return radio;
        }

        private void AddResultantID(HtmlControl control, XDocumentTableContent content)
        {
            control.Attributes.Add("resultantID", DocumentManager.getDocumentTablesContentID(content.fieldcalculations[0].resultContentID).controlID);
        }

        private void AddResultantID(WebControl control, XDocumentTableContent content)
        {
            control.Attributes.Add("resultantID", DocumentManager.getDocumentTablesContentID(content.fieldcalculations[0].resultContentID).controlID);
        }
            public  HtmlInputCheckBox createCheckBox(XDocumentTableContent content)
        {
            HtmlInputCheckBox check = new HtmlInputCheckBox();
            check.Name = content.controlName;
            check.ID = content.controlID;
            check.Attributes.Add("irequired", content.isRequired);
            if (!string.IsNullOrEmpty(content.isReadonly))
                check.Attributes.Add("disabled", content.isReadonly);
            check.Attributes.Add("imask", content.mask);
            check.Attributes.Add("points", content.points);

            if (content.fieldcalculations.Count > 0)
            {
                check.Attributes.Add("onchange", "calculation();");
                AddResultantID(check, content);
                check.Attributes.Add("operation", content.fieldcalculations[0].operation);
            }
            if (!string.IsNullOrEmpty(content.defaultValue))
                check.Value = content.defaultValue;

            return check;
        }

        public  DropDownList createCombo(XDocumentTableContent content,string lang)
        {
            DropDownList ddl = new DropDownList();
            ddl.ID = content.controlID;
            ddl.DataValueField = "Code";
            ddl.DataTextField = "Text";
            ddl.Attributes.Add("irequired", content.isRequired);
            if (!string.IsNullOrEmpty(content.isReadonly))
                ddl.Attributes.Add("disabled", content.isReadonly);

            ddl.Attributes.Add("imask", content.mask);
            ddl.Attributes.Add("points", content.points);
            if (content.fieldcalculations.Count > 0)
            {
                ddl.Attributes.Add("onchange", "calculation();");
                AddResultantID(ddl, content);
                ddl.Attributes.Add("operation", content.fieldcalculations[0].operation);
            }

            ddl.DataSource = LookupManager.readbyLookupName(content.lookupName, lang);

            return ddl;
        }

        public Control addControl(XDocumentTableContent content,string lang)
        {
            if (content.controlType == ApplicationCodes.FORMS_CONTROL_LABEL)
                return createLabel(content);
            else if (content.controlType == ApplicationCodes.FORMS_CONTROL_TAXTBOX)
                return createTextBox(content);
            else if (content.controlType == ApplicationCodes.FORMS_CONTROL_RADIOBUTTON)
                return createRadioButton(content);
            else if (content.controlType == ApplicationCodes.FORMS_CONTROL_COMBObOX)
                return createCombo(content, lang);
            else if (content.controlType == ApplicationCodes.FORMS_CONTROL_CHECKBOX)
                return createCheckBox(content);
            else
                return null;
        }
        
    }
}
