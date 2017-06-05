
using Forms.itinsync.src.session;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utils.itinsync.icom.xml.evo;

namespace Forms
{
    public partial class _Default : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string url = HttpContext.Current.Request.Url.AbsoluteUri;
            string htmlString = new UTF8Encoding().GetString(new WebClient().DownloadData(url));
            
            byte[] pdfbyte =  new EVOConverter().getPDF(htmlString, url);

            // Set response content type
            Response.AddHeader("Content-Type", "application/pdf");

            // Instruct the browser to open the PDF file as an attachment or inline
            Response.AddHeader("Content-Disposition", String.Format("{0}; filename=Getting_Started.pdf; size={1}",
            "attachment", pdfbyte.Length.ToString()));

            // Write the PDF document buffer to HTTP response
            Response.BinaryWrite(pdfbyte);

            // End the HTTP response and stop the current page processing
            Response.End();



        }
    }
}