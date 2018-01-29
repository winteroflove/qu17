using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using ClassLibrary.Common;

namespace WebUI.vip
{
    public partial class info : System.Web.UI.Page
    {
        string userName;
        protected ClassLibrary.Model.Member member = new ClassLibrary.Model.Member();
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
                        UpdateUserInfo();
                    }
                }

                BindInfo();

            }
        }

        private void BindInfo()
        {
            userName = userName.Replace(" ", "").Replace("'", "");
            List<ClassLibrary.Model.Member> list = memberBLL.GetModelList("UserName='" + userName + "'");

            if (list.Count == 0)
            {
                Response.Write("<script>alert('用户不存在，请重新登录');location.href='/login/';</script>");
            }
            else
            {
                member = list[0];
            }
        }

        private void UpdateUserInfo()
        {
            member.ID = Convert.ToInt32(Function.GetFormString("ID"));
            member.UserName = userName;
            member.Nickname = Function.GetFormString("Nickname");
            member.Telphone = Function.GetFormString("Telphone");
            member.QQ = Function.GetFormString("QQ");
            member.SafetyQuestion = Function.GetFormString("SafetyQuestion");
            member.SafetyAnswer = HttpUtility.HtmlEncode(Function.GetFormString("SafetyAnswer"));

            string strSet = "Nickname='" + member.Nickname + "'";
            strSet += ",Telphone='" + member.Telphone + "'";
            strSet += ",QQ='" + member.QQ + "'";
            strSet += ",SafetyQuestion='" + member.SafetyQuestion + "'";
            strSet += ",SafetyAnswer='" + member.SafetyAnswer + "'";

            string strWhere = "ID=" + member.ID + "";
            strWhere += " AND UserName='" + member.UserName + "'";

            if (memberBLL.Updates(strSet, strWhere) > 0)
            {
                Response.Write("<script>alert('资料保存成功');location.href='/vip/info/';</script>");
            }
            else
            {
                Response.Write("<script>alert('数据保存失败，请重试。。。');location.href='/vip/info/';</script>");
            }

        }
    }
}
