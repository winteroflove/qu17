using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Data;
using ClassLibrary.Common;

namespace WebUI
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Function.IsPostMethod())
            {
                UserLogin();
            }
        }

        private void UserLogin()
        {
            string userName = HttpUtility.HtmlEncode(Function.GetFormString("UserName"));
            string password = Function.GetFormString("Password");

            string script = string.Empty;

            if (Function.IsNull(userName) || Function.IsNull(password))
            {
                script = "<script>alert('用户名和密码不能为空。');history.back(-1);</script>";
            }
            else if (Session["ValidateCode"] == null)
            {
                script = "<script>alert('验证码输入错误，请重新输入。');login.href='/login/';</script>";
            }
            else if (Request.Form["code"] != Session["ValidateCode"].ToString())
            {
                script = "<script>alert('验证码输入错误，请重新输入。');history.back(-1);</script>";
            }
            else
            {
                ClassLibrary.BLL.Member bll = new ClassLibrary.BLL.Member();
                DataTable myTable = bll.UserLogin(userName, Function.MD5(password));

                if (myTable.Rows.Count == 0)
                {
                    script = "<script>alert('用户名或密码输入有误，请重新输入。');location.href='/login/';</script>";
                }
                else
                {
                    UserInfo u = new UserInfo(CookieName.MemberInfo);

                    Dictionary<string, string> dic = new Dictionary<string, string>();
                    dic.Add(LoginInfo.ID.ToString(), myTable.Rows[0]["ID"].ToString());
                    dic.Add(LoginInfo.UserName.ToString(), myTable.Rows[0]["UserName"].ToString());
                    dic.Add(LoginInfo.Nickname.ToString(), myTable.Rows[0]["Nickname"].ToString());
                    u.CreatedCookie(dic);

                    script = "<script>location.href='/vip/info/';</script>";
                }
            }

            Response.Write(script);
        }

    }
}