using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebUI.WebApp
{
    public partial class appOrder : System.Web.UI.Page
    {
        protected string orderNumber;
        protected void Page_Load(object sender, EventArgs e)
        {
            orderNumber = Request.QueryString["order"];
        }
    }
}