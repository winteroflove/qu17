using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Text;
using System.Data;
using ClassLibrary.Common;

namespace WebUI
{
    public partial class about : System.Web.UI.Page
    {
        protected int systemArticleID;
        protected ClassLibrary.Model.SystemArticle model = new ClassLibrary.Model.SystemArticle();
        protected string dataSalesList = "";
        protected string dataHotRoute = "";
        protected string appurl = SysConfig.webSiteApp + "/aboutus/";

        ClassLibrary.BLL.RouteClass rcBll = new ClassLibrary.BLL.RouteClass();
        ClassLibrary.BLL.Routes routeBll = new ClassLibrary.BLL.Routes();
        List<ClassLibrary.Model.RouteClass> gList = new List<ClassLibrary.Model.RouteClass>();

        protected void Page_Load(object sender, EventArgs e)
        {
            GetArgument();
            BindInfo();
            BindRouteClass();
            BindRouteSales();
        }
        public void BindRouteSales()
        {
            StringBuilder sb = new StringBuilder();
            DataSet mySet = routeBll.GetPageData(5, 1, "isdisplay=1", "RecommendHot Desc,RouteOrder Asc,Createdtime Desc");
            DataTable table = mySet.Tables["Data"];

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
            string strSystemArticleID = Function.GetQueryString("id");
            if (Function.IsNumber(strSystemArticleID))
            {
                systemArticleID = Convert.ToInt32(strSystemArticleID);
                if (systemArticleID != 1 && systemArticleID != 2)
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
        }

        private void BindInfo()
        {
            ClassLibrary.BLL.SystemArticle bll = new ClassLibrary.BLL.SystemArticle();
            model = bll.GetModel(systemArticleID);
        }
        private void BindRouteClass()
        {
            gList = rcBll.GetModelList(String.Empty);
        }

    }
}
