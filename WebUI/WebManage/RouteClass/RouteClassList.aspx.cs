using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using ClassLibrary.Common;

namespace WebUI.WebManage.RouteClass 
{
    public partial class RouteClassList : System.Web.UI.Page
    {
        protected int maxClassID;
        protected string dataRouteClassList;

        ClassLibrary.BLL.RouteClass routeClassBLL = new ClassLibrary.BLL.RouteClass();

        protected void Page_Load(object sender, EventArgs e)
        {
            ClassLibrary.Common.UserInfo.ChekcPower();

            GetArgument();

            BindData();
        }

        private void GetArgument()
        {
            string strid = Request.QueryString["cid"];

            if (Function.IsNumber(strid))
            {
                maxClassID = Convert.ToInt32(strid);
            }
        }

        private void BindData()
        {
            List<ClassLibrary.Model.RouteClass> list = routeClassBLL.GetSubList(maxClassID, "");

            StringBuilder sb = new StringBuilder();

            int rowIndex = 0;
            foreach (ClassLibrary.Model.RouteClass model in list)
            {
                sb.AppendFormat("<tr id='tr_{0}'>", model.ID);
                sb.AppendFormat("<td>{0}</td>", ++rowIndex);
                sb.AppendFormat("<td>{0}</td>", model.ClassName);
                sb.AppendFormat("<td>{0}</td>", GetRouteClass(model.ParentID.ToString()));
                sb.AppendFormat("<td>{0}</td>", model.Recommend ? "<span class='red'>是</span>" : "否");
                sb.AppendFormat("<td>{0}</td>", model.CreatedTime);
                sb.Append("<td>");
                sb.AppendFormat("<a href='RouteClassEdit.aspx?id={0}&cid={1}'>修改</a>　", model.ID, maxClassID);
                if (model.ParentID != 0)
                {
                    sb.AppendFormat("<a href='javascript:void(0)' onclick='routeClassDelete({0})'>删除</a>", model.ID);
                }
                sb.Append("</td>");

                sb.Append("</tr>");
            }

            if (sb.Length == 0)
            {
                sb.Append("<tr><td colspan='6'>无</td></tr>");
            }

            dataRouteClassList = sb.ToString();
        }

        private string GetRouteClass(string routeClassId)
        {
            if (!string.IsNullOrEmpty(routeClassId) && routeClassId != "0")
            {
                return routeClassBLL.GetModel(Convert.ToInt32(routeClassId)).ClassName;
            }
            else
            { return "无类型"; }
        }
    }
}
