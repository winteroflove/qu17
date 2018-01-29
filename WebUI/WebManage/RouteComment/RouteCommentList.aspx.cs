using System;
using System.Data;
using System.Text;
using ClassLibrary.Common;
using System.Collections.Generic;

namespace WebUI.WebManage.RouteComment 
{
    public partial class RouteCommentList : System.Web.UI.Page
    {
        protected string dataRouteCommentList;
        protected string pageInfo;

        ClassLibrary.BLL.RouteComment routeCommentBLL = new ClassLibrary.BLL.RouteComment();
        ClassLibrary.Common.Pagination pg = new ClassLibrary.Common.Pagination();
        ClassLibrary.BLL.Routes routeBLL = new ClassLibrary.BLL.Routes();
        ClassLibrary.BLL.RouteClass rcBll = new ClassLibrary.BLL.RouteClass();

        List<ClassLibrary.Model.RouteClass> rcList = new List<ClassLibrary.Model.RouteClass>();

        protected void Page_Load(object sender, EventArgs e)
        {
            ClassLibrary.Common.UserInfo.ChekcPower();
            rcList = rcBll.GetModelList(String.Empty);

            if (Function.IsNumber(Request.QueryString["ID"]))
            {
                int id = Convert.ToInt32(Request.QueryString["ID"]);
                RouteCommentCheck(id);
            }
            else if (!string.IsNullOrEmpty(Request.QueryString["routeId"]))
            {
                BindData(" routeID=" + Convert.ToInt32(Request.QueryString["routeId"]));
            }
            else
            {
                BindData("");
            }
        }

        private void RouteCommentCheck(int id)
        {
            ClassLibrary.BLL.RouteComment routeCommentBLL = new ClassLibrary.BLL.RouteComment();

            if (routeCommentBLL.UpdateCheck(id) > 0)
            {
                Response.Write("<script>alert('审核成功！');location.href='RouteCommentList.aspx';</script>");
            }
        }

        private void BindData(string sql)
        {
            DataTable myTable = routeCommentBLL.GetData(sql);

            myTable = pg.pagination(myTable, 20, "");
            pageInfo = pg.pageNumList;

            StringBuilder sb = new StringBuilder();

            foreach (DataRow dr in myTable.Rows)
            {
                sb.AppendFormat("<tr id='tr_{0}'>", dr["ID"].ToString());
                ClassLibrary.Model.Routes rmodel = routeBLL.GetModel(Convert.ToInt32(dr["routeId"]));
                string tmpClassPy = rcList.Find(delegate(ClassLibrary.Model.RouteClass rcm) { return rcm.ID == rmodel.LocationID; }).ClassNamePY;

                sb.AppendFormat("<td><a href='/{2}/{1}.html' target='_blank'>{0}</a></td>", Function.Clip(GetRoute(Convert.ToInt32(dr["routeID"])), 10, true), Convert.ToInt32(dr["routeID"]), tmpClassPy);
                sb.AppendFormat("<td>{0}</td>", Convert.ToInt16(dr["Grade"].ToString()));
                sb.AppendFormat("<td>{0}</td>", dr["UserName"].ToString());
                sb.AppendFormat("<td>{0}</td>", dr["Nickname"].ToString());
                sb.AppendFormat("<td>{0}</td>", dr["Email"].ToString());
                sb.AppendFormat("<td>{0}</td>", Convert.ToBoolean(dr["Checked"]) ? "<span class='green'>是</span>" : "<span class='red'>否</span>");
                sb.AppendFormat("<td>{0}</td>", dr["CreatedTime"].ToString());
                sb.Append("<td>");
                if (!Convert.ToBoolean(dr["Checked"]))
                {
                    sb.AppendFormat("<a href='RouteCommentList.aspx?ID={0}'>审核</a>　", dr["ID"].ToString());
                }
                else
                {
                    sb.Append("　　　");
                }
                sb.AppendFormat("<a href='RouteCommentDetail.aspx?id={0}'>查看</a>　", dr["ID"].ToString());
                sb.AppendFormat("<a href='javascript:void(0)' onclick='routeCommentDelete({0})'>删除</a>", dr["ID"].ToString());
                sb.Append("</td>");

                sb.Append("</tr>");
            }
            dataRouteCommentList = sb.ToString();
        }

        private string GetRoute(int routeId)
        {
            return routeBLL.GetModel(routeId).Title;
        }
    }
}
