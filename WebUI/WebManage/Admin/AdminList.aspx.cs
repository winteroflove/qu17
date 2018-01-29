using System;
using System.Data;
using System.Text;

namespace WebUI.WebManage.Admin
{
    public partial class AdminList : System.Web.UI.Page
    {
        protected string adminList;
        ClassLibrary.BLL.Admin adminBLL = new ClassLibrary.BLL.Admin();

        protected void Page_Load(object sender, EventArgs e)
        {
            ClassLibrary.Common.UserInfo.ChekcPower();

            BindData();
        }

        private void BindData()
        {
            DataTable myTable = adminBLL.GetData(string.Empty);

            StringBuilder sb = new StringBuilder();

            int rowIndex = 0;
            foreach (DataRow dr in myTable.Rows)
            {
                sb.AppendFormat("<tr id='tr_{0}'>", dr["ID"].ToString());

                sb.AppendFormat("<td align='center'>{0}</td>", ++rowIndex);
                sb.AppendFormat("<td align='center'>{0}</td>", dr["UserName"].ToString());
                sb.AppendFormat("<td align='center'>{0}</td>", dr["CreatedTime"].ToString());

                sb.Append("<td align='center'>");
                sb.AppendFormat("<a href='AdminEdit.aspx?id={0}'>修改</a>　", dr["ID"].ToString());
                if (dr["UserName"].ToString().ToLower() != "admin")
                {
                    sb.AppendFormat("<a href='SetPower.aspx?id={0}'>设权限置</a>　", dr["ID"].ToString());
                    sb.AppendFormat("<a href='javascript:void(0)' onclick='adminDelete({0})'>删除</a>", dr["ID"].ToString());
                }
                sb.Append("</td>");

                sb.Append("</tr>");
            }

            adminList = sb.ToString();
        }
    }
}
