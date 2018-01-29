using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Data;
using ClassLibrary.Common;

namespace WebUI
{
    public partial class forgetpwd2 : System.Web.UI.Page
    {
        protected string userName;
        protected string safetyQuestion;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Function.IsPostMethod())
            {
                userName = HttpUtility.HtmlEncode(Function.GetFormString("UserName"));

                if (string.IsNullOrEmpty(userName))
                {
                    Response.Redirect("/forgetpwd/");
                }
            }
            else
            {
                Response.Redirect("/forgetpwd/");
            }


            GetSafetyQuestion();
        
        }

        private void GetSafetyQuestion()
        {
            ClassLibrary.BLL.Member bll = new ClassLibrary.BLL.Member();

            List<ClassLibrary.Model.Member> list = bll.GetModelList("UserName='" + userName + "'");

            if (list.Count == 0)
            {
                Response.Write("<script>alert('用户名不存在，请重新输入。。。');location.href='/forgetpwd/';</script>");
            }
            else
            {
                safetyQuestion = list[0].SafetyQuestion;
            }

        }

        
    }
}
