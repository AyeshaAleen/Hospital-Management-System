using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using Domains.itinsync.icom.interfaces.response;
using HtmlAgilityPack;
using Services.itinsync.icom.tablecontent;
using Services.itinsync.icom.tablecontent.dto;
using Utils.itinsync.icom.constant.application;
using Utils.itinsync.icom.date;

namespace Forms.Webroot.Forms.Management.FormsManager
{
    public partial class FormsManager : System.Web.UI.Page
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

            HtmlDocument resultat = new HtmlDocument();
            string source = "<table><tr><td> <input id='txt1' type = 'textbox' irequired='1' imask='numaric' ></td><td><input id='txt2' type = 'textbox' irequired='1' imask='numaric' ></td></tr><tr><td><input id='txt3' type = 'textbox' irequired='1' imask='numaric' ></td><td><input id='txt4' type = 'textbox' irequired='1' imask='numaric' ></td></tr></table>";
            resultat.LoadHtml(source);

            tablecontentDTO dto = new tablecontentDTO();
            dto.document.documentName = "FormDynamic";
            dto.document.transDate = DateFunctions.getCurrentDateAsString();
            dto.document.transTime = DateFunctions.getCurrentTimeInMillis();
            dto.document.data = source;



            HtmlNode table = resultat.DocumentNode.Descendants().Where
            (x => (x.Name == "table")).SingleOrDefault();

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

                        dto.documentTableTD.tdType = "600";
                        dto.documentTableTDlist.Add(dto.documentTableTD);
                        //if (attr.Name.Trim() == "Class")
                        //{

                        //}


                        foreach (HtmlNode fieldnode in colnode.ChildNodes)
                        {
                            if (!string.IsNullOrWhiteSpace(fieldnode.OuterHtml))
                            {
                                if (fieldnode.HasAttributes)
                                {
          
                                    foreach (HtmlAttribute attr in fieldnode.Attributes)
                                    {
                                        if(attr.Name== "type" && attr.Value== "textbox")
                                        {
                                            dto.documentTableContent.controlType = "3";
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
                                        if (attr.Name == "irequired" && attr.Value=="1")
                                        {
                                                dto.documentTableContent.isRequired = "1";
                                            continue;
                                        }
                                        if (attr.Name == "imask" && attr.Value !=null)
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
                                }
                                dto.documentTableContent.colspan = Convert.ToInt32(colnode.GetAttributeValue("Colspan", null));
                                dto.documentTableContentlist.Add(dto.documentTableContent);
                            }
                        }
                    }
                }
            }
            
         IResponseHandler response=   new tablecontentSaveService().executeAsPrimary(dto);
            if(response.getErrorBlock().ErrorCode==ApplicationCodes.ERROR_NO)
            {
                //ShowSuccessMessage();
            }
            else
            {
                //ShowErrorMessage();
            }

        }
    }
}