using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using Domains.itinsync.icom.interfaces.response;
using Forms.itinsync.src.session;
using HtmlAgilityPack;
using Services.itinsync.icom.tablecontent;
using Services.itinsync.icom.tablecontent.dto;
using Utils.itinsync.icom.constant.application;
using Utils.itinsync.icom.date;
using Utils.itinsync.icom.xml;

namespace Forms.Webroot.Forms.Management.FormsManager
{
    public partial class FormsManager : BasePage
    {
        private static int section_id = 8;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
            }
        }

        protected void savedocument_Click(object sender, EventArgs e)
        {

            string tablesss = "<table id='tblEditor'>< tbody >";
            tablesss += "<tr>";
            tablesss += "<td style =''>";
            tablesss += "<div class='redips-drag' id='te1c0' style='cursor: move; width: 148px; opacity: 0.9;'>";
            tablesss += "<table class='redips -nolayout cHeader'>";
            tablesss += "<tbody>";
            tablesss += "<tr>";
            tablesss += "<td class='hLeft' onclick='redips.details(this)'>+</td>";
            tablesss += "<td class='hTitle'><input id = '555' type='radio' onclick='testID(this)'></td>";
            tablesss += "<td class='hRight' onclick='redips.divDelete(this)'>x</td>";
            tablesss += "</tr>";
            tablesss += "</tbody>";
            tablesss += "</table>";
            tablesss += "</div>";
            tablesss += "</td>";
            tablesss += "<td style = '' >";
            tablesss += "<div class='redips -drag' id='ca1c0' style='cursor: move; width: 148px;'>";
            tablesss += "<table class='redips -nolayout cHeader'>";
            tablesss += "<tbody>";
            tablesss += "<tr>";
            tablesss += "<td class='hLeft' onclick='redips.details(this)'>+</td>";
            tablesss += "<td class='hTitle'><input type = 'password' class='form-control' id='input-password-1' placeholder='Password'></td>";
            tablesss += "<td class=hRight onclick='redips.divDelete(this)'>x</td>";
            tablesss += "</tr>";
            tablesss += "</tbody>";
            tablesss += "</table>";
            tablesss += "</div>";
            tablesss += "</td>";
            tablesss += "< td></td>";
            tablesss += "</tr>";
            tablesss += "</tbody>";
            tablesss += "</table>";

            //SautinSoft.PdfMetamorphosis p = new SautinSoft.PdfMetamorphosis();



            //if (p != null)

            //{

            //    // Specify page options.

            //    p.PageSettings.Size.A4();



            //    string htmlPath = @"c:\Fathers and Sons.html";

            //    string pdfPath = @"c:\Fathers and Sons.pdf";




            //    int result = p.HtmlToPdfConvertFile(htmlPath, pdfPath);

            //}


            HtmlDocument resultat = new HtmlDocument();

            //string source = tableOuterHtml.Value;

            string source = tablesss;
            source = XMLUtils.DecodeXML(source);



            resultat.LoadHtml(source);

            tablecontentDTO dto = new tablecontentDTO();
            dto.document.documentName = "FormDynamic";
            dto.document.transDate = DateFunctions.getCurrentDateAsString();
            dto.document.transTime = DateFunctions.getCurrentTimeInMillis();
            dto.document.data = source;



            HtmlNode table = resultat.DocumentNode.Descendants().Where
            (x => (x.Name == "table")).First();

            if (table != null)
            {
                dto.documentTable.documentsectionid = section_id;
            }


            List<HtmlNode> rowcount = resultat.DocumentNode.Descendants().Where
            (x => (x.Name == "tr")).ToList();

            foreach (HtmlNode Rownode in rowcount)
            {

                dto.documentTableTR.cssClass = "table-border";
                dto.documentTableTRlist.Add(dto.documentTableTR);


                if (Rownode.HasChildNodes)
                {
                    foreach (HtmlNode colnode in Rownode.ChildNodes)
                    {
                        if (colnode.Name == "td")
                        {
                            dto.documentTableTD.tdType = "600";
                            dto.documentTableTDlist.Add(dto.documentTableTD);
                            //if (attr.Name.Trim() == "Class")
                            //{

                            //}

                            if (colnode.HasChildNodes)
                            {
                                foreach (HtmlNode fieldnode in colnode.ChildNodes)
                                {
                                    if (!string.IsNullOrWhiteSpace(fieldnode.OuterHtml))
                                    {
                                        if (fieldnode.HasAttributes)
                                        {

                                            foreach (HtmlAttribute attr in fieldnode.Attributes)
                                            {
                                                if (attr.GetType().ToString() == "password" || attr.GetType().ToString() == "textbox")
                                                {
                                                    dto.documentTableContent.controlType = "3";
                                                    continue;
                                                }
                                                if (attr.GetType().ToString() == "radio")
                                                {
                                                    dto.documentTableContent.controlType = "2";
                                                    continue;
                                                }
                                                if (attr.Name == "id")
                                                {
                                                    dto.documentTableContent.controlName = attr.Value;
                                                    dto.documentTableContent.controlID = attr.Value;
                                                    continue;
                                                }
                                                if (attr.Name == "irequired")
                                                {
                                                    if (attr.Value == "1")
                                                        dto.documentTableContent.isRequired = "1";
                                                    continue;
                                                }
                                                if (attr.Name == "irequired" && attr.Value == "1")
                                                {
                                                    dto.documentTableContent.isRequired = "1";
                                                    continue;
                                                }
                                                if (attr.Name == "imask" && attr.Value != null)
                                                {
                                                    dto.documentTableContent.mask = attr.Value;
                                                    continue;
                                                }
                                                if (attr.Name == "Class")
                                                {
                                                    dto.documentTableContent.cssClass = attr.Value;
                                                    continue;
                                                }
                                            }

                                            dto.documentTableContent.colspan = Convert.ToInt32(colnode.GetAttributeValue("Colspan", null));
                                            dto.documentTableContentlist.Add(dto.documentTableContent);

                                        }

                                    }
                                }
                            }
                        }
                    }
                }
            }

            IResponseHandler response = new tablecontentSaveService().executeAsPrimary(dto);
            if (response.getErrorBlock().ErrorCode == ApplicationCodes.ERROR_NO)
            {
                showSuccessMessage(response);

            }
            else
            {
                showErrorMessage(response);
            }

        }
    }
}