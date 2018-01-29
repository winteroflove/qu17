using System;
using System.Data;
using System.Text;
using ClassLibrary.Common;

namespace WebUI.WebManage.Links
{
    public partial class InternalLinkList : System.Web.UI.Page
    {
        int pageSize = 20;
        int pageIndex;
        protected string searchKey;
        protected string linksList;
        protected string pageInfo;

        ClassLibrary.BLL.InternalLink linksBLL = new ClassLibrary.BLL.InternalLink();
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
            searchKey = Function.GetQueryString("key");

            string where = "1=1";
            if(searchKey != "")
            {
                where += " and CHARINDEX('" + searchKey + "',Title) > 0";
            }

            DataSet mySet = linksBLL.GetPageData(pageSize, pageIndex, where, "");
            DataTable tableCount = mySet.Tables["Count"];
            DataTable myTable = mySet.Tables["Data"];

            int countRows = 0;
            countRows = Convert.ToInt32(tableCount.Rows[0][0].ToString());
            string[] urlParam = { "key", "cid1", "cid2" };
            pageInfo = pg.pageForDynamic(countRows, 20, pageIndex, urlParam);

            StringBuilder sb = new StringBuilder();

            int i = 0;
            int rowIndex = 0;

            foreach (DataRow dr in myTable.Rows)
            {
                i++;
                rowIndex = pageSize * (pageIndex - 1) + i;

                sb.AppendFormat("<tr id='tr_{0}'>", dr["ID"].ToString());

                sb.AppendFormat("<td align='center'>{0}</td>", rowIndex);
                sb.AppendFormat("<td>{0}</td>", dr["Title"].ToString());
                sb.AppendFormat("<td>{0}</td>", dr["LinkURL"].ToString());
                sb.Append("<td align='center'>");
                sb.AppendFormat("<a href='InternalLinkEdit.aspx?id={0}'>修改</a>　", dr["ID"].ToString());
                sb.AppendFormat("<a href='javascript:void(0)' onclick='InternalLinkDelete({0})'>删除</a>", dr["ID"].ToString());
                sb.Append("</td>");

                sb.Append("</tr>");
            }

            if (sb.Length == 0)
            {
                sb.Append("<tr><td colspan='4'>没有相关数据</td></tr>");
            }

            linksList = sb.ToString();
        }
    }
}
