using System;
using System.Data;
using System.IO;
using System.Text;
using System.Web;
using ClassLibrary.Common;
using System.Collections.Generic;
using System.Drawing;

namespace WebUI.WebManage.News
{
    public partial class NewsEdit : System.Web.UI.Page
    {
        protected string newsClassIDs;

        protected int newsId;
        protected string title;
        protected int newsClassId;
        protected string routeClassId;
        protected string editor;
        protected string source;
        protected string image;
        protected string content;
        protected string newsClassList;
        protected string routeClassList;
        protected string routeSubClassList = "";
        protected string ntag = "";
        protected string seoKeywords;
        protected string seoDescription;
        protected bool isdisplay;
        protected int routeParentId = 1;
        protected bool issanxia;

        ClassLibrary.BLL.News newsBLL = new ClassLibrary.BLL.News();
        ClassLibrary.BLL.RouteClass routeClassBLL = new ClassLibrary.BLL.RouteClass();

        protected void Page_Load(object sender, EventArgs e)
        {
            newsClassIDs = Request.QueryString["cid"];

            if (Function.IsPostMethod())
            {
                if (Request.QueryString["ac"] == "edit")
                {
                    newsId = Convert.ToInt32(Request.Form["ID"]);
                    EditNews();
                }
            }
            else
            {
                GetArgument();
                BindNewsClass();
                BindData();
                if (newsClassIDs != "9" && newsClassIDs != "8" && newsClassIDs != "10")
                {
                    BindRouteClass();
                    BindRouteSubClass();
                }
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
                Function.goMessagePage("修改文章", "操作失败，参数错误!", "News/NewsList.aspx?cid=" + newsClassIDs);
            }
        }

        public void BindNewsClass()
        {
            ClassLibrary.BLL.NewsClass newsClass = new ClassLibrary.BLL.NewsClass();
            DataTable myTable = newsClass.GetData("ID in(" + newsClassIDs + ")");

            StringBuilder sb = new StringBuilder();

            foreach (DataRow dr in myTable.Rows)
            {
                sb.AppendFormat("<option value='{0}'>{1}</option>", dr["ID"].ToString(), dr["ClassName"].ToString());
            }

            newsClassList = sb.ToString();
        }

        public void BindRouteClass()
        {
            StringBuilder sb = new StringBuilder();
            int maxClassId = Convert.ToInt32(routeClassId.Split(',')[0]);
            List<ClassLibrary.Model.RouteClass> list = routeClassBLL.GetSubList(maxClassId, "ClassLevel = 3");
            string temClassID = "," + routeClassId + ",";

            foreach (ClassLibrary.Model.RouteClass model in list)
            {
                if (temClassID.Contains("," + model.ID + ","))
                {
                    sb.AppendFormat("<input name='ProvinceCheckBox' onclick='ProvinceChange(this)' type='checkbox' value='{0}' checked />{1}&nbsp;&nbsp;", model.ID, model.ClassName);
                }
                else
                {
                    sb.AppendFormat("<input name='ProvinceCheckBox' onclick='ProvinceChange(this)' type='checkbox' value='{0}' />{1}&nbsp;&nbsp;", model.ID, model.ClassName);
                }
            }

            routeClassList = sb.ToString();
        }

        public void BindRouteSubClass()
        {
            string[] classid = routeClassId.Split(',');
            StringBuilder sb = new StringBuilder();

            List<ClassLibrary.Model.RouteClass> rcList = routeClassBLL.GetModelList("id in (" + routeClassId + ") and classlevel = 3");

            string temParentIds = "";
            foreach (ClassLibrary.Model.RouteClass model in rcList)
            {
                temParentIds += model.ID + ",";
            }
            temParentIds = temParentIds.Substring(0, temParentIds.Length - 1);

            List<ClassLibrary.Model.RouteClass> rcList2 = routeClassBLL.GetModelList("ParentID in (" + temParentIds + ")");
            string temClassID = "," + routeClassId + ",";

            //if (rcList2.Count == 0) rcList2 = rcList;

            foreach (ClassLibrary.Model.RouteClass model in rcList2)
            {
                if (temClassID.Contains("," + model.ID + ","))
                {
                    sb.AppendFormat("<input name='ScenicCheckBox' type='checkbox' value='{0}' checked />{1}&nbsp;&nbsp;", model.ID, model.ClassName);
                }
                else
                {
                    sb.AppendFormat("<input name='ScenicCheckBox' type='checkbox' value='{0}' />{1}&nbsp;&nbsp;", model.ID, model.ClassName);
                }
            }

            routeSubClassList = sb.ToString();
        }

        private void BindData()
        {

            DataTable myTable = newsBLL.GetData(" id =" + newsId);

            if (myTable.Rows.Count == 1)
            {
                newsClassId = Convert.ToInt32(myTable.Rows[0]["newsClassID"]);
                routeClassId = myTable.Rows[0]["routeClassID"].ToString();
                if (routeClassId != "")
                {
                    routeParentId = Convert.ToInt32(routeClassId.Split(',')[0]);
                }
                title = myTable.Rows[0]["Title"].ToString();
                editor = myTable.Rows[0]["Editor"].ToString();
                source = myTable.Rows[0]["Source"].ToString();
                image = myTable.Rows[0]["Image"].ToString();
                content = myTable.Rows[0]["Content"].ToString();
                seoKeywords = Convert.ToString(myTable.Rows[0]["seoKeyword"]);
                seoDescription = Convert.ToString(myTable.Rows[0]["seoDescription"]);
                isdisplay = Convert.ToBoolean(myTable.Rows[0]["isDisplay"]);
                issanxia = Convert.ToBoolean(myTable.Rows[0]["IsSanxia"]);
                ntag = myTable.Rows[0]["ntag"].ToString();
            }
            else
            {
                Function.goMessagePage("修改文章", "操作失败，数据不存在!", "News/NewsList.aspx?cid=" + newsClassIDs);
            }

        }

        private void EditNews()
        {
            ClassLibrary.Model.News newsModel = new ClassLibrary.Model.News();

            newsModel.ID = newsId;
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

            if (newsModel.newsClassID == 1 ||
                 newsModel.newsClassID == 2 ||
                 newsModel.newsClassID == 3 ||
                 newsModel.newsClassID == 4 ||
                 newsModel.newsClassID == 5 ||
                 newsModel.newsClassID == 6 ||
                 newsModel.newsClassID == 7)
            {
                if (newsModel.routeClassID == "")
                {
                    Response.Write("<script>alert('请选择所属区域！');history.back(-1);</script>");
                    return;
                }
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
            string oldImages = Request.Form["Image_Hidden"];
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

                Function.DeleteFile(fileFullPath + oldImages);

                newsModel.Image = fileName;
            }
            else
            {
                newsModel.Image = oldImages;
            }

            if (string.IsNullOrEmpty(newsModel.Image))
            {
                Response.Write("<script>alert('请选择文章图片！');history.back(-1);</script>");
                return;
            }

            if (newsBLL.Update(newsModel)>0)
            {
                Function.goMessagePage("修改文章", "操作成功", "News/NewsList.aspx?cid=" + newsClassIDs);
            }
            else
            {
                Function.goMessagePage("修改文章", "操作失败，请稍后再试", "News/NewsList.aspx?cid=" + newsClassIDs);
            }

        }
        //获取当前子的所有父ID
        private string ParentClassIDList(string subClassIDs)
        {
            string str = string.Empty;
            ClassLibrary.BLL.RouteClass routeClassBLL = new ClassLibrary.BLL.RouteClass();
            List<ClassLibrary.Model.RouteClass> list = routeClassBLL.GetParentList(subClassIDs, string.Empty, "classlevel Asc");

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
