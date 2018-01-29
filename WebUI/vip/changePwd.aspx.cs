using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using ClassLibrary.Common;

namespace WebUI.vip
{
    public partial class changePwd : System.Web.UI.Page
    {
        protected string userName;
        ClassLibrary.BLL.Member memberBLL = new ClassLibrary.BLL.Member();

        protected void Page_Load(object sender, EventArgs e)
        {
            UserInfo u = new UserInfo(CookieName.MemberInfo);
            if (!u.IsLogin())
            {
                Response.Write("<script>alert('您还没登录，请先登录。。。');location.href='/login/';</script>");
            }
            else
            {
                userName = u.GetInfo(LoginInfo.UserName);

                if (Function.IsPostMethod())
                {
                    if (Request.QueryString["ac"] == "post")
                    {
                        UpdatePassword();
                    }
                }

            }
        }

        private void UpdatePassword()
        {
            string oldPassword = Function.GetFormString("oldPwd");
            string newPassword = Function.GetFormString("newPwd");

            oldPassword = Function.MD5(oldPassword);
            newPassword = Function.MD5(newPassword);

            string strSet = "Password='" + newPassword + "'";

            string strWhere = "UserName='" + userName + "'";
            strWhere += " AND Password='" + oldPassword + "'";


            userName = userName.Replace(" ", "").Replace("'", "");

            if (memberBLL.Updates(strSet, strWhere) > 0)
            {
                Response.Write("<script>alert('密码修改成功');location.href='/vip/changePwd/';</script>");
            }
            else
            {
                Response.Write("<script>alert('旧密码错误，请重试。。。');location.href='/vip/changePwd/';</script>");
            }

        }
    }
}
