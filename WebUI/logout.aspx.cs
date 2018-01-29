using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebUI
{
    public partial class logout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ClassLibrary.Common.UserInfo u = new ClassLibrary.Common.UserInfo(ClassLibrary.Common.CookieName.MemberInfo);

            u.UserLogout();

            Response.Redirect("/");
        }
    }
}
