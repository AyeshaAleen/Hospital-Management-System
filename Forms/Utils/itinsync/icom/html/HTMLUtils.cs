using Domains.itinsync.icom.idocument;
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
using Domains.itinsync.icom.idocument.table.calculation;
using System.Web.UI.WebControls;
using Utils.itinsync.icom.cache.translation;

namespace Utils.itinsync.icom.html
{
    public static class HTMLUtils
    {
        public static XDocumentTable  HtmlParse(string html, int section_id,string formname)
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

                  

                    foreach (HtmlNode colnode in Rownode.ChildNodes)
                    {
                        if(colnode.Name=="td"|| colnode.Name=="th")
                        { 
                        if (colnode.HasChildNodes && !(colnode.GetAttributeValue("last", false)))
                        {
                            XDocumentTableTD tableTD = new XDocumentTableTD();
                            
                            
                            if (colnode.Descendants("h4").SingleOrDefault()!=null)
                            tableTD.tdType = ApplicationCodes.FORMS_TABLE_HEADER_TYPE; 
                            else
                                tableTD.tdType = ApplicationCodes.FORMS_TABLE_TD_TYPE;

                            tableTD.cssClass = colnode.GetAttributeValue("Class", "");
                                if(colnode.GetAttributeValue("colspan", "")!="0" && colnode.GetAttributeValue("colspan", "") != "")
                                tableTD.colSpan = colnode.GetAttributeValue("colspan", "");
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
                                        else  if (type == "select")
                                            tableContent.controlType = ApplicationCodes.FORMS_CONTROL_SELECT;
                                        else if (type == "textarea")
                                            tableContent.controlType = ApplicationCodes.FORMS_CONTROL_TEXTAREA;
                                        else if (type == "heading")
                                            tableContent.controlType = ApplicationCodes.FORMS_CONTROL_HEADING;
                                        else if (type == "hidden")
                                                tableContent.controlType = ApplicationCodes.FORMS_CONTROL_HIDDEN;



                                        tableContent.formula = fieldnode.ChildNodes[1].GetAttributeValue("formula", "");
                                        tableContent.controlName = fieldnode.ChildNodes[1].GetAttributeValue("name", "");
                                        tableContent.controlID = fieldnode.ChildNodes[1].GetAttributeValue("id", "");
                                        tableContent.isRequired = fieldnode.ChildNodes[1].GetAttributeValue("irequired", "");
                                        tableContent.mask = fieldnode.ChildNodes[1].GetAttributeValue("imask", "");
                                        tableContent.cssClass = fieldnode.ChildNodes[1].GetAttributeValue("Class", "");
                                        tableContent.lookupName= fieldnode.ChildNodes[1].GetAttributeValue("LookupName", "");
                                        tableContent.translation= fieldnode.ChildNodes[1].GetAttributeValue("translation", "");
                                        tableContent.points = fieldnode.ChildNodes[1].GetAttributeValue("points", "");
                                        tableContent.defaultValue = fieldnode.ChildNodes[1].GetAttributeValue("defaultValue", "");
                                        tableContent.isReadonly = fieldnode.ChildNodes[1].GetAttributeValue("readonly", "");



                                        tableContent.colspan = Convert.ToInt32(colnode.GetAttributeValue("Colspan", null));

                                        //fieldcalculation.documentcontentID= fieldnode.ChildNodes[1].GetAttributeValue("id", "") + section_id + "formname";
                                        if (fieldnode.ChildNodes[1].GetAttributeValue("Operation", "") != "")
                                        {
                                            XDocumentCalculation fieldcalculation = new XDocumentCalculation();
                                            string resultContentAttribute = fieldnode.ChildNodes[1].GetAttributeValue("resultantid", "").Replace(section_id.ToString() + formname, string.Empty);


                                            fieldcalculation.resultContentAttribute = resultContentAttribute + section_id + formname;
                                            fieldcalculation.operation = fieldnode.ChildNodes[1].GetAttributeValue("Operation", "");

                                            //dto.documentTableContentlist.Add(dto.documentTableContent);
                                            tableContent.calculations.Add(fieldcalculation);
                                        }
                                        tableTD.fields.Add(tableContent);
                                    }
                                }
                                
                            }
                            #endregion
                        }
                        }
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
                            foreach (XDocumentTableContent content in td.fields)
                            {
                                ControlsHelper helper = new ControlsHelper();

                                if (td.tdType == ApplicationCodes.FORMS_TABLE_HEADER_TYPE)
                                {
                                   
                                    tabletr.Cells.Add(ControlsHelper.createHTMLTableHeaderColumn(content));
                                }
                                else
                                {
                                    HtmlTableCell tc = new HtmlTableCell();
                                    tabletr.Cells.Add(tc);

                                    HtmlGenericControl createDiv = new HtmlGenericControl("DIV");
                                    createDiv.Attributes.Add("class", "redips-drag");
                                    createDiv.Style.Add("cursor", "move");
                                    createDiv.Style.Add("width", "158px");


                                    ControlsHelper.createDetailSpan(createDiv, content.controlID);
                                    if (helper.addControl(content, lang) != null)
                                    createDiv.Controls.Add( helper.addControl(content, lang));
                                    ControlsHelper.removeDetailSpan(createDiv, content.controlID);

                                    tc.ColSpan = content.colspan;
                                    tc.Controls.Add(createDiv);
                                }
                               
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

            HtmlGenericControl crosscell = new HtmlGenericControl("span");
            crosscell.Attributes.Add("class", "rowTool");
            crosscell.Attributes.Add("onclick", "redips.cellDelete(this)");
            crosscell.InnerHtml = "xc";
            createDiv.Controls.Add(crosscell);


            HtmlGenericControl cross = new HtmlGenericControl("span");
            cross.Attributes.Add("class", "rowTool");
            cross.Attributes.Add("onclick", "redips.rowDelete(this)");
            cross.InnerHtml = "/xr";
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

            crudTD.Attributes.Add("last", "true");
            crudTD.Controls.Add(createDiv);

            return crudTD;

        }

       
    }
}
