using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using ClassLibrary.Common;

namespace WebUI.WebManage.RouteType 
{
    public partial class RouteTypeList : System.Web.UI.Page
    {
        protected string dataRouteTypeList;

        ClassLibrary.BLL.RouteType routeTypeBLL = new ClassLibrary.BLL.RouteType();

        protected void Page_Load(object sender, EventArgs e)
        {
            ClassLibrary.Common.UserInfo.ChekcPower();

            BindData();
        }

        private void BindData()
        {
            List<ClassLibrary.Model.RouteType> list = routeTypeBLL.GetModelList("");

            StringBuilder sb = new StringBuilder();

            int rowIndex = 0;
            foreach (ClassLibrary.Model.RouteType model in list)
            {
                sb.AppendFormat("<tr id='tr_{0}'>", model.ID);
                sb.AppendFormat("<td>{0}</td>", ++rowIndex);
                sb.AppendFormat("<td>{0}</td>", model.ClassName);
                sb.AppendFormat("<td>{0}</td>", model.CreatedTime);
                sb.Append("<td>");
                sb.AppendFormat("<a href='RouteTypeEdit.aspx?id={0}'>修改</a>　", model.ID);
                sb.AppendFormat("<a href='javascript:void(0)' onclick='RouteTypeDelete({0})'>删除</a>", model.ID);
                sb.Append("</td>");

                sb.Append("</tr>");
            }

            if (sb.Length == 0)
            {
                sb.Append("<tr><td colspan='6'>无</td></tr>");
            }

            dataRouteTypeList = sb.ToString();
        }

    }
}
