using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml.Linq;
using System.Text;
using ClassLibrary.Common;
using System.Net.Mail;
using System.Web.UI;
using System.Web.SessionState;

namespace WebUI.WebApp
{
    /// <summary>
    /// $codebehindclassname$ 的摘要说明
    /// </summary>

    public class appService : IHttpHandler, IRequiresSessionState 
    {

        public void ProcessRequest(HttpContext context)
        {
            if (context.Request.QueryString["ac"] == null)
                return;

            string action = context.Request.QueryString["ac"];
            switch (action)
            {
                case "loadMoreRoute":
                    loadMoreRoute(context);
                    break;
                case "loadMoreSearch":
                    loadMoreSearch(context);
                    break;
                case "loadArticleList":
                    loadArticleList(context);
                    break;
            }
        }
        public void loadArticleList(HttpContext context)
        {
            int typeid = Convert.ToInt32(context.Request.QueryString["typeid"]);
            int pageIndex = Convert.ToInt32(context.Request.QueryString["page"]);
            string strWhere = "isdisplay = 1";

            if (typeid != 0)
            {
                strWhere += " and newsClassID=" + typeid;
            }
            ClassLibrary.BLL.News newsBll = new ClassLibrary.BLL.News();
            ClassLibrary.BLL.RouteClass rcBll = new ClassLibrary.BLL.RouteClass();
            List<ClassLibrary.Model.RouteClass> gList = new List<ClassLibrary.Model.RouteClass>();
            DataSet mySet = newsBll.GetPageData(10, pageIndex, strWhere, "CreatedTime Desc");
            DataTable myTable = mySet.Tables["Data"];

            StringBuilder sb = new StringBuilder();
            gList = rcBll.GetModelList(String.Empty, "ClassOrder Asc");
            List<ClassLibrary.Model.News> tnewsList = newsBll.GetModelList(myTable);

            foreach (ClassLibrary.Model.News model in tnewsList)
            {
                string turl = Enum.GetName(typeof(SysConfig.NewsClassPY), model.newsClassID);
                sb.AppendLine("<div class='aricleitem'>");
                sb.AppendFormat("<a href='{0}/{1}/{2}.html'>", SysConfig.webSiteApp, turl, model.ID);
                string aimg = "/image/defaultImg.jpg";
                if (model.Image != "")
                {
                    aimg = SysConfig.UploadFilePathNewsImg + model.Image;
                }
                sb.AppendFormat("<div class='ai_img'><img src='{0}{1}' alt='' /></div>", SysConfig.webSite, aimg);
                sb.AppendLine("<div class='ai_content'>");
                sb.AppendFormat("<div class='ai_title'>{0}</div>", Function.Clip(model.Title, 13, true));
                sb.AppendFormat("<div class='ai_desc'>{0}</div>",
                    Function.Clip(Function.ClearHtml(model.Content), 27, true));
                sb.AppendFormat("<div class='ai_ctime'>{0}</div>", model.CreatedTime.ToString("yyyy-MM-dd HH:mm"));
                sb.AppendLine("</div>");
                sb.AppendLine("</a>");
                sb.AppendLine("</div>");
            }
            Print(context, sb.ToString());
        }
        public void loadMoreSearch(HttpContext context)
        {
            string skey = context.Request.QueryString["skey"];
            int pageIndex = Convert.ToInt32(context.Request.QueryString["page"]);
            ClassLibrary.BLL.Routes routeBLL = new ClassLibrary.BLL.Routes();
            ClassLibrary.BLL.RouteClass routeClassBLL = new ClassLibrary.BLL.RouteClass();
            string routewhere = " isdisplay=1 and CHARINDEX('" + skey + "',Title) > 0 ";
            DataSet mySet = routeBLL.GetPageData(10, pageIndex, routewhere, "RouteOrder Asc, CreatedTime Desc");
            DataTable myTable = mySet.Tables["Data"];
            List<ClassLibrary.Model.RouteClass> glClass = routeClassBLL.GetModelList(string.Empty);
            StringBuilder sb = new StringBuilder();
            List<ClassLibrary.Model.Routes> pgRouteList = routeBLL.GetModelList(myTable);
            foreach (ClassLibrary.Model.Routes model in pgRouteList)
            {
                //string[] images = model.Image.Split(',');
                //int tmpClassId = Convert.ToInt32(model.routesClassID.Split(',')[1]);
                string tmpPy = glClass.Find(delegate(ClassLibrary.Model.RouteClass tm) { return tm.ID == model.LocationID; }).ClassNamePY;
                sb.AppendLine("<li>");
                sb.AppendFormat("<a href='{0}/{1}/{2}.html'>", SysConfig.webSiteApp, tmpPy, model.ID);
                sb.AppendFormat("<div class='hot_img' style='background-image:url({0}{1})'></div>", SysConfig.webSite, SysConfig.UploadFilePathRoutesImg + model.AppImg);
                sb.AppendFormat("<div class='hot_price'>&yen;<em>{0}</em>起</div>", Convert.ToInt32(model.Price));
                sb.AppendFormat("<div class='hot_title'>{0}</div>", Function.Clip(model.Title, 18, true));
                sb.AppendLine("</a>");
                sb.AppendLine("</li>");
            }

            Print(context, sb.ToString());
        }
        public void loadMoreRoute(HttpContext context)
        {
            int cid = Convert.ToInt32(context.Request.QueryString["cid"]);
            int pid = Convert.ToInt32(context.Request.QueryString["pid"]);
            int pageIndex = Convert.ToInt32(context.Request.QueryString["page"]);
            ClassLibrary.BLL.Routes routeBLL = new ClassLibrary.BLL.Routes();
            ClassLibrary.BLL.RouteClass routeClassBLL = new ClassLibrary.BLL.RouteClass();
            string routewhere = " isdisplay=1 ";

            if (pid == 0)
            {
                routewhere += " and charindex('," + cid + ",',','+themeId+',')>0";
            }
            else
            {
                routewhere += " and charindex('," + cid + ",',','+routesPrentClassID+',')>0";
            }
            DataSet mySet = routeBLL.GetPageData(10, pageIndex, routewhere, "RouteOrder Asc, CreatedTime Desc");
            DataTable myTable = mySet.Tables["Data"];
            List<ClassLibrary.Model.RouteClass> glClass = routeClassBLL.GetModelList(string.Empty);
            StringBuilder sb = new StringBuilder();
            List<ClassLibrary.Model.Routes> pgRouteList = routeBLL.GetModelList(myTable);
            foreach (ClassLibrary.Model.Routes model in pgRouteList)
            {
                //string[] images = model.Image.Split(',');
                //int tmpClassId = Convert.ToInt32(model.routesClassID.Split(',')[1]);
                string tmpPy = glClass.Find(delegate(ClassLibrary.Model.RouteClass tm) { return tm.ID == model.LocationID; }).ClassNamePY;
                sb.AppendLine("<li>");
                sb.AppendFormat("<a href='{0}/{1}/{2}.html'>", SysConfig.webSiteApp, tmpPy, model.ID);
                sb.AppendFormat("<div class='hot_img' style='background-image:url({0}{1})'></div>", SysConfig.webSite, SysConfig.UploadFilePathRoutesImg + model.AppImg);
                sb.AppendFormat("<div class='hot_title'>{0}</div>", Function.Clip(model.Title, 18, true));
                sb.AppendFormat("<div class='hot_price'>&yen;<em>{0}</em>起</div>", Convert.ToInt32(model.Price));
                sb.AppendLine("</a>");
                sb.AppendLine("</li>");
            }

            Print(context, sb.ToString());
        }
        
        private void Print(HttpContext context, string msg)
        {
            context.Response.Cache.SetCacheability(HttpCacheability.NoCache);
            context.Response.ContentType = "text/plain";
            context.Response.Write(msg);
            context.Response.End();
        }
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}
