using System;
using System.Data;
using System.IO;
using System.Text;
using System.Web;
using ClassLibrary.Common;
using System.Drawing;

namespace WebUI.WebManage.Advertise
{
    public partial class AppScrollImageAdd : System.Web.UI.Page
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
            ClassLibrary.BLL.AppScrollImages linksBLL = new ClassLibrary.BLL.AppScrollImages();
            ClassLibrary.Model.AppScrollImages linksModel = new ClassLibrary.Model.AppScrollImages();

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

            HttpPostedFile file = Request.Files["Img"];
            if (file.ContentLength > 0)
            {
                string ext = Path.GetExtension(file.FileName);
                string fileName = Function.GetRandomTime() + ext;
                string fileFullPath = Server.MapPath(SysConfig.UploadFilePathScrollImg);
                Function.CreatedDirectory(fileFullPath);
                file.SaveAs(fileFullPath + fileName);

                //缩图
                //Bitmap tmp = new Bitmap(fileFullPath + fileName);
                //Bitmap bmp0 = Function.MakeThumNail(tmp, 735, 352);
                //tmp.Dispose();
                ////bmp0.Save(fileFullPath + fileName);
                //Function.SaveBitmapImg(bmp0, fileFullPath + fileName, ((long)100));
                //bmp0.Dispose();

                linksModel.Img = fileName;
            }

            if (linksBLL.Add(linksModel) > 0)
            {
                Function.goMessagePage("添加首页图片", "操作成功", "Advertise/AppScrollImageList.aspx");
            }
            else
            {
                Function.goMessagePage("添加首页图片", "操作失败，请稍后再试", "Advertise/AppScrollImageList.aspx");
            }

        }
    }
}
