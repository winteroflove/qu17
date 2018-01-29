using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Web;
using System.Text;
using ClassLibrary.Common;

namespace WebUI.Manager
{
    public partial class menu : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected string BindRouteClass()
        {
            ClassLibrary.BLL.RouteClass bll = new ClassLibrary.BLL.RouteClass();

            List<ClassLibrary.Model.RouteClass> list = bll.GetModelList("ParentID=0");

            StringBuilder sb = new StringBuilder();

            foreach (ClassLibrary.Model.RouteClass model in list)
            {
                sb.AppendFormat("<li><a href='RouteClass/RouteClassList.aspx?cid={0}' target='main-frame'>{1}</a></li>", model.ID, model.ClassName);
            }

            return sb.ToString();

        }

    }
}
