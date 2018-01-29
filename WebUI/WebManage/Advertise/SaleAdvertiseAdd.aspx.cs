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
    public partial class SaleAdvertiseAdd : System.Web.UI.Page
    {
        protected string routeClassList;
        ClassLibrary.BLL.RouteType rtBLL = new ClassLibrary.BLL.RouteType();

        protected void Page_Load(object sender, EventArgs e)
        {
            ClassLibrary.Common.UserInfo.ChekcPower();

            if (Function.IsPostMethod())
            {
                if (Request.QueryString["ac"] == "add")
                {
                    AddAdvertise();
                }
            }
            else
            {
                BindRouteClassList();
            }
        }

        private void BindRouteClassList()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<option value='1'>国内旅游</option>");
            sb.AppendLine("<option value='2'>出境旅游</option>");
            sb.AppendLine("<option value='3'>三峡旅游</option>");
            sb.AppendLine("<option value='5'>周边旅游</option>");

            List<ClassLibrary.Model.RouteType> rtList = rtBLL.GetModelList(string.Empty, "ClassOrder Asc, CreatedTime Desc");
            foreach (ClassLibrary.Model.RouteType model in rtList)
            {
                sb.AppendFormat("<option value='z{0}'>{1}</option>", model.ID, model.ClassName).AppendLine();
            }
            routeClassList = sb.ToString();
        }

        private void AddAdvertise()
        {
            ClassLibrary.BLL.SaleAdvertise linksBLL = new ClassLibrary.BLL.SaleAdvertise();
            ClassLibrary.Model.SaleAdvertise linksModel = new ClassLibrary.Model.SaleAdvertise();

            linksModel.RouteClassId = Request.Form["RouteClassId"];
            linksModel.Title = Request.Form["Title"];
            linksModel.LinkUrl = Request.Form["LinkURL"];
            linksModel.ExpiredTime = Convert.ToDateTime(Request.Form["expiredtime"]);
            linksModel.SaleOrder = Convert.ToInt32(Request.Form["saleorder"]);
            linksModel.Img = string.Empty;

            HttpPostedFile file = Request.Files["Img"];
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

                linksModel.Img = fileName;
            }

            if (linksBLL.Add(linksModel) > 0)
            {
                Function.goMessagePage("添加特价广告", "操作成功", "Advertise/SaleAdvertiseList.aspx");
            }
            else
            {
                Function.goMessagePage("添加特价广告", "操作失败，请稍后再试", "Advertise/SaleAdvertiseList.aspx");
            }

        }
    }
}
