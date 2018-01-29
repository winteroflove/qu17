using System;
using System.Data;
using System.Text;
using ClassLibrary.Common;
using System.Web;

namespace WebUI.vip
{
    public partial class index : System.Web.UI.Page
    {
        protected string orderNumber;
        protected string dataOrdersList;

        ClassLibrary.BLL.Orders ordersBLL = new ClassLibrary.BLL.Orders();

        protected void Page_Load(object sender, EventArgs e)
        {
            orderNumber = Request.Form["order_no"];
            if (orderNumber == null || orderNumber == "")
            {
                orderNumber = HttpUtility.HtmlEncode(Function.GetQueryString("order_no"));
            }
            BindData();
        }

        private void BindData()
        {
            DataTable myTable = ordersBLL.GetData("OrderNumber='" + orderNumber + "'");

            StringBuilder sb = new StringBuilder();

            foreach (DataRow dr in myTable.Rows)
            {
                sb.AppendFormat("<tr id='tr_{0}'>", dr["OrderNumber"].ToString());

                sb.AppendFormat("<td>{0}</td>", dr["OrderNumber"].ToString());

                sb.AppendFormat("<td>{0}</td>", dr["UserName"].ToString());
                string[] temp = dr["proQuantity"].ToString().Split(',');
                sb.AppendFormat("<td>{0}</td>", temp[0] + "大" + temp[1] + "小");
                sb.AppendFormat("<td>&yen;{0}元</td>",Convert.ToInt32(dr["proTotalPrice"]));
                sb.AppendFormat("<td>{0}</td>", dr["Linkman"].ToString());
                sb.AppendFormat("<td>{0}</td>", dr["ContractType"].ToString());
                sb.AppendFormat("<td>{0}</td>", dr["Payment"].ToString());
                sb.AppendFormat("<td>{0}</td>", dr["CreatedTime"].ToString());
                sb.AppendFormat("<td>{0}</td>", dr["Status"].ToString());
                sb.Append("<td>");
                sb.AppendFormat("<a href='{1}/vip/orders/o{0}.html'>查看</a>　", dr["OrderNumber"].ToString(), SysConfig.webSite);
                sb.Append("</td>");

                sb.Append("</tr>");
            }

            if (sb.Length == 0)
            {
                sb.Append("<tr><td colspan='10'>无</td></tr>");
            }

            dataOrdersList = sb.ToString();
        }

    }
}
