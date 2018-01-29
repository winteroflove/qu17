using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using ClassLibrary.Common;

namespace WebUI.WebApp
{
    public partial class appNav : System.Web.UI.Page
    {
        protected string navList = "";
        protected string hotList = "";
        ClassLibrary.BLL.RouteClass rcBll = new ClassLibrary.BLL.RouteClass();

        protected void Page_Load(object sender, EventArgs e)
        {
            BindNav();
        }
        private void BindNav()
        {
            StringBuilder sb = new StringBuilder();
            List<ClassLibrary.Model.RouteClass> routeList = rcBll.GetModelList(string.Empty, "ClassOrder Asc");

            List<ClassLibrary.Model.RouteClass> hotRCList = routeList.FindAll(delegate(ClassLibrary.Model.RouteClass rc) { return rc.ClassLevel >= 3 && rc.Recommend; });
            int i = 0;
            foreach (ClassLibrary.Model.RouteClass model in hotRCList)
            {
                if (model.ParentID == (int)SysConfig.RouteClass.重庆 || model.ParentID == (int)SysConfig.RouteClass.豪华船) continue;
                i++;
                sb.AppendFormat("<a href='{0}/{1}/'>{2}</a>", SysConfig.webSiteApp, model.ClassNamePY, model.ClassName).AppendLine();
                if (i >= 4) break;
            }
            hotList = sb.ToString();
            sb.Length = 0;

            //海岛
            sb.AppendLine("<div class='mnav_item'>");
            sb.AppendLine("<div class='nav_left current'>海岛</div>");
            sb.AppendLine("<div class='nav_right'>");
            sb.AppendLine("<div class='navlist'>");
            List<ClassLibrary.Model.RouteClass> hdList = routeList.FindAll(delegate(ClassLibrary.Model.RouteClass rc) { return rc.IsHaidao; });
            foreach (ClassLibrary.Model.RouteClass model in hdList)
            {
                sb.AppendFormat("<a href='{0}/{1}/'>{2}</a>", SysConfig.webSiteApp, model.ClassNamePY, model.ClassName).AppendLine();
            }
            sb.AppendLine("</div>");
            sb.AppendLine("</div>");
            sb.AppendLine("</div>");
            
            //出境
            sb.AppendLine("<div class='mnav_item'>");
            sb.AppendLine("<div class='nav_left'>出境</div>");
            sb.AppendLine("<div class='nav_right t_cj hide' id='navcj'>");
            List<ClassLibrary.Model.RouteClass> cjList = routeList.FindAll(delegate(ClassLibrary.Model.RouteClass rc) { return rc.ParentID == (int)SysConfig.RouteClass.出境旅游; });
            foreach (ClassLibrary.Model.RouteClass model in cjList)
            {
                sb.AppendLine("<div class='nrlitem'>");
                sb.AppendFormat("<div class='navgroup'><a href='{0}/{1}/'>{2}</a><span class='grouplist'></span></div>",
                    SysConfig.webSiteApp, model.ClassNamePY, model.ClassName);
                sb.AppendLine("<div class='navlist'>");
                List<ClassLibrary.Model.RouteClass> cjLevelList = routeList.FindAll(delegate(ClassLibrary.Model.RouteClass rc) { return rc.ParentID == model.ID; });
                foreach (ClassLibrary.Model.RouteClass model2 in cjLevelList)
                {
                    sb.AppendFormat("<a href='{0}/{1}/'>{2}</a>", SysConfig.webSiteApp, model2.ClassNamePY, model2.ClassName).AppendLine();
                }
                sb.AppendLine("</div>");
                sb.AppendLine("</div>");
            }
            sb.AppendLine("</div>");
            sb.AppendLine("</div>");

            //国内
            sb.AppendLine("<div class='mnav_item'>");
            sb.AppendLine("<div class='nav_left'>国内</div>");
            sb.AppendLine("<div class='nav_right t_gn hide' id='navgn'>");
            List<ClassLibrary.Model.RouteClass> gnList = routeList.FindAll(delegate(ClassLibrary.Model.RouteClass rc) { return rc.ParentID == (int)SysConfig.RouteClass.国内旅游; });
            foreach (ClassLibrary.Model.RouteClass model in gnList)
            {
                List<ClassLibrary.Model.RouteClass> gnLevel2List = routeList.FindAll(delegate(ClassLibrary.Model.RouteClass rc) { return rc.ParentID == model.ID; });

                foreach (ClassLibrary.Model.RouteClass model2 in gnLevel2List)
                {
                    if (model2.ID == (int)SysConfig.RouteClass.重庆) continue;
                    sb.AppendLine("<div class='nrlitem'>");
                    sb.AppendFormat("<div class='navgroup'><a href='{0}/{1}/'>{2}</a><span class='grouplist'></span></div>",
                    SysConfig.webSiteApp, model2.ClassNamePY, model2.ClassName);
                    sb.AppendLine("<div class='navlist'>");
                    List<ClassLibrary.Model.RouteClass> gnLevelList = routeList.FindAll(delegate(ClassLibrary.Model.RouteClass rc) { return rc.ParentID == model2.ID; });
                    foreach (ClassLibrary.Model.RouteClass model3 in gnLevelList)
                    {
                        sb.AppendFormat("<a href='{0}/{1}/'>{2}</a>", SysConfig.webSiteApp, model3.ClassNamePY, model3.ClassName).AppendLine();
                    }
                    sb.AppendLine("</div>");
                    sb.AppendLine("</div>");
                }
            }
            sb.AppendLine("</div>");
            sb.AppendLine("</div>");

            //三峡
            sb.AppendLine("<div class='mnav_item'>");
            sb.AppendLine("<div class='nav_left'>三峡</div>");
            sb.AppendLine("<div class='nav_right t_sx hide'>");
            sb.AppendLine("<div class='nrlitem'>");
            sb.AppendFormat("<div class='navgroup'><a href='{0}/{1}/'>{2}</a></div>",
                SysConfig.webSiteApp, "guoneichuan", "国内游船");
            sb.AppendLine("</div>");
            sb.AppendLine("<div class='nrlitem'>");
            sb.AppendFormat("<div class='navgroup'><a href='{0}/{1}/'>{2}</a></div>",
                SysConfig.webSiteApp, "haohuachuan", "豪华游轮");
            List<ClassLibrary.Model.RouteClass> sxList = routeList.FindAll(delegate(ClassLibrary.Model.RouteClass rc) { return rc.ParentID == (int)SysConfig.RouteClass.豪华船; });
            sb.AppendLine("<div class='navlist' style='display:block;'>");
            foreach (ClassLibrary.Model.RouteClass model in sxList)
            {
                sb.AppendFormat("<a href='{0}/{1}/'>{2}</a>", SysConfig.webSiteApp, model.ClassNamePY, model.ClassName).AppendLine();
            }
            sb.AppendLine("</div>");
            sb.AppendLine("</div>");
            sb.AppendLine("</div>");
            sb.AppendLine("</div>");

            //周边
            sb.AppendLine("<div class='mnav_item'>");
            sb.AppendLine("<div class='nav_left'>周边</div>");
            sb.AppendLine("<div class='nav_right t_zb hide'>");
            sb.AppendLine("<div class='navlist'>");
            List<ClassLibrary.Model.RouteClass> cqList = routeList.FindAll(delegate(ClassLibrary.Model.RouteClass rc) { return rc.ParentID == (int)SysConfig.RouteClass.重庆; });
            foreach (ClassLibrary.Model.RouteClass model in cqList)
            {
                sb.AppendFormat("<a href='{0}/{1}/'>{2}</a>", SysConfig.webSiteApp, model.ClassNamePY, model.ClassName).AppendLine();
            }
            sb.AppendLine("</div>");
            sb.AppendLine("</div>");
            sb.AppendLine("</div>");

            //主题
            sb.AppendLine("<div class='mnav_item'>");
            sb.AppendLine("<div class='nav_left'>主题</div>");
            sb.AppendLine("<div class='nav_right t_zt hide'>");
            sb.AppendLine("<div class='navlist'>");
            ClassLibrary.BLL.RouteType rtBll = new ClassLibrary.BLL.RouteType();
            List<ClassLibrary.Model.RouteType> ztList = rtBll.GetModelList(string.Empty, "ClassOrder Asc, CreatedTime Desc");
            foreach (ClassLibrary.Model.RouteType model in ztList)
            {
                sb.AppendFormat("<a href='{0}/{1}/'>{2}</a>", SysConfig.webSiteApp, model.classNamePY, model.ClassName).AppendLine();
            }
            sb.AppendLine("</div>");
            sb.AppendLine("</div>");
            sb.AppendLine("</div>");

            navList = sb.ToString();
        }
    }
}