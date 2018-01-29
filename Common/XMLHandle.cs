using System;
using System.Web;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Xml;

namespace B2C.Common
{
    public class XMLHandle
    {
        public string xmlPath
        {
            get { return HttpContext.Current.Server.MapPath("/WebManage/Columns.xml"); }
        }

        public string GetDataByAttr(string attr)
        {
            return "";
        }

        public string GetDataByText()
        {
            return "";
        }

        public void getdata()
        {
            XmlDataDocument xml = new XmlDataDocument();
            xml.Load(xmlPath);

            XmlNodeList nodeList = xml.GetElementsByTagName("function");

            foreach (XmlNode node in nodeList)
            {
                XmlNodeList nodeListSub = node.ChildNodes;

                File.AppendAllText("/aa.txt", node.Attributes["name"].Value + ":");

                foreach (XmlNode nodeSub in nodeListSub)
                {
                    File.AppendAllText("/aa.txt", nodeSub.InnerText + "--");
                }

                
            }


        }

    }
}
