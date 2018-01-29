using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Data;
using System.Text;
using ClassLibrary.Common;

namespace WebUI.vip
{
    public partial class orders : System.Web.UI.Page
    {
        string userName;
        protected string orderNumber;
        protected string dataOrdersList;
        ClassLibrary.BLL.Orders ordersBLL = new ClassLibrary.BLL.Orders();

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
                orderNumber = Request.Form["order_no"];

                BindList();
            }
        }

        private void BindList()
        {
            string strWhere = "UserName='" + userName + "'";

            if (!string.IsNullOrEmpty(orderNumber))
            {
                strWhere += " AND OrderNumber LIKE '%" + orderNumber + "%'";
            }

            List<ClassLibrary.Model.Orders> list = ordersBLL.GetModelList(strWhere);

            StringBuilder sb = new StringBuilder();

            int rowIndex = 0;
            foreach (ClassLibrary.Model.Orders model in list)
            {
                sb.Append("<tr>");

                sb.AppendFormat("<td align='center'>{0}</td>", ++rowIndex);
                sb.AppendFormat("<td align='center'>{0}</td>", model.OrderNumber);
                sb.AppendFormat("<td align='center'>{0}</td>", model.proQuantity.Split(',')[0] + "大" + model.proQuantity.Split(',')[1] + "小");
                sb.AppendFormat("<td align='center'>&yen;{0}元</td>", Convert.ToInt32(model.proTotalPrice));
                sb.AppendFormat("<td align='center'>{0}</td>", model.Linkman);
                sb.AppendFormat("<td align='center'>{0}</td>", model.CreatedTime.ToString("yyyy-MM-dd"));
                sb.AppendFormat("<td align='center'>{0}</td>", model.Status);

                sb.AppendFormat("<td align='center'><a href='{1}/vip/orders/o{0}.html'>详情</a></td>", model.OrderNumber, SysConfig.webSite);

                sb.Append("</tr>");
            }

            if (sb.Length == 0)
            {
                sb.Append("<tr><td colspan='8'>暂无订单！</td></tr>");
            }

            dataOrdersList = sb.ToString();
        }
    }
}
