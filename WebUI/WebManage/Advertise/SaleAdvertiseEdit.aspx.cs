using System;
using System.Data;
using System.IO;
using System.Text;
using System.Web;
using ClassLibrary.Common;
using System.Drawing;
using System.Collections.Generic;

namespace WebUI.WebManage.Advertise
{
    public partial class SaleAdvertiseEdit : System.Web.UI.Page
    {
        protected int saleId;
        protected string title;
        protected string img;
        protected string LinkURL;
        protected string routeClassId;
        protected int saleorder;
        protected string expiredtime;
        protected string routeClassList;
        ClassLibrary.BLL.RouteType rtBLL = new ClassLibrary.BLL.RouteType();
        ClassLibrary.BLL.SaleAdvertise saleBLL = new ClassLibrary.BLL.SaleAdvertise();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Function.IsPostMethod())
            {
                if (Request.QueryString["ac"] == "edit")
                {
                    saleId = Convert.ToInt32(Request.Form["ID"]);
                    EditAdvertise();
                }
            }
            else
            {
                GetArgument();
                BindData();
                BindRouteClassList();
            }
        }
        private void BindRouteClassList()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("<option value='1' {0}>国内旅游</option>", routeClassId == "1" ? "selected" : "").AppendLine();
            sb.AppendFormat("<option value='2' {0}>出境旅游</option>", routeClassId == "2" ? "selected" : "").AppendLine();
            sb.AppendFormat("<option value='3' {0}>三峡旅游</option>", routeClassId == "3" ? "selected" : "").AppendLine();
            sb.AppendFormat("<option value='5' {0}>周边旅游</option>", routeClassId == "5" ? "selected" : "").AppendLine();

            List<ClassLibrary.Model.RouteType> rtList = rtBLL.GetModelList(string.Empty, "ClassOrder Asc, CreatedTime Desc");
            foreach (ClassLibrary.Model.RouteType model in rtList)
            {
                sb.AppendFormat("<option value='z{0}' {2}>{1}</option>", model.ID, model.ClassName, routeClassId == ("z" + model.ID) ? "selected" : "").AppendLine();
            }
            routeClassList = sb.ToString();
        }

        private void GetArgument()
        {
            string id = Request.QueryString["id"];

            if (Function.IsNumber(id))
            {
                saleId = Convert.ToInt32(id);
            }
            else
            {
                Function.goMessagePage("修改特价广告", "操作失败，参数错误!", "Advertise/SaleAdvertiseList.aspx");
            }
        }

        private void BindData()
        {

            ClassLibrary.Model.SaleAdvertise model = saleBLL.GetModel(saleId);

            if (model.Img != "")
            {
                title = model.Title;
                img = model.Img;
                LinkURL = model.LinkUrl;
                routeClassId = model.RouteClassId;
                saleorder = model.SaleOrder;
                expiredtime = model.ExpiredTime.ToString("yyyy-MM-dd");
            }
            else
            {
                Function.goMessagePage("修改特价广告", "操作失败，数据不存在!", "Advertise/SaleAdvertiseList.aspx");
            }

        }

        private void EditAdvertise()
        {
            ClassLibrary.Model.SaleAdvertise saleModel = new ClassLibrary.Model.SaleAdvertise();

            saleModel.ID = saleId;
           
            saleModel.RouteClassId = Request.Form["RouteClassId"];
            saleModel.Title = Request.Form["Title"];
            saleModel.LinkUrl = Request.Form["LinkURL"];
            saleModel.ExpiredTime = Convert.ToDateTime(Request.Form["expiredtime"]);
            saleModel.SaleOrder = Convert.ToInt32(Request.Form["saleorder"]);
    
            HttpPostedFile file = Request.Files["Img"];
            string oldImages = Request.Form["Image_Hidden"];
            if (file.ContentLength > 0)
            {
                string ext = Path.GetExtension(file.FileName);
                string fileName = Function.GetRandomTime() + ext;
                string fileFullPath = Server.MapPath(SysConfig.UploadFilePathAdImg);
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

                saleModel.Img = fileName;
            }
            else
            {
                saleModel.Img = oldImages;
            }


            if (saleBLL.Update(saleModel))
            {
                Function.goMessagePage("修改特价广告", "操作成功", "Advertise/SaleAdvertiseList.aspx");
            }
            else
            {
                Function.goMessagePage("修改特价广告", "操作失败，请稍后再试", "Advertise/SaleAdvertiseList.aspx");
            }

        }
    }
}
