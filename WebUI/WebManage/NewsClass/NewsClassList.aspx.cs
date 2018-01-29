using System;
using System.Data;
using System.Text;


namespace WebUI.WebManage.NewsClass 
{
    public partial class NewsClassList : System.Web.UI.Page
    {
        protected string dataNewsClassList;
        protected string pageInfo;

        ClassLibrary.BLL.NewsClass newsClassBLL = new ClassLibrary.BLL.NewsClass();
        ClassLibrary.Common.Pagination pg = new ClassLibrary.Common.Pagination();

        protected void Page_Load(object sender, EventArgs e)
        {

            BindData();
        }

        private void BindData()
        {
            DataTable myTable = newsClassBLL.GetData("");

            myTable = pg.pagination(myTable, 20, "");
            pageInfo = pg.pageNumList;

            StringBuilder sb = new StringBuilder();

            foreach (DataRow dr in myTable.Rows)
            {
                sb.AppendFormat("<tr id='tr_{0}'>", dr["ID"].ToString());
                sb.AppendFormat("<td>{0}</td>", dr["ID"].ToString());
                sb.AppendFormat("<td>{0}</td>", dr["ClassName"].ToString());
                sb.AppendFormat("<td>{0}</td>", dr["CreatedTime"].ToString());
                sb.Append("<td>");
                sb.AppendFormat("<a href='NewsClassEdit.aspx?id={0}'>修改</a>　", dr["ID"].ToString());
                sb.AppendFormat("<a href='javascript:void(0)' onclick='newsClassDelete({0})'>删除</a>", dr["ID"].ToString());
                sb.Append("</td>");

                sb.Append("</tr>");
            }

            dataNewsClassList = sb.ToString();
        }
    }
}
