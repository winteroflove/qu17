using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Text;
using System.Data;
using ClassLibrary.Common;
using System.Collections;

namespace WebUI
{
    public partial class articleDetail : System.Web.UI.Page
    {
        protected int newsID = 0;
        protected int zanCount = 0;
        int routeClassId = 0;
        protected string location = "";
        protected string prevAndNexLink;
        protected string dataSalesList = "";
        protected string articleTitle = "";
        protected string displayName = "";
        protected string displayPing = "";
        protected string dataGongLuList = "";
        protected string relateArticleList = "";
        protected string ntag = "";
        protected string routelistAds = "";
        protected string appurl = "";
        protected ClassLibrary.Model.News news = new ClassLibrary.Model.News();
        ClassLibrary.BLL.News newsBll = new ClassLibrary.BLL.News();
        ClassLibrary.BLL.RouteClass rcBll = new ClassLibrary.BLL.RouteClass();
        ClassLibrary.BLL.Routes routeBll = new ClassLibrary.BLL.Routes();
        ClassLibrary.BLL.SaleAdvertise saBll = new ClassLibrary.BLL.SaleAdvertise();
        List<ClassLibrary.Model.RouteClass> gList = new List<ClassLibrary.Model.RouteClass>();

        protected void Page_Load(object sender, EventArgs e)
        {
            GetArgument();
            BindInfo();
            GetLocation();
            BindPrevAndNextNews();
            BindRouteAds();
            BindRouteSales();
            BindNewsList();
            BindRelateArticles();
            newsBll.Updates("ViewCount=ViewCount+1", "ID=" + newsID);
        }
        private void BindRouteAds()
        {
            string where = " ExpiredTime > '" + DateTime.Now.ToString("yyyy-MM-dd") + "'";
            List<ClassLibrary.Model.SaleAdvertise> saList = saBll.GetModelList(4, where, "SaleOrder Asc, CreatedTime Desc");
            if (saList.Count > 0)
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("<div class='route_sale'>");
                sb.AppendLine("<div class='route_sale_top'>限时特价</div>");
                sb.AppendLine("<div class='route_sale_items'>");
                foreach (ClassLibrary.Model.SaleAdvertise model in saList)
                {
                    sb.AppendFormat("<a href='{0}' title='{1}' target='_blank' >", model.LinkUrl, model.Title);
                    sb.AppendFormat("<img src='{0}' alt='' width='211px' height='254px' /></a>", SysConfig.UploadFilePathAdImg + model.Img);
                }
                sb.AppendLine("</div>");
                sb.AppendLine("</div>");

                routelistAds = sb.ToString();
            }
        }
        private void BindRelateArticles()
        {
            StringBuilder sb = new StringBuilder();
            DataTable table = new DataTable();
            string where = "isdisplay = 1";
            
            if (news.IsSanxia)
            {
                table = newsBll.GetData(10, where + " and IsSanxia = 1", "ID desc ");
            }
            else
            {
                string where2 = " and CHARINDEX('," + routeClassId + ",',','+routeClassID+',') > 0 ";
                table = newsBll.GetData(10, where + where2, "ID desc ");
                if (table.Rows.Count < 10)
                {
                    ClassLibrary.Model.RouteClass crc = gList.Find(delegate(ClassLibrary.Model.RouteClass rc) { return rc.ID == routeClassId; });
                    if (crc.ClassLevel == 4)
                    {
                        DataTable table4 = newsBll.GetData(10, where + " and CHARINDEX('," + crc.ParentID + ",',','+routeClassID+',') > 0 ", "ID desc");
                        table.Merge(table4);
                        table = table.AsDataView().ToTable(true);
                    }
                }
            }
            if (table.Rows.Count < 10)
            {
                DataSet mySet2 = newsBll.GetPageData(10, 1, where, "ID desc ");
                DataTable table2 = mySet2.Tables["Data"];
                table.Merge(table2);
                table = table.AsDataView().ToTable(true);
            }

            int i = 0;
            List<ClassLibrary.Model.News> raList = newsBll.GetModelList(table);
            foreach (ClassLibrary.Model.News model in raList)
            {
                i++;
                string preurl = Enum.GetName(typeof(SysConfig.NewsClassPY), model.newsClassID);

                sb.AppendFormat("<li><a href='{0}/{1}/{2}.html' title='{3}' target='_blank'>{4}</a><span>{5}</span></li>",
                    SysConfig.webSite, preurl, model.ID, model.Title, Function.Clip(model.Title, 20, false), model.CreatedTime.ToString("yyyy-MM-dd")).AppendLine();
                if (i >= 10) break;
            }

            relateArticleList = sb.ToString();
        }
        private void BindNewsList()
        {
            StringBuilder sb = new StringBuilder();
            DataTable table = newsBll.GetData(8, "isDisplay = 1", "Createdtime desc");
            int i = 0;
            foreach (DataRow dr in table.Rows)
            {
                i++;
                sb.AppendFormat("<li class='{0}'>", (i == 8 || i == table.Rows.Count) ? "lastline" : "");
                sb.AppendFormat("<a class='side_title_n' href='{3}/{2}/{0}.html' target='_blank' title='{4}'>{1}</a>",
                    dr["ID"], Function.Clip(dr["Title"].ToString(), 15, true), Enum.GetName(typeof(SysConfig.NewsClassPY),Convert.ToInt32(dr["newsClassId"])), SysConfig.webSite, dr["Title"].ToString()).AppendLine();
                sb.AppendLine("</li>");
            }

            dataGongLuList = sb.ToString();
        }
        
        private void BindRouteSales()
        {
            StringBuilder sb = new StringBuilder();
            string where = "isdisplay=1 and CHARINDEX('," + routeClassId + ",',','+routesPrentClassID+',')>0";
            DataSet mySet = routeBll.GetPageData(5, 1, where, "RecommendHot Desc,RouteOrder Asc,Createdtime Desc");
            DataTable table = mySet.Tables["Data"];

            int countRows = table.Rows.Count;

            if (countRows < 5)
            {
                DataSet mySet2 = routeBll.GetPageData(5, 1, "isdisplay=1", "id desc");
                DataTable table2 = mySet2.Tables["Data"];
                table.Merge(table2);
                table = table.AsDataView().ToTable(true);
            }
            int i = 0;
            List<ClassLibrary.Model.Routes> pgRouteList = routeBll.GetModelList(table);
            foreach (ClassLibrary.Model.Routes model in pgRouteList)
            {
                string tmpPy = gList.Find(delegate(ClassLibrary.Model.RouteClass tm) { return tm.ID == model.LocationID; }).ClassNamePY;
                string[] images = model.Image.Split(',');
                i++;
                sb.AppendFormat("<li class='{0}'>", (i == 5 || i == pgRouteList.Count) ? "lastline" : "");
                sb.AppendLine("<div class='item_order'><span>" + i + "</span></div>");
                sb.AppendFormat("<a href='{4}/{3}/{2}.html' title='{0}' rel='nofollow'><img alt='{0}' src='{1}' width='202' height='128' /></a>",
                    model.Title, SysConfig.UploadFilePathRoutesImg + images[0], model.ID, tmpPy, SysConfig.webSite).AppendLine();
                sb.AppendFormat("<div class='item_title'><a href='{3}/{2}/{0}.html' title='{4}'>{1}</a></div>",
                    model.ID, Function.Clip(model.Title, 33, true), tmpPy, SysConfig.webSite, model.Title).AppendLine();
                string tp = string.Format("&yen;{0}起", Convert.ToInt32(model.Price));
                if (Convert.ToInt32(model.Price) == 0) tp = "电询";
                sb.AppendFormat("<div class='item_visit'><div class='visit_cnt'><i></i>{0}次</div><div class='item_price'>{1}</div></div>",
                    model.ViewCount, tp);
                sb.AppendLine("</li>");

                if (i == 5) break;
            }
            dataSalesList = sb.ToString();
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
            }
            appurl = SysConfig.webSiteApp + Request.RawUrl;
        }

        //新闻详情
        private void BindInfo()
        {
            news = newsBll.GetModel(newsID);
            if (news.Title == "")
            {
                Response.StatusCode = 404;
                Response.End();
            }
            routeClassId = news.LocationID;
            gList = rcBll.GetModelList(String.Empty);

            ClassLibrary.Model.RouteClass rcmodel = gList.Find(delegate(ClassLibrary.Model.RouteClass rc) { return rc.ID == routeClassId; });
            
            displayPing = rcmodel.ClassNamePY;
            displayName = rcmodel.ClassName;
            ntag = news.Ntag.Replace(",", "&nbsp;&nbsp;&nbsp;&nbsp;").Replace("，", "&nbsp;&nbsp;&nbsp;&nbsp;");
            zanCount = news.ZanCount;
            articleTitle = news.Title;
        }

        //导航
        private void GetLocation()
        {
            string preUrl = "";
            string preUrlName = "";

            preUrl = SysConfig.webSite + "/" + Enum.GetName(typeof(SysConfig.NewsClassPY), news.newsClassID) + "/";
            preUrlName = Enum.GetName(typeof(SysConfig.NewsClass), news.newsClassID);
            location += string.Format("<i class='next'></i><a href='{0}' >{1}</a>", preUrl, preUrlName);
            location += string.Format("<i class='next'></i>{0}", news.Title);
        }
        //上一篇、下一篇
        private void BindPrevAndNextNews()
        {
            StringBuilder sb = new StringBuilder();

            DataTable tbPrev = newsBll.GetPrevData(newsID);
            DataTable tbNext = newsBll.GetNextData(newsID);

            if(tbPrev.Rows.Count ==0)
            {
                sb.Append("<div class='prevLink'>上一篇：<a>没有上一篇</a></div>");
            }
            else
            {
                int tmpNewsClassId = Int32.Parse(tbPrev.Rows[0]["newsClassId"].ToString());

                sb.AppendFormat("<div class='prevLink'>上一篇：<a href='{5}/{0}/{1}.html' title='{2}'>{3}</a><span>({4})</span></div>",
                    Enum.GetName(typeof(SysConfig.NewsClassPY), tmpNewsClassId),
                    tbPrev.Rows[0]["ID"].ToString(),
                    tbPrev.Rows[0]["Title"].ToString(),
                    Function.Clip(tbPrev.Rows[0]["Title"].ToString(), 20, true),
                    Function.ToSortTime(Convert.ToDateTime(tbPrev.Rows[0]["CreatedTime"])),
                    SysConfig.webSite);
            }

            if (tbNext.Rows.Count == 0)
            {
                sb.Append("<div class='nextLink'>下一篇：<a>没有下一篇</a></div>");
            }
            else
            {
                int tmpNewsClassId = Int32.Parse(tbNext.Rows[0]["newsClassId"].ToString());

                sb.AppendFormat("<div class='nextLink'>下一篇：<a href='{5}/{4}/{0}.html' title='{3}'>{1}</a><span>({2})</span></div>",
                    tbNext.Rows[0]["ID"].ToString(),
                    Function.Clip(tbNext.Rows[0]["Title"].ToString(), 20, true),
                    Function.ToSortTime(Convert.ToDateTime(tbNext.Rows[0]["CreatedTime"])),
                    tbNext.Rows[0]["Title"].ToString(),
                    Enum.GetName(typeof(SysConfig.NewsClassPY), tmpNewsClassId),
                    SysConfig.webSite);
            }
            prevAndNexLink = sb.ToString();
        }

    }
}