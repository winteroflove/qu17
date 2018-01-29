using System;
using System.Data;
using System.Text;

namespace WebUI.WebManage.SystemSet
{
    public partial class MemberList : System.Web.UI.Page
    {
        int pageSize = 20;
        int pageIndex;

        protected string memberList;
        protected string pageInfo;

        ClassLibrary.BLL.Member memberBLL = new ClassLibrary.BLL.Member();
        ClassLibrary.Common.Pagination pg = new ClassLibrary.Common.Pagination();

        protected void Page_Load(object sender, EventArgs e)
        {
            ClassLibrary.Common.UserInfo.ChekcPower();

            getArgument();
            BindData();
        }

        private void getArgument()
        {
            string strPageIndex = Request.QueryString["page"];
            if (ClassLibrary.Common.Function.IsNumber(strPageIndex))
            {
                pageIndex = Convert.ToInt32(strPageIndex);
            }
            else
            {
                pageIndex = 1;
            }
        }

        private void BindData()
        {
            DataTable myTable = memberBLL.GetData("");

            myTable = pg.pagination(myTable, pageSize, "");
            pageInfo = pg.pageNumList;

            StringBuilder sb = new StringBuilder();

            int i = 0;
            int rowIndex = 0;

            foreach (DataRow dr in myTable.Rows)
            {
                i++;
                rowIndex = pageSize * (pageIndex - 1) + i;

                sb.AppendFormat("<tr id='tr_{0}'>", dr["ID"].ToString());

                sb.AppendFormat("<td>{0}</td>", rowIndex);
                sb.AppendFormat("<td>{0}</td>", dr["UserName"].ToString());
                sb.AppendFormat("<td>{0}</td>", dr["Nickname"].ToString());
                sb.AppendFormat("<td>{0}</td>", dr["Telphone"].ToString());
                sb.AppendFormat("<td>{0}</td>", Convert.ToDateTime(dr["CreatedTime"]).ToString("yyyy-MM-dd"));
                sb.Append("<td>");
                sb.AppendFormat("<a href='javascript:void(0)' onclick='resetPassword({0})'>重置密码</a>　", dr["ID"].ToString());
                sb.AppendFormat("<a href='javascript:void(0)' onclick='memberDelete({0})'>删除</a>", dr["ID"].ToString());
                sb.Append("</td>");

                sb.Append("</tr>");
            }
            memberList = sb.ToString();
        }
    }
}

