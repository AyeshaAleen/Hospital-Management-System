using Domains.itinsync.icom.idocument.table.calculation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Utils.itinsync.icom.constant.application;

namespace Utils.itinsync.icom.idoument.table.calculation
{
    public  class DocumentCalculationHelper
    {
        public   void fieldCalculation(XDocumentCalculation calculation, Control parent)
        {
            Control fieldControl = parent.FindControl(calculation.fieldContent.controlID);
            Control resultontrol = parent.FindControl(calculation.resultContent.controlID);

            string fieldValue = getControlValue(fieldControl);
            string resultValue = getControlValue(resultontrol);
            // in case control doesnot exist then ignore calculation
            if (fieldControl == null || resultontrol == null || fieldValue.Length==0 || resultValue.Length ==0)
                return;



            if (calculation.operation == ApplicationCodes.FORMS_CALCULATION_PLUS)
                setControlValue(resultontrol, Convert.ToDouble(fieldValue)+ Convert.ToDouble(resultValue));


        }
        private void setControlValue(Control c, Double value)
        {
            setControlValue(c, value.ToString());
        }
        private void setControlValue(Control c,string value)
        {
            if ((c.GetType() == typeof(TextBox)))
            {
                 ((TextBox)(c)).Text = value;

            }

            else if ((c.GetType() == typeof(HtmlInputText)))
            {
                ((HtmlInputText)(c)).Value= value;

            }
            else if ((c.GetType() == typeof(DropDownList)))
            {

                 ((DropDownList)(c)).SelectedValue= value;
            }

            else if ((c.GetType() == typeof(HtmlInputRadioButton)))
            {

                ((HtmlInputRadioButton)(c)).Value= value;
            }
            else if ((c.GetType() == typeof(HtmlSelect)))
            {

                 ((HtmlSelect)(c)).Value = value;
            }
            
        }
        private string getControlValue(Control c)
        {
            if ((c.GetType() == typeof(TextBox)))
            {
                return ((TextBox)(c)).Text;
                
            }

            else if ((c.GetType() == typeof(HtmlInputText)))
            {
                return ((HtmlInputText)(c)).Value;

            }
            else if ((c.GetType() == typeof(DropDownList)))
            {

                return ((DropDownList)(c)).SelectedValue;
            }
            
            else if ((c.GetType() == typeof(HtmlInputRadioButton)))
            {

                return ((HtmlInputRadioButton)(c)).Value;
            }
            else if ((c.GetType() == typeof(HtmlSelect)))
            {

                return ((HtmlSelect)(c)).Value;
            }
            return "0";
        }      
        
    }
}
