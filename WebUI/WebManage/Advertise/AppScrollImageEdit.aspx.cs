using System;
using System.Data;
using System.IO;
using System.Text;
using System.Web;
using ClassLibrary.Common;
using System.Drawing;

namespace WebUI.WebManage.Advertise
{
    public partial class AppScrollImageEdit : System.Web.UI.Page
    {
        protected int newsId;
        protected string title;
        protected string img;
        protected string LinkURL;

        ClassLibrary.BLL.AppScrollImages linksBLL = new ClassLibrary.BLL.AppScrollImages();

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
                Function.goMessagePage("修改首页图片", "操作失败，参数错误!", "Advertise/AppScrollImageList.aspx");
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
            }
            else
            {
                Function.goMessagePage("修改首页图片", "操作失败，数据不存在!", "Advertise/AppScrollImageList.aspx");
            }

        }

        private void EditLink()
        {
            ClassLibrary.Model.AppScrollImages linksModel = new ClassLibrary.Model.AppScrollImages();

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
    
            HttpPostedFile file = Request.Files["Img"];
            string oldImages = Request.Form["Image_Hidden"];
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

                Function.DeleteFile(fileFullPath + oldImages);

                linksModel.Img = fileName;
            }
            else
            {
                linksModel.Img = oldImages;
            }


            if (linksBLL.Update(linksModel) > 0)
            {
                Function.goMessagePage("修改首页图片", "操作成功", "Advertise/AppScrollImageList.aspx");
            }
            else
            {
                Function.goMessagePage("修改首页图片", "操作失败，请稍后再试", "Advertise/AppScrollImageList.aspx");
            }

        }
    }
}
