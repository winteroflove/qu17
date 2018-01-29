using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using ClassLibrary.Common;

namespace WebUI.Manager
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!new ClassLibrary.Common.UserInfo(CookieName.AdminInfo).IsLogin())
            {
                Response.Redirect("/WebManage/login.aspx");
            }
        }
    }
}
