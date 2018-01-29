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
    public partial class routeList : System.Web.UI.Page
    {
        protected int pid = 0;
        protected int cid = 0;
        protected string price;
        protected int days = 0;
        protected int themeId = 0;
        string vPrice = "";
        protected int order = 0;
        protected string parentPY = "";
        protected string currentName = "";
        protected string leftNavList = "";
        bool isZhuti = false;
        protected string location;
        protected string pageInfo;
        protected string dataRouteList;
        int pageIndex = 0;
        int level2Id = 0;
        protected string areahref = "";
        protected string pricehref = "";
        protected string themehref = "";
        protected string dayshref = "";

        protected string priceFilter = "";
        protected string areaFilter = "";
        protected string themeFilter = "";
        protected string daysFilter = "";

        protected string currentFilter = "";
        protected string currentFilter2 = "";
        protected string currentfiltertext = "";

        protected string dataSalesList = "";
        protected string dataGongLuList = "";

        string pageKeyWord = "";
        protected string displayKey = "";
        protected string clearAllPy = "";
        protected string linkList = "";
        protected int maxClassId = 0;
        protected string routelistAds = "";
        protected string appurl = "";

        Pagination pg = new Pagination();
        ClassLibrary.BLL.Routes bll = new ClassLibrary.BLL.Routes();
        ClassLibrary.BLL.RouteClass routeClassBLL = new ClassLibrary.BLL.RouteClass();
        ClassLibrary.BLL.RouteType routeTypeBll = new ClassLibrary.BLL.RouteType();
        ClassLibrary.BLL.News newsBll = new ClassLibrary.BLL.News();
        ClassLibrary.BLL.SaleAdvertise saBll = new ClassLibrary.BLL.SaleAdvertise();

        ClassLibrary.Model.RouteClass currClass = new ClassLibrary.Model.RouteClass();
        ClassLibrary.Model.RouteClass prtClass = new ClassLibrary.Model.RouteClass();
        ClassLibrary.Model.RouteType currZtClass = new ClassLibrary.Model.RouteType();

        List<ClassLibrary.Model.RouteClass> glClass = new List<ClassLibrary.Model.RouteClass>();
        List<ClassLibrary.Model.RouteType> grtClass = new List<ClassLibrary.Model.RouteType>();

        protected void Page_Load(object sender, EventArgs e)
        {
            GetArgument();
            BindSearchData();
            BindKeyWord();
            BindLocation();
            BindCurrentFilter();

            BindLeftNav();
            BindRouteSales();
            BindZhinanList();
            if (cid == 1 || cid == 2 || cid == 3 || cid == 5 || isZhuti)
            {
                BindRouteAds();
            }

            if (!isZhuti && currClass.ClassLevel >= 3 && maxClassId != (int)SysConfig.RouteClass.重庆)
            {
                BindAreaItems();
            }
            BindPriceFilter();
            if (!isZhuti && maxClassId <= 2)
            {
                BindThemeFilter();
            }
            BindDaysFilter();

            BindRouteList();

            BindLink();
        }

        private void BindRouteAds()
        {
            string where = "ExpiredTime > '" + DateTime.Now.ToString("yyyy-MM-dd") + "'";
            if (isZhuti)
            {
                where += " AND RouteClassId = 'z" + currZtClass.ID + "'";
            }
            else
            {
                where += " AND RouteClassId = '" + maxClassId + "'";
            }

            List<ClassLibrary.Model.SaleAdvertise> saList = saBll.GetModelList(4, where, "SaleOrder Asc, CreatedTime Desc");
            if (saList.Count > 0)
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("<div class='route_sale'>");
                sb.AppendLine("<div class='route_sale_top'>限时特价</div>");
                sb.AppendLine("<div class='route_sale_items'>");
                foreach(ClassLibrary.Model.SaleAdvertise model in saList){
                    sb.AppendFormat("<a href='{0}' title='{1}' target='_blank' >", model.LinkUrl, model.Title);
                    sb.AppendFormat("<img src='{0}' alt='' width='211px' height='254px' /></a>", SysConfig.UploadFilePathAdImg + model.Img);
                }
                sb.AppendLine("</div>");
                sb.AppendLine("</div>");

                routelistAds = sb.ToString();
            }
        }

        private void BindLeftNav()
        {
            StringBuilder sb = new StringBuilder();
            if (isZhuti)
            {
                sb.AppendLine("<div class='side_nav_items'>");
                sb.AppendLine("<div class='nav_items_title on'>");
                sb.AppendLine("主题旅游<i></i>");
                sb.AppendLine("</div>");
                sb.AppendLine("<div class='nav_items_list'>");
                foreach (ClassLibrary.Model.RouteType model in grtClass)
                {
                    sb.AppendFormat("<a href='{0}/{1}/' >{2}</a>", SysConfig.webSite, model.classNamePY, model.ClassName).AppendLine();
                }
                sb.AppendLine("</div>");
                sb.AppendLine("</div>");
            }
            else if (maxClassId == (int)SysConfig.RouteClass.重庆)
            {
                sb.AppendLine("<div class='side_nav_items'>");
                sb.AppendLine("<div class='nav_items_title on'>");
                sb.AppendFormat("<a href='{0}/{1}/'>重庆周边旅游</a><i></i>", SysConfig.webSite, "chongqing");
                sb.AppendLine("</div>");
                sb.AppendLine("<div class='nav_items_list'>");
                List<ClassLibrary.Model.RouteClass> level4List = glClass.FindAll(delegate(ClassLibrary.Model.RouteClass rc) { return rc.ParentID == maxClassId; });
                foreach (ClassLibrary.Model.RouteClass model in level4List)
                {
                    sb.AppendFormat("<a href='{0}/{1}/' >{2}</a>", SysConfig.webSite, model.ClassNamePY, model.ClassName).AppendLine();
                }
                sb.AppendLine("</div>");
                sb.AppendLine("</div>");
            }
            else
            {
                List<ClassLibrary.Model.RouteClass> level2List = glClass.FindAll(delegate(ClassLibrary.Model.RouteClass rc) { return rc.ParentID == maxClassId; });
                int i = 0;
                foreach (ClassLibrary.Model.RouteClass model in level2List)
                {
                    i++;
                    sb.AppendLine("<div class='side_nav_items'>");
                    sb.AppendFormat("<div class='nav_items_title {0}'>", ((level2Id == 0 && i == 1) || level2Id == model.ID) ? "on" : "");
                    sb.AppendFormat("{0}<i></i>", maxClassId == (int)SysConfig.RouteClass.国内旅游 ? model.ClassName : string.Format("<a href='{0}/{1}/'>{2}</a>", SysConfig.webSite, model.ClassNamePY, model.ClassName)).AppendLine();
                    sb.AppendLine("</div>");

                    List<ClassLibrary.Model.RouteClass> level3List = glClass.FindAll(delegate(ClassLibrary.Model.RouteClass rc) { return rc.ParentID == model.ID; });
                    if (level3List.Count > 0)
                    {
                        sb.AppendFormat("<div class='nav_items_list' style='{0}'>", ((level2Id == 0 && i == 1) || level2Id == model.ID) ? "" : "display:none").AppendLine();

                        foreach (ClassLibrary.Model.RouteClass model2 in level3List)
                        {
                            sb.AppendFormat("<a href='{0}/{1}/' >{2}</a>", SysConfig.webSite, model2.ClassNamePY, model2.ClassName).AppendLine();
                        }
                        sb.AppendLine("</div>");
                    }
                    sb.AppendLine("</div>");
                }
                if (maxClassId == (int)SysConfig.RouteClass.三峡旅游)
                {
                    sb.AppendLine("<div class='side_nav_items'>");
                    sb.AppendLine("<div class='nav_items_title'>");
                    sb.AppendFormat("<a href='{0}/{1}/'>{2}</a><i></i>", SysConfig.webSite, "schedule", "船期表").AppendLine();
                    sb.AppendLine("</div>");
                    sb.AppendLine("</div>");
                }
            }
            leftNavList = sb.ToString();
        }

        private void BindAreaItems()
        {
            List<ClassLibrary.Model.RouteClass> aiList = null;
            if (currClass.ClassLevel == 4)
            {
                aiList = glClass.FindAll(delegate(ClassLibrary.Model.RouteClass rc) { return rc.ParentID == pid; });
            }
            else
            {
                aiList = glClass.FindAll(delegate(ClassLibrary.Model.RouteClass rc) { return rc.ParentID == cid; });
            }
            if (aiList.Count > 0)
            {
                StringBuilder sb = new StringBuilder();
                int index = 1;
                bool isdisplayed = false;
                sb.AppendLine("<div class='condition_item' id='areaFilter'>");
                sb.AppendLine("<p class='item_title' data='1'>目&nbsp;&nbsp;的&nbsp;&nbsp;地</p>");
                sb.AppendLine("<div class='item_list'>");
                sb.AppendFormat("<div class='item_cur'><a href='{0}' rel='nofollow'>全部</a></div>", areahref).AppendLine();
                sb.AppendLine("<ul id='more_area'>");
                foreach (ClassLibrary.Model.RouteClass model in aiList)
                {
                    if ((!isdisplayed && model.ID == cid) || model.ID != cid)
                    {
                        sb.AppendFormat("<li class='{1}'><a class='{2}' title='{0}旅游线路' href='{3}/{4}/'>{0}</a></li>",
                            model.ClassName, index > 10 ? "hide" : "", model.ID == cid ? "on2" : "", SysConfig.webSite, model.ClassNamePY);
                        index++;
                    }
                    if (!isdisplayed && model.ID == cid)
                    {
                        isdisplayed = true;
                    }
                    if (!isdisplayed && index == 10 && aiList.Count > 10)
                    {
                        ClassLibrary.Model.RouteClass tmpClass = aiList.Find(delegate(ClassLibrary.Model.RouteClass rc) { return rc.ID == cid; });
                        sb.AppendFormat("<li class='{1}'><a class='{2}' title='{0}旅游线路' href='{3}/{4}/'>{0}</a></li>",
                            tmpClass.ClassName, index > 10 ? "hide" : "", "on2", SysConfig.webSite, tmpClass.ClassNamePY);
                        isdisplayed = true;
                        index++;
                    }
                }
                if (aiList.Count > 10)
                {
                    sb.AppendFormat("<li class='moreli'><div class='morearea'><span title='更多旅游目的地'>展开</span><i></i></div></li>");
                }
                sb.AppendLine("</ul>");
                sb.AppendLine("</div>");
                sb.AppendLine("</div>");
                areaFilter = sb.ToString();
            }
        }
        private void BindZhinanList()
        {
            StringBuilder sb = new StringBuilder();
            string sqlWhere = "isdisplay = 1";
            if (!isZhuti)
            {
                if (cid == (int)SysConfig.RouteClass.三峡旅游 || pid == (int)SysConfig.RouteClass.三峡旅游 || pid == (int)SysConfig.RouteClass.豪华船)
                {
                    sqlWhere += " and IsSanxia = 1";
                }
                else
                {
                    sqlWhere += " and CHARINDEX('," + cid + ",',','+routeClassID+',') > 0 ";
                }
            }
            DataSet mySet = newsBll.GetPageData(8, 1, sqlWhere, " CreatedTime desc ");
            DataTable table = mySet.Tables["Data"];

            if (table.Rows.Count < 8 && !isZhuti)
            {
                DataSet mySet2 = newsBll.GetPageData(8, 1, "isdisplay = 1 and CHARINDEX('," + maxClassId + ",',','+routeClassID+',') > 0 ", " CreatedTime desc ");
                DataTable table2 = mySet2.Tables["Data"];
                table.Merge(table2);
                table = table.AsDataView().ToTable(true);
            }
            int i = 0;
            foreach (DataRow dr in table.Rows)
            {
                i++;
                ClassLibrary.Model.RouteClass temClass = glClass.Find(delegate(ClassLibrary.Model.RouteClass trc) { return trc.ID == Convert.ToInt32(dr["LocationID"].ToString()); });

                sb.AppendFormat("<li class='{0}'>", (i == 8 || i == table.Rows.Count) ? "lastline" : "");
                sb.AppendFormat("<a class='side_img' href='{0}/{1}/{2}.html' title='{3}' target='_blank' rel='nofollow'>",
                    SysConfig.webSite, Enum.GetName(typeof(SysConfig.NewsClassPY), Convert.ToInt32(dr["newsClassId"])), dr["ID"], dr["Title"]).AppendLine();
                sb.AppendFormat("<img src='{0}' alt='' width='48' height='48' /></a>", SysConfig.UploadFilePathNewsImg + dr["Image"]).AppendLine();
                sb.AppendFormat("<a class='side_title' href='{0}/{1}/{2}.html' title='{3}' target='_blank'>{4}</a>",
                    SysConfig.webSite, Enum.GetName(typeof(SysConfig.NewsClassPY), Convert.ToInt32(dr["newsClassId"])), dr["ID"], dr["Title"], Function.Clip(dr["Title"].ToString(), 30, true)).AppendLine();
                sb.AppendLine("</li>");

                if (i == 8) break;
            }

            dataGongLuList = sb.ToString();
        }
        public void BindRouteSales()
        {
            StringBuilder sb = new StringBuilder();

            string saleWhere = " isdisplay=1 ";
            string where2 = "";
            if (isZhuti)
            {
                where2 += " and CHARINDEX('," + currZtClass.ID + ",',','+ThemeID+',') > 0 ";
            }
            else
            {
                where2 += " and CHARINDEX('," + cid + ",',','+routesPrentClassID+',') > 0 ";
            }

            DataSet mySet = bll.GetPageData(5, 1, saleWhere + where2, "RecommendHot Desc,RouteOrder Asc,Createdtime desc");
            DataTable table = mySet.Tables["Data"];

            if (table.Rows.Count < 5 && !isZhuti)
            {
                DataSet mySet3 = bll.GetPageData(5, 1, "isdisplay=1 and CHARINDEX('," + maxClassId + ",',','+routesPrentClassID+',') > 0 ", "ID desc");
                DataTable table3 = mySet3.Tables["Data"];
                table.Merge(table3);
                table = table.AsDataView().ToTable(true);
            }
            int i = 0;
            foreach (DataRow dr in table.Rows)
            {
                i++;
                int tmpClassId = Convert.ToInt32(dr["LocationID"].ToString());
                string tmpPy = glClass.Find(delegate(ClassLibrary.Model.RouteClass tm) { return tm.ID == tmpClassId; }).ClassNamePY;

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
        private void BindCurrentFilter()
        {
            StringBuilder sb = new StringBuilder();
            if (!isZhuti)
            {
                if (currClass.ClassLevel != 1)
                {
                    if (currClass.ClassLevel == 4)
                    {
                        sb.AppendFormat("<a class=\"cur_select\" onclick=\"clk_hotel(this, 1)\"><span>景点：</span><span>" + currClass.ClassName + "</span><span class=\"c_icon\"></span></a>");
                    }
                    else
                    {
                        sb.AppendFormat("<a class=\"cur_select\" onclick=\"clk_hotel(this, 1)\"><span>地区：</span><span>" + currClass.ClassName + "</span><span class=\"c_icon\"></span></a>");
                    }
                }
            }
            else
            {
                sb.AppendFormat("<a class=\"cur_select\" onclick=\"clk_hotel(this, 1)\"><span>主题：</span><span>" + currZtClass.ClassName + "</span><span class=\"c_icon\"></span></a>");
            }
            currentfiltertext += isZhuti ? currZtClass.ClassName : currClass.ClassName.Replace("旅游", "");

            if (price != "")
            {
                string temPrice = price + "元";
                if (maxClassId == (int)SysConfig.RouteClass.出境旅游)
                {
                    if (price == "0-3000")
                    {
                        temPrice = price.Substring(price.IndexOf("-") + 1) + "元以下";
                    }
                    if (price == "20000-0")
                    {
                        temPrice = price.Substring(0, price.IndexOf("-")) + "元以上";
                    }
                }
                else
                {
                    if (price == "0-500")
                    {
                        temPrice = price.Substring(price.IndexOf("-") + 1) + "元以下";
                    }
                    if (price == "10000-0")
                    {
                        temPrice = price.Substring(0, price.IndexOf("-")) + "元以上";
                    }
                }
                sb.AppendFormat("<a class=\"cur_select\" onclick=\"clk_hotel(this, 2)\"><span>价格：</span><span>" + temPrice + "</span><span class=\"c_icon\"></span></a>");
                currentfiltertext += temPrice;
            }
            if (themeId != 0)
            {
                string c_bName = grtClass.Find(delegate(ClassLibrary.Model.RouteType rt) { return rt.ID == themeId; }).ClassName;
                sb.AppendFormat("<a class=\"cur_select\" onclick=\"clk_hotel(this, 3)\"><span>主题：</span><span>" + c_bName + "</span><span class=\"c_icon\"></span></a>");
                currentfiltertext += c_bName;
            }
            if (days != 0)
            {
                string temDay = Enum.GetName(typeof(SysConfig.Numbers), days) + "日游";

                sb.AppendFormat("<a class=\"cur_select\" onclick=\"clk_hotel(this, 4)\"><span>天数：</span><span>" + temDay + "</span><span class=\"c_icon\"></span></a>");
                currentfiltertext += temDay;
            }

            displayKey = currentfiltertext;
            if (isZhuti)
            {
                displayKey = "重庆出发" + displayKey;
            }
            else
            {

                if (currClass.ClassLevel == 4 || currClass.ClassLevel == 3)
                {
                    if (cid == (int)SysConfig.RouteClass.重庆)
                    {
                        displayKey = displayKey.Replace("重庆", "重庆周边");
                    }
                    else if (pid == (int)SysConfig.RouteClass.豪华船)
                    {
                        displayKey = "重庆三峡" + displayKey;
                    }
                    else
                    {
                        displayKey = "重庆到" + displayKey;
                    }
                }
                else if (currClass.ClassLevel == 2)
                {
                    if (pid == (int)SysConfig.RouteClass.三峡旅游)
                    {
                        displayKey = "重庆三峡" + displayKey;
                    }
                    else
                    {
                        displayKey = "重庆到" + displayKey;
                    }
                }
                else if (currClass.ClassLevel == 1)
                {
                    if (pid == (int)SysConfig.RouteClass.三峡旅游)
                    {
                        displayKey = "重庆" + displayKey;
                    }
                    else
                    {
                        displayKey = "重庆出发" + displayKey;
                    }
                }
            }
            displayKey += "旅游线路";
            
            currentFilter = sb.ToString();

            if (!isZhuti && currClass.ClassLevel >= 3) areahref = SysConfig.webSite + "/" + parentPY + "/";
            themehref = SysConfig.webSite + "/" + (isZhuti ? currZtClass.classNamePY : currClass.ClassNamePY) + "/";
            pricehref = SysConfig.webSite + "/" + (isZhuti ? currZtClass.classNamePY : currClass.ClassNamePY) + "/";
            dayshref = SysConfig.webSite + "/" + (isZhuti ? currZtClass.classNamePY : currClass.ClassNamePY) + "/";

            if (days != 0 || themeId != 0 || price != "")
            {
                if (themeId != 0)
                {
                    areahref += "t" + themeId;
                }
                areahref += vPrice;
                if (days != 0)
                {
                    areahref += "day" + days;
                }
                areahref += "/";
            }
            if (days != 0 || price != "")
            {
                themehref += vPrice;
                if (days != 0)
                {
                    themehref += "day" + days;
                }
                themehref += "/";
            }
            if (days != 0 || themeId != 0)
            {
                if (themeId != 0)
                {
                    pricehref += "t" + themeId;
                }
                if (days != 0)
                {
                    pricehref += "day" + days;
                }
                pricehref += "/";
            }
            if (themeId != 0 || price != "")
            {
                if (themeId != 0)
                {
                    dayshref += "t" + themeId;
                }
                dayshref += vPrice;
                dayshref += "/";
            }
            currentFilter2 = SysConfig.webSite + "/" + (isZhuti ? currZtClass.classNamePY : currClass.ClassNamePY) + "/";
            if (price != "" || days != 0 || themeId != 0)
            {
                currentFilter2 += string.Format("{2}{1}{0}/", days == 0 ? "" : ("day" + days), vPrice, themeId == 0 ? "" : ("t" + themeId));
            }
        }

        private void BindThemeFilter()
        {
            string themeSql = "Exists(select * from Routes b where isdisplay = 1 and CHARINDEX(','+CONVERT(varchar(10),RouteType.ID)+',',','+b.ThemeID+',') > 0 and CHARINDEX('," + cid + ",',','+b.routesPrentClassID+',') > 0 ";
            if (days != 0)
            {
                if (maxClassId == (int)SysConfig.RouteClass.出境旅游)
                {
                    if (days == 11)
                    {
                        themeSql += " and routetime >= 11";
                    }
                    else if (days == 5)
                    {
                        themeSql += " and routetime <= 5";
                    }
                    else
                    {
                        themeSql += "and routetime = " + days;
                    }
                }
                else
                {
                    if (days == 7)
                    {
                        themeSql += " and routetime >= 7";
                    }
                    else
                    {
                        themeSql += "and routetime = " + days;
                    }
                }
            }
            if (price != "")
            {
                string[] temPrice2 = price.Split('-');
                int price1 = Convert.ToInt32(temPrice2[0]);
                int price2 = Convert.ToInt32(temPrice2[1]);
                if (price1 == 0)
                {
                    themeSql += " and price < " + price2;
                }
                else if (price2 == 0)
                {
                    themeSql += " and price > " + price1;
                }
                else
                {
                    themeSql += " and price >= " + price1 + " and price <= " + price2;
                }
            }
            themeSql += ")";

            List<ClassLibrary.Model.RouteType> list = routeTypeBll.GetModelList(themeSql, "ClassOrder Asc, CreatedTime Desc");

            if (list.Count > 0)
            {
                StringBuilder sb = new StringBuilder();
                string crtName = isZhuti ? currZtClass.ClassName : currClass.ClassName;
                string crtNamePy = isZhuti ? currZtClass.classNamePY : currClass.ClassNamePY;

                sb.AppendLine("<div class='condition_item' id='themeFilter'>");
                sb.AppendLine("<p class='item_title' data='3'>主题分类</p>");
                sb.AppendLine("<div class='item_list' id='more_theme'>");
                sb.AppendFormat("<div class='item_cur'><a href='{0}' rel='nofollow'>全部</a></div>", themehref).AppendLine();
                sb.AppendLine("<ul>");

                int index = 1;
                bool isdisplayed = false;
                foreach (ClassLibrary.Model.RouteType model in list)
                {
                    if ((!isdisplayed && model.ID == themeId) || model.ID != themeId)
                    {
                        string url = string.Format("{0}/{1}/{4}{3}{2}/", SysConfig.webSite, crtNamePy, days == 0 ? "" : ("day" + days), vPrice, "t" + model.ID);

                        sb.AppendFormat("<li class='{1}'><a class='{2}' title='{3}{0}旅游线路' href='{4}'>{0}</a></li>",
                            model.ClassName, index > 9 ? "hide" : "", model.ID == themeId ? "on2" : "", crtName, url).AppendLine();
                        index++;
                    }
                    if (!isdisplayed && model.ID == themeId)
                    {
                        isdisplayed = true;
                    }
                    if (!isdisplayed && index == 9 && list.Count > 9 && themeId != 0)
                    {
                        ClassLibrary.Model.RouteType tmpClass = list.Find(delegate(ClassLibrary.Model.RouteType rc) { return rc.ID == themeId; });
                        if (tmpClass != null)
                        {
                            string url = string.Format("{0}/{1}/{4}{3}{2}/", SysConfig.webSite, crtNamePy, days == 0 ? "" : ("day" + days), vPrice, "t" + model.ID);

                            sb.AppendFormat("<li class='{1}'><a class='{2}' title='{3}{0}旅游线路' href='{4}'>{0}</a></li>",
                                tmpClass.ClassName, index > 9 ? "hide" : "", tmpClass.ID == themeId ? "on2" : "", crtName, url).AppendLine();
                            index++;
                            isdisplayed = true;
                        }
                    }
                }
                if (list.Count > 9)
                {
                    sb.AppendFormat("<li class='moreli'><div class='moretheme'><span title='更多旅游主题'>展开</span><i></i></div></li>").AppendLine();
                }
                sb.AppendLine("</ul>");
                sb.AppendLine("</div>");
                sb.AppendLine("</div>");
                themeFilter = sb.ToString();
            }
        }
        private void BindPriceFilter()
        {
            string priceSql = "CHARINDEX('," + cid + ",',','+routesPrentClassID+',') > 0";

            if (isZhuti)
                priceSql = "CHARINDEX('," + currZtClass.ID + ",',','+themeid+',') > 0";

            if (days != 0)
            {
                if (maxClassId == (int)SysConfig.RouteClass.出境旅游)
                {
                    if (days == 11)
                    {
                        priceSql += " and routeTime >= 11 ";
                    }
                    else if (days == 5)
                    {
                        priceSql += " and routeTime <= 5 ";
                    }
                    else
                    {
                        priceSql += " and routeTime = " + days;
                    }
                }
                else
                {
                    if (days != 7)
                    {
                        priceSql += " and routeTime = " + days;
                    }
                    else
                    {
                        priceSql += " and routeTime >=7 ";
                    }
                }
            }
            if (themeId != 0)
            {
                priceSql += " and charindex('," + themeId + ",',','+themeId+',')>0";
            }

            string strPriceLevel = "";

            if (maxClassId == (int)SysConfig.RouteClass.出境旅游)
            {
                strPriceLevel = bll.GetPriceLevelCj(priceSql);
            }
            else
            {
                strPriceLevel = bll.GetPriceLevel(priceSql);
            }

            StringBuilder sb = new StringBuilder();
            if (strPriceLevel != "")
            {
                string crtName = isZhuti ? currZtClass.ClassName : currClass.ClassName;
                string crtNamePy = isZhuti ? currZtClass.classNamePY : currClass.ClassNamePY;
                strPriceLevel = "," + strPriceLevel + ",";
                if (maxClassId == (int)SysConfig.RouteClass.出境旅游)
                {
                    if (strPriceLevel.Contains(",0-3000,"))
                    {
                        string url = string.Format("{0}/{1}/{4}{3}{2}/", SysConfig.webSite, crtNamePy, days == 0 ? "" : ("day" + days), "v0v3000", themeId == 0 ? "" : ("t" + themeId));
                        sb.AppendFormat("<li><a class='{1}' title='{2}{0}旅游线路' href='{3}'>{0}</a></li>",
                            "3000以下", price == "0-3000" ? "on2" : "", crtName, url);
                    }
                    if (strPriceLevel.Contains(",3000-8000,"))
                    {
                        string url = string.Format("{0}/{1}/{4}{3}{2}/", SysConfig.webSite, crtNamePy, days == 0 ? "" : ("day" + days), "v3000v8000", themeId == 0 ? "" : ("t" + themeId));
                        sb.AppendFormat("<li><a class='{1}' title='{2}{0}旅游线路' href='{3}'>{0}</a></li>",
                        "3000-8000元", price == "3000-8000" ? "on2" : "", crtName, url);
                    }
                    if (strPriceLevel.Contains(",8000-15000,"))
                    {
                        string url = string.Format("{0}/{1}/{4}{3}{2}/", SysConfig.webSite, crtNamePy, days == 0 ? "" : ("day" + days), "v8000v15000", themeId == 0 ? "" : ("t" + themeId));
                        sb.AppendFormat("<li><a class='{1}' title='{2}{0}旅游线路' href='{3}'>{0}</a></li>",
                        "8000-15000元", price == "8000-15000" ? "on2" : "", crtName, url);
                    }
                    if (strPriceLevel.Contains(",15000-20000,"))
                    {
                        string url = string.Format("{0}/{1}/{4}{3}{2}/", SysConfig.webSite, crtNamePy, days == 0 ? "" : ("day" + days), "v15000v20000", themeId == 0 ? "" : ("t" + themeId));
                        sb.AppendFormat("<li><a class='{1}' title='{2}{0}旅游线路' href='{3}'>{0}</a></li>",
                        "15000-20000元", price == "15000-20000" ? "on2" : "", crtName, url);
                    }
                    if (strPriceLevel.Contains(",20000-0,"))
                    {
                        string url = string.Format("{0}/{1}/{4}{3}{2}/", SysConfig.webSite, crtNamePy, days == 0 ? "" : ("day" + days), "v20000v0", themeId == 0 ? "" : ("t" + themeId));
                        sb.AppendFormat("<li><a class='{1}' title='{2}{0}旅游线路' href='{3}'>{0}</a></li>",
                        "20000以上", price == "20000-0" ? "on2" : "", crtName, url);
                    }
                }
                else
                {
                    if (strPriceLevel.Contains(",0-500,"))
                    {
                        string url = string.Format("{0}/{1}/{4}{3}{2}/", SysConfig.webSite, crtNamePy, days == 0 ? "" : ("day" + days), "v0v500", themeId == 0 ? "" : ("t" + themeId));
                        sb.AppendFormat("<li><a class='{1}' title='{2}{0}旅游线路' href='{3}'>{0}</a></li>",
                            "500以下", price == "0-500" ? "on2" : "", crtName, url);
                    }
                    if (strPriceLevel.Contains(",500-1500,"))
                    {
                        string url = string.Format("{0}/{1}/{4}{3}{2}/", SysConfig.webSite, crtNamePy, days == 0 ? "" : ("day" + days), "v500v1500", themeId == 0 ? "" : ("t" + themeId));
                        sb.AppendFormat("<li><a class='{1}' title='{2}{0}旅游线路' href='{3}'>{0}</a></li>",
                        "500-1500元", price == "500-1500" ? "on2" : "", crtName, url);
                    }
                    if (strPriceLevel.Contains(",1500-3000,"))
                    {
                        string url = string.Format("{0}/{1}/{4}{3}{2}/", SysConfig.webSite, crtNamePy, days == 0 ? "" : ("day" + days), "v1500v3000", themeId == 0 ? "" : ("t" + themeId));
                        sb.AppendFormat("<li><a class='{1}' title='{2}{0}旅游线路' href='{3}'>{0}</a></li>",
                        "1500-3000元", price == "1500-3000" ? "on2" : "", crtName, url);
                    }
                    if (strPriceLevel.Contains(",3000-10000,"))
                    {
                        string url = string.Format("{0}/{1}/{4}{3}{2}/", SysConfig.webSite, crtNamePy, days == 0 ? "" : ("day" + days), "v3000v10000", themeId == 0 ? "" : ("t" + themeId));
                        sb.AppendFormat("<li><a class='{1}' title='{2}{0}旅游线路' href='{3}'>{0}</a></li>",
                        "3000-10000元", price == "3000-10000" ? "on2" : "", crtName, url);
                    }
                    if (strPriceLevel.Contains(",10000-0,"))
                    {
                        string url = string.Format("{0}/{1}/{4}{3}{2}/", SysConfig.webSite, crtNamePy, days == 0 ? "" : ("day" + days), "v10000v0", themeId == 0 ? "" : ("t" + themeId));
                        sb.AppendFormat("<li><a class='{1}' title='{2}{0}旅游线路' href='{3}'>{0}</a></li>",
                        "10000以上", price == "10000-0" ? "on2" : "", crtName, url);
                    }
                }
            }
            priceFilter = sb.ToString();
        }
        private void BindDaysFilter()
        {
            string daySql = "CHARINDEX('," + cid + ",',','+routesPrentClassID+',') > 0";

            if (isZhuti)
                daySql = "CHARINDEX('," + currZtClass.ID + ",',','+themeid+',') > 0";

            if (price != "")
            {
                string[] temPrice2 = price.Split('-');
                int price1 = Convert.ToInt32(temPrice2[0]);
                int price2 = Convert.ToInt32(temPrice2[1]);
                if (price1 == 0)
                {
                    daySql += " and price < " + price2;
                }
                else if (price2 == 0)
                {
                    daySql += " and price > " + price1;
                }
                else
                {
                    daySql += " and price >= " + price1 + " and price <= " + price2;
                }
            }
            if (themeId != 0)
            {
                daySql += " and charindex('," + themeId + ",',','+themeId+',')>0";
            }

            string strDayLevel = "";

            if (maxClassId == (int)SysConfig.RouteClass.出境旅游)
            {
                strDayLevel = bll.GetDaysLevelCj(daySql);
            }
            else
            {
                strDayLevel = bll.GetDaysLevel(daySql);
            }

            StringBuilder sb = new StringBuilder();
            if (strDayLevel != "")
            {
                string crtName = isZhuti ? currZtClass.ClassName : currClass.ClassName;
                string crtNamePy = isZhuti ? currZtClass.classNamePY : currClass.ClassNamePY;
                strDayLevel = "," + strDayLevel + ",";
                if (maxClassId == (int)SysConfig.RouteClass.出境旅游)
                {
                    if (strDayLevel.Contains(",5,"))
                    {
                        string url = string.Format("{0}/{1}/{4}{3}{2}/", SysConfig.webSite, crtNamePy, "day5", vPrice, themeId == 0 ? "" : ("t" + themeId));
                        sb.AppendFormat("<li><a class='{1}' title='{2}五日游及以下线路' href='{3}'>{0}</a></li>",
                        "五日游及以下", days == 5 ? "on2" : "", crtName, url);
                    }
                    if (strDayLevel.Contains(",6,"))
                    {
                        string url = string.Format("{0}/{1}/{4}{3}{2}/", SysConfig.webSite, crtNamePy, "day6", vPrice, themeId == 0 ? "" : ("t" + themeId));
                        sb.AppendFormat("<li><a class='{1}' title='{2}六日游线路' href='{3}'>{0}</a></li>",
                        "六日游", days == 6 ? "on2" : "", crtName, url);
                    }
                    if (strDayLevel.Contains(",7,"))
                    {
                        string url = string.Format("{0}/{1}/{4}{3}{2}/", SysConfig.webSite, crtNamePy, "day7", vPrice, themeId == 0 ? "" : ("t" + themeId));
                        sb.AppendFormat("<li><a class='{1}' title='{2}七日游线路' href='{3}'>{0}</a></li>",
                        "七日游", days == 7 ? "on2" : "", crtName, url);
                    }
                    if (strDayLevel.Contains(",8,"))
                    {
                        string url = string.Format("{0}/{1}/{4}{3}{2}/", SysConfig.webSite, crtNamePy, "day8", vPrice, themeId == 0 ? "" : ("t" + themeId));
                        sb.AppendFormat("<li><a class='{1}' title='{2}八日游线路' href='{3}'>{0}</a></li>",
                        "八日游", days == 8 ? "on2" : "", crtName, url);
                    }
                    if (strDayLevel.Contains(",9,"))
                    {
                        string url = string.Format("{0}/{1}/{4}{3}{2}/", SysConfig.webSite, crtNamePy, "day9", vPrice, themeId == 0 ? "" : ("t" + themeId));
                        sb.AppendFormat("<li><a class='{1}' title='{2}九日游线路' href='{3}'>{0}</a></li>",
                        "九日游", days == 9 ? "on2" : "", crtName, url);
                    }
                    if (strDayLevel.Contains(",10,"))
                    {
                        string url = string.Format("{0}/{1}/{4}{3}{2}/", SysConfig.webSite, crtNamePy, "day10", vPrice, themeId == 0 ? "" : ("t" + themeId));
                        sb.AppendFormat("<li><a class='{1}' title='{2}十日游线路' href='{3}'>{0}</a></li>",
                        "十日游", days == 10 ? "on2" : "", crtName, url);
                    }
                    if (strDayLevel.Contains(",11,"))
                    {
                        string url = string.Format("{0}/{1}/{4}{3}{2}/", SysConfig.webSite, crtNamePy, "day11", vPrice, themeId == 0 ? "" : ("t" + themeId));
                        sb.AppendFormat("<li><a class='{1}' title='{2}十一日游及以上线路' href='{3}'>{0}</a></li>",
                        "十一日游及以上", days == 11 ? "on2" : "", crtName, url);
                    }
                }
                else
                {
                    if (strDayLevel.Contains(",1,"))
                    {
                        string url = string.Format("{0}/{1}/{4}{3}{2}/", SysConfig.webSite, crtNamePy, "day1", vPrice, themeId == 0 ? "" : ("t" + themeId));
                        sb.AppendFormat("<li><a class='{1}' title='{2}一日游线路' href='{3}'>{0}</a></li>",
                        "一日游", days == 1 ? "on2" : "", crtName, url);
                    }
                    if (strDayLevel.Contains(",2,"))
                    {
                        string url = string.Format("{0}/{1}/{4}{3}{2}/", SysConfig.webSite, crtNamePy, "day2", vPrice, themeId == 0 ? "" : ("t" + themeId));
                        sb.AppendFormat("<li><a class='{1}' title='{2}二日游线路' href='{3}'>{0}</a></li>",
                        "二日游", days == 2 ? "on2" : "", crtName, url);
                    }
                    if (strDayLevel.Contains(",3,"))
                    {
                        string url = string.Format("{0}/{1}/{4}{3}{2}/", SysConfig.webSite, crtNamePy, "day3", vPrice, themeId == 0 ? "" : ("t" + themeId));
                        sb.AppendFormat("<li><a class='{1}' title='{2}三日游线路' href='{3}'>{0}</a></li>",
                        "三日游", days == 3 ? "on2" : "", crtName, url);
                    }
                    if (strDayLevel.Contains(",4,"))
                    {
                        string url = string.Format("{0}/{1}/{4}{3}{2}/", SysConfig.webSite, crtNamePy, "day4", vPrice, themeId == 0 ? "" : ("t" + themeId));
                        sb.AppendFormat("<li><a class='{1}' title='{2}四日游线路' href='{3}'>{0}</a></li>",
                        "四日游", days == 4 ? "on2" : "", crtName, url);
                    }
                    if (strDayLevel.Contains(",5,"))
                    {
                        string url = string.Format("{0}/{1}/{4}{3}{2}/", SysConfig.webSite, crtNamePy, "day5", vPrice, themeId == 0 ? "" : ("t" + themeId));
                        sb.AppendFormat("<li><a class='{1}' title='{2}五日游线路' href='{3}'>{0}</a></li>",
                        "五日游", days == 5 ? "on2" : "", crtName, url);
                    }
                    if (strDayLevel.Contains(",6,"))
                    {
                        string url = string.Format("{0}/{1}/{4}{3}{2}/", SysConfig.webSite, crtNamePy, "day6", vPrice, themeId == 0 ? "" : ("t" + themeId));
                        sb.AppendFormat("<li><a class='{1}' title='{2}六日游线路' href='{3}'>{0}</a></li>",
                        "六日游", days == 6 ? "on2" : "", crtName, url);
                    }
                    if (strDayLevel.Contains(",7,"))
                    {
                        string url = string.Format("{0}/{1}/{4}{3}{2}/", SysConfig.webSite, crtNamePy, "day7", vPrice, themeId == 0 ? "" : ("t" + themeId));
                        sb.AppendFormat("<li><a class='{1}' title='{2}七日游线路' href='{3}'>{0}</a></li>",
                        "七日游及以上", days == 7 ? "on2" : "", crtName, url);
                    }
                }
            }
            daysFilter = sb.ToString();
        }
        private void GetArgument()
        {
            string pingyin = Function.GetQueryString("py");
            glClass = routeClassBLL.GetModelList(String.Empty, "ClassOrder Asc,CreatedTime Desc");
            grtClass = routeTypeBll.GetModelList(String.Empty, "ClassOrder Asc,CreatedTime Desc");

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
                appurl = SysConfig.webSiteApp + "/" + currClass.ClassNamePY + "/";

                List<ClassLibrary.Model.RouteClass> classList = glClass.FindAll(delegate(ClassLibrary.Model.RouteClass tm) { return tm.ParentID == cid; });
                if (classList.Count == 0)
                {
                    pid = currClass.ParentID;
                    prtClass = glClass.Find(delegate(ClassLibrary.Model.RouteClass tm) { return tm.ID == pid; });
                    parentPY = prtClass.ClassNamePY;
                }
                else
                {
                    pid = cid;
                    prtClass = currClass;
                    parentPY = currClass.ClassNamePY;
                }
                if (currClass.ClassLevel == 1)
                {
                    maxClassId = currClass.ID;
                }
                else
                {
                    if (prtClass.ClassLevel == 1)
                    {
                        maxClassId = prtClass.ID;
                        level2Id = cid;
                    }
                    else if (cid == (int)SysConfig.RouteClass.重庆 || pid == (int)SysConfig.RouteClass.重庆)
                    {
                        maxClassId = (int)SysConfig.RouteClass.重庆;
                        level2Id = (int)SysConfig.RouteClass.重庆;
                    }
                    else
                    {
                        List<ClassLibrary.Model.RouteClass> rcItems = routeClassBLL.GetParentList(cid, string.Empty, "classLevel Asc");
                        maxClassId = rcItems[0].ID;
                        level2Id = rcItems[1].ID;
                    }
                }
                currentName = currClass.ClassName.Replace("旅游", "").Replace("地区", "") + (cid == (int)SysConfig.RouteClass.重庆 ? "周边" : "") + "旅游";
                if (pid == (int)SysConfig.RouteClass.豪华船) currentName = "三峡" + currClass.ClassName + "旅游";
            }
            else
            {
                currentName = currZtClass.ClassName.Replace("旅游", "").Replace("游", "") + "旅游";
                appurl = SysConfig.webSiteApp + "/" + currZtClass.classNamePY + "/";
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
            clearAllPy = isZhuti ? currZtClass.classNamePY : (currClass.ClassLevel == 4 ? prtClass.ClassNamePY : currClass.ClassNamePY);
        }

        //位置
        private void BindLocation()
        {
            if (!isZhuti)
            {
                List<ClassLibrary.Model.RouteClass> list = routeClassBLL.GetParentList(cid, "ID<>" + cid, "classlevel asc");

                foreach (ClassLibrary.Model.RouteClass model in list)
                {
                    if (model.ParentID == (int)SysConfig.RouteClass.国内旅游) continue;
                    location += string.Format("<i class='next'></i><a href='{2}/{1}/'>{0}</a>", model.ClassName.Replace("旅游", "") + "旅游", model.ClassNamePY, SysConfig.webSite);
                }
            }
            location += string.Format("<i class='next'></i>{0}", isZhuti ? currZtClass.ClassName : currClass.ClassName.Replace("旅游", "") + "旅游");
        }

        private void BindSearchData()
        {
            price = Function.GetQueryString("price");
            if (price != "")
            {
                string[] temPrice2 = price.Split('-');
                vPrice = "v" + temPrice2[0] + "v" + temPrice2[1];
                if ((maxClassId == (int)SysConfig.RouteClass.出境旅游 && SysConfig.chujingPriceStr.IndexOf(vPrice) < 0) ||
                    (maxClassId != (int)SysConfig.RouteClass.出境旅游 && SysConfig.guoneiPriceStr.IndexOf(vPrice) < 0))
                {
                    Response.StatusCode = 404;
                    Response.End();
                }
            }
            if (Function.GetQueryString("theme") != "" && Function.IsNumber(Function.GetQueryString("theme")))
            {
                themeId = Convert.ToInt32(Function.GetQueryString("theme"));
                ClassLibrary.Model.RouteType trt = grtClass.Find(delegate(ClassLibrary.Model.RouteType rt) { return rt.ID == themeId; });
                if (trt == null)
                {
                    Response.StatusCode = 404;
                    Response.End();
                }
            }
            if (Function.GetQueryString("od") != "" && Function.IsNumber(Function.GetQueryString("od")))
            {
                order = Convert.ToInt32(Function.GetQueryString("od"));
                if (order < 0 || order > 2)
                {
                    Response.StatusCode = 404;
                    Response.End();
                }
            }
            if (Function.GetQueryString("day") != "" && Function.IsNumber(Function.GetQueryString("day")))
            {
                days = Convert.ToInt32(Function.GetQueryString("day"));
                if ((maxClassId == (int)SysConfig.RouteClass.出境旅游 && (days < 5 || days > 11)) || 
                    (maxClassId != (int)SysConfig.RouteClass.出境旅游 && (days < 1 || days > 7)))
                {
                    Response.StatusCode = 404;
                    Response.End();
                }
            }
        }
        //获取当前页主关键词
        private void BindKeyWord()
        {
            if (isZhuti)
            {
                pageKeyWord = "重庆出发" + currZtClass.ClassName.Replace("游", "") + "旅游";
            }
            else
            {
                if (currClass.ClassLevel == 4 || currClass.ClassLevel == 3)
                {
                    pageKeyWord = "重庆到" + currClass.ClassName + "旅游";
                    if (cid == (int)SysConfig.RouteClass.重庆)
                    {
                        pageKeyWord = "重庆周边旅游";
                    }
                    else if (pid == (int)SysConfig.RouteClass.豪华船)
                    {
                        pageKeyWord = "三峡" + currClass.ClassName + "旅游";
                    }
                }
                else if (currClass.ClassLevel == 2)
                {
                    pageKeyWord = "重庆出发到" + currClass.ClassName + "旅游";
                    if (pid == (int)SysConfig.RouteClass.三峡旅游)
                    {
                        pageKeyWord = "重庆三峡" + currClass.ClassName + "旅游";
                    }
                }
                else if (currClass.ClassLevel == 1)
                {
                    pageKeyWord = "重庆出发" + currClass.ClassName;
                    if (cid == (int)SysConfig.RouteClass.三峡旅游)
                    {
                        pageKeyWord = "重庆三峡旅游";
                    }
                }
            }
            pageKeyWord += "_";
        }

        //线路
        private void BindRouteList()
        {
            string routewhere = " isdisplay=1 ";
            if (isZhuti)
            {
                routewhere += " and charindex('," + currZtClass.ID + ",',','+themeId+',')>0";
            }
            else
            {
                routewhere += " and charindex('," + cid + ",',','+routesPrentClassID+',')>0";
            }
            if (days != 0)
            {
                if (maxClassId == (int)SysConfig.RouteClass.出境旅游)
                {
                    if (days == 11)
                    {
                        routewhere += " and routeTime >= 11 ";
                    }
                    else if (days == 5)
                    {
                        routewhere += " and routeTime <= 5 ";
                    }
                    else
                    {
                        routewhere += " and routeTime = " + days;
                    }
                }
                else
                {
                    if (days != 7)
                    {
                        routewhere += " and routeTime = " + days;
                    }
                    else
                    {
                        routewhere += " and routeTime >=7 ";
                    }
                }
            }
            if (price != "")
            {
                string[] temPrice2 = price.Split('-');
                int price1 = Convert.ToInt32(temPrice2[0]);
                int price2 = Convert.ToInt32(temPrice2[1]);
                if (price1 == 0)
                {
                    routewhere += " and price < " + price2;
                }
                else if (price2 == 0)
                {
                    routewhere += "and price > " + price1;
                }
                else
                {
                    routewhere += "and price >= " + price1 + " and price <= " + price2;
                }
            }
            if (themeId != 0)
            {
                routewhere += " and charindex('," + themeId + ",',','+themeId+',')>0";
            }
            string orderwhere = "RouteOrder Asc,CreatedTime Desc";
            if (order != 0)
            {
                if (order == 1)
                {
                    orderwhere = "price Asc";
                }
                else if (order == 2)
                {
                    orderwhere = "price Desc";
                }
                else if (order == 3)
                {
                    orderwhere = "CreatedTime Desc";
                }
                else if (order == 4)
                {
                    orderwhere = "CreatedTime Asc";
                }
            }

            DataSet mySet = bll.GetPageData(10, pageIndex, routewhere, orderwhere);
            DataTable tableCount = mySet.Tables["Count"];
            DataTable myTable = mySet.Tables["Data"];

            int countRows = 0;
            countRows = Convert.ToInt32(tableCount.Rows[0][0].ToString());

            string currUrl = currentFilter2;
            if (order != 0)
            {
                currUrl += "order" + order;
            }
            pageInfo = pg.pagination5(countRows, 10, pageIndex, currUrl);

            StringBuilder sb = new StringBuilder();
            List<ClassLibrary.Model.Routes> pgRouteList = bll.GetModelList(myTable);
            foreach (ClassLibrary.Model.Routes model in pgRouteList)
            {
                string[] images = model.Image.Split(',');
                string tmpPy = glClass.Find(delegate(ClassLibrary.Model.RouteClass tm) { return tm.ID == model.LocationID; }).ClassNamePY;
                string hideTitle = model.Title.Contains(displayKey) ? model.Title : pageKeyWord + model.Title;

                sb.AppendLine("<div class='routeList_item'>");
                if (model.RecommendHot)
                {
                    sb.AppendLine("<div class='icon_tj'></div>");
                }
                sb.AppendLine("<div class='routelist_img'>");
                sb.AppendFormat("<a href='{4}/{3}/{0}.html' target='_blank' title='{2}' rel='nofollow'><img src='{1}' alt='{2}'  width='208' height='127'/></a>", 
                    model.ID, ClassLibrary.Common.SysConfig.UploadFilePathRoutesImg + images[0], hideTitle, tmpPy, SysConfig.webSite).AppendLine();
                sb.AppendLine("</div>");
                sb.AppendLine("<div class='routelist_middle'>");
                sb.AppendLine("<div class='routelist_title'>");
                sb.AppendFormat("<a href='{4}/{3}/{0}.html' target='_blank' title='{2}'>{1}</a>",
                    model.ID, Function.Clip(model.Title, 40, false), hideTitle, tmpPy, SysConfig.webSite).AppendLine();
                sb.AppendLine("</div>");
                sb.AppendFormat("<div class='rootlist_feature'>{0}</div>", Function.Clip(model.Bright, 70, true)).AppendLine();
                string maidian = "";
                if (model.ThemeID != "")
                {
                    string[] themeIds = model.ThemeID.Split(',');
                    int n = 0;
                    foreach (string themeid in themeIds)
                    {
                        ClassLibrary.Model.RouteType tim = grtClass.Find(delegate(ClassLibrary.Model.RouteType tm) { return tm.ID.ToString() == themeid; });
                        if (tim == null) continue;
                        n++;
                        maidian += string.Format("<span class='zhuti'><a href='{1}/{2}/' target='_blank'>{0}</a></span>", tim.ClassName, SysConfig.webSite, tim.classNamePY);
                        if (n >= 8) break;
                    }
                }
                sb.AppendFormat("<div class='routeList_maidian'>{0}</div>", maidian).AppendLine();//<span class='youhui'><em>省</em>200元/人</span>
               
                string startdate = "";
                if (model.DatePrice != "")
                {
                    int sn = 1;
                    string[] sdates = model.DatePrice.Split('|');
                    ArrayList priceList = new ArrayList();
                    foreach (string sd in sdates)
                    {
                        if (sd == "") continue;
                        string curdate = sd.Split(',')[0];
                        string[] tpd = curdate.Split('-');
                        DateTime tmpDate = new DateTime(Convert.ToInt32(tpd[0]), Convert.ToInt32(tpd[1]), Convert.ToInt32(tpd[2]));
                        if (tmpDate < DateTime.Now) continue;
                        priceList.Add(tmpDate);
                        //startdate += curdate.Substring(sd.IndexOf("-") + 1) + " , ";
                    }
                    if (priceList.Count > 0)
                    {
                        priceList.Sort();
                        foreach (DateTime dtitem in priceList)
                        {
                            startdate += dtitem.Month + "-" + dtitem.Day + " , ";
                            if (sn >= 12) break;
                            sn++;
                        }
                    }
                }
                else if (!model.DateType)
                {
                    DateTime rdtime = DateTime.Now;
                    for (int k = 0; k < 12; k++)
                    {
                        rdtime = rdtime.AddDays(1);
                        startdate += rdtime.Month + "-" + rdtime.Day + " , ";
                    }
                }
                if (startdate != "") startdate = startdate.Substring(0, startdate.Length - 3);
                else startdate = "详情请咨询在线客服或拨打400-017-5761";
                sb.AppendFormat("<div class='routeList_start'><span class='startTime'><i class='cftq_icon'></i>出发团期：{0}</span></div>", startdate).AppendLine();
                
                sb.AppendLine("</div>");
                sb.AppendLine("<div class='routelist_right'>");
                string strPrice = "";
                if (model.Price == 0) strPrice = "电询";
                else strPrice = "&yen;<span>" + Convert.ToInt32(model.Price) + "</span>起";
                sb.AppendFormat("<div class='rootlist_price'>{0}</div>", strPrice).AppendLine();
                sb.AppendFormat("<div class='content_book'><a href='{2}/{1}/{0}.html' target='_blank' rel='nofollow'>立即查看</a></div>",
                    model.ID, tmpPy, SysConfig.webSite);
                sb.AppendLine("</div>");
                sb.AppendLine("</div>");
            }
            if (sb.Length == 0)
            {
                sb.Append("<div class='nopagedata'>没有" + currentfiltertext + "旅游线路</div>");
            }
            dataRouteList = sb.ToString();
        }

        //友情链接
        protected void BindLink()
        {
            if (themeId != 0 || days != 0 || price != "" || cid == 0) return;

            ClassLibrary.BLL.Links linkBLL = new ClassLibrary.BLL.Links();

            List<ClassLibrary.Model.Links> list = linkBLL.GetModelList("LinkClass = " + cid);

            if (list.Count == 0) return;

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<div id='links' class='link_list' >");
            sb.AppendLine("<div class='link_title'>友情链接：</div>");
            sb.AppendLine("<ul>");
            foreach (ClassLibrary.Model.Links model in list)
            {
                sb.AppendFormat("<li><a href='{0}' title='{1}' target='_blank'>{1}</a></li>", model.LinkURL, Function.Clip(model.Title, 10, false));
            }
            sb.AppendLine("</ul>");
            sb.AppendLine("</div>");
            linkList = sb.ToString();
        }
    }
}