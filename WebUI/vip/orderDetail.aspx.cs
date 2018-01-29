using System;
using System.Data;
using System.IO;
using System.Text;
using System.Web;
using ClassLibrary.Common;

namespace WebUI.vip
{
    public partial class orderDetail : System.Web.UI.Page
    {
        protected string orderNumber;
        protected string userName;
        protected string proQuantity;
        protected int proTotalPrice;
        protected string linkman;
        protected string fax;
        protected string mobile;
        protected string telphone;
        protected string email;
        protected string identityCard;
        protected string contractType;
        protected string payment;
        protected string remark;
        protected string status;

        protected string createdTime;
        protected string dataOrderDetailList;

        ClassLibrary.BLL.Orders ordersBLL = new ClassLibrary.BLL.Orders();
        ClassLibrary.BLL.OrderDetail orderDetailBLL = new ClassLibrary.BLL.OrderDetail();
        ClassLibrary.BLL.Routes routeBLL = new ClassLibrary.BLL.Routes();
        ClassLibrary.BLL.RouteClass routeClassBll = new ClassLibrary.BLL.RouteClass();

        protected void Page_Load(object sender, EventArgs e)
        {
            GetArgument();
            BindOrdersData();
            BindOrderDetailData();
        }

        private void GetArgument()
        {
            orderNumber = Function.GetQueryString("id");

            if(string.IsNullOrEmpty(orderNumber))
            {
                if (new UserInfo().IsLogin())
                {
                    Response.Redirect("/vip/orders/");
                }
                else
                {
                    Response.Redirect("/vip/");
                }
            }
        }

        private void BindOrdersData()
        {
            DataTable myTable = ordersBLL.GetData("orderNumber ='" + orderNumber + "'");

            if (myTable.Rows.Count == 1)
            {
                userName = myTable.Rows[0]["UserName"].ToString();
                string[] temp = myTable.Rows[0]["proQuantity"].ToString().Split(',');
                proQuantity = temp[0] + "大" + temp[1] + "小";
                proTotalPrice = Convert.ToInt32(myTable.Rows[0]["proTotalPrice"]);
                linkman = myTable.Rows[0]["Linkman"].ToString();
                fax = myTable.Rows[0]["Fax"].ToString();
                mobile = myTable.Rows[0]["Mobile"].ToString();
                telphone = myTable.Rows[0]["Telphone"].ToString();
                email = myTable.Rows[0]["Email"].ToString();
                identityCard = myTable.Rows[0]["IdentityCard"].ToString();
                contractType = myTable.Rows[0]["ContractType"].ToString();
                payment = myTable.Rows[0]["Payment"].ToString();
                remark = myTable.Rows[0]["Remark"].ToString();
                status = myTable.Rows[0]["Status"].ToString();

                createdTime = myTable.Rows[0]["CreatedTime"].ToString();
            }
            else
            {
                if (new UserInfo().IsLogin())
                {
                    Response.Redirect("/vip/orders/");
                }
                else
                {
                    Response.Redirect("/vip/");
                }
            }
        }

        private void BindOrderDetailData()
        {
            DataTable myTable = orderDetailBLL.GetData("orderNumber ='" + orderNumber + "'");

            StringBuilder sb = new StringBuilder();
            foreach (DataRow dr in myTable.Rows)
            {
                sb.Append("<tr>");

                ClassLibrary.Model.Routes route = routeBLL.GetModel(Convert.ToInt32(dr["routeID"]));
                string tmpClassPy = routeClassBll.GetModel(Convert.ToInt32(route.LocationID)).ClassNamePY;

                sb.AppendFormat("<td><a href='{3}/{2}/{0}.html' target='_blank'>{1}</a></td>", dr["routeID"].ToString(), dr["RouteName"].ToString(), tmpClassPy, SysConfig.webSite);
                string[] temp = dr["Number"].ToString().Split(',');
                sb.AppendFormat("<td>{0}</td>", temp[0] + "大" + temp[1] + "小");
                sb.AppendFormat("<td>{0}</td>", (Convert.ToInt32(dr["RoutePrice"]) == 0 ? "价格电讯" : "&yen;" + Convert.ToInt32(dr["RoutePrice"]) + "元"));
                sb.AppendFormat("<td>{0}</td>", dr["RouteTime"].ToString());
                sb.AppendFormat("<td>{0}</td>", dr["StartTime"].ToString());
                sb.AppendFormat("<td>{0}</td>", dr["CreatedTime"].ToString());
                sb.Append("</tr>");
            }

            dataOrderDetailList = sb.ToString();
        }

    }
}
