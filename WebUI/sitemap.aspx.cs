using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Text;
using System.Collections.Generic;
using ClassLibrary.Common;

namespace WebUI
{
    public partial class sitemap : System.Web.UI.Page
    {
        protected string DataMap;
        protected string mapRoute;
        protected string mapArticle;
        protected string mapNews;
        ClassLibrary.BLL.RouteClass classbll = new ClassLibrary.BLL.RouteClass();
        List<ClassLibrary.Model.RouteClass> rcList = new List<ClassLibrary.Model.RouteClass>();

        protected void Page_Load(object sender, EventArgs e)
        {
            BindItem();
        }
        private void BindItem()
        {
            rcList = classbll.GetModelList(String.Empty);

            DataTable table= classbll.GetData(" classlevel=1 and id < 6","createdtime desc");
            StringBuilder sb = new StringBuilder();

            /*国内旅游*/
            sb.Append("<div class='SiteMap_Item'>");
            sb.AppendFormat("<p><a href='{2}/{1}/'>{0}</a></p>", "国内旅游", "guonei", SysConfig.webSite);
            List<ClassLibrary.Model.RouteClass> gnList = rcList.FindAll(delegate(ClassLibrary.Model.RouteClass rcm) { return rcm.ParentID == (int)SysConfig.RouteClass.国内旅游; });
            foreach (ClassLibrary.Model.RouteClass model in gnList)
            {
                sb.AppendFormat("<p>{0}</p>", model.ClassName);
                List<ClassLibrary.Model.RouteClass> level3List = rcList.FindAll(delegate(ClassLibrary.Model.RouteClass rcm) { return rcm.ParentID == model.ID; });
                foreach (ClassLibrary.Model.RouteClass model3 in level3List)
                {
                    sb.Append("<div class='SiteMap_Text'>");
                    sb.AppendFormat("<div class='SiteMap_Text_first'><a href='{2}/{1}/'>{0}旅游</a></div>", model3.ClassName, model3.ClassNamePY, SysConfig.webSite);
                    sb.Append(" <div class='SiteMap_Text_child'>");
                    List<ClassLibrary.Model.RouteClass> level4List = rcList.FindAll(delegate(ClassLibrary.Model.RouteClass rcm) { return rcm.ParentID == model3.ID; });
                    foreach (ClassLibrary.Model.RouteClass model4 in level4List)
                    {
                        sb.AppendFormat("<a href='{2}/{1}/'>{0}旅游</a>", model4.ClassName, model4.ClassNamePY, SysConfig.webSite);
                    }
                    sb.Append("</div></div>");
                }
            }
            sb.Append("</div>");

            /*出境旅游*/
            sb.Append("<div class='SiteMap_Item'>");
            sb.AppendFormat("<p><a href='{2}/{1}/'>{0}</a></p>", "出境旅游", "chujing", SysConfig.webSite);
            List<ClassLibrary.Model.RouteClass> cjList = rcList.FindAll(delegate(ClassLibrary.Model.RouteClass rcm) { return rcm.ParentID == (int)SysConfig.RouteClass.出境旅游; });
            foreach (ClassLibrary.Model.RouteClass model in cjList)
            {
                sb.Append("<div class='SiteMap_Text'>");
                sb.AppendFormat("<div class='SiteMap_Text_first'><a href='{2}/{1}/'>{0}旅游</a></div>", model.ClassName, model.ClassNamePY, SysConfig.webSite);
                sb.Append(" <div class='SiteMap_Text_child'>");
                List<ClassLibrary.Model.RouteClass> level2List = rcList.FindAll(delegate(ClassLibrary.Model.RouteClass rcm) { return rcm.ParentID == model.ID; });
                foreach (ClassLibrary.Model.RouteClass model2 in level2List)
                {
                    sb.AppendFormat("<a href='{2}/{1}/'>{0}旅游</a>", model2.ClassName, model2.ClassNamePY, SysConfig.webSite);
                }
                sb.Append("</div></div>");
            }
            sb.Append("</div>");

            /*三峡旅游*/
            sb.Append("<div class='SiteMap_Item'>");
            sb.AppendFormat("<p><a href='{2}/{1}/'>{0}</a></p>", "三峡旅游", "sanxia", SysConfig.webSite);
            List<ClassLibrary.Model.RouteClass> sxList = rcList.FindAll(delegate(ClassLibrary.Model.RouteClass rcm) { return rcm.ParentID == (int)SysConfig.RouteClass.三峡旅游; });
            sb.Append("<div class='SiteMap_Text'>");
            sb.AppendFormat("<div class='SiteMap_Text_first'>&nbsp;</div>");
            sb.Append("<div class='SiteMap_Text_child'>");
            foreach (ClassLibrary.Model.RouteClass model in sxList)
            {
                sb.AppendFormat("<a href='{2}/{1}/'>{0}</a>", model.ClassName, model.ClassNamePY, SysConfig.webSite);
            }
            sxList = rcList.FindAll(delegate(ClassLibrary.Model.RouteClass rcm) { return rcm.ParentID == (int)SysConfig.RouteClass.豪华船; });
            foreach (ClassLibrary.Model.RouteClass model in sxList)
            {
                sb.AppendFormat("<a href='{2}/{1}/'>{0}</a>", model.ClassName, model.ClassNamePY, SysConfig.webSite);
            }
            sb.Append("</div></div></div>");

            /*主题旅游*/
            ClassLibrary.BLL.RouteType rtBll = new ClassLibrary.BLL.RouteType();
            sb.Append("<div class='SiteMap_Item'>");
            sb.AppendFormat("<p>{0}</p>", "主题旅游");
            List<ClassLibrary.Model.RouteType> ztList = rtBll.GetModelList(String.Empty);
            sb.Append("<div class='SiteMap_Text'>");
            sb.AppendFormat("<div class='SiteMap_Text_first'>&nbsp;</div>");
            sb.Append("<div class='SiteMap_Text_child'>");
            foreach (ClassLibrary.Model.RouteType model in ztList)
            {
                sb.AppendFormat("<a href='{2}/{1}/'>{0}</a>", model.ClassName, model.classNamePY, SysConfig.webSite);
            }
            sb.Append("</div></div></div>");
            DataMap = sb.ToString();

            ClassLibrary.BLL.Routes routeBll = new ClassLibrary.BLL.Routes();
            List<ClassLibrary.Model.Routes> routeList = routeBll.GetModelList(20, "isdisplay = 1", "CreatedTime Desc");
            StringBuilder sb2 = new StringBuilder();
            foreach (ClassLibrary.Model.Routes model in routeList)
            {
                ClassLibrary.Model.RouteClass temClass = rcList.Find(delegate(ClassLibrary.Model.RouteClass trc) { return trc.ID == model.LocationID; });
                sb2.AppendFormat("<li><a href='{0}/{1}/{2}.html' target='_blank'>{3}</a></li>",
                    SysConfig.webSite, temClass.ClassNamePY, model.ID, model.Title).AppendLine();
            }
            mapRoute = sb2.ToString();

            ClassLibrary.BLL.News newsBll = new ClassLibrary.BLL.News();
            List<ClassLibrary.Model.News> newsList = newsBll.GetModelList(10, "isdisplay = 1 and newsClassId = 2", "CreatedTime Desc");
            StringBuilder sb3 = new StringBuilder();
            foreach (ClassLibrary.Model.News model in newsList)
            {
                sb3.AppendFormat("<li><a href='{0}/{1}/{2}.html' target='_blank'>{3}</a></li>",
                    SysConfig.webSite, Enum.GetName(typeof(SysConfig.NewsClassPY), model.newsClassID), model.ID, model.Title).AppendLine();
            }
            mapArticle = sb3.ToString();

            newsList = newsBll.GetModelList(10, "isdisplay = 1 and newsClassId = 1", "CreatedTime Desc");
            StringBuilder sb4 = new StringBuilder();
            foreach (ClassLibrary.Model.News model in newsList)
            {
                sb4.AppendFormat("<li><a href='{0}/{1}/{2}.html' target='_blank'>{3}</a></li>",
                    SysConfig.webSite, Enum.GetName(typeof(SysConfig.NewsClassPY), model.newsClassID), model.ID, model.Title).AppendLine();
            }
            mapNews = sb4.ToString();
        }
    }
}
