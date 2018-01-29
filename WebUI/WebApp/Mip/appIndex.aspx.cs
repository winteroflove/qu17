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

namespace WebUI.WebApp.Mip
{
    public partial class appIndex : System.Web.UI.Page
    {
        protected string dataScroll = "";//图片轮转
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
                sb.AppendFormat("<a href='{0}/mip/{1}/{2}.html' target='_blank'>", SysConfig.webSiteApp, tmpClassPy, model.ID);
                sb.AppendFormat("<mip-img class='hot_img' src='{0}{1}'></mip-img>", SysConfig.webSite, SysConfig.UploadFilePathRoutesImg + model.AppImg);
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
            sb.AppendFormat("<a href='{0}/mip/{1}/' target='_blank'>", SysConfig.webSiteApp, "sanxia");
            sb.AppendLine("<div class='item_text'>");
            sb.AppendFormat("<div class='icon_img'><mip-img src='{0}' ></mip-img></div>", SysConfig.webSiteApp + "/image/bg_sanxia.png");
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
                    sb.AppendFormat("<a href='{0}/mip/{1}/' target='_blank'>", SysConfig.webSiteApp, model.classNamePY);
                    sb.AppendLine("<div class='item_text'>");
                    sb.AppendFormat("<div class='icon_img'><mip-img src='{0}{1}' ></mip-img></div>", SysConfig.webSite, SysConfig.UploadFilePathClassImg + model.AppClassImg);
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
                sb.AppendFormat("<li><a href='{0}/mip/{1}/{2}.html' target='_blank'>{3}</a></li>",
                    SysConfig.webSiteApp,
                    Enum.GetName(typeof(SysConfig.NewsClassPY), model.newsClassID),
                    model.ID,
                    Function.Clip(model.Title, 14, true));
                break;
            }

            dataArticleList = sb.ToString();
        }

        private void BindScroll()
        {
            DataTable table = scrollBLL.GetData("", " CreatedTime desc");
            StringBuilder sb = new StringBuilder();
            int i = 0;
            foreach (DataRow dr in table.Rows)
            {
                i++;
                //sb.AppendFormat("<a href='{0}' target='_blank'><mip-img src='{1}' width='640' height='120' ></mip-img></a>",
                sb.AppendFormat("<mip-img src='{0}' width='640' height='120' ></mip-img>",
                    SysConfig.webSite + SysConfig.UploadFilePathScrollImg + dr["Img"]);
                if (i == 2)
                {
                    break;
                }
            }
            dataScroll = sb.ToString();
        }
    }
}