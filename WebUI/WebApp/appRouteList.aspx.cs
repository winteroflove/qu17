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
    public partial class appRouteList : System.Web.UI.Page
    {
        protected int pid = 0;
        protected int cid = 0;
        protected string displayName = "";
        int pageIndex;
        protected int countPage = 0;
        protected string hotClassList = "";
        protected string dataRouteList = "";
        protected string pageInfo = "";
        bool isZhuti = false;
        protected string mipUrl = "";

        ClassLibrary.BLL.Routes bll = new ClassLibrary.BLL.Routes();
        ClassLibrary.BLL.RouteClass routeClassBLL = new ClassLibrary.BLL.RouteClass();
        ClassLibrary.BLL.RouteType routeTypeBll = new ClassLibrary.BLL.RouteType();
        ClassLibrary.Model.RouteClass currClass = new ClassLibrary.Model.RouteClass();
        ClassLibrary.Model.RouteType currZtClass = new ClassLibrary.Model.RouteType();
        List<ClassLibrary.Model.RouteClass> glClass = new List<ClassLibrary.Model.RouteClass>();
        List<ClassLibrary.Model.RouteType> grtClass = new List<ClassLibrary.Model.RouteType>();

        protected void Page_Load(object sender, EventArgs e)
        {
            GetArgument();
            BindHotArea();
            BindRouteList();
        }

        private void BindRouteList()
        {
            string routewhere = " isdisplay=1 ";

            if (pid == 0)
            {
                routewhere += " and charindex('," + cid + ",',','+themeId+',')>0";
            }
            else
            {
                routewhere += " and charindex('," + cid + ",',','+routesPrentClassID+',')>0";
            }
            
            ClassLibrary.Common.Pagination pg = new ClassLibrary.Common.Pagination();
            //ClassLibrary.BLL.Routes rbll = new ClassLibrary.BLL.Routes();

            DataSet mySet = bll.GetPageData(10, pageIndex, routewhere, "RouteOrder Asc, CreatedTime Desc");
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
            /*if (countPage > 1)
            {
                //if (pageIndex != 1)
                //{
                //    pageInfo += string.Format("<a class='pagelink' rel='nofollow' href='{0}/{1}/{2}'>上一页</a>",
                //        SysConfig.webSiteApp, currClass.ClassNamePY, pageIndex == 2 ? "" : ("page" + (pageIndex - 1)));
                //}
                //if (countPage > pageIndex)
                //{
                //    pageInfo += string.Format("<a class='pagelink' rel='nofollow' href='{0}/{1}/page{2}'>更&nbsp;&nbsp;多</a>",
                //        SysConfig.webSiteApp, currClass.ClassNamePY, pageIndex + 1);
                //}
                pageInfo += string.Format("<a class='pagelink' rel='nofollow' onclick='loadMore({0},{1},{2},{3})' >更&nbsp;&nbsp;多</a>",
                    pageIndex + 1, countPage, cid, pid);
            }*/
            StringBuilder sb = new StringBuilder();
            List<ClassLibrary.Model.Routes> pgRouteList = bll.GetModelList(myTable);
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
            if (sb.Length == 0)
            {
                sb.Append("<div class='nopagedata'>没有相关旅游线路</div>");
            }
            dataRouteList = sb.ToString();
        }

        private void BindHotArea()
        {
            StringBuilder sb = new StringBuilder();
            if (!isZhuti)
            {
                List<ClassLibrary.Model.RouteClass> hotRcList = new List<ClassLibrary.Model.RouteClass>();
                if (pid == (int)SysConfig.RouteClass.国内旅游)
                {
                    hotRcList = routeClassBLL.GetSubList((int)SysConfig.RouteClass.国内旅游, "ClassLevel = 3", "ClassOrder Asc");
                }
                else
                {
                    hotRcList = glClass.FindAll(delegate(ClassLibrary.Model.RouteClass rc) { return rc.ParentID == pid; });
                }
                int i = 0;
                foreach (ClassLibrary.Model.RouteClass model in hotRcList)
                {
                    i++;
                    sb.AppendFormat("<li><a href='{0}/{1}/' title='{2}旅游'>{2}</a></li>", SysConfig.webSiteApp, model.ClassNamePY, model.ClassName);
                    if (i >= 8) break;
                }
            }
            else
            {
                int i = 0;
                foreach (ClassLibrary.Model.RouteType model in grtClass)
                {
                    i++;
                    sb.AppendFormat("<li><a href='{0}/{1}/' title='{2}旅游'>{2}</a></li>", SysConfig.webSiteApp, model.classNamePY, model.ClassName);
                    if (i >= 8) break;
                }
            }
            hotClassList = sb.ToString();
        }

        private void GetArgument()
        {
            string pingyin = Function.GetQueryString("py");
            glClass = routeClassBLL.GetModelList(String.Empty, "ClassOrder Asc");
            grtClass = routeTypeBll.GetModelList(String.Empty, "ClassOrder Asc");
            mipUrl = SysConfig.webSiteApp + "/mip/" + pingyin + "/";

            if (pingyin != "")
            {
                currClass = glClass.Find(delegate(ClassLibrary.Model.RouteClass tm) { return tm.ClassNamePY == pingyin; });

                if (currClass == null)
                {
                    currZtClass = grtClass.Find(delegate(ClassLibrary.Model.RouteType tm) { return tm.classNamePY == pingyin; });
                    if (currZtClass == null)
                    {
                        Response.StatusCode = 404;
                        Response.End();
                    }
                    else
                    {
                        isZhuti = true;
                    }
                }
            }
            else
            {
                Response.StatusCode = 404;
                Response.End();
            }
            if (!isZhuti)
            {
                cid = currClass.ID;

                List<ClassLibrary.Model.RouteClass> classList = glClass.FindAll(delegate(ClassLibrary.Model.RouteClass tm) { return tm.ParentID == cid; });
                if (classList.Count == 0)
                {
                    pid = currClass.ParentID;
                }
                else
                {
                    pid = cid;
                }
                displayName = currClass.ClassName.Replace("旅游", "");
            }
            else
            {
                cid = currZtClass.ID;
                displayName = currZtClass.ClassName.Replace("游", "");
            }

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
    }
}