using System;
using System.Data;
using System.IO;
using System.Text;
using System.Web;
using ClassLibrary.Common;

namespace WebUI.WebManage.Links
{
    public partial class InternalLinkAdd : System.Web.UI.Page
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
            ClassLibrary.BLL.InternalLink linksBLL = new ClassLibrary.BLL.InternalLink();
            ClassLibrary.Model.InternalLink linksModel = new ClassLibrary.Model.InternalLink();

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

            if (linksBLL.Add(linksModel) > 0)
            {
                Function.goMessagePage("添加友情链接", "操作成功", "Links/InternalLinkList.aspx");
            }
            else
            {
                Function.goMessagePage("添加友情链接", "操作失败，请稍后再试", "Links/InternalLinkList.aspx");
            }

        }
    }
}
