using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Data;
using System.Text;
using ClassLibrary.Common;

namespace WebUI.vip
{
    public partial class message : System.Web.UI.Page
    {
        string userName;
        protected string pageInfo;
        protected string dataList;
        Pagination pg = new Pagination();
        ClassLibrary.BLL.Routes routeBLL = new ClassLibrary.BLL.Routes();
        ClassLibrary.BLL.RouteComment comBLL = new ClassLibrary.BLL.RouteComment();

        protected void Page_Load(object sender, EventArgs e)
        {
            UserInfo u = new UserInfo(CookieName.MemberInfo);
            if (!u.IsLogin())
            {
                Response.Write("<script>alert('您还没登录，请先登录。。。');location.href='/login/';</script>");
            }
            else
            {
                userName = u.GetInfo(LoginInfo.UserName);

                BindList();
            }
        }

        private void BindList()
        {
            DataTable myTable = comBLL.GetData("UserName='" + userName + "'");

            myTable = pg.pagination(myTable, 10, "");
            pageInfo = pg.pageNumList;

            StringBuilder sb = new StringBuilder();
            List<ClassLibrary.Model.RouteClass> rcList = new List<ClassLibrary.Model.RouteClass>();

            if (myTable.Rows.Count != 0)
            {
                ClassLibrary.BLL.RouteClass rcBLL = new ClassLibrary.BLL.RouteClass();
                rcList = rcBLL.GetModelList(string.Empty);
            }
            int rowIndex = 0;
            foreach (DataRow dr in myTable.Rows)
            {
                sb.Append("<tr'>");
                ClassLibrary.Model.Routes route = routeBLL.GetModel(Convert.ToInt32(dr["routeID"]));

                string tmpClassPy = rcList.Find(delegate(ClassLibrary.Model.RouteClass rc) { return rc.ID == route.LocationID; }).ClassNamePY;

                sb.AppendFormat("<td align='center'>{0}</td>", ++rowIndex);
                sb.AppendFormat("<td align='center'><a href='{3}/{2}/{0}.html' target='_blank'>{1}</a></td>", dr["routeID"].ToString(), route.Title, tmpClassPy, SysConfig.webSite);
                sb.AppendFormat("<td align='center'>{0}</td>", GetGradeImg(dr["Grade"].ToString()));
                sb.AppendFormat("<td align='center'>{0}</td>", dr["Content"].ToString());
                sb.AppendFormat("<td align='center'>{0}</td>", Convert.ToBoolean(dr["Checked"]) ? "<span class='red'>已审核</span>" : "审核中");
                sb.AppendFormat("<td align='center'>{0}</td>", Convert.ToDateTime(dr["CreatedTime"]).ToString("yyyy-MM-dd"));

                sb.Append("</tr>");
            }

            if (sb.Length == 0)
            {
                sb.Append("<tr><td colspan='6'>暂无评价！</td></tr>");
            }

            dataList = sb.ToString();
        }

        private string GetRoute(int routeId)
        {
            return routeBLL.GetModel(routeId).Title;
        }

        private string GetGradeImg(string strGrade)
        {
            StringBuilder sb = new StringBuilder();

            if (Function.IsNumber(strGrade))
            {
                int grade = Convert.ToInt32(strGrade);

                for (int i = 0; i < grade; i++)
                {
                    sb.AppendFormat("<img src='/image/star1.gif' alt='{0}星' />", grade);
                }
                for (int i = 0; i < (5 - grade); i++)
                {
                    sb.AppendFormat("<img src='/image/star2.gif' alt='{0}星' />", grade);
                }
            }
            else
            {
                sb.Append("无");
            }

            return sb.ToString();
        }

    }
}
