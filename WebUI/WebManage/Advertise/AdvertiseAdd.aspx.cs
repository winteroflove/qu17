using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Text;
using System.IO;
using ClassLibrary.Common;
using System.Collections;
using System.Drawing;

namespace WebUI.WebManage.Advertise
{
    public partial class AdvertiseAdd : System.Web.UI.Page
    {
        string position;        
        protected string dataPositionList;
        protected string size = "";
        protected Hashtable sizeHT = new Hashtable();
        ClassLibrary.BLL.Advertise adBLL = new ClassLibrary.BLL.Advertise();
        ClassLibrary.BLL.AdPosition adPositionBLL = new ClassLibrary.BLL.AdPosition();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            ClassLibrary.Common.UserInfo.ChekcPower();

            if (Function.IsPostMethod())
            {
                if (Request.QueryString["ac"] == "add")
                {
                    advertiseAdd();
                }
            }

            binderPosition();
        }

        //绑定位置
        private void binderPosition()
        {
            position = Request.QueryString["position"];

            StringBuilder sb = new StringBuilder();

            List<ClassLibrary.Model.AdPosition> list = adPositionBLL.GetModelList(string.Empty);

            foreach (ClassLibrary.Model.AdPosition model in list)
            {
                if (position == model.ID.ToString())
                {
                    sb.AppendFormat("<option value='{0}' data='{3}' selected='selected'>{1} ({2})</option>", model.ID, model.Name, model.Description, model.Size);
                }
                else
                {
                    sb.AppendFormat("<option value='{0}' data='{3}'>{1} ({2})</option>", model.ID, model.Name, model.Description, model.Size);
                }
                //sizeHT.Add(model.ID, model.Size);
            }
            size = list[0].Size ;
            dataPositionList = sb.ToString();
        }


        //添加
        private void advertiseAdd()
        {
            ClassLibrary.Model.Advertise model = new ClassLibrary.Model.Advertise();

            position = Request.Form["position"];

            if (!Function.IsNumber(position))
            {
                Function.goMessagePage("添加广告", "数据类型错误", "Advertise/AdvertiseList.aspx?position=" + position);
            }


            model.Title = Request.Form["Title"];
            model.LinkURL = Request.Form["LinkURL"];
            model.positionID = Convert.ToInt32(position);
            model.Img = string.Empty;

            if (adBLL.Exists("positionID=" + model.positionID))
            {
                Response.Write("<script>alert('此广告位已存在，请更新！');history.back(-1);</script>");
                return;
            }

            string[] imgsize = Request.Form["imgSize"].ToString().Split('*');
            HttpPostedFile file = Request.Files["Img"];
            int size = file.ContentLength;

            if (size > 1024 * 1024 * 2)
            {
                Function.goMessagePage("添加广告", "图片上传超时，请重试", "Advertise/AdvertiseList.aspx");
            }
            else if (size > 0)
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
            else
            {
                Function.goMessagePage("添加广告", "操作失败，没有获取到图片数据。", "Advertise/AdvertiseList.aspx");
            }

            if (adBLL.Add(model) > 0)
            {
                Function.goMessagePage("添加广告", "操作成功", "Advertise/AdvertiseList.aspx");
            }
            else
            {
                Function.goMessagePage("添加广告", "操作失败，请重试...", "Advertise/AdvertiseList.aspx");
            }
        }

    }
}
