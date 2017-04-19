using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Forms.Webroot.Forms.SIO
{
    public partial class Cleanliness : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        
        protected void btnNext_Click(object sender, EventArgs e)
        {
            Response.Redirect("BasicInfo.aspx");
        }
        protected void btnPrevious_Click(object sender, EventArgs e)
        {
            Response.Redirect("Quality.aspx");
        }
    }
}