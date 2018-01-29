using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using ClassLibrary.Common;
using System.Text.RegularExpressions;

namespace WebUI.WebApp
{
    public partial class appIndex : System.Web.UI.Page
    {
        protected string dataScroll = "";//图片轮转
        protected string dataScrollTitles = "";//图片轮转
        protected string dataArticleList = "";
        protected string dataZhutiList = "";
        protected string dataRouteList = "";

        List<ClassLibrary.Model.RouteClass> gList;
        ClassLibrary.BLL.AppScrollImages scrollBLL = new ClassLibrary.BLL.AppScrollImages();
        ClassLibrary.BLL.News newsBll = new ClassLibrary.BLL.News();
        ClassLibrary.BLL.RouteClass rcBll = new ClassLibrary.BLL.RouteClass();
        ClassLibrary.BLL.RouteType rtBll = new ClassLibrary.BLL.RouteType();
        ClassLibrary.BLL.Routes routeBll = new ClassLibrary.BLL.Routes();

        protected void Page_Load(object sender, EventArgs e)
        {
            //CheckSiteApp();
            gList = rcBll.GetModelList(string.Empty, "ClassOrder Asc");
            BindScroll();
            BindArticles();
            BindZhuTi();
            BindRouteList();
        }

        private void CheckSiteApp()
        {
            string src = Function.GetQueryString("src");
            if (src != "")
            {
                string rule = "/([a-zA-Z]+)/([0-9]+).html";
                Match match = Regex.Match(src, rule);
                if (match.ToString() != "")
                {
                    string url = SysConfig.webSiteApp + match.ToString();
                    Response.Status = "301 Moved Permanently";
                    Response.AddHeader("Location", url);
                    Response.End();
                }
                string arule = "/article/([a-zA-Z]+)/([0-9]+).html";
                match = Regex.Match(src, arule);
                if (match.ToString() != "")
                {
                    string url = SysConfig.webSiteApp + match.ToString();
                    Response.Status = "301 Moved Permanently";
                    Response.AddHeader("Location", url);
                    Response.End();
                }
            }
        }

        private void BindRouteList()
        {
            StringBuilder sb = new StringBuilder();
            List<ClassLibrary.Model.Routes> routeList = routeBll.GetModelList(8, "isdisplay = 1", "RecommendHot desc,RouteOrder Asc");
            int i = 0;
            foreach (ClassLibrary.Model.Routes model in routeList)
            {
                i++;
                string tmpClassPy = gList.Find(delegate(ClassLibrary.Model.RouteClass rc) { return rc.ID == model.LocationID; }).ClassNamePY;
                sb.AppendFormat("<li class='{0}'>", i == 8 ? "lastline" : "");
                sb.AppendFormat("<a href='{0}/{1}/{2}.html'>", SysConfig.webSiteApp, tmpClassPy, model.ID);
                sb.AppendFormat("<div class='hot_img' style='background-image:url({0}{1})'></div>", SysConfig.webSite, SysConfig.UploadFilePathRoutesImg + model.AppImg);
                sb.AppendFormat("<div class='hot_title'>{0}</div>", Function.Clip(model.Title, 20, true));
                sb.AppendFormat("<div class='hot_price'>&yen;<em>{0}</em>起</div>", Convert.ToInt32(model.Price));
                sb.AppendLine("</a>");
                sb.AppendLine("</li>");
            }
            dataRouteList = sb.ToString();
        }

        private void BindZhuTi()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<li class='box_item'>");
            sb.AppendFormat("<a href='{0}/{1}/'>", SysConfig.webSiteApp, "sanxia");
            sb.AppendLine("<div class='item_text'>");
            sb.AppendFormat("<div class='icon_img'><img src='{0}' alt='' /></div>", "/image/bg_sanxia.png");
            sb.AppendFormat("<div class='item_title'>{0}</div>", "三峡游");
            sb.AppendLine("</div>");
            sb.AppendLine("</a>");
            sb.AppendLine("</li>");
            List<ClassLibrary.Model.RouteType> ztList = rtBll.GetModelList(string.Empty, "ClassOrder Asc,CreatedTime Desc");
            int i = 0;
            foreach (ClassLibrary.Model.RouteType model in ztList)
            {
                if (model.Recommend)
                {
                    i++;
                    sb.AppendLine("<li class='box_item'>");
                    sb.AppendFormat("<a href='{0}/{1}/'>", SysConfig.webSiteApp, model.classNamePY);
                    sb.AppendLine("<div class='item_text'>");
                    sb.AppendFormat("<div class='icon_img'><img src='{0}{1}' alt='' /></div>", SysConfig.webSite, SysConfig.UploadFilePathClassImg + model.AppClassImg);
                    sb.AppendFormat("<div class='item_title'>{0}</div>", model.ClassName);
                    sb.AppendLine("</div>");
                    sb.AppendLine("</a>");
                    sb.AppendLine("</li>");
                }
                if (i >= 3) break;
            }
            dataZhutiList = sb.ToString();
        }

        private void BindArticles()
        {
            StringBuilder sb = new StringBuilder();
            List<ClassLibrary.Model.News> newsList = newsBll.GetModelList(5, "isdisplay = 1");

            foreach (ClassLibrary.Model.News model in newsList)
            {
                sb.AppendFormat("<li><a href='{0}/{1}/{2}.html'>{3}</a></li>",
                    SysConfig.webSiteApp,
                    Enum.GetName(typeof(SysConfig.NewsClassPY), model.newsClassID),
                    model.ID,
                    Function.Clip(model.Title, 14, true));
            }

            dataArticleList = sb.ToString();
        }

        private void BindScroll()
        {
            DataTable table = scrollBLL.GetData("", " CreatedTime desc");
            StringBuilder sb = new StringBuilder();
            StringBuilder sb2 = new StringBuilder();
            int i = 0;
            foreach (DataRow dr in table.Rows)
            {
                i++;
                //sb.AppendFormat("<a href='{2}' title='{1}' target='_blank'><img src='{0}' alt='{1}' width='735' height='352' /></a>", ClassLibrary.Common.SysConfig.UploadFilePathScrollImg + dr["Img"], dr["Title"], dr["LinkURL"]);
                sb.AppendFormat("<li style='display: {0};' class='{1}'><a href='{2}' target='_blank' title='{5}' rel='nofollow'><img {3}='{4}' alt='' /></a></li>",
                    i == 1 ? "list-item" : "none", i == 1 ? "current" : "", dr["LinkURL"], i == 1 ? "src" : "data-src", SysConfig.webSite + SysConfig.UploadFilePathScrollImg + dr["Img"], dr["Title"]);
                sb2.AppendFormat("<a class='{0}' href='javascript:void(0)'></a>", i == 1 ? "current" : "");
                if (i == 6)
                {
                    break;
                }
            }
            dataScroll = sb.ToString();
            dataScrollTitles = sb2.ToString();
        }
    }
}