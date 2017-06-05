﻿using Domains.itinsync.icom.idocument;
using Domains.itinsync.icom.idocument.definition;
using Domains.itinsync.icom.idocument.section;
using Domains.itinsync.icom.idocument.table;
using Domains.itinsync.icom.idocument.table.content;
using Domains.itinsync.icom.idocument.table.td;
using Domains.itinsync.icom.idocument.table.tr;
using Domains.itinsync.icom.interfaces.document;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using Utils.itinsync.icom.constant.application;
using Utils.itinsync.icom.controls;

namespace Utils.itinsync.icom.html
{
    public static class HTMLUtils
    {
        public static XDocumentTable  HtmlParse(string html, int section_id)
        {
              #region add Load Html
          
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
                //tableTR.id

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
                                   
                                    string type = fieldnode.ChildNodes[1].GetAttributeValue("type", string.Empty);


                                    if (!string.IsNullOrEmpty(type))
                                    {
                                        XDocumentTableContent tableContent = new XDocumentTableContent();


                                        if (type == "checkbox")
                                            tableContent.controlType =ApplicationCodes.FORMS_CONTROL_CHECKBOX;
                                        else if (type == "radio")
                                            tableContent.controlType = ApplicationCodes.FORMS_CONTROL_RADIOBUTTON;
                                        else if (type == "text")
                                            tableContent.controlType = ApplicationCodes.FORMS_CONTROL_TAXTBOX;
                                        else if  (type == "label")
                                            tableContent.controlType = ApplicationCodes.FORMS_CONTROL_LABEL;
                                        //if (type=="select")
                                        //{
                                        //    dto.documentTableContent.controlType = "4";
                                        //}
                                        //if (fieldnode.FirstChild.GetType() == typeof(Label))
                                        //{
                                        //    dto.documentTableContent.controlType = "5";
                                        //}

                                        tableContent.controlName = fieldnode.ChildNodes[1].GetAttributeValue("name", "");
                                        tableContent.controlID = fieldnode.ChildNodes[1].GetAttributeValue("id", "") + section_id + "formname";
                                        tableContent.isRequired = fieldnode.ChildNodes[1].GetAttributeValue("irequired", "");
                                        tableContent.mask = fieldnode.ChildNodes[1].GetAttributeValue("imask", "");
                                        tableContent.cssClass = fieldnode.ChildNodes[1].GetAttributeValue("Class", "");
                                        tableContent.lookupName= fieldnode.ChildNodes[1].GetAttributeValue("LookupName", "");
                                        tableContent.translation= fieldnode.ChildNodes[1].GetAttributeValue("translation", "");
                                        tableContent.points = fieldnode.ChildNodes[1].GetAttributeValue("points", "");
                                        tableContent.defaultValue = fieldnode.ChildNodes[1].GetAttributeValue("defaultValue", "");



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


        public static string HTMLTable(XDocumentDefination xdocumentDefinition, Int32 sectionID,string lang)
        {
            

            foreach (XDocumentSection section in xdocumentDefinition.documentSections)
            {
                if (section.documentsectionid != sectionID)
                    continue;

                HtmlTable htmltable = new HtmlTable();
                htmltable.Attributes.Add("class", "table table-bordered table-responsive");
                

                foreach (XDocumentTable table in section.documentTable)
                {
                    foreach (XDocumentTableTR tr in table.trs)
                    {
                        HtmlTableRow tabletr = new HtmlTableRow();
                        tabletr.Style.Add("class", tr.cssClass);
                        tabletr.Style.Add("border-width", "10");
                        htmltable.Rows.Add(tabletr);

                        foreach (XDocumentTableTD td in tr.tds)
                        {
                            HtmlTableCell tc = new HtmlTableCell();
                            tabletr.Cells.Add(tc);
                            foreach (XDocumentTableContent content in td.fields)
                            {
                                ControlsHelper helper = new ControlsHelper();

                                HtmlGenericControl createDiv = new HtmlGenericControl("DIV");
                                createDiv.Attributes.Add("class", "redips-drag");
                                createDiv.Style.Add("cursor", "move");
                                createDiv.Style.Add("width", "158px");


                                createDetailSpan(createDiv, content.controlID);
                                createDiv.Controls.Add( helper.addControl(content, lang));
                                removeDetailSpan(createDiv, content.controlID);

                                tc.Controls.Add(createDiv);
                               
                            }

                        }

                        //create CRUD column
                        tabletr.Cells.Add(createCRUDColumn());

                    }
                }

                if (htmltable.Rows.Count > 0)
                {
                    StringWriter sw = new StringWriter();
                    htmltable.RenderControl(new HtmlTextWriter(sw));

                    string html = sw.ToString();
                    return html;
                }


            }

            return "";
        }

        public static HtmlTableCell createCRUDColumn()
        {
            HtmlTableCell crudTD = new HtmlTableCell();

            HtmlGenericControl createDiv = new HtmlGenericControl("div");

            HtmlGenericControl cross = new HtmlGenericControl("span");
            cross.Attributes.Add("class", "rowTool");
            cross.Attributes.Add("onclick", "redips.rowDelete(this)");
            cross.InnerHtml = "x";
            createDiv.Controls.Add(cross);


            HtmlGenericControl row = new HtmlGenericControl("span");
            row.Attributes.Add("class", "rowTool");
            row.Attributes.Add("onclick", "redips.rowInsert(this)");
            row.InnerHtml = "/r+";
            createDiv.Controls.Add(row);

            HtmlGenericControl column = new HtmlGenericControl("span");
            column.Attributes.Add("class", "rowTool");
            column.Attributes.Add("onclick", "redips.colInsert(this)");
            column.InnerHtml = "/c+";
            createDiv.Controls.Add(column);


            crudTD.Controls.Add(createDiv);

            return crudTD;

        }

        public static void createDetailSpan(HtmlGenericControl createDiv, string controlID)
        {
            HtmlGenericControl spanAddDetail = new HtmlGenericControl("span");
            spanAddDetail.Attributes.Add("class", "hLeft");
            spanAddDetail.Attributes.Add("onclick", "AddDetail('" + controlID + "')");
            spanAddDetail.InnerHtml = "+";
            createDiv.Controls.Add(spanAddDetail);
        }

        public static void removeDetailSpan(HtmlGenericControl createDiv, string controlID)
        {
            HtmlGenericControl spanRemoveDetail = new HtmlGenericControl("span");
            spanRemoveDetail.Attributes.Add("class", "hRight");
            spanRemoveDetail.Attributes.Add("onclick", "deleteColumn('" + controlID + "')");
            spanRemoveDetail.InnerHtml = "x";
            createDiv.Controls.Add(spanRemoveDetail);
        }
    }
}