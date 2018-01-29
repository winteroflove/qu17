using System;
using System.Data;
using System.Text;

namespace WebUI.WebManage.Advertise
{
    public partial class ScrollImageList : System.Web.UI.Page
    {
        int pageSize = 20;
        int pageIndex;

        protected string linksList;
        protected string pageInfo;

        ClassLibrary.BLL.ScrollImages linksBLL = new ClassLibrary.BLL.ScrollImages();
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
            DataTable myTable = linksBLL.GetData("");

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

                sb.AppendFormat("<td align='center'>{0}</td>", rowIndex);
                sb.AppendFormat("<td align='center'><img src='{0}{1}' width='100' height='60' /></td>", ClassLibrary.Common.SysConfig.UploadFilePathScrollImg, dr["Img"].ToString());
                sb.AppendFormat("<td>{0}</td>", dr["Title"].ToString());
                sb.AppendFormat("<td>{0}</td>", dr["LinkURL"].ToString());
                sb.AppendFormat("<td align='center'>{0}</td>", dr["CreatedTime"].ToString());
                sb.Append("<td align='center'>");
                sb.AppendFormat("<a href='ScrollImageEdit.aspx?id={0}'>修改</a>　", dr["ID"].ToString());
                sb.AppendFormat("<a href='javascript:void(0)' onclick='scrollImageDelete({0},\"{1}\")'>删除</a>", dr["ID"].ToString(),dr["Img"].ToString());
                sb.Append("</td>");

                sb.Append("</tr>");
            }

            if (sb.Length == 0)
            {
                sb.Append("<tr><td colspan='5'>没有相关数据</td></tr>");
            }

            linksList = sb.ToString();
        }
    }
}
