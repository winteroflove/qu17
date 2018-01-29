using System;
using System.Data;
using System.IO;
using System.Text;
using System.Web;
using ClassLibrary.Common;

namespace WebUI.WebManage.Links
{
    public partial class InternalLinkEdit : System.Web.UI.Page
    {
        protected int newsId;
        protected string title;
        protected string img;
        protected string LinkURL;

        ClassLibrary.BLL.InternalLink linksBLL = new ClassLibrary.BLL.InternalLink();

        protected void Page_Load(object sender, EventArgs e)
        {

            if (Function.IsPostMethod())
            {
                if (Request.QueryString["ac"] == "edit")
                {
                    newsId = Convert.ToInt32(Request.Form["ID"]);
                    EditLink();
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
                newsId = Convert.ToInt32(id);
            }
            else
            {
                Function.goMessagePage("修改友情链接", "操作失败，参数错误!", "Links/InternalLinkList.aspx");
            }
        }

        private void BindData()
        {

            DataTable myTable = linksBLL.GetData(" id =" + newsId);

            if (myTable.Rows.Count == 1)
            {
                title = myTable.Rows[0]["Title"].ToString();
                LinkURL = myTable.Rows[0]["LinkURL"].ToString();
            }
            else
            {
                Function.goMessagePage("修改友情链接", "操作失败，数据不存在!", "Links/InternalLinkList.aspx");
            }

        }

        private void EditLink()
        {
            ClassLibrary.Model.InternalLink linksModel = new ClassLibrary.Model.InternalLink();

            linksModel.ID = newsId;
           
            if (string.IsNullOrEmpty(Request.Form["Title"]))
            {
                Response.Write("<script>alert('请输入标题！');history.back(-1);</script>");
                return;
            }
            else
            {
                linksModel.Title = Request.Form["Title"];
            }

            linksModel.LinkURL = Request.Form["LinkURL"];

            if (linksBLL.Update(linksModel) > 0)
            {
                Function.goMessagePage("修改友情链接", "操作成功", "Links/InternalLinkList.aspx");
            }
            else
            {
                Function.goMessagePage("修改友情链接", "操作失败，请稍后再试", "Links/InternalLinkList.aspx");
            }

        }
    }
}
