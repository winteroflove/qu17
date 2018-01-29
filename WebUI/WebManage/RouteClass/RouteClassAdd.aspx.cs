using System;
using System.Data;
using System.Text;
using ClassLibrary.Common;
using System.Web;
using System.IO;
using System.Drawing;

namespace WebUI.WebManage.RouteClass
{
    public partial class RouteClassAdd : System.Web.UI.Page
    {
        protected int maxClassID;
        protected string routeClassList;

        protected void Page_Load(object sender, EventArgs e)
        {
            GetArgument();

            if (Function.IsPostMethod())
            {
                if (Request.QueryString["ac"] == "add")
                {
                    AddRouteClass();
                }
            }
            else
            {
                BindRouteClass();
            }
        }

        private void GetArgument()
        {
            string strid = Request.QueryString["cid"];

            if (Function.IsNumber(strid))
            {
                maxClassID = Convert.ToInt32(strid);
            }
            else
            {
                maxClassID = (int)SysConfig.RouteClass.国内旅游;
            }
        }

        public void BindRouteClass()
        {
            ClassLibrary.BLL.RouteClass routeClassBLL = new ClassLibrary.BLL.RouteClass();
            DataTable myTable = ClassLibrary.BLL.WebClass.GetRouteTree(routeClassBLL.GetTableSubList(maxClassID, string.Empty));

            StringBuilder sb = new StringBuilder();

            foreach (DataRow dr in myTable.Rows)
            {
                sb.AppendFormat("<option value='{0}'>{1}</option>", dr["ID"].ToString(), dr["ClassName"].ToString());
            }

            routeClassList = sb.ToString();
        }

        public void AddRouteClass()
        {
            ClassLibrary.BLL.RouteClass routeClassBLL = new ClassLibrary.BLL.RouteClass();
            ClassLibrary.Model.RouteClass routeClassModel = new ClassLibrary.Model.RouteClass();

            routeClassModel.ParentID = Convert.ToInt32(Request.Form["routeClassID"]);
            if (routeClassModel.ParentID == 0)
            {
                routeClassModel.ClassLevel = 1;
            }
            else
            {
                routeClassModel.ClassLevel = routeClassBLL.GetModel(routeClassModel.ParentID).ClassLevel + 1;
            }

            if (string.IsNullOrEmpty(Request.Form["ClassName"]))
            {
                Response.Write("<script>alert('请输入路线类型！');history.back(-1);</script>");
                return;
            }
            else
            {
                routeClassModel.ClassName = Request.Form["ClassName"];
            }

            if (string.IsNullOrEmpty(Request.Form["ClassNamePinYin"]))
            {
                Response.Write("<script>alert('请输入城市拼音！');history.back(-1);</script>");
                return;
            }
            else
            {
                routeClassModel.ClassNamePY = Request.Form["ClassNamePinYin"].Trim();
            }
            if (!string.IsNullOrEmpty(Request.Form["SeoTitle"]))
            {
                routeClassModel.SeoTitle = Request.Form["SeoTitle"];
            }
            if (!string.IsNullOrEmpty(Request.Form["SeoKeywords"]))
            {
                routeClassModel.SeoKeyword = Request.Form["SeoKeywords"];
            }
            if (!string.IsNullOrEmpty(Request.Form["SeoDescription"]))
            {
                routeClassModel.SeoDesc = Request.Form["SeoDescription"];
            }
            if (!string.IsNullOrEmpty(Request.Form["classOrder"]) && Function.IsNumber(Request.Form["classOrder"]))
            {
                routeClassModel.ClassOrder = Convert.ToInt32(Request.Form["classOrder"]);
            }
            routeClassModel.Recommend = Convert.ToBoolean(Request.Form["Recommend"]);
            routeClassModel.IsHaidao = Convert.ToBoolean(Request.Form["IsHaidao"]);

            //int nmaxid = Convert.ToInt32(Request.Form["maxid"]);
            //int nwidth = 61;
            //int nheight = 41;
            //if (nmaxid == (int)SysConfig.RouteClass.三峡旅游)
            //{
            //    nwidth = 50;
            //    nheight = 50;
            //}
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

                routeClassModel.ClassImg = fileName;
            }
            if (routeClassBLL.Add(routeClassModel)>0)
            {
                Function.goMessagePage("添加路线类型", "操作成功", "RouteClass/RouteClassList.aspx?cid=" + maxClassID);
            }
            else
            {
                Function.goMessagePage("添加路线类型", "操作失败，请稍后再试", "RouteClass/RouteClassList.aspx?cid=" + maxClassID);
            }

        }

    }
}
