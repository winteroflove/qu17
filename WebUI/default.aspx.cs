using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Text;
using System.Data;
using LitJson;
using ClassLibrary.Common;
using System.Collections;
using System.IO;

namespace WebUI
{
    public partial class _default : System.Web.UI.Page
    {
        protected string DataScroll = "";//图片轮转
        protected string DataScrollTitles = "";//图片轮转
        protected string DataSaleAd = "";
        protected string dataGnCity = "";
        protected string dataCjCity = "";
        protected string dataCjScenic = "";
        protected string dataZbCity = "";
        protected string dataGnList = "";
        protected string dataCjList = "";
        protected string dataZbList = "";
        protected string dataSxList = "";
        protected string appurl = SysConfig.webSiteApp;

        protected bool hasSaleAd = true;

        protected int cqid = (int)SysConfig.RouteClass.重庆;
        protected int sanid = (int)SysConfig.RouteClass.三峡旅游;
        protected int homeid = (int)SysConfig.RouteClass.国内旅游;
        protected int outid = (int)SysConfig.RouteClass.出境旅游;
        List<ClassLibrary.Model.RouteClass> globalList;
        ClassLibrary.BLL.ScrollImages scrollBLL = new ClassLibrary.BLL.ScrollImages();
        ClassLibrary.BLL.SaleAdvertise adBll = new ClassLibrary.BLL.SaleAdvertise();
        ClassLibrary.BLL.Links linkBLL = new ClassLibrary.BLL.Links();
        ClassLibrary.BLL.Routes routeBLL = new ClassLibrary.BLL.Routes();
        ClassLibrary.BLL.RouteClass routeClassBll = new ClassLibrary.BLL.RouteClass();

        protected void Page_Load(object sender, EventArgs e)
        {
            BindScroll();
            BindSaleAd();

            globalList = routeClassBll.GetModelList(string.Empty, "ClassOrder Asc");

            dataGnCity = BindCityData(homeid, 3, true, 15);
            dataCjCity = BindCityData(outid, 3, false, 18);
            dataCjScenic = BindCityData(outid, 4, false, 18);
            dataZbCity = BindCityData(cqid, 4, false, 9);

            dataGnList = BindRouteList(homeid);
            dataCjList = BindRouteList(outid);
            dataZbList = BindRouteList(cqid);

            bindRouteForSX();

        }
        private void BindSaleAd()
        {
            string where = " ExpiredTime > '" + DateTime.Now.ToString("yyyy-MM-dd") + "'";
            List<ClassLibrary.Model.SaleAdvertise> sadList = adBll.GetModelList(4, where, "SaleOrder Asc, CreatedTime Desc");
            StringBuilder sb = new StringBuilder();
            foreach (ClassLibrary.Model.SaleAdvertise model in sadList)
            {
                sb.AppendFormat("<li><a href='{0}' title='{1}'><img src='{2}' alt='' width='272' height='345' /></a>",
                    model.LinkUrl, model.Title, SysConfig.UploadFilePathAdImg + model.Img).AppendLine();
                sb.AppendFormat("<a class='showimg' href='{0}' target='_blank' rel='nofollow'>查看</a></li>",
                    SysConfig.webSite + SysConfig.UploadFilePathAdImg + model.Img).AppendLine();
            }
            DataSaleAd = sb.ToString();
            if (DataSaleAd == "") hasSaleAd = false;
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
                sb.AppendFormat("<li style='display: {0};' class='{1}'><a href='{2}' target='_blank' title='{5}'><img {3}='{4}' alt='{5}' width='970' height='389' /></a></li>",
                    i == 1 ? "list-item" : "none", i == 1 ? "current" : "", dr["LinkURL"], i == 1 ? "src" : "data-src", SysConfig.UploadFilePathScrollImg + dr["Img"], dr["Title"]);
                sb2.AppendFormat("<li class='{0}' ><a href='{2}' target='_blank'>{1}</a></li>", i == 1 ? "current" : "", dr["Title"].ToString().Replace(",", "<br/>").Replace("，", "<br/>"), dr["LinkURL"]);
            }
            DataScroll = sb.ToString();
            DataScrollTitles = sb2.ToString();
        }

        private string BindCityData(int pid, int classlevel, bool currentLevel, int maxCount)
        {
            List<ClassLibrary.Model.RouteClass> rcList = routeClassBll.GetSubList(pid, " recommend=1 and classlevel " + (currentLevel ? ">=" : "=") + classlevel, "classOrder Asc, CreatedTime desc");
            StringBuilder sb = new StringBuilder();
            int i = 0;
            foreach (ClassLibrary.Model.RouteClass model in rcList)
            {
                if (model.ID == cqid || (pid == homeid && model.ParentID == cqid)) continue;
                i++;
                if (pid != outid) sb.AppendLine("<li>");
                sb.AppendFormat("<a href='{2}/{0}/' target='_blank'>{1}</a></li>", model.ClassNamePY, model.ClassName, SysConfig.webSite).AppendLine();
                if (pid != outid) sb.AppendLine("</li>");
                if (i == 3 && pid == cqid) sb.AppendFormat("<li class='inline'><a href='{0}/chongqing/day1/' target='_blank'>重庆周边一日游</a></li>", SysConfig.webSite);
                if (i == 6 && pid == cqid) sb.AppendFormat("<li class='inline'><a href='{0}/chongqing/day2/' target='_blank'>重庆周边二日游</a></li>", SysConfig.webSite);
                if (i >= maxCount) break;
            }
            
            return sb.ToString();
        }
        //国内出境周边旅游线路
        private string BindRouteList(int classId)
        {
            string where = "isdisplay=1 and (CHARINDEX('," + classId + ",',','+routesPrentClassID+',') > 0)";
            if (classId == homeid) where += "and (CHARINDEX('," + cqid + ",',','+routesPrentClassID+',') = 0)";
            DataTable mytable = routeBLL.GetData(6, where, " RecommendHot Desc, RouteOrder Asc, Createdtime Desc");
            List<ClassLibrary.Model.Routes> routeList = routeBLL.GetModelList(mytable);
            StringBuilder sb = new StringBuilder();
            foreach (ClassLibrary.Model.Routes model in routeList)
            {
                ClassLibrary.Model.RouteClass temModel = globalList.Find(delegate(ClassLibrary.Model.RouteClass tm) { return tm.ID == model.LocationID; });

                sb.AppendLine("<li>");
                sb.AppendFormat("<a href='{4}/{2}/{3}.html' title='{1}' target='_blank' rel='nofollow' class='imglink'><img alt='' src='{0}' width='264' height='153' /></a>",
                    SysConfig.UploadFilePathRoutesImg + model.Image.Split(',')[0], model.Title, temModel.ClassNamePY, model.ID, SysConfig.webSite);
                sb.AppendLine("<div class='rinfo'>");
                sb.AppendFormat("<a class='rlink' href='{4}/{2}/{3}.html' title='{1}' target='_blank'><span>{0}</span></a>",
                    Function.Clip(model.Title, 16, true), model.Title, temModel.ClassNamePY, model.ID, SysConfig.webSite);
                sb.AppendFormat("<div class='rprice'>&yen;<em>{0}</em>起</div>", Convert.ToInt32(model.Price));
                sb.AppendLine("</div>");
                sb.AppendLine("</li>");
            }
            return sb.ToString();
        }
        //三峡旅游线路
        private void bindRouteForSX()
        {
            List<ClassLibrary.Model.Routes> routeList = routeBLL.GetModelList(6, "isdisplay=1 and (CHARINDEX('," + sanid + ",',','+routesPrentClassID+',') > 0)", " RecommendHot Desc, RouteOrder Asc,Createdtime Desc");
            StringBuilder sb = new StringBuilder();
            foreach (ClassLibrary.Model.Routes model in routeList)
            {
                ClassLibrary.Model.RouteClass temModel = globalList.Find(delegate(ClassLibrary.Model.RouteClass tm) { return tm.ID == model.LocationID; });
                
                sb.AppendLine("<li>");
                sb.AppendLine("<div class='sxi_info'>");
                sb.AppendFormat("<span class='sxi_title'><a href='{0}/{1}/{2}.html' title='{3}' target='_blank'>{4}</a></span>",
                    SysConfig.webSite, temModel.ClassNamePY, model.ID, model.Title, Function.Clip(model.Title, 17, true));
                sb.AppendFormat("<span class='sxi_price'>&yen;<em>{0}</em>起</span>", Convert.ToInt32(model.Price));
                sb.AppendLine("</div>");
                sb.AppendFormat("<a class='sxi_img' href='{0}/{1}/{2}.html' target='_blank' rel='nofollow'><img src='{3}' alt='' width='221' height='148' /></a>",
                    SysConfig.webSite, temModel.ClassNamePY, model.ID, SysConfig.UploadFilePathRoutesImg + model.Image.Split(',')[0]);
                sb.AppendLine("</li>");
            }

            dataSxList = sb.ToString();
        }
        //友情链接
        protected string BindLink()
        {
            List<ClassLibrary.Model.Links> list = linkBLL.GetModelList("LinkClass = 0");

            StringBuilder sb = new StringBuilder();

            foreach (ClassLibrary.Model.Links model in list)
            {
                sb.AppendFormat("<li><a href='{0}' title='{1}' target='_blank'>{1}</a></li>", model.LinkURL, Function.Clip(model.Title, 10, false));
            }
            return sb.ToString();
        }
    }
}