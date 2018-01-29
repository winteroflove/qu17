using System;
using ClassLibrary.Common;

namespace WebUI.WebManage.Admin
{
    public partial class AdminAdd : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ClassLibrary.Common.UserInfo.ChekcPower();

            if (Function.IsPostMethod())
            {
                if (Request.QueryString["ac"] == "add")
                {
                    AddLinks();
                }
            }
        }

        public void AddLinks()
        {
            ClassLibrary.BLL.Admin adminBLL = new ClassLibrary.BLL.Admin();
            ClassLibrary.Model.Admin adminModel = new ClassLibrary.Model.Admin();

            if (string.IsNullOrEmpty(Request.Form["UserName"]))
            {
                Response.Write("<script>alert('请输入管理员账号！');history.back(-1);</script>");
                return;
            }
            else
            {
                adminModel.UserName = Request.Form["UserName"];
            }
            if (!string.IsNullOrEmpty(Request.Form["Password"]))
            {
                if (Request.Form["Password"] == Request.Form["RePassword"])
                {
                    adminModel.Password = Function.MD5(Request.Form["Password"]);
                }
                else
                {
                    Response.Write("<script>alert('管理员密码和确认密码不一致！');history.back(-1);</script>");
                    return;
                }
            }
            else
            {
                Response.Write("<script>alert('请输入管理员密码！');history.back(-1);</script>");
                return;
            }

            if (adminBLL.Add(adminModel) > 0)
            {
                Function.goMessagePage("添加管理员", "操作成功", "Admin/AdminList.aspx");
            }
            else
            {
                Function.goMessagePage("添加管理员", "操作失败，请稍后再试", "Admin/AdminList.aspx");
            }

        }
    }
}
