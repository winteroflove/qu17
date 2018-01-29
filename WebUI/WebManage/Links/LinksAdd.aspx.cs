using System;
using System.Data;
using System.IO;
using System.Text;
using System.Web;
using ClassLibrary.Common;

namespace WebUI.WebManage.Links
{
    public partial class LinksAdd : System.Web.UI.Page
    {
        protected string dataLinkClass = "";

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
            else
            {
                BindLinkClass();
            }
        }

        public void BindLinkClass()
        {
            ClassLibrary.BLL.RouteClass bll = new ClassLibrary.BLL.RouteClass();

            DataTable myTable = bll.GetData(string.Empty);

            myTable = ClassLibrary.BLL.WebClass.GetRouteTree(myTable, 0);

            StringBuilder sb = new StringBuilder();

            foreach (DataRow dr in myTable.Rows)
            {
                sb.AppendFormat("<option value='{0}'>{1}</option>", dr["ID"].ToString(), dr["ClassName"].ToString());
            }

            dataLinkClass = sb.ToString();
        }

        public void AddLinks()
        {
            ClassLibrary.BLL.Links linksBLL = new ClassLibrary.BLL.Links();
            ClassLibrary.Model.Links linksModel = new ClassLibrary.Model.Links();

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
            linksModel.Img = string.Empty;
            linksModel.LinkClass = Convert.ToInt32(Request.Form["LinkClass"]);

            HttpPostedFile file = Request.Files["Img"];
            if (file.ContentLength > 0)
            {
                string ext = Path.GetExtension(file.FileName);
                string fileName = Function.GetRandomTime() + ext;
                string fileFullPath = Server.MapPath(SysConfig.UploadFilePathLinksImg);
                Function.CreatedDirectory(fileFullPath);
                file.SaveAs(fileFullPath + fileName);

                linksModel.Img = fileName;
            }

            if (linksBLL.Add(linksModel) > 0)
            {
                Function.goMessagePage("添加友情链接", "操作成功", "Links/LinksList.aspx");
            }
            else
            {
                Function.goMessagePage("添加友情链接", "操作失败，请稍后再试", "Links/LinksList.aspx");
            }

        }
    }
}
