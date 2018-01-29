using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using ClassLibrary.Common;

namespace WebUI
{
    public partial class register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Function.IsPostMethod())
            {
                AddUser();
            }
        }

        //注册
        private void AddUser()
        {
            ClassLibrary.BLL.Member bll = new ClassLibrary.BLL.Member();
            ClassLibrary.Model.Member model = new ClassLibrary.Model.Member();

            model.UserName = HttpUtility.HtmlEncode(Function.GetFormString("UserName"));
            model.Password = Function.MD5(Function.GetFormString("Password"));
            model.Nickname = HttpUtility.HtmlEncode(Function.GetFormString("Nickname"));
            model.Telphone = HttpUtility.HtmlEncode(Function.GetFormString("Telphone"));
            model.QQ = HttpUtility.HtmlEncode(Function.GetFormString("QQ"));
            model.SafetyQuestion = HttpUtility.HtmlEncode(Function.GetFormString("SafetyQuestion"));
            model.SafetyAnswer = HttpUtility.HtmlEncode(Function.GetFormString("SafetyAnswer"));
            model.CreatedTime = DateTime.Now;

            if (string.IsNullOrEmpty(model.UserName))
            {
                Response.Write("<script>alert('资料填写不完整，请重新输入。');location.href='/register/';</script>");
            }
            else
            {
                if (Session["ValidateCode"] == null)
                {
                    Response.Write("<script>alert('验证码输入错误，请重新输入。');login.href='/register/';</script>");
                }
                else if (Request.Form["code"] != Session["ValidateCode"].ToString())
                {
                    Response.Write("<script>alert('验证码输入错误，请重新输入。');history.back(-1);</script>");
                }
                else
                {
                    if (bll.GetModelList("UserName='" + model.UserName + "'").Count > 0)
                    {
                        Response.Write("<script>alert('您输入的Email地址已被注册，请重新输入。');history.back(-1);</script>");
                    }
                    else
                    {
                        if (bll.Add(model) > 0)
                        {
                            Response.Write("<script>alert('恭喜您，注册成功！请登录。。。');location.href='/login/';</script>");
                        }
                        else
                        {
                            Response.Write("<script>alert('注册失败，您输入的数据有误，请重试。');location.href='/register/';</script>");
                        }
                    }
                }
            }

        }

    }
}