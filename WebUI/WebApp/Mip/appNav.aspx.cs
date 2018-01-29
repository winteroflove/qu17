using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using ClassLibrary.Common;

namespace WebUI.WebApp.Mip
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
                sb.AppendFormat("<a href='{0}/mip/{1}/' target='_blank'>{2}</a>", SysConfig.webSiteApp, model.ClassNamePY, model.ClassName).AppendLine();
                if (i >= 4) break;
            }
            hotList = sb.ToString();
            sb.Length = 0;
            sb.AppendLine("<div class='mnav_item'>");
            sb.AppendLine("<mip-accordion sessions-key='mip_1' type='manual'>");
            sb.AppendLine("<section expanded>");
            //海岛
            sb.AppendLine("<h4 class='nav_left'>海岛</h4>");
            sb.AppendLine("<div class='nav_right'>");
            sb.AppendLine("<div class='navlist'>");
            List<ClassLibrary.Model.RouteClass> hdList = routeList.FindAll(delegate(ClassLibrary.Model.RouteClass rc) { return rc.IsHaidao; });
            foreach (ClassLibrary.Model.RouteClass model in hdList)
            {
                sb.AppendFormat("<a href='{0}/mip/{1}/' target='_blank'>{2}</a>", SysConfig.webSiteApp, model.ClassNamePY, model.ClassName).AppendLine();
            }
            sb.AppendLine("</div>");
            sb.AppendLine("</div>");
            sb.AppendLine("</section>");

            //出境
            sb.AppendLine("<section>");
            sb.AppendFormat("<h4 class='nav_left'><a href='{0}/mip/chujing/' target='_blank'>出境</a></h4>", SysConfig.webSiteApp).AppendLine();
            sb.AppendLine("<div class='nav_right'>");
            List<ClassLibrary.Model.RouteClass> cjList = routeList.FindAll(delegate(ClassLibrary.Model.RouteClass rc) { return rc.ParentID == (int)SysConfig.RouteClass.出境旅游; });
            foreach (ClassLibrary.Model.RouteClass model in cjList)
            {
                sb.AppendLine("<div class='nrlitem'>");
                sb.AppendFormat("<div class='navgroup'><a href='{0}/mip/{1}/' target='_blank'>{2}</a><span class='grouplist'></span></div>",
                    SysConfig.webSiteApp, model.ClassNamePY, model.ClassName);
                sb.AppendLine("<div class='navlist'>");
                List<ClassLibrary.Model.RouteClass> cjLevelList = routeList.FindAll(delegate(ClassLibrary.Model.RouteClass rc) { return rc.ParentID == model.ID; });
                foreach (ClassLibrary.Model.RouteClass model2 in cjLevelList)
                {
                    sb.AppendFormat("<a href='{0}/mip/{1}/' target='_blank'>{2}</a>", SysConfig.webSiteApp, model2.ClassNamePY, model2.ClassName).AppendLine();
                }
                sb.AppendLine("</div>");
                sb.AppendLine("</div>");
            }
            sb.AppendLine("</div>");
            sb.AppendLine("</section>");

            //国内
            sb.AppendLine("<section>");
            sb.AppendFormat("<h4 class='nav_left'><a href='{0}/mip/guonei/' target='_blank'>国内</a></h4>", SysConfig.webSiteApp).AppendLine();
            sb.AppendLine("<div class='nav_right'>");
            List<ClassLibrary.Model.RouteClass> gnList = routeList.FindAll(delegate(ClassLibrary.Model.RouteClass rc) { return rc.ParentID == (int)SysConfig.RouteClass.国内旅游; });
            foreach (ClassLibrary.Model.RouteClass model in gnList)
            {
                List<ClassLibrary.Model.RouteClass> gnLevel2List = routeList.FindAll(delegate(ClassLibrary.Model.RouteClass rc) { return rc.ParentID == model.ID; });

                foreach (ClassLibrary.Model.RouteClass model2 in gnLevel2List)
                {
                    if (model2.ID == (int)SysConfig.RouteClass.重庆) continue;
                    sb.AppendLine("<div class='nrlitem'>");
                    sb.AppendFormat("<div class='navgroup'><a href='{0}/mip/{1}/' target='_blank'>{2}</a><span class='grouplist'></span></div>",
                    SysConfig.webSiteApp, model2.ClassNamePY, model2.ClassName);
                    sb.AppendLine("<div class='navlist'>");
                    List<ClassLibrary.Model.RouteClass> gnLevelList = routeList.FindAll(delegate(ClassLibrary.Model.RouteClass rc) { return rc.ParentID == model2.ID; });
                    foreach (ClassLibrary.Model.RouteClass model3 in gnLevelList)
                    {
                        sb.AppendFormat("<a href='{0}/mip/{1}/' target='_blank'>{2}</a>", SysConfig.webSiteApp, model3.ClassNamePY, model3.ClassName).AppendLine();
                    }
                    sb.AppendLine("</div>");
                    sb.AppendLine("</div>");
                }
            }
            sb.AppendLine("</div>");
            sb.AppendLine("</section>");

            //三峡
            sb.AppendLine("<section>");
            sb.AppendFormat("<h4 class='nav_left'><a href='{0}/mip/sanxia/' target='_blank'>三峡</a></h4>", SysConfig.webSiteApp).AppendLine();
            sb.AppendLine("<div class='nav_right'>");
            sb.AppendLine("<div class='nrlitem'>");
            sb.AppendFormat("<div class='navgroup'><a href='{0}/mip/{1}/' target='_blank'>{2}</a></div>",
                SysConfig.webSiteApp, "guoneichuan", "国内游船");
            sb.AppendLine("</div>");
            sb.AppendLine("<div class='nrlitem'>");
            sb.AppendFormat("<div class='navgroup'><a href='{0}/mip/{1}/' target='_blank'>{2}</a></div>",
                SysConfig.webSiteApp, "haohuachuan", "豪华游轮");
            List<ClassLibrary.Model.RouteClass> sxList = routeList.FindAll(delegate(ClassLibrary.Model.RouteClass rc) { return rc.ParentID == (int)SysConfig.RouteClass.豪华船; });
            sb.AppendLine("<div class='navlist'>");
            foreach (ClassLibrary.Model.RouteClass model in sxList)
            {
                sb.AppendFormat("<a href='{0}/mip/{1}/' target='_blank'>{2}</a>", SysConfig.webSiteApp, model.ClassNamePY, model.ClassName).AppendLine();
            }
            sb.AppendLine("</div>");
            sb.AppendLine("</div>");
            sb.AppendLine("</div>");
            sb.AppendLine("</section>");

            //周边
            sb.AppendLine("<section>");
            sb.AppendFormat("<h4 class='nav_left'><a href='{0}/mip/chongqing/' target='_blank'>周边</a></h4>", SysConfig.webSiteApp).AppendLine();
            sb.AppendLine("<div class='nav_right'>");
            sb.AppendLine("<div class='navlist'>");
            List<ClassLibrary.Model.RouteClass> cqList = routeList.FindAll(delegate(ClassLibrary.Model.RouteClass rc) { return rc.ParentID == (int)SysConfig.RouteClass.重庆; });
            foreach (ClassLibrary.Model.RouteClass model in cqList)
            {
                sb.AppendFormat("<a href='{0}/mip/{1}/' target='_blank'>{2}</a>", SysConfig.webSiteApp, model.ClassNamePY, model.ClassName).AppendLine();
            }
            sb.AppendLine("</div>");
            sb.AppendLine("</div>");
            sb.AppendLine("</section>");

            //主题
            sb.AppendLine("<section>");
            sb.AppendLine("<h4 class='nav_left'>主题</h4>");
            sb.AppendLine("<div class='nav_right'>");
            sb.AppendLine("<div class='navlist'>");
            ClassLibrary.BLL.RouteType rtBll = new ClassLibrary.BLL.RouteType();
            List<ClassLibrary.Model.RouteType> ztList = rtBll.GetModelList(string.Empty, "ClassOrder Asc, CreatedTime Desc");
            foreach (ClassLibrary.Model.RouteType model in ztList)
            {
                sb.AppendFormat("<a href='{0}/mip/{1}/' target='_blank'>{2}</a>", SysConfig.webSiteApp, model.classNamePY, model.ClassName).AppendLine();
            }
            sb.AppendLine("</div>");
            sb.AppendLine("</div>");
            sb.AppendLine("</section>");

            sb.AppendLine("</mip-accordion>");
            sb.AppendLine("</div>");
            navList = sb.ToString();
        }
    }
}