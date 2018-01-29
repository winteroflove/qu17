using System;
using System.Collections;
using System.Configuration;
using System.Data;

using System.Web;
using ClassLibrary.Common;

namespace WebUI.Manager
{
    public partial class banner : System.Web.UI.Page
    {
        protected string name;
        protected string time;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!new ClassLibrary.Common.UserInfo(CookieName.AdminInfo).IsLogin())
            {
                Response.Redirect("/WebManage/login.aspx");
            }

            try
            {
                UserInfo u = new UserInfo(CookieName.AdminInfo);
                name = u.GetInfo(LoginInfo.UserName);

                time = DateTime.Now.ToString("yyyy年MM月dd日") + "　" + Function.GetWeek(DateTime.Now);
            }
            catch
            {
            }
        }
    }
}
