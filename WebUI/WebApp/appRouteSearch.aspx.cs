using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClassLibrary.Common;
using System.Text;
using System.Data;

namespace WebUI.WebApp
{
    public partial class appRouteSearch : System.Web.UI.Page
    {
        int pageIndex = 0;
        protected string pageInfo;
        protected int countPage = 0;
        protected string sKey = "";
        string urlKey = "";
        protected string dataRouteList = "";

        Pagination pg = new Pagination();
        ClassLibrary.BLL.Routes bll = new ClassLibrary.BLL.Routes();
        ClassLibrary.BLL.RouteClass routeClassBLL = new ClassLibrary.BLL.RouteClass();
        List<ClassLibrary.Model.RouteClass> glClass = new List<ClassLibrary.Model.RouteClass>();

        protected void Page_Load(object sender, EventArgs e)
        {
            GetArgument();
            BindRouteList();
        }
        private void GetArgument()
        {
            sKey = Request.QueryString["sk"];
            if (sKey == null) sKey = "";
            if (sKey == "")
            {
                Response.StatusCode = 404;
                Response.End();
            }
            urlKey = HttpUtility.UrlEncode(sKey, Encoding.UTF8);
            List<ClassLibrary.Model.RouteClass> tmpList = routeClassBLL.GetModelList("CHARINDEX('" + sKey + "', ClassName)>0 or CHARINDEX(ClassName,'" + sKey + "')>0", "ClassLevel Desc, Recommend Desc");
            if (tmpList.Count > 0)
            {
                ClassLibrary.Model.RouteClass tm = tmpList[0];
                if (tm.ParentID != (int)SysConfig.RouteClass.国内旅游)
                {
                    Response.Redirect(SysConfig.webSiteApp + "/" + tmpList[0].ClassNamePY + "/");
                }
            }
            glClass = routeClassBLL.GetModelList(String.Empty, "ClassLevel Desc, Recommend Desc");
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
        //线路
        private void BindRouteList()
        {
            string routewhere = " isdisplay=1 ";

            if (sKey != "")
            {
                //routewhere += " and (CHARINDEX('" + sKey + "',Title) > 0 or CHARINDEX('" + sKey + "',DescriptionRoute) > 0 or Exists(select RouteID from Routedetails where routeid=routes.ID and CHARINDEX('" + sKey + "',DayDetail)>0))";
                routewhere += " and CHARINDEX('" + sKey + "',Title) > 0 ";
            }
            string orderwhere = "routeOrder Asc";

            ClassLibrary.Common.Pagination pg = new ClassLibrary.Common.Pagination();
            //ClassLibrary.BLL.Routes rbll = new ClassLibrary.BLL.Routes();

            DataSet mySet = bll.GetPageData(10, pageIndex, routewhere, orderwhere);
            DataTable tableCount = mySet.Tables["Count"];
            DataTable myTable = mySet.Tables["Data"];

            int countRows = 0;
            countRows = Convert.ToInt32(tableCount.Rows[0][0].ToString());

            if (countRows % 10 == 0)
            {
                countPage = countRows / 10;
            }
            else
            {
                countPage = countRows / 10 + 1;
            }
            //if (countPage > 1)
            //{
            //    if (pageIndex != 1)
            //    {
            //        pageInfo += string.Format("<a class='pagelink' rel='nofollow' href='{0}/rkey{1}/{2}'>上一页</a>",
            //            SysConfig.webSiteApp, urlKey, pageIndex == 2 ? "" : ("page" + (pageIndex - 1)));
            //    }
            //    if (countPage > pageIndex)
            //    {
            //        pageInfo += string.Format("<a class='pagelink' rel='nofollow' href='{0}/rkey{1}/page{2}'>下一页</a>",
            //            SysConfig.webSiteApp, urlKey, pageIndex + 1);
            //    }
            //}
            StringBuilder sb = new StringBuilder();

            List<ClassLibrary.Model.Routes> pgRouteList = bll.GetModelList(myTable);
            foreach (ClassLibrary.Model.Routes model in pgRouteList)
            {
                string[] images = model.Image.Split(',');
                //int tmpClassId = Convert.ToInt32(model.routesClassID.Split(',')[1]);
                string tmpPy = glClass.Find(delegate(ClassLibrary.Model.RouteClass tm) { return tm.ID == model.LocationID; }).ClassNamePY;
                sb.AppendLine("<li>");
                sb.AppendFormat("<a href='{0}/{1}/{2}.html'>", SysConfig.webSiteApp, tmpPy, model.ID);
                sb.AppendFormat("<div class='hot_img' style='background-image:url({0}{1})'></div>", SysConfig.webSite, SysConfig.UploadFilePathRoutesImg + images[0]);
                sb.AppendFormat("<div class='hot_price'>&yen;<em>{0}</em>起</div>", Convert.ToInt32(model.Price));
                sb.AppendFormat("<div class='hot_title'>{0}</div>", Function.Clip(model.Title, 18, true));
                sb.AppendLine("</a>");
                sb.AppendLine("</li>");
            }
            if (sb.Length == 0)
            {
                sb.Append("<div class='nopagedata'>没有相关" + sKey + "旅游线路</div>");
            }
            dataRouteList = sb.ToString();
        }
    }
}