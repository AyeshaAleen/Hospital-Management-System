using Domains.itinsync.icom.interfaces.response;
using Forms.itinsync.src.session;
using Services.itinsync.icom.documents;
using Services.itinsync.icom.documents.dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using Utils.itinsync.icom.constant.application;
using Utils.itinsync.icom.date;
using System.Data;
using System.Web.UI.WebControls;

namespace Forms.Webroot.Forms.SIO
{
    public partial class GeneralSIO : BasePage
    {
        private static int section_id = 1;

        public static string xml = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //loaddata();
            }
        }
        protected void Page_LoadComplete(object sender, EventArgs e)
        {
            DocumentDTO dto = new DocumentDTO();
            dto.header = getHeader();
            dto.document.documentDefinitionID = 1001;
            IResponseHandler response = new DocumentGetService().executeAsPrimary(dto);

            if (response.getErrorBlock().ErrorCode == ApplicationCodes.ERROR_NO)
            {
                dto = (DocumentDTO)response;
                Table obj_Table= processDynamicContent(tableDynamic, dto.document, section_id);
                validate.Controls.Add(obj_Table);
            }

        }

        private void save_data()
        {
            Control parent= tableDynamic;
            Control tableControl = parent.FindControl("tableDynamic");
            Table parentTable = ((Table)(tableControl));


            for (int i = 0; i < parentTable.Rows.Count; i++)
            {
                for (int j = 0; j < tableDynamic.Rows[i].Cells.Count; j++)
                {


                    string cellValue = tableDynamic.Rows[i].Cells[j].Text;

                }
                    }

                  
          


        }


        private void loaddata()
        {
            if (!string.IsNullOrEmpty(getXMLSession()))
            {
                processXML(validate, getXMLSession(), "ServiceTime");
            }
        }

        protected void btnNext_Click(object sender, EventArgs e)
        {

            Table tabless=(Table)FindControlRecursive(this, "tableDynamic");

        
            
            //Control tablee = (Control)this.Master.FindControl("cntGeneralSIOHead");



            //Table tablesss = (Table)this.FindControl("tableDynamic");
            //Table table = (Table)this.FindControl("CommonMasterBody_FormMasterBody_GSIORadioYes1");
            
            xml = "<SIO>" + "<GeneralSIO>" + xmlConversion(validate, "") + "</GeneralSIO>";
         
            Response.Redirect("ServiceTime.aspx");
        }


        private Control FindControlRecursive(Control rootControl, string controlID)
        {
            if (rootControl.ID == controlID) return rootControl;

            foreach (Control controlToSearch in rootControl.Controls)
            {
                Control controlToReturn =
                    FindControlRecursive(controlToSearch, controlID);
                if (controlToReturn != null) return controlToReturn;
            }
            return null;
        }
    }
}