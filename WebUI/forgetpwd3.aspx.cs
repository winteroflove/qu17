using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Data;
using ClassLibrary.Common;

namespace WebUI
{
    public partial class forgetpwd3 : System.Web.UI.Page
    {
        protected string userName;
        protected string safetyAnswer;

        ClassLibrary.BLL.Member bll = new ClassLibrary.BLL.Member();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Function.IsPostMethod())
            {
                userName = HttpUtility.HtmlEncode(Function.GetFormString("UserName"));
                safetyAnswer = HttpUtility.HtmlEncode(Function.GetFormString("SafetyAnswer"));

                if (string.IsNullOrEmpty(userName))
                {
                    Response.Redirect("/forgetpwd/");
                }

                if (Request.QueryString["ac"] == "post") //修改密码
                {
                    ChangePassword();
                }
                else //验证第二步传过来的答案
                {
                    CheckSafetyAnswer();
                }
            }
            else
            {
                Response.Redirect("/forgetpwd/");
            }
           
        }

        private void CheckSafetyAnswer()
        {
            List<ClassLibrary.Model.Member> list = bll.GetModelList("UserName='" + userName + "' AND SafetyAnswer='" + safetyAnswer + "'");

            if (list.Count == 0)
            {
                Response.Write("<script>alert('密码保护答案和您注册时输入的答案不一致，请重试。。。');location.href='/forgetpwd/';</script>");
            }
        }

        private void ChangePassword()
        {
            string newPassword = Function.GetFormString("Password");

            if (string.IsNullOrEmpty(newPassword))
            {
                Response.Write("<script>alert('没有检测到新密码，密码找回失败，请重试。。。');location.href='/forgetpwd/';</script>");
            }
            else
            {
                newPassword = Function.MD5(newPassword);

                if (bll.Updates("Password='" + newPassword + "'", "UserName='" + userName + "' AND SafetyAnswer='" + safetyAnswer + "'") > 0)
                {
                    Response.Write("<script>alert('密码修改成功，请登录！');location.href='/login/';</script>");
                }
                else
                {
                    Response.Write("<script>alert('数据保存失败，请重试。。。');location.href='/forgetpwd/';</script>");
                }
            }
        }

    }
}
