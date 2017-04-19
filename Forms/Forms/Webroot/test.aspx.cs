using Forms.itinsync.src.session;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Forms.Webroot
{
    public partial class test : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnd_Click(object sender, EventArgs e)
        {
           

           string xml = xmlConversion(this,"ServiceTime");
        }
    }
}