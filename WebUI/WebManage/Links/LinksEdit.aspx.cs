using System;
using System.Data;
using System.IO;
using System.Text;
using System.Web;
using ClassLibrary.Common;

namespace WebUI.WebManage.Links
{
    public partial class LinksEdit : System.Web.UI.Page
    {
        protected int newsId;
        protected string title;
        protected string img;
        protected string LinkURL;
        protected string dataLinkClass = "";
        protected string linkClass;

        ClassLibrary.BLL.Links linksBLL = new ClassLibrary.BLL.Links();

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
                sb.AppendFormat("<option value='{0}' {2}>{1}</option>", dr["ID"].ToString(), dr["ClassName"].ToString(), dr["ID"].ToString() == linkClass ? "selected" : "");
            }

            dataLinkClass = sb.ToString();
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
                Function.goMessagePage("修改友情链接", "操作失败，参数错误!", "Links/LinksList.aspx");
            }
        }

        private void BindData()
        {

            DataTable myTable = linksBLL.GetData(" id =" + newsId);

            if (myTable.Rows.Count == 1)
            {
                title = myTable.Rows[0]["Title"].ToString();
                img = myTable.Rows[0]["Img"].ToString();
                LinkURL = myTable.Rows[0]["LinkURL"].ToString();
                linkClass = myTable.Rows[0]["LinkClass"].ToString();
            }
            else
            {
                Function.goMessagePage("修改友情链接", "操作失败，数据不存在!", "Links/LinksList.aspx");
            }

        }

        private void EditLink()
        {
            ClassLibrary.Model.Links linksModel = new ClassLibrary.Model.Links();

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
            else
            {
                linksModel.Img = Request.Form["Img_Hidden"];
            }

            if (linksBLL.Update(linksModel) > 0)
            {
                Function.goMessagePage("修改友情链接", "操作成功", "Links/LinksList.aspx");
            }
            else
            {
                Function.goMessagePage("修改友情链接", "操作失败，请稍后再试", "Links/LinksList.aspx");
            }

        }
    }
}
