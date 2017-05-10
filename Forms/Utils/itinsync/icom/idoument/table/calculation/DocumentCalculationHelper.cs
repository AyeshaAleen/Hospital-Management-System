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
using Domains.itinsync.icom.idocument.table.content;

namespace Utils.itinsync.icom.idoument.table.calculation
{
    public  class DocumentCalculationHelper
    {
        public   void fieldCalculation(XDocumentTableContent content, Control parent)
        {
            Control resultontrol = parent.FindControl(content.controlID);

            string resultValue = getControlValue(resultontrol);
            // in case control doesnot exist then ignore calculation
            if (resultontrol == null)
                return;
            string operation = "";
            Double AVG = 0.0;
            foreach (XDocumentCalculation calculation in content.calculations)
            {
                operation = calculation.operation;
                 Control fieldControl = parent.FindControl(calculation.fieldContent.controlID);
                string fieldValue = getControlValue(fieldControl);
                if (fieldControl == null)
                    continue;


                if (calculation.operation == ApplicationCodes.FORMS_CONTROL_AVERAGE)
                    AVG = AVG + Convert.ToDouble(fieldValue);

                else if (calculation.operation == ApplicationCodes.FORMS_CALCULATION_PLUS)
                    setControlValue(resultontrol, Convert.ToDouble(fieldValue) + Convert.ToDouble(resultValue));

                else if (calculation.operation == ApplicationCodes.FORMS_CALCULATION_MINUS)
                    setControlValue(resultontrol, Convert.ToDouble(fieldValue) - Convert.ToDouble(resultValue));

                else if (calculation.operation == ApplicationCodes.FORMS_CALCULATION_MULTIPLY)
                    setControlValue(resultontrol, Convert.ToDouble(fieldValue) * Convert.ToDouble(resultValue));

                else if (calculation.operation == ApplicationCodes.FORMS_CALCULATION_DIVIDE)
                    setControlValue(resultontrol, Convert.ToDouble(fieldValue) / Convert.ToDouble(resultValue));

            }


            if (operation == ApplicationCodes.FORMS_CONTROL_AVERAGE && content.calculations.Count > 0)
            {
                setControlValue(resultontrol, AVG / content.calculations.Count);
            }
        }
           // 
            
          




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
                return ((TextBox)(c)).Attributes["points"];
                
            }

            else if ((c.GetType() == typeof(HtmlInputText)))
            {
                return ((HtmlInputText)(c)).Attributes["points"];

            }
            else if ((c.GetType() == typeof(DropDownList)))
            {

                return ((DropDownList)(c)).Attributes["points"];
            }
            
            else if ((c.GetType() == typeof(HtmlInputRadioButton)))
            {

                return ((HtmlInputRadioButton)(c)).Attributes["points"];
            }
            else if ((c.GetType() == typeof(HtmlSelect)))
            {

                return ((HtmlSelect)(c)).Attributes["points"];
            }
            return "0";
        }      
        
    }
}
