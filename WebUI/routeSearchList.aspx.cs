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
    public partial class routeSearchList : System.Web.UI.Page
    {
        protected int order = 0;
        protected string sKey = "";
        string urlKey = "";

        protected string location;
        protected string pageInfo;
        protected string dataRouteList;
        Pagination pg = new Pagination();
        ClassLibrary.BLL.Routes bll = new ClassLibrary.BLL.Routes();
        ClassLibrary.BLL.RouteClass routeClassBLL = new ClassLibrary.BLL.RouteClass();

        int pageIndex = 0;

        protected string currentFilter2 = "";
        protected string currentfiltertext = "";

        protected string dataSalesList = "";

        protected string dataScenicList = "";
        protected string dataGongLuList = "";

        protected string adRightImg1 = "";
        protected string adRightImg2 = "";

        protected string displayKey = "";
        protected string recommendAreaList = "";

        protected string dataListMenu = "";

        ClassLibrary.Model.RouteClass currClass = new ClassLibrary.Model.RouteClass();
        List<ClassLibrary.Model.RouteClass> glClass = new List<ClassLibrary.Model.RouteClass>();
        List<ClassLibrary.Model.RouteType> grtClass = new List<ClassLibrary.Model.RouteType>();
        ClassLibrary.BLL.News newsBll = new ClassLibrary.BLL.News();
        ClassLibrary.BLL.RouteType rtBll = new ClassLibrary.BLL.RouteType();

        protected void Page_Load(object sender, EventArgs e)
        {
            GetArgument();
            BindSearchData();
            BindLocation();
            BindCurrentFilter();
            BindRouteList();
            BindRouteSales();
            BindDatapromotion();
        }
        private void BindDatapromotion()
        {
            StringBuilder sb = new StringBuilder();
            string sqlWhere = "isdisplay = 1 and CHARINDEX('" + sKey + "',Title)>0";

            DataSet mySet = newsBll.GetPageData(8, 1, sqlWhere, " CreatedTime desc ");
            DataTable table = mySet.Tables["Data"];

            if (table.Rows.Count < 8)
            {
                DataSet mySet2 = newsBll.GetPageData(5, 1, "isdisplay = 1", " CreatedTime desc ");
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

            DataSet mySet = bll.GetPageData(5, 1, "isdisplay=1", "RecommendHot Desc,RouteOrder Asc,Createdtime desc");
            DataTable table = mySet.Tables["Data"];

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
            displayKey = "旅游线路搜索";
            currentfiltertext = "相关";
            currentFilter2 = SysConfig.webSite + "/rkey" + urlKey + "/";
        }
        
        private void GetArgument()
        {
            sKey = Request.QueryString["sk"];
            if (sKey == null) sKey = "";
            if (sKey.Trim() == "")
            {
                Response.StatusCode = 404;
                Response.End();
            }
            sKey = sKey.Trim();

            List<ClassLibrary.Model.RouteClass> tmpList = routeClassBLL.GetModelList("CHARINDEX('" + sKey + "', ClassName)>0 or CHARINDEX(ClassName,'" + sKey + "')>0", "ClassLevel Desc, Recommend Desc");
            if (tmpList.Count > 0)
            {
                ClassLibrary.Model.RouteClass tm = tmpList[0];
                if (tm.ParentID != (int)SysConfig.RouteClass.国内旅游)
                {
                    Response.Redirect(SysConfig.webSite + "/" + tm.ClassNamePY + "/");
                }
            }
            List<ClassLibrary.Model.RouteType> tmpList2 = rtBll.GetModelList("CHARINDEX('" + sKey + "', ClassName)>0 or CHARINDEX(ClassName,'" + sKey + "')>0");
            if (tmpList2.Count > 0)
            {
                ClassLibrary.Model.RouteType tm = tmpList2[0];
                Response.Redirect(SysConfig.webSite + "/" + tm.classNamePY + "/");
            }
            glClass = routeClassBLL.GetModelList(String.Empty, "ClassLevel Desc, Recommend Desc, CreatedTime Desc");
            grtClass = rtBll.GetModelList(string.Empty, "Recommend Desc,ClassOrder Asc,CreatedTime Desc");
            
        }

        //位置
        private void BindLocation()
        {
            location = " &gt; <strong>搜索结果</strong>";
        }

        private void BindSearchData()
        {
            if (Function.GetQueryString("od") != "" && Function.IsNumber(Function.GetQueryString("od")))
            {
                order = Convert.ToInt32(Function.GetQueryString("od"));
            }

            urlKey = HttpUtility.UrlEncode(sKey, Encoding.UTF8);

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
            string routewhere = " isdisplay=1 and CHARINDEX('" + sKey + "',Title) > 0";
            string orderwhere = "routeOrder Asc";
            if (order == 1)
            {
                orderwhere = "price Asc";
            }
            else if (order == 2)
            {
                orderwhere = "createdTime Desc";
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

                sb.AppendLine("<div class='routeList_item'>");
                if (model.RecommendHot)
                {
                    sb.AppendLine("<div class='icon_tj'></div>");
                }
                sb.AppendLine("<div class='routelist_img'>");
                sb.AppendFormat("<a href='{4}/{3}/{0}.html' target='_blank' title='{2}' rel='nofollow'><img src='{1}' alt='{2}'  width='208' height='127'/></a>",
                    model.ID, ClassLibrary.Common.SysConfig.UploadFilePathRoutesImg + images[0], model.Title, tmpPy, SysConfig.webSite).AppendLine();
                sb.AppendLine("</div>");
                sb.AppendLine("<div class='routelist_middle'>");
                sb.AppendLine("<div class='routelist_title'>");
                sb.AppendFormat("<a href='{4}/{3}/{0}.html' target='_blank' title='{2}'>{1}</a>",
                    model.ID, Function.Clip(model.Title, 40, false), model.Title, tmpPy, SysConfig.webSite).AppendLine();
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

    }
}