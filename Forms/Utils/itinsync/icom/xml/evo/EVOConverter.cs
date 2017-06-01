using EvoPdf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utils.itinsync.icom.xml.evo
{
   public  class EVOConverter
    {
        public byte[] getPDF(string htmlString,string baseUrl)
        {
            // Create a HTML to PDF converter object with default settings
            HtmlToPdfConverter htmlToPdfConverter = new HtmlToPdfConverter();

            // Set license key received after purchase to use the converter in licensed mode
            // Leave it not set to use the converter in demo mode
            htmlToPdfConverter.LicenseKey = "4W9+bn19bn5ue2B+bn1/YH98YHd3d3c=";

            // Set HTML Viewer width in pixels which is the equivalent in converter of the browser window width
            htmlToPdfConverter.HtmlViewerWidth = 1024;
            htmlToPdfConverter.HtmlViewerHeight = 1024;

            // Set PDF page size which can be a predefined size like A4 or a custom size in points 
            // Leave it not set to have a default A4 PDF page
            htmlToPdfConverter.PdfDocumentOptions.PdfPageSize = PdfPageSize.A4;

            // Set PDF page orientation to Portrait or Landscape
            // Leave it not set to have a default Portrait orientation for PDF page
            htmlToPdfConverter.PdfDocumentOptions.PdfPageOrientation = PdfPageOrientation.Portrait;


            // Set the maximum time in seconds to wait for HTML page to be loaded 
            // Leave it not set for a default 60 seconds maximum wait time
            htmlToPdfConverter.NavigationTimeout = 60;

            htmlToPdfConverter.ConversionDelay = 2;

            
            return htmlToPdfConverter.ConvertHtml(htmlString, baseUrl);

        }
    }
}
