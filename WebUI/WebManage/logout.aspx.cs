using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using ClassLibrary.Common;

namespace WebUI.Manager
{
    public partial class logout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            UserInfo u = new UserInfo(CookieName.AdminInfo);
            u.UserLogout();

            Response.Redirect("Login.aspx");
        }
    }
}
