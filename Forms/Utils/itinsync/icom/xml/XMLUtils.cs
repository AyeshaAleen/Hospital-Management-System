using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Xml;

namespace Utils.itinsync.icom.xml
{
    public static class XMLUtils
    {
        public static readonly string XML_START_TAG = "<";
        public static readonly string XML_END_TAG = ">";
        
        public static string appendTag(string key,string value)
        {

            return XML_START_TAG + key + XML_END_TAG + value + XML_START_TAG + "/" + key + XML_END_TAG;
        }

        public static string appendTag(string key, Int32 value)
        {
            return appendTag(key, Convert.ToString(value));
        }

        public static string appendTag(string key, double value)
        {
            return appendTag(key, Convert.ToString(value));
        }

        public static string appendTag(string key, Decimal value)
        {
            return appendTag(key, Convert.ToString(value));
        }

        public static string appendTag(string key, float value)
        {
            return appendTag(key, Convert.ToString(value));
        }
        public static string appendTag(string key, bool value)
        {
            return appendTag(key, Convert.ToString(value));
        }

        public static string EncodeXML(string xml)
        {
           // string xml = xml;
           return xml.Replace("&", "&amp;").Replace("<", "&lt;").Replace(">", "&gt;").Replace("\"", "&quot;").Replace("'", "&apos;");

        }
        public static string DecodeXML(string xml)
        {
            // string xml = xml;
            return xml.Replace("&amp;", "&").Replace("&lt;", "<").Replace("&gt;", ">").Replace("&quot;", "\"").Replace("&apos;", "'");

        }


        public static string DecodedFinalXML(string xml)
        {
            string finalxml = "";
            finalxml = xml.Replace("&", "&amp;").Replace("<", "&lt;").Replace(">", "&gt;").Replace("\"", "&quot;").Replace("'", "&apos;");
            finalxml=finalxml.Replace("&amp;", "&").Replace("&lt;", "<").Replace("&gt;", ">").Replace("&quot;", "\"").Replace("&apos;", "'");
            return finalxml;
        }

        public static string getDynamicXML(string CurrentTagName, string dbxml, Control parent)
        {
            string  xml =  appendTag(CurrentTagName, xmlConversion(parent, ""));
            XMLParser xmlparser = new XMLParser(dbxml);
            XMLParser xmlparser_In = new XMLParser(xml);
            xmlparser.setTagXML(CurrentTagName, xmlparser_In.getinnerxml(CurrentTagName));
            return xmlparser.getXML();

         
        }
        public static string xmlConversion(Control parent, string outPut)
        {

            // Table table = parent.Controls.OfType<Table>().SingleOrDefault();

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

        public static void processXML(Control parent, string xml, string root)
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xml);
            XmlNodeList elemList = doc.GetElementsByTagName(root);
            if (elemList != null)
            {
                XmlNode mynode = elemList.Item(0);
                if (mynode != null)
                {
                    foreach (XmlNode childnode in mynode.ChildNodes)
                    {
                        // setControlValues(parent, childnode.Name, childnode.InnerText);

                        findSetControl(parent.FindControl(childnode.Name), childnode.InnerText);
                    }
                }
            }
        }

        private static void findSetControl(Control control, string value)
        {
            if (control == null)
                return;

            if (control.GetType() == typeof(TextBox))
            {
                ((TextBox)control).Text = value;

            }

            else if (control.GetType() == typeof(HtmlInputText))
            {
                ((HtmlInputText)control).Value = value;

            }

            else if (control.GetType() == typeof(HtmlInputText))
            {
                ((DropDownList)control).SelectedValue = value;

            }

            else if (control.GetType() == typeof(HtmlInputRadioButton))
            {
                if (value == "1" || value == "Y" || value == "y" || value == "True" || value == "true")
                    ((HtmlInputRadioButton)control).Checked = true;
                else
                    ((HtmlInputRadioButton)control).Checked = false;

            }
            else if (control.GetType() == typeof(HtmlSelect))
            {
                ((HtmlSelect)control).Value = value;

            }
            else if (control.GetType() == typeof(CheckBox))
            {
                if (value == "1" || value == "Y" || value == "y" || value == "True" || value == "true")
                    ((CheckBox)control).Checked = true;
                else
                    ((CheckBox)control).Checked = false;

            }
        }

    }
}
