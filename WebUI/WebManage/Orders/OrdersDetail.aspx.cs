using System;
using System.Data;
using System.IO;
using System.Text;
using System.Web;
using ClassLibrary.Common;

namespace WebUI.WebManage.Orders
{
    public partial class OrdersDetail : System.Web.UI.Page
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
        protected int status;

        protected string createdTime;
        protected string dataOrderDetailList;
        //protected string pageInfo;
        ClassLibrary.BLL.Orders ordersBLL = new ClassLibrary.BLL.Orders();
        ClassLibrary.BLL.OrderDetail orderDetailBLL = new ClassLibrary.BLL.OrderDetail();
        ClassLibrary.BLL.Routes routeBLL = new ClassLibrary.BLL.Routes();
        ClassLibrary.Common.Pagination pg = new ClassLibrary.Common.Pagination();
        ClassLibrary.BLL.RouteClass routeClassBll = new ClassLibrary.BLL.RouteClass();

        protected void Page_Load(object sender, EventArgs e)
        {

            if (Function.IsPostMethod())
            {
                if (Request.QueryString["ac"] == "edit")
                {
                    UpdateState();
                }
            }
            else
            {
                GetArgument();
                BindOrdersData();
                BindOrderDetailData();
            }
        }

        private void GetArgument()
        {
            string id = Function.GetQueryString("id");

            if (!string.IsNullOrEmpty(id))
            {
                orderNumber =id;
            }
            else
            {
                Function.goMessagePage("显示订单详情", "操作失败，参数错误!", "Orders/OrdersList.aspx");
            }
        }

        private void UpdateState()
        {
            if (ordersBLL.Updates(" Status = '" + Request.Form["Status"] + "' ", " OrderNumber ='" + Request.Form["OrderNumber_Hidden"] + "' ") > 0)
            {
                Response.Write("<script>alert('审核成功！');location.href='OrdersDetail.aspx?id=" + Request.Form["OrderNumber_Hidden"] + "';</script>");
            }
        }

        private void BindOrdersData()
        {

            DataTable myTable = ordersBLL.GetData(" orderNumber ='" + orderNumber + "'");

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
                if (myTable.Rows[0]["Status"].ToString() == SysConfig.OrderType.未付款待处理.ToString())
                    status = 0;
                else if (myTable.Rows[0]["Status"].ToString() == SysConfig.OrderType.已付款处理中.ToString())
                    status = 1;
                else if (myTable.Rows[0]["Status"].ToString() == SysConfig.OrderType.已完成.ToString())
                    status = 2;
                else
                    status = 3;

                createdTime = myTable.Rows[0]["CreatedTime"].ToString();
            }
            else
            {
                Function.goMessagePage("显示订单详情", "操作失败，数据不存在!", "Orders/OrdersList.aspx");
            }
        }

        private void BindOrderDetailData()
        {
            DataTable myTable = orderDetailBLL.GetData(" orderNumber ='" + orderNumber + "'");

            myTable = pg.pagination(myTable, 20, "");

            StringBuilder sb = new StringBuilder();

            foreach (DataRow dr in myTable.Rows)
            {
                sb.AppendFormat("<tr id='tr_{0}'>", dr["ID"].ToString());

                ClassLibrary.Model.Routes route = routeBLL.GetModel(Convert.ToInt32(dr["routeID"]));
                string tmpClassPy = routeClassBll.GetModel(Convert.ToInt32(route.LocationID)).ClassNamePY;

                sb.AppendFormat("<td><a href='/{2}/{1}.html' target='_blank'>{0}</a></td>", dr["RouteName"].ToString(), dr["routeID"].ToString(), tmpClassPy);
                string[] temp = dr["Number"].ToString().Split(',');
                sb.AppendFormat("<td>{0}</td>", temp[0] + "大" + temp[1] + "小");
                //sb.AppendFormat("<td><input id='price_{0}' type='text' size='10' value='{1}' /><input type='button' class='button' value='修改' onclick='UpdateOrderDetailPrice({0},{2})' /></td>", dr["ID"].ToString(), Convert.ToInt32(dr["RoutePrice"]), dr["ordernumber"].ToString());
                sb.AppendFormat("<td>&yen;{0}元</td>", Convert.ToInt32(dr["RoutePrice"]));
                sb.AppendFormat("<td>{0}</td>", dr["RouteTime"].ToString());
                sb.AppendFormat("<td>{0}</td>", dr["StartTime"].ToString());
                sb.AppendFormat("<td>{0}</td>", dr["CreatedTime"].ToString());
                sb.Append("</tr>");
            }

            dataOrderDetailList = sb.ToString();
        }
    }
}
