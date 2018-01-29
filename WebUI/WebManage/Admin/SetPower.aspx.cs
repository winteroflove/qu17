using System;
using System.Collections.Generic;
using System.Web;
using System.Text;
using System.Data;
using System.IO;
using System.Xml;
using ClassLibrary.Common;

namespace WebUI.WebManage.SystemConfig
{
    public partial class SetPower : System.Web.UI.Page
    {
        protected int adminID;
        protected string adminName;
        protected string adminPower;

        protected string dataColumnList;
        ClassLibrary.BLL.Admin bll = new ClassLibrary.BLL.Admin();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Function.IsPostMethod())
            {
                if (Request.QueryString["ac"] == "set")
                {
                    setUserPower();
                }
            }

            getArgument();
            InitColumn();
            binderInfo();
        }

        private void getArgument()
        {
            string strid = Request.QueryString["id"];

            if (Function.IsNumber(strid))
            {
                adminID = Convert.ToInt32(strid);
            }
            else
            {
                Function.goMessagePage("设置权限", "用户不存在，请重试", "Admin/AdminList.aspx");
            }
        }

        private void InitColumn()
        {
            string xmlPath = HttpContext.Current.Server.MapPath("/WebManage/Columns.xml");

            XmlDataDocument xml = new XmlDataDocument();
            xml.Load(xmlPath);

            XmlNodeList nodeList = xml.GetElementsByTagName("function");

            StringBuilder sb = new StringBuilder();
            foreach (XmlNode node in nodeList)
            {
                XmlNodeList nodeListSub = node.ChildNodes;

                sb.AppendFormat(@"
                                <dl>
                                    <dt>
                                        <label><input type='checkbox' name='mainColumn' value='' />{0}</label>
                                    </dt>",
                                                node.Attributes["name"].Value);

                foreach (XmlNode nodeSub in nodeListSub)
                {
                    sb.AppendFormat(@"<dd>
                                        <label><input type='checkbox' value='{0}' />{1}</label>
                                    </dd>",
                                                nodeSub.Attributes["path"].Value,
                                                nodeSub.InnerText);

                }

                sb.AppendLine("</dl>");
            }

            dataColumnList = sb.ToString();

        }

        private void binderInfo()
        {
            ClassLibrary.Model.Admin model = bll.GetModel(adminID);
            adminName = model.UserName;
            adminPower = model.Power;
        }

        private void setUserPower()
        {
            adminID = Convert.ToInt32(Request.Form["ID"]);
            string power = Request.Form["power"];

            if (bll.Updates("Power='" + power + "'", "ID=" + adminID) > 0)
            {
                Function.goMessagePage("设置权限", "操作成功", "Admin/AdminList.aspx");
            }
            else
            {
                Function.goMessagePage("设置权限", "操作失败，请重试", "Admin/AdminList.aspx");
            }
        }

    }
}
