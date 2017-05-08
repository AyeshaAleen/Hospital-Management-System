using Domains.itinsync.icom.idocument.table.content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using Utils.itinsync.icom.cache.translation;

namespace Utils.itinsync.icom.idoument.table
{
    public class DocumentTableHelper
    {

        public Label createLable(XDocumentTableContent content )
        {

             
            Label lbl = new Label();
            lbl.ID = content.controlID;
            //lbl.CssClass = content.cssClass;
            lbl.Text = TranslationManager.trans(content.translation);
            return lbl;
        }
    }
}
