using System;
using System.Data;
using System.Text;
using ClassLibrary.Common;

namespace WebUI.WebManage.Orders 
{
    public partial class OrdersList : System.Web.UI.Page
    {
        protected string dataOrdersList;
        protected string pageInfo;

        ClassLibrary.BLL.Orders ordersBLL = new ClassLibrary.BLL.Orders();
        ClassLibrary.Common.Pagination pg = new ClassLibrary.Common.Pagination();

        protected void Page_Load(object sender, EventArgs e)
        {
            ClassLibrary.Common.UserInfo.ChekcPower();

            BindData();
        }

        private void BindData()
        {
            DataTable myTable = ordersBLL.GetData("");

            myTable = pg.pagination(myTable, 20, "");
            pageInfo = pg.pageNumList;

            StringBuilder sb = new StringBuilder();

            foreach (DataRow dr in myTable.Rows)
            {
                sb.AppendFormat("<tr id='tr_{0}'>", dr["OrderNumber"].ToString());

                sb.AppendFormat("<td>{0}</td>", dr["OrderNumber"].ToString());

                sb.AppendFormat("<td>{0}</td>", dr["UserName"].ToString());
                string[] temp = dr["proQuantity"].ToString().Split(',');
                sb.AppendFormat("<td>{0}</td>", temp[0] + "大" + temp[1] + "小");
                sb.AppendFormat("<td>&yen;{0}元</td>", Convert.ToInt32(dr["proTotalPrice"]));
                sb.AppendFormat("<td>{0}</td>", dr["Linkman"].ToString());
                sb.AppendFormat("<td>{0}</td>", dr["ContractType"].ToString());
                sb.AppendFormat("<td>{0}</td>", dr["Payment"].ToString());
                sb.AppendFormat("<td>{0}</td>", dr["Status"].ToString());
                sb.AppendFormat("<td>{0}</td>", dr["CreatedTime"].ToString());
                sb.Append("<td>");

                sb.AppendFormat("<a href='OrdersDetail.aspx?id={0}'>查看</a>　", dr["OrderNumber"].ToString());

                if (dr["Status"].ToString() == "未处理")
                {
                    sb.AppendFormat("<a href='javascript:void(0)' onclick='ordersDelete({0})'>删除</a>", dr["OrderNumber"].ToString());
                }
                sb.Append("</td>");

                sb.Append("</tr>");
            }
            dataOrdersList = sb.ToString();
        }
    }
}
