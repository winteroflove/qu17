using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Web;
using ClassLibrary.Common;

namespace WebUI.Manager
{
    public partial class main : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!new ClassLibrary.Common.UserInfo(CookieName.AdminInfo).IsLogin())
            {
                Response.Redirect("/WebManage/login.aspx");
            }

        }

        protected string checkNewOrder()
        {
            string orders = "";
            ClassLibrary.BLL.Orders ordersBLL = new ClassLibrary.BLL.Orders();
            int countNewOrder = ordersBLL.Count("status = '未付款待处理'");
            if (countNewOrder != 0)
            {
                orders = "您有 <a href='./Orders/OrdersList.aspx'>" + countNewOrder + "</a> 个订单未处理！";
            }
            return orders;
        }

        protected string checkNewComment()
        {
            string comments = "";
            ClassLibrary.BLL.RouteComment commentsBLL = new ClassLibrary.BLL.RouteComment();
            int countNewComment = commentsBLL.Count("Checked = 0");
            if (countNewComment != 0)
            {
                comments = "您有 <a href='./RouteComment/RouteCommentList.aspx'>" + countNewComment + "</a> 条留言未处理！";
            }
            return comments;
        }

    }
}

