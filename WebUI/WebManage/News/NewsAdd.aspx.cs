using System;
using System.Data;
using System.IO;
using System.Text;
using System.Web;
using ClassLibrary.Common;
using System.Drawing;
using System.Collections.Generic;

namespace WebUI.WebManage.News
{
    public partial class NewsAdd : System.Web.UI.Page
    {
        protected string newsClassIDs;
        protected string newsClassList;
        protected string routeClassList;
        protected string scenicThemeList="";

        protected void Page_Load(object sender, EventArgs e)
        {
            ClassLibrary.Common.UserInfo.ChekcPower();
            newsClassIDs = Request.QueryString["cid"];

            if (Function.IsPostMethod())
            {
                if (Request.QueryString["ac"] == "add")
                {
                    AddNews();
                }
            }
            else
            {
                BindNewsClass();
                BindRouteClass();
            }
        }
        public void BindNewsClass()
        {
            ClassLibrary.BLL.NewsClass newsClassBLL = new ClassLibrary.BLL.NewsClass();
            DataTable myTable = newsClassBLL.GetData("ID in(" + newsClassIDs + ")");

            StringBuilder sb = new StringBuilder();

            foreach (DataRow dr in myTable.Rows)
            {
                sb.AppendFormat("<option value='{0}'>{1}</option>", dr["ID"].ToString(), dr["ClassName"].ToString());
            }

            newsClassList = sb.ToString();
        }

        public void BindRouteClass()
        {
            ClassLibrary.BLL.RouteClass routeClassBLL = new ClassLibrary.BLL.RouteClass();
            StringBuilder sb = new StringBuilder();
            List<ClassLibrary.Model.RouteClass> list = routeClassBLL.GetSubList(1, "ClassLevel = 3");

            foreach (ClassLibrary.Model.RouteClass model in list)
            {
                sb.AppendFormat("<input name='ProvinceCheckBox' onclick='ProvinceChange(this)' type='checkbox' value='{0}' />{1}&nbsp;&nbsp;", model.ID, model.ClassName);
            }

            routeClassList = sb.ToString();
        }

        public void AddNews()
        {
            ClassLibrary.BLL.News newsBLL = new ClassLibrary.BLL.News();
            ClassLibrary.Model.News newsModel = new ClassLibrary.Model.News();

            newsModel.newsClassID = Convert.ToInt32(Request.Form["newsClassID"]);

            string province = Request.Form["ProvinceCheckBox"];
            string scenic = Request.Form["ScenicCheckBox"];
            if (scenic == null) scenic = "";
            if (province == null) province = "";
            
            if (province == "")
            {
                Response.Write("<script>alert('请至少选择一个所属区域！');history.back(-1);</script>");
                return;
            }
            newsModel.LocationID = Convert.ToInt32(province.Split(',')[0]);
            newsModel.routeClassID = "," + ParentClassIDList(province) + ",";

            if (scenic != "")
            {
                string[] temScenics = scenic.Split(',');
                foreach (string temScenic in temScenics)
                {
                    if (!newsModel.routeClassID.Contains("," + temScenic + ","))
                    {
                        newsModel.routeClassID += temScenic + ",";
                    }
                }
            }
            newsModel.routeClassID = newsModel.routeClassID.Substring(1, newsModel.routeClassID.Length - 2);
            
            newsModel.Title = Request.Form["Title"];
            newsModel.Content = ClassLibrary.BLL.WebClass.addInternelLink(Request.Form["Content"].ToString(), SysConfig.linkCount, null);  //添加内部链接

            newsModel.Editor = Request.Form["Editor"];
            newsModel.Source = Request.Form["Source"];
            newsModel.Image = string.Empty;
            newsModel.Ntag = Request.Form["Ntag"];

            newsModel.Description = Request.Form["SeoDescription"];
            newsModel.Keywords = Request.Form["SeoKeywords"];
            newsModel.Display = Convert.ToBoolean(Request.Form["Isdisplay"]);

            newsModel.IsSanxia = Convert.ToBoolean(Request.Form["IsSanxia"]);
            if (newsModel.IsSanxia) newsModel.LocationID = (int)SysConfig.RouteClass.三峡旅游;

            if (newsModel.newsClassID == 0)
            {
                Response.Write("<script>alert('请选择文章类型！');history.back(-1);</script>");
                return;
            }
            if ( newsModel.routeClassID == "")
            {
                Response.Write("<script>alert('请选择所属区域！');history.back(-1);</script>");
                return;
            }

            if (string.IsNullOrEmpty(newsModel.Title))
            {
                Response.Write("<script>alert('请输入标题！');history.back(-1);</script>");
                return;
            }

            if (string.IsNullOrEmpty(newsModel.Content))
            {
                Response.Write("<script>alert('请输入文章内容！');history.back(-1);</script>");
                return;
            }
            int width = 300;
            int height = 186;

            HttpPostedFile file = Request.Files["Image"];
            if (file.ContentLength > 0)
            {
                string ext = Path.GetExtension(file.FileName);
                string fileName = Function.GetRandomTime() + ext;
                string fileFullPath = Server.MapPath(SysConfig.UploadFilePathNewsImg);
                Function.CreatedDirectory(fileFullPath);
                file.SaveAs(fileFullPath + fileName);

                //缩图
                Bitmap tmp = new Bitmap(fileFullPath + fileName);
                Bitmap bmp0 = Function.MakeThumNail(tmp, width, height);
                tmp.Dispose();
                //bmp0.Save(fileFullPath + fileName);
                Function.SaveBitmapImg(bmp0, fileFullPath + fileName, ((long)88));
                bmp0.Dispose();

                newsModel.Image = fileName;
            }
            else //if (newsModel.newsClassID == 6 || newsModel.newsClassID == 7) 概述和景点介绍
            {
                Response.Write("<script>alert('请选择文章图片！');history.back(-1);</script>");
                return;
            }

            if (newsBLL.Add(newsModel)>0)
            {
                Function.goMessagePage("添加文章", "操作成功", "News/NewsList.aspx?cid=" + newsClassIDs);
            }
            else
            {
                Function.goMessagePage("添加文章", "操作失败，请稍后再试", "News/NewsList.aspx?cid=" + newsClassIDs);
            }

        }
        //获取当前子的所有父ID
        private string ParentClassIDList(string subClassIDs)
        {
            string str = string.Empty;
            ClassLibrary.BLL.RouteClass routeClassBLL = new ClassLibrary.BLL.RouteClass();
            List<ClassLibrary.Model.RouteClass> list = routeClassBLL.GetParentList(subClassIDs, string.Empty, "classlevel Asc" );

            foreach (ClassLibrary.Model.RouteClass model in list)
            {
                str += model.ID + ",";
            }

            if (!string.IsNullOrEmpty(str))
            {
                str = str.Substring(0, str.Length - 1);
            }
            else
            {
                str = subClassIDs.ToString();
            }

            return str;
        }
        
    }
}
