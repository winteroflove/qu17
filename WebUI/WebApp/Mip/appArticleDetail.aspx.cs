using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClassLibrary.Common;
using System.Text;
using System.Data;

namespace WebUI.WebApp.Mip
{
    public partial class appArticleDetail : System.Web.UI.Page
    {
        int newsID;
        int routeClassId = 0;
        protected string articleTitle = "";
        protected string articleData = "";
        protected string prevAndNexLink = "";
        protected ClassLibrary.Model.News news;
        ClassLibrary.BLL.News newsBll = new ClassLibrary.BLL.News();
        ClassLibrary.BLL.RouteClass rcBll = new ClassLibrary.BLL.RouteClass();
        protected string mipUrl = SysConfig.webSiteApp;
        protected void Page_Load(object sender, EventArgs e)
        {
            GetArgument();
            BindInfo();
            newsBll.Updates("ViewCount=ViewCount+1", "ID=" + newsID);
            BindPrevAndNextNews();
        }
        //上一篇、下一篇
        private void BindPrevAndNextNews()
        {
            StringBuilder sb = new StringBuilder();

            DataTable tbPrev = newsBll.GetPrevData(newsID);
            DataTable tbNext = newsBll.GetNextData(newsID);

            if (tbPrev.Rows.Count == 0)
            {
                sb.Append("<div>上一篇：<a href='#' target='_blank'>没有上一篇</a></div>");
            }
            else
            {
                int tmpNewsClassId = Int32.Parse(tbPrev.Rows[0]["newsClassId"].ToString());

                sb.AppendFormat("<div>上一篇：<a href='{4}/mip/{0}/{1}.html' title='{2}' target='_blank'>{3}</a></div>",
                    Enum.GetName(typeof(SysConfig.NewsClassPY), tmpNewsClassId),
                    tbPrev.Rows[0]["ID"].ToString(),
                    tbPrev.Rows[0]["Title"].ToString(),
                    Function.Clip(tbPrev.Rows[0]["Title"].ToString(), 20, true),
                    SysConfig.webSiteApp);
            }

            if (tbNext.Rows.Count == 0)
            {
                sb.Append("<div>下一篇：<a href='#' target='_blank'>没有下一篇</a></div>");
            }
            else
            {
                int tmpNewsClassId = Int32.Parse(tbNext.Rows[0]["newsClassId"].ToString());

                sb.AppendFormat("<div>下一篇：<a href='{4}/mip/{3}/{0}.html' title='{2}' target='_blank'>{1}</a></div>",
                    tbNext.Rows[0]["ID"].ToString(),
                    Function.Clip(tbNext.Rows[0]["Title"].ToString(), 20, true),
                    tbNext.Rows[0]["Title"].ToString(),
                    Enum.GetName(typeof(SysConfig.NewsClassPY), tmpNewsClassId),
                    SysConfig.webSiteApp);
            }
            prevAndNexLink = sb.ToString();
        }
        private void GetArgument()
        {
            string strNewsID = Function.GetQueryString("id");
            if (Function.IsNumber(strNewsID))
            {
                newsID = Convert.ToInt32(strNewsID);
            }
            else
            {
                Response.StatusCode = 404;
                Response.End();
                //Response.Redirect("/nopage/");
            }

        }
        //新闻详情
        private void BindInfo()
        {
            news = newsBll.GetModel(newsID);
            if (news.Title == "")
            {
                Response.StatusCode = 404;
                Response.End();
                //Response.Redirect("/nopage/");
            }
            mipUrl = SysConfig.webSiteApp + "/" + Enum.GetName(typeof(SysConfig.NewsClassPY), news.newsClassID) + "/" + newsID + ".html";
            articleTitle = news.Title;
            articleData = news.Content.Replace(SysConfig.webSite, SysConfig.webSiteApp)
                .Replace(SysConfig.webSiteApp + "/images/", SysConfig.webSite + "/images/")
                .Replace("\"/images/", "\"" + SysConfig.webSite + "/images/");
                //.Replace("<img", "<mip-img layout='responsive'").Replace("<IMG", "<mip-img layout='responsive'")
                //.Replace("</img>", "</mip-img>").Replace("</IMG>", "</mip-img>");
            articleData = Function.UpdateImgTagForMip(articleData);
            articleData = Function.UpdateStyleForMip(articleData);
            articleData = Function.AddTargetForMip(articleData);
        }
    }
}