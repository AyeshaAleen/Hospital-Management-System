using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace Utils.itinsync.icom.xml
{
   public class XMLParser
    {
        private XmlDocument xmlDoc = new XmlDocument();
        public XMLParser(string xml)
        {
            xmlDoc.LoadXml(xml);
        }
        public void Load(string xml)
        {
            xmlDoc.LoadXml(xml);

            
        }



        //SIO
        public XmlNodeList getXmlNodeList(string node)
        {
           return xmlDoc.GetElementsByTagName(node);
        }

        //"/SIO/ServiceTime"
        public XmlNode getNodes(string node)
        {
            return xmlDoc.SelectSingleNode(node);
        }

        public string getTagValue(string tagName)
        {
            XmlNodeList nodeList=  xmlDoc.DocumentElement.SelectNodes(tagName);

         
                    foreach (XmlNode node in nodeList)
                    {
                        return node.InnerText;
                        
                       
                    }
                
            

            return "";
        }
        public string getXPath(string xPath)
        {
            string[] elements = { "",""};

            if (xPath.Contains("/"))
                elements = xPath.Split('/');
            else if( xPath.Contains("."))
                elements = xPath.Split('.');

            string xmlPath = "";
            for (int i = 0; i < elements.Length-1; i++)
            {
                xmlPath = xmlPath + "/" + elements[i];
            }

            XmlNodeList nodeList = xmlDoc.DocumentElement.SelectNodes(xmlPath);

            foreach (XmlNode node in nodeList)
            {
               if(node.Name == elements[elements.Length-1])
                    return node.SelectSingleNode(elements[elements.Length - 1]).InnerText;
            }


            return "";
        }

        public string getTagXML(string xPath,string tag)
        {
            

            XmlNodeList nodeList = xmlDoc.DocumentElement.SelectNodes(xPath);

            foreach (XmlNode node in nodeList)
            {
               
                    return "<"+ tag + ">" + node.InnerXml +"</"+ tag + ">";
            }

            return "";
        }

       

    }
}
