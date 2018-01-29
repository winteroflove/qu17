using System;
using System.Data;
using System.Text;
using ClassLibrary.Common;
using System.Web;
using System.IO;
using System.Drawing;

namespace WebUI.WebManage.RouteType
{
    public partial class RouteTypeAdd : System.Web.UI.Page
    {
        protected string routeTypeList;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Function.IsPostMethod())
            {
                if (Request.QueryString["ac"] == "add")
                {
                    AddRouteType();
                }
            }
        }

        public void AddRouteType()
        {
            ClassLibrary.BLL.RouteType routeTypeBLL = new ClassLibrary.BLL.RouteType();
            ClassLibrary.Model.RouteType routeTypeModel = new ClassLibrary.Model.RouteType();

            if (string.IsNullOrEmpty(Request.Form["ClassName"]))
            {
                Response.Write("<script>alert('请输入主题类型！');history.back(-1);</script>");
                return;
            }
            else
            {
                routeTypeModel.ClassName = Request.Form["ClassName"];
            }

            if (string.IsNullOrEmpty(Request.Form["ClassNamePinYin"]))
            {
                Response.Write("<script>alert('请输入城市拼音！');history.back(-1);</script>");
                return;
            }
            else
            {
                routeTypeModel.classNamePY = Request.Form["ClassNamePinYin"].Trim();
            }
            if (!string.IsNullOrEmpty(Request.Form["SeoTitle"]))
            {
                routeTypeModel.seoTitle = Request.Form["SeoTitle"];
            }
            if (!string.IsNullOrEmpty(Request.Form["SeoKeywords"]))
            {
                routeTypeModel.seoKeyword = Request.Form["SeoKeywords"];
            }
            if (!string.IsNullOrEmpty(Request.Form["SeoDescription"]))
            {
                routeTypeModel.seoDesc = Request.Form["SeoDescription"];
            }
            if (!string.IsNullOrEmpty(Request.Form["classOrder"]) && Function.IsNumber(Request.Form["classOrder"]))
            {
                routeTypeModel.ClassOrder = Convert.ToInt32(Request.Form["classOrder"]);
            }
            routeTypeModel.Recommend = Convert.ToBoolean(Request.Form["Recommend"]);

            //int nwidth = 61;
            //int nheight = 41;
            HttpPostedFile file = Request.Files["Image"];
            if (file.ContentLength > 0)
            {
                string ext = Path.GetExtension(file.FileName);
                string fileName = Function.GetRandomTime() + ext;
                string fileFullPath = Server.MapPath(SysConfig.UploadFilePathClassImg);
                Function.CreatedDirectory(fileFullPath);
                file.SaveAs(fileFullPath + fileName);
                //缩图
                //Bitmap tmp = new Bitmap(fileFullPath + fileName);
                //Bitmap bmp0 = Function.MakeThumNail(tmp, nwidth, nheight);
                //tmp.Dispose();
                ////bmp0.Save(fileFullPath + fileName);
                //Function.SaveBitmapImg(bmp0, fileFullPath + fileName, ((long)100));
                //bmp0.Dispose();

                routeTypeModel.ClassImg = fileName;
            }
            file = Request.Files["appImage"];
            if (file.ContentLength > 0)
            {
                string ext = Path.GetExtension(file.FileName);
                string fileName = Function.GetRandomTime() + ext;
                string fileFullPath = Server.MapPath(SysConfig.UploadFilePathClassImg);
                Function.CreatedDirectory(fileFullPath);
                file.SaveAs(fileFullPath + fileName);

                routeTypeModel.AppClassImg = fileName;
            }
            if (routeTypeBLL.Add(routeTypeModel)>0)
            {
                Function.goMessagePage("添加主题类型", "操作成功", "RouteType/RouteTypeList.aspx");
            }
            else
            {
                Function.goMessagePage("添加主题类型", "操作失败，请稍后再试", "RouteType/RouteTypeList.aspx");
            }

        }

    }
}
