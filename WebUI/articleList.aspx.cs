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
    public partial class articleList : System.Web.UI.Page 
    {
        protected int nid = 0;
        protected string location;
        protected string pageInfo;
        protected string dataArticleList;
        Pagination pg = new Pagination();
        int pageIndex = 0;
        protected string typeName = "";

        ClassLibrary.BLL.RouteClass rcBll = new ClassLibrary.BLL.RouteClass();
        ClassLibrary.BLL.News newsBll = new ClassLibrary.BLL.News();
        ClassLibrary.BLL.Routes routeBll = new ClassLibrary.BLL.Routes();
        List<ClassLibrary.Model.RouteClass> gList = new List<ClassLibrary.Model.RouteClass>();

        protected string dataSalesList = "";
        protected string dataScenicList = "";
        protected string dataGongLuList = "";
        protected string appurl = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            GetArgument();
            GetLocation();
            BindArticleList();
            BindRouteSales();
        }
        public void BindRouteSales()
        {
            StringBuilder sb = new StringBuilder();

            DataSet mySet = routeBll.GetPageData(5, 1, "isdisplay=1", "RecommendHot Desc,RouteOrder Asc,Createdtime desc");
            DataTable table = mySet.Tables["Data"];

            int i = 0;
            foreach (DataRow dr in table.Rows)
            {
                i++;
                int tmpClassId = Convert.ToInt32(dr["LocationID"].ToString());
                string tmpPy = gList.Find(delegate(ClassLibrary.Model.RouteClass tm) { return tm.ID == tmpClassId; }).ClassNamePY;

                sb.AppendFormat("<li class='{0} {1}'>", i == 1 ? "on" : "", (i == 5 || i == table.Rows.Count) ? "lastline" : "");
                sb.AppendFormat("<div class='side_rec_no'><span>{0}</span></div>", i);
                sb.AppendFormat("<a class='side_img' href='{0}/{1}/{2}.html' title='{3}' target='_blank' rel='nofollow'><img src='{4}' alt='' width='90px' height='68px' /></a>",
                    SysConfig.webSite, tmpPy, dr["ID"], dr["Title"], SysConfig.UploadFilePathRoutesImg + dr["Image"].ToString().Split(',')[0]);
                sb.AppendLine("<div class='side_info'>");
                sb.AppendFormat("<a class='side_title' href='{0}/{1}/{2}.html' title='{3}' target='_blank'>{4}</a>",
                    SysConfig.webSite, tmpPy, dr["ID"], dr["Title"], Function.Clip(dr["Title"].ToString(), 30, true));
                sb.AppendFormat("<span class='side_price'>&yen;<em>{0}</em>起</span>", Convert.ToInt32(dr["price"]));
                sb.AppendLine("</div>");
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
                nid = Convert.ToInt32(strNewsID);
                if (nid != 1 && nid != 2)
                {
                    Response.StatusCode = 404;
                    Response.End();
                }
            }
            else
            {
                Response.StatusCode = 404;
                Response.End();
            }
            appurl = SysConfig.webSiteApp + "/" + Enum.GetName(typeof(SysConfig.NewsClassPY), nid) + "/";

            gList = rcBll.GetModelList(String.Empty);
            
            string strPageIndex = Request.QueryString["page"];
            if (ClassLibrary.Common.Function.IsNumber(strPageIndex))
            {
                pageIndex = Convert.ToInt32(strPageIndex);
            }
            else
            {
                pageIndex = 1;
            }
        }

        //导航
        private void GetLocation()
        {
            typeName = Enum.GetName(typeof(SysConfig.NewsClass), nid);
        }

        //列表
        private void BindArticleList()
        {
            string where = "isdisplay = 1 and newsClassId = " + nid;
            
            DataSet mySet = newsBll.GetPageData(10, pageIndex, where, "ID desc");
            DataTable tableCount = mySet.Tables["Count"];
            DataTable myTable = mySet.Tables["Data"];

            int countRows = 0;
            countRows = Convert.ToInt32(tableCount.Rows[0][0].ToString());

            string currUrl = SysConfig.webSite + "/" + Enum.GetName(typeof(SysConfig.NewsClassPY), nid) + "/";
            pageInfo = pg.pagination4(countRows, 10, pageIndex, currUrl);

            StringBuilder sb = new StringBuilder();
            int i = 0;
            List<ClassLibrary.Model.News> newsList = newsBll.GetModelList(myTable);
            string preurl = Enum.GetName(typeof(SysConfig.NewsClassPY), nid);
            foreach (ClassLibrary.Model.News model in newsList)
            {
                i++;
                sb.AppendFormat("<li class='{0}'>", i == 10 ? "lastline" : "").AppendLine();
                sb.AppendLine("<div class='dstn_gl_img'>");
                string aimg = "/image/defaultImg.jpg";
                if (model.Image != "")
                {
                    aimg = SysConfig.UploadFilePathNewsImg + model.Image;
                }
                sb.AppendFormat("<a href='{0}/{4}/{1}.html' title='{2}' target='_blank' rel='nofollow'><img src='{3}' alt='' width='186' height='118' /></a>",
                    SysConfig.webSite, model.ID, model.Title, aimg, preurl).AppendLine();
                sb.AppendLine("</div>");
                sb.AppendLine("<div class='dstn_gl_detail'>");
                sb.AppendFormat("<div class='gl_detail_title'><a href='{0}/{4}/{1}.html' title='{2}' target='_blank'>{3}</a></div>",
                    SysConfig.webSite, model.ID, model.Title, Function.Clip(model.Title, 30, false), preurl).AppendLine();
                sb.AppendFormat("<div class='gl_detail_info'><div class='gl_detail_tag'>关键词：{0}</div><div class='gl_detail_time'>发表时间：{1}</div><div class='gl_detail_view'>{2}人浏览</div></div>", 
                    model.Ntag.Replace(",","&nbsp;&nbsp;&nbsp;&nbsp;").Replace("，","&nbsp;&nbsp;&nbsp;&nbsp;"), model.CreatedTime.ToString("yyyy-MM-dd"), Convert.ToInt32(model.ViewCount)).AppendLine();
                sb.AppendFormat("<div class='gl_detail_content'><p>{0}</p></div>", Function.Clip(Function.ClearHtml(model.Content), 150, true)).AppendLine();
                sb.AppendLine("</div>");
                sb.AppendLine("</li>");
            }

            if (sb.Length == 0)
            {
                sb.Append("<div class='nodata'>没有相关数据!</div>");
            }

            dataArticleList = sb.ToString();

        }

    }
}