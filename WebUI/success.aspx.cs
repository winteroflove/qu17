using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebUI
{
    public partial class success : System.Web.UI.Page
    {
        protected string orderNumber;
        protected string payMessage;

        protected void Page_Load(object sender, EventArgs e)
        {
            orderNumber = Request.QueryString["order"];
            if (!string.IsNullOrEmpty(Request.QueryString["status"]))
            {
                if (Request.QueryString["status"] == "true")
                {
                    payMessage = "支付宝付款已成功。";
                }
                else
                {
                    payMessage = "支付宝付款失败。";
                }
            }
        }
    }
}