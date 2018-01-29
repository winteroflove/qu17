using System;
using System.Data;
using System.Text;
using ClassLibrary.Common;
using System.Web;
using System.IO;
using System.Drawing;

namespace WebUI.WebManage.RouteType
{
    public partial class RouteTypeEdit : System.Web.UI.Page
    {
        protected bool recommend;
        protected string className;
        protected int routeTypeId;
        protected string routeTypeList;
        protected string seoKeyword;
        protected string seoDesc;
        protected string classNamePinYin;
        protected string seoTitle;
        protected int classOrder;
        protected string image;
        protected string appImg;

        ClassLibrary.BLL.RouteType routeTypeBLL = new ClassLibrary.BLL.RouteType();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Function.IsPostMethod())
            {
                if (Request.QueryString["ac"] == "edit")
                {
                    routeTypeId = Convert.ToInt32(Request.Form["ID"]);
                    EditRouteType();
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
                routeTypeId = Convert.ToInt32(id);
            }
            else
            {
                Function.goMessagePage("修改主题类型", "操作失败，参数错误!", "RouteType/RouteTypeList.aspx");
            }
        }

        private void BindData()
        {

            DataTable myTable = routeTypeBLL.GetList("id = " + routeTypeId);

            if (myTable.Rows.Count == 1)
            {
                routeTypeId = Convert.ToInt32(myTable.Rows[0]["ID"]);
                className = myTable.Rows[0]["ClassName"].ToString();
                recommend = Convert.ToBoolean(myTable.Rows[0]["Recommend"]);

                classNamePinYin = myTable.Rows[0]["classNamePY"].ToString();
                seoKeyword = myTable.Rows[0]["SeoKeyword"].ToString();
                seoDesc = myTable.Rows[0]["SeoDesc"].ToString();
                seoTitle = myTable.Rows[0]["SeoTitle"].ToString(); 
                classOrder = Convert.ToInt32(myTable.Rows[0]["ClassOrder"]);
                image = myTable.Rows[0]["ClassImg"].ToString();
                appImg = myTable.Rows[0]["AppClassImg"].ToString();
            }
            else
            {
                Function.goMessagePage("修改主题类型", "操作失败，数据不存在!", "RouteType/RouteTypeList.aspx");
            }

        }

        private void EditRouteType()
        {
            ClassLibrary.Model.RouteType routeTypeModel = new ClassLibrary.Model.RouteType();

            routeTypeModel.ID = routeTypeId;

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

            int nmaxid = Convert.ToInt32(Request.Form["maxid"]);
            //int nwidth = 61;
            //int nheight = 41;
            HttpPostedFile file = Request.Files["Image"];
            string oldImages = Request.Form["Image_Hidden"];
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

                Function.DeleteFile(fileFullPath + oldImages);

                routeTypeModel.ClassImg = fileName;
            }
            else
            {
                routeTypeModel.ClassImg = oldImages;
            }
            file = Request.Files["appImage"];
            oldImages = Request.Form["appImage_Hidden"];
            if (file.ContentLength > 0)
            {
                string ext = Path.GetExtension(file.FileName);
                string fileName = Function.GetRandomTime() + ext;
                string fileFullPath = Server.MapPath(SysConfig.UploadFilePathClassImg);
                Function.CreatedDirectory(fileFullPath);
                file.SaveAs(fileFullPath + fileName);

                Function.DeleteFile(fileFullPath + oldImages);

                routeTypeModel.AppClassImg = fileName;
            }
            else
            {
                routeTypeModel.AppClassImg = oldImages;
            }

            if (routeTypeBLL.Update(routeTypeModel))
            {
                Function.goMessagePage("修改主题类型", "操作成功", "RouteType/RouteTypeList.aspx");
            }
            else
            {
                Function.goMessagePage("修改主题类型", "操作失败，请稍后再试", "RouteType/RouteTypeList.aspx");
            }
        }
    }
}
