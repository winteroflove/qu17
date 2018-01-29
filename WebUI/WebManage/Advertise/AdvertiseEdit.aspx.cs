using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Text;
using System.IO;
using ClassLibrary.Common;
using System.Drawing;

namespace WebUI.WebManage.Advertise
{
    public partial class AdvertiseEdit : System.Web.UI.Page
    {
        string adid;
        protected string position;
        protected string dataPositionList;
        protected string dataClassListBig;

        protected ClassLibrary.Model.Advertise model;
        ClassLibrary.BLL.Advertise adBLL = new ClassLibrary.BLL.Advertise();
        ClassLibrary.BLL.AdPosition adPositionBLL = new ClassLibrary.BLL.AdPosition();

        protected string size = "";

        protected void Page_Load(object sender, EventArgs e)
        {

            if (Function.IsPostMethod())
            {
                if (Request.QueryString["ac"] == "edit")
                {
                    advertiseEdit();
                }
            }
            else
            {
                binderInfo();
                binderPosition();
            }
        }

        //绑定位置
        private void binderPosition()
        {
            position = Request.QueryString["position"];

            StringBuilder sb = new StringBuilder();

            List<ClassLibrary.Model.AdPosition> list = adPositionBLL.GetModelList(string.Empty);

            foreach (ClassLibrary.Model.AdPosition adm in list)
            {
                sb.AppendFormat("<option value='{0}' data='{3}' {4}>{1} ({2})</option>", adm.ID, adm.Name, adm.Description, adm.Size, adm.ID == model.positionID?"selected":"");
                if (adm.ID == model.positionID) size = adm.Size;
            }
            dataPositionList = sb.ToString();
        }

        //绑定信息
        private void binderInfo()
        {
            adid = Request.QueryString["adid"];
            position = Request.QueryString["position"];

            if (!Function.IsNumber(adid))
            {
                Function.goMessagePage("修改广告", "数据读取错误", "Advertise/AdvertiseList.aspx?position=" + position);
            }

            model = adBLL.GetModel(Convert.ToInt32(adid));

        }

        //修改
        private void advertiseEdit()
        {
            position = Request.Form["position"];

            if (!Function.IsNumber(position))
            {
                Function.goMessagePage("修改广告", "数据类型错误", "Advertise/AdvertiseList.aspx?position=" + position);
            }

            model = new ClassLibrary.Model.Advertise();

            model.ID = Convert.ToInt32(Request.Form["ID"]);
            model.Title = Request.Form["Title"];
            model.LinkURL = Request.Form["LinkURL"];
            model.positionID = Convert.ToInt32(position);
            model.Img = Request.Form["oldImg"];

            if (adBLL.Exists("positionID=" + model.positionID + " and id <> " + model.ID))
            {
                Response.Write("<script>alert('此广告位已存在，请更新！');history.back(-1);</script>");
                return;
            }
            string[] imgsize = Request.Form["imgSize"].ToString().Split('*');
            HttpPostedFile file = Request.Files["Img"];
            int size = file.ContentLength;

            if (size > 0)
            {
                string ext = Path.GetExtension(file.FileName);
                string fileName = Function.GetRandomTime() + ext;

                string fileFullPath = Server.MapPath(SysConfig.UploadFilePathAdImg + fileName);

                Function.CreatedDirectory(Server.MapPath(SysConfig.UploadFilePathAdImg));

                file.SaveAs(fileFullPath);
                //缩图
                //Bitmap tmp = new Bitmap(fileFullPath);
                //Bitmap bmp0 = Function.MakeThumNail(tmp, Convert.ToInt32(imgsize[0]), Convert.ToInt32(imgsize[1]));
                //tmp.Dispose();
                ////bmp0.Save(fileFullPath + fileName);
                //Function.SaveBitmapImg(bmp0, fileFullPath, ((long)100));
                //bmp0.Dispose();

                model.Img = fileName;
            }           

            if (adBLL.Update(model) > 0)
            {
                Function.goMessagePage("修改广告", "操作成功", "Advertise/AdvertiseList.aspx?position=" + position);
            }
            else
            {
                Function.goMessagePage("修改广告", "操作失败，请重试...", "Advertise/AdvertiseList.aspx?position=" + position);
            }
        }
    }
}
