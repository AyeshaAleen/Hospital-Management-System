﻿using Forms.itinsync.src.session;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Forms.Webroot.Forms.SIO
{
    public partial class BasicInfo : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnPrevious_Click(object sender, EventArgs e)
        {
            Response.Redirect("Cleanliness.aspx");
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
           String xml =  xmlConversion(this,"BASICINFORMATION");
        }
    }
}