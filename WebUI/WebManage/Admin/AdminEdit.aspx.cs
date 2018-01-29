using System;
using System.Data;
using ClassLibrary.Common;

namespace WebUI.WebManage.Admin
{
    public partial class AdminEdit : System.Web.UI.Page
    {
        protected int adminId;
        protected string userName;
        protected string password;

        ClassLibrary.BLL.Admin adminBLL = new ClassLibrary.BLL.Admin();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Function.IsPostMethod())
            {
                if (Request.QueryString["ac"] == "edit")
                {
                    adminId = Convert.ToInt32(Request.Form["ID"]);
                    EditAdmin();
                }
            }
            else
            {
                GetArgument();
                BindData();
            }
        }

        private void GetArgument()
        {
            string id = Request.QueryString["id"];

            if (Function.IsNumber(id))
            {
                adminId = Convert.ToInt32(id);
            }
            else
            {
                Function.goMessagePage("修改管理员密码", "操作失败，参数错误!", "Admin/AdminList.aspx");
            }
        }

        private void BindData()
        {

            DataTable myTable = adminBLL.GetData(" id =" + adminId);

            if (myTable.Rows.Count == 1)
            {
                userName = myTable.Rows[0]["UserName"].ToString();
                password = myTable.Rows[0]["Password"].ToString();
            }
            else
            {
                Function.goMessagePage("修改管理员密码", "操作失败，数据不存在!", "Admin/AdminList.aspx");
            }

        }

        private void EditAdmin()
        {
            ClassLibrary.Model.Admin adminModel = new ClassLibrary.Model.Admin();

            adminModel.ID = adminId;

            if (string.IsNullOrEmpty(Request.Form["UserName"]))
            {
                Response.Write("<script>alert('请输入管理员账号！');history.back(-1);</script>");
                return;
            }
            else
            {
                adminModel.UserName = Request.Form["UserName"];
            }

            if (!string.IsNullOrEmpty(Request.Form["OldPassword"]))
            {
                if (Function.MD5(Request.Form["OldPassword"]) == Request.Form["Password"])
                {
                    if (!string.IsNullOrEmpty(Request.Form["NewPassword"]))
                    {
                        adminModel.Password = Function.MD5(Request.Form["NewPassword"]);
                    }
                    else
                    {
                        Response.Write("<script>alert('请输入新密码！');history.back(-1);</script>");
                        return;
                    }
                }
                else 
                {
                    Response.Write("<script>alert('旧密码错误！');history.back(-1);</script>");
                    return;
                }
            }
            else
            {
                Response.Write("<script>alert('请输入旧密码！');history.back(-1);</script>");
                return;
            }

            if (adminBLL.Update(adminModel) > 0)
            {
                Function.goMessagePage("修改管理员密码", "操作成功", "Admin/AdminList.aspx");
            }
            else
            {
                Function.goMessagePage("修改管理员密码", "操作失败，请稍后再试", "Admin/AdminList.aspx");
            }

        }
    }
}
