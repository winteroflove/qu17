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
    public partial class productDetail : System.Web.UI.Page
    {
        protected int routeID;
        protected int routeClassId;
        protected bool isLogin;
        protected string location;
        protected string buyEventStr;

        protected string userNickname;
        protected string userName;
        protected string smallImageList;
        protected string pageInfo;
        protected string traffic;

        protected string themeName = "";
        protected string datePrice = "";
        protected bool dateType;
        protected int price = 0;
        protected int childPrice = 0;
        protected string routeFeature = "";
        protected string descriptionPrice = "";
        protected string routeNotice = "";
        protected string dataDay = "";//行程
        protected string dataDayInfo = "";//行程
        protected string dataXiangRoute = "";
        protected string datacomment = "";
        protected string commentGrade = "";
        protected int commentCount = 0;
        protected bool detailType;
        protected string pingYin = "";
        string comePY = "";

        protected string displayName = "";
        private int parentId = 0;
        protected string displayPy = "";
        protected string dataArticleList = "";
        protected string firstImg = "";
        protected string bookinginfo = "&nbsp;";
        protected string bookingday = "";
        protected int bookingAdultPrice = 0;
        protected int bookingChildPrice = 0;
        protected string strAdultPrice = "电询";
        protected string strPrice = "";
        protected string inactive = "";
        protected string appurl = "";

        protected ClassLibrary.Model.Routes route = new ClassLibrary.Model.Routes();

        Pagination pg = new Pagination();
        ClassLibrary.BLL.RouteComment cmtBLL = new ClassLibrary.BLL.RouteComment();
        ClassLibrary.BLL.Routes bll = new ClassLibrary.BLL.Routes();
        ClassLibrary.BLL.News newsBll = new ClassLibrary.BLL.News();
        ClassLibrary.BLL.RouteClass rcBLL = new ClassLibrary.BLL.RouteClass();
        List<ClassLibrary.Model.RouteClass> gList = new List<ClassLibrary.Model.RouteClass>();
        ClassLibrary.BLL.SystemArticle saBll = new ClassLibrary.BLL.SystemArticle();
        ClassLibrary.BLL.RouteType rtBll = new ClassLibrary.BLL.RouteType();

        protected void Page_Load(object sender, EventArgs e)
        {
            UserInfo u = new UserInfo(CookieName.MemberInfo);
            userName = u.GetInfo(LoginInfo.UserName);
            userNickname = u.GetInfo(LoginInfo.Nickname);
            isLogin = u.IsLogin();

            if (Function.IsPostMethod())
            {
                AddComment();
            }
            else
            {
                GetArgument();
                BindInfo();
                BindBooking();
                BindDay();
                GetLocation();
                BindComment();
                BindXiangRoute();
                bll.Updates("ViewCount=ViewCount+1", "ID=" + routeID);
                BindArticleList();
            }
        }
        private void BindBooking()
        {
            ClassLibrary.Model.SystemArticle samodel = saBll.GetModel((int)SysConfig.SystemArticle.如何预订);
            if (samodel != null) bookinginfo = samodel.Content;
            DateTime dnow = DateTime.Now;
            //StringBuilder sb = new StringBuilder();

            if (route.DateType)
            {
                if (route.DatePrice != "")
                {
                    string[] dp = route.DatePrice.Split('|');
                    Hashtable pricetable = new Hashtable();
                    foreach (string pi in dp)
                    {
                        if (pi.Trim() == "") continue;
                        string[] dpi = pi.Split(',');
                        string[] tpd = dpi[0].Split('-');
                        DateTime tmpDate = new DateTime(Convert.ToInt32(tpd[0]), Convert.ToInt32(tpd[1]), Convert.ToInt32(tpd[2]));
                        if (tmpDate < DateTime.Now) continue;
                        pricetable.Add(tmpDate, dpi[1] + "," + dpi[2]);
                    }
                    if (pricetable.Count > 0)
                    {
                        ArrayList priceList = new ArrayList(pricetable.Keys);
                        priceList.Sort();  //从小到大排序
                        //priceList.Reverse(); 顺序反转
                        foreach (DateTime dtitem in priceList)
                        {
                            bookingday = dtitem.Year + "-" + dtitem.Month + "-" + dtitem.Day;
                            string[] cprice = pricetable[dtitem].ToString().Split(',');
                            bookingAdultPrice = Convert.ToInt32(cprice[0]);
                            bookingChildPrice = Convert.ToInt32(cprice[1]);
                            if (bookingAdultPrice != 0) strAdultPrice = bookingAdultPrice + "元";
                            break;
                        }
                    }
                }
                if (bookingday == "")
                {
                    dnow = dnow.AddDays(1);
                    bookingday = dnow.Year + "-" + dnow.Month + "-" + dnow.Day;
                }
            }
            else
            {
                dnow = dnow.AddDays(1);
                bookingday = dnow.Year + "-" + dnow.Month + "-" + dnow.Day;
                bookingAdultPrice = Convert.ToInt32(route.Price);
                bookingChildPrice = Convert.ToInt32(route.ChildPrice);
                if (bookingAdultPrice != 0) strAdultPrice = bookingAdultPrice + "元";
            }
        }
        private void GetArgument()
        {
            string strRouteID = Function.GetQueryString("id");
            if (Function.IsNumber(strRouteID))
            {
                routeID = Convert.ToInt32(strRouteID);
            }
            else
            {
                Response.StatusCode = 404;
                Response.End();
            }
            comePY = Function.GetQueryString("py");
            appurl = SysConfig.webSiteApp + Request.RawUrl;
        }
        private void BindComment()
        {
            ClassLibrary.BLL.RouteComment cBll = new ClassLibrary.BLL.RouteComment();
            DataSet mtSet = cBll.GetPageData(100, 1, "checked = 1 and routeID=" + routeID, " createdTime desc");
            StringBuilder sb = new StringBuilder();
            DataTable myTable1 = mtSet.Tables["Data"];
            //DataTable tableCount1 = mtSet.Tables["Count"];
            int i = 0;
            int fen = 0;
            foreach (DataRow row in myTable1.Rows)
            {
                i++;
                fen += Convert.ToInt32(row["grade"]);
                sb.Append("<div class='comment_item'>");
                sb.AppendFormat("<div class='comment_user'>出游人：{0} &nbsp; &nbsp; &nbsp;   点评时间：{1} &nbsp; &nbsp; &nbsp;   满意度：<em>{2}</em></div>", Convert.ToBoolean(row["Anonymous"]) ? "匿名" : row["Nickname"].ToString(), Convert.ToDateTime(row["createdTime"]).ToShortDateString(), Convert.ToDouble(row["grade"]) * 20 + "%");
                sb.AppendFormat("<p class='comment_content'>{0}</p>", row["Content"]);
                sb.Append("</div>");
            }
            if (i == 0)
            {
                sb.Append("<div class='comment_item'>该线路暂无评论</div>");
            }
            commentGrade = i == 0 ? "100%" : Convert.ToDouble(fen / i) * 20 + "%";
            commentCount = i;

            datacomment = sb.ToString();
        }
        //绑定相关线路
        private void BindXiangRoute()
        {
            DataSet mySet = bll.GetPageData(5, 1, "isdisplay=1 and id <> " + routeID + " and CHARINDEX('," + route.LocationID + ",',','+routesPrentClassID+',')>0", " RouteOrder,CreatedTime desc");
            DataTable table = mySet.Tables["Data"];
            DataTable tableCount = mySet.Tables["Count"];

            int countRows = 0;
            countRows = Convert.ToInt32(tableCount.Rows[0][0].ToString());

            if (countRows < 5)
            {
                DataSet mySet2 = bll.GetPageData(5, 1, "isdisplay=1 and id <> " + routeID, "RouteOrder,CreatedTime desc");
                DataTable table2 = mySet2.Tables["Data"];
                table.Merge(table2);
                table = table.AsDataView().ToTable(true);
            }
            int index = 0;
            StringBuilder sb = new StringBuilder();

            foreach (DataRow dr in table.Rows)
            {
                index++;
                //sb.Append("<div class='main_car_main'>");
                string[] imgs = dr["image"].ToString().Split(',');
                int tmpClassId = Convert.ToInt32(dr["LocationID"].ToString());
                string tmpPy = gList.Find(delegate(ClassLibrary.Model.RouteClass tm) { return tm.ID == tmpClassId; }).ClassNamePY;
                sb.AppendLine("<li>");
                sb.AppendFormat("<a href='{4}/{3}/{2}.html' title='{1}' rel='nofollow'><img src='{0}' alt='{1}' width='217' height='136' /></a>",
                    SysConfig.UploadFilePathRoutesImg + imgs[0], dr["Title"].ToString() + dr["Bright"].ToString(), dr["ID"], tmpPy, SysConfig.webSite).AppendLine();
                sb.AppendFormat("<p class='item_t'><a href='{4}/{3}/{2}.html' title='{1}'>{0}</a></p>",
                    Function.Clip(dr["Title"].ToString(), 14, false), dr["Title"].ToString() + dr["Bright"].ToString(), dr["ID"], tmpPy, SysConfig.webSite).AppendLine();
                sb.AppendFormat("<p class='item_f'>{0}</p>", Function.Clip(dr["Bright"].ToString(), 16, false));
                string tp = string.Format("&yen;{0}<span>起</span>", Convert.ToInt32(dr["price"]));
                if (Convert.ToInt32(dr["price"]) == 0) tp = "电询";
                sb.AppendFormat("<p class='item_p'>{0}</p>", tp);
                sb.AppendLine("</li>");
                if (index == 5) break;
            }
            dataXiangRoute = sb.ToString();
        }
        //线路信息
        private void BindInfo()
        {
            route = bll.GetModel(routeID);
            if (route.routesClassID == "")
            {
                Response.StatusCode = 404;
                Response.End();
            }
            gList = rcBLL.GetModelList(String.Empty);
            if (route.ThemeID != "")
            {
                ClassLibrary.Model.RouteType classmodel = rtBll.GetModel(Convert.ToInt32(route.ThemeID.Split(',')[0]));
                if (classmodel != null) themeName = string.Format("<div class='info_zhuti'><a href='{0}/{1}/' target='_blank'>{2}</a></div>", SysConfig.webSite, classmodel.classNamePY, classmodel.ClassName);
            }
            routeClassId = route.LocationID;
            traffic = route.TrafficModel;
            if (traffic.IndexOf("自理") > -1) traffic = traffic.Replace("自理去", "").Replace("自理回", "").Trim();

            ClassLibrary.Model.RouteClass curClass = gList.Find(delegate(ClassLibrary.Model.RouteClass rc) { return rc.ID == routeClassId; });

            pingYin = curClass.ClassNamePY;
            if (curClass.ClassLevel == 4)
            {
                parentId = curClass.ParentID;
                displayName = curClass.ClassName;
                displayPy = curClass.ClassNamePY;
            }
            else if (curClass.ID == (int)SysConfig.RouteClass.三峡旅游 || curClass.ParentID == (int)SysConfig.RouteClass.三峡旅游 || curClass.ParentID == (int)SysConfig.RouteClass.豪华船)
            {
                parentId = (int)SysConfig.RouteClass.三峡旅游;
                displayName = "三峡";
                displayPy = "sanxia";
            }
            else
            {
                parentId = curClass.ID;
                displayName = curClass.ClassName;
                displayPy = curClass.ClassNamePY;
            }

            if (pingYin != comePY)
            {
                Response.StatusCode = 404;
                Response.End();
            }

            //购买事件
            buyEventStr = string.Format("buy2('{0}','{1}','{2}','{3}')",
                        route.ID,
                        Function.Clip(route.Title, 18, true),
                        route.RouteTime,
                        pingYin);

            dateType = route.DateType;
            price = Convert.ToInt32(route.Price);
            childPrice = Convert.ToInt32(route.ChildPrice);
            routeFeature = route.RouteFeature;
            descriptionPrice = route.DescriptionPrice;
            routeNotice = route.RouteNotice;
            detailType = route.DetailType;

            if (price == 0)
            {
                strPrice = "电询";
            }
            else
            {
                strPrice = "&yen;<em>" + price + "</em>起";
            }

            datePrice = "";

            if (route.DatePrice != "")
            {
                string[] tmpDatePrice = route.DatePrice.Split('|');
                string cDate = DateTime.Now.ToShortDateString().ToString();
                for (int k = 0; k < tmpDatePrice.Length; k++)
                {
                    string tmpPrices = tmpDatePrice[k];
                    if (tmpPrices == "") continue;
                    string[] tmpPrice = tmpPrices.Split(',');
                    TimeSpan ts = DateTime.Parse(tmpPrice[0]) - DateTime.Now;
                    if (ts.TotalDays > 0)
                    {
                        datePrice += tmpPrices + "|";
                    }
                }
            }

            StringBuilder sb = new StringBuilder();
            string[] imgs = route.Image.Split(',');
            if (imgs.Length <= 3) inactive = "inactive";
            int imgIndex = 0;
            foreach (string img in imgs)
            {
                imgIndex++;
                if (imgIndex == 1) firstImg = ClassLibrary.Common.SysConfig.UploadFilePathRoutesImg + img;
                sb.AppendFormat("<li class='{1}'><i></i><img src='{0}' alt='' width='100' height='63' /></li>", ClassLibrary.Common.SysConfig.UploadFilePathRoutesImg + img, imgIndex == 1 ? "on" : "");
            }
            smallImageList = sb.ToString();
        }
        private void BindDay()
        {

            if (route.DetailType == false)
            {
                dataDayInfo = "<div class='content_detail'>" + route.DescriptionRoute + "</div>";
            }
            else
            {
                ClassLibrary.BLL.RouteDetails daybll = new ClassLibrary.BLL.RouteDetails();
                DataTable myTable = daybll.GetList("routeid =" + route.ID + " order by dayorder");
                StringBuilder sb = new StringBuilder();
                StringBuilder sbday = new StringBuilder();
                sb.AppendLine("<div class='routeday_content'>");
                sbday.AppendLine("<div id='routeday_menu'>");
                sbday.AppendLine("<ul>");
                int i = 0;
                foreach (DataRow dr in myTable.Rows)
                {
                    i++;
                    if (i == 1)
                    {
                        sbday.AppendFormat("<li class='on'>{0}</li>", "第" + dr["dayorder"] + "天");
                    }
                    else
                    {
                        sbday.AppendFormat("<li>{0}</li>", "第" + dr["dayorder"] + "天");
                    }
                    sb.AppendLine("<div class='content_items'>");
                    sb.AppendFormat("<div class='content_date'><i>D{0}</i><span class='date_title'>{1}</span></div>", dr["dayorder"], dr["daytitle"]);
                    sb.AppendFormat("<div class='content_detail'>{0}</div>", dr["daydetail"]);
                    sb.AppendFormat("<div class='content_yc'><i></i><span class='yct'>餐饮</span><span>早餐：{0}</span><span>午餐：{1}</span><span>晚餐：{2}</span></div>",
                        Convert.ToInt32(dr["breakfast"]) == 0 ? "不含餐" : dr["breakfastdesc"].ToString() == "" ? "含早餐" : dr["breakfastdesc"].ToString(),
                        Convert.ToInt32(dr["lunch"]) == 0 ? "不含餐" : dr["lunchdesc"].ToString() == "" ? "含中餐" : dr["lunchdesc"].ToString(),
                        Convert.ToInt32(dr["dinner"]) == 0 ? "不含餐" : dr["dinnerdesc"].ToString() == "" ? "含晚餐" : dr["dinnerdesc"].ToString());
                    sb.AppendFormat("<div class='content_zs'><i></i><span class='yct'>住宿</span><span>{0}</span></div>", dr["hotel"].ToString() == "" ? "无" : dr["hotel"].ToString());
                    sb.AppendLine("</div>");
                    sb.AppendLine("<div class='clear'></div>");
                }
                sbday.AppendLine("</ul>");
                sbday.AppendLine("</div>");
                sb.AppendLine("</div>");
                dataDayInfo = sbday.ToString() + sb.ToString();
            }
        }
        //导航
        private void GetLocation()
        {

            ClassLibrary.Model.RouteClass crc = gList.Find(delegate(ClassLibrary.Model.RouteClass rc) { return rc.ID == route.LocationID; });

            location += string.Format("<i class='next'></i><a href='{2}/{0}/'>{1}</a>", crc.ClassNamePY, crc.ClassName.Replace("旅游", "") + "旅游", SysConfig.webSite);

            location += string.Format("<i class='next'></i>{0}", Function.Clip(route.Title, 38, true)); 
        }

        //添加评论
        private void AddComment()
        {
            if (!isLogin)
            {
                Response.Write("<script>alert('仅登录会员可评论...');history.back(-1);</script>");
                return;
            }
            ClassLibrary.Model.RouteComment model = new ClassLibrary.Model.RouteComment();

            model.routeID = Convert.ToInt32(Function.GetFormString("routeID"));
            model.Nickname = Function.GetFormString("Nickname");
            model.Email = HttpUtility.HtmlEncode(Function.GetFormString("Email"));
            model.Grade = Convert.ToByte(Function.GetFormString("xing"));
            model.Content = HttpUtility.HtmlEncode(Function.GetFormString("Content"));
            string pingyin = Function.GetFormString("pingyin");

            model.UserName = userName;

            if (!string.IsNullOrEmpty(Function.GetFormString("Anonymous")))
            {
                model.Anonymous = Convert.ToBoolean(Function.GetFormString("Anonymous"));
            }
            model.Checked = false;

            if (Session["ValidateCode"] == null)
            {
                Response.Write("<script>alert('验证码输入错误，请重新输入。');history.back(-1);</script>");
                return;
            }
            else if (Request.Form["yanz"] != Session["ValidateCode"].ToString())
            {
                Response.Write("<script>alert('验证码输入错误，请重新输入。');history.back(-1);</script>");
                return;
            }

            DataTable myTable = cmtBLL.GetData("routeID=" + model.routeID);

            DateTime lastTime = DateTime.Now;
            bool existcomment = false;
            foreach (DataRow dr in myTable.Rows)
            {
                lastTime = DateTime.Parse(dr["CreatedTime"].ToString());
                existcomment = true;
                break;
            }

            System.TimeSpan ts = DateTime.Now - lastTime;

            if (existcomment && ts.Days == 0 && ts.Hours == 0 && ts.Minutes <= 3)
            {
                Response.Write("<script>alert('请3分钟后重新输入！');history.back(-1);</script>");
                return;
            }

            if (cmtBLL.Add(model) > 0)
            {
                Response.Write("<script>alert('评论成功！');location.href='/" + pingyin + "/" + model.routeID + ".html';</script>");
            }
            else
            {
                Response.Write("<script>alert('评论失败，数据错误，请重试。。。');location.href='/" + pingyin + "/" + model.routeID + ".html';</script>");
            }
        }

        private void BindArticleList()
        {
            StringBuilder sb = new StringBuilder();

            string articleWhere = " isdisplay = 1 ";
            if (parentId == (int)SysConfig.RouteClass.三峡旅游)
            {
                articleWhere += " and IsSanxia = 1 ";
            }
            else
            {
                articleWhere += " and charindex('," + routeClassId + ",',','+routeClassID+',')>0 ";
            }
            DataSet mySet = newsBll.GetPageData(15, 1, articleWhere, "Createdtime desc");
            DataTable table = mySet.Tables["Data"];
            DataTable tableCount = mySet.Tables["Count"];

            int countRows = 0;
            countRows = Convert.ToInt32(tableCount.Rows[0][0].ToString());

            if (countRows < 15 && parentId != (int)SysConfig.RouteClass.三峡旅游 && parentId != routeClassId)
            {
                DataSet mySet3 = newsBll.GetPageData(15, 1, "isdisplay=1 and charindex('," + parentId + ",',','+routeClassID+',')>0", "Createdtime desc");
                DataTable table3 = mySet3.Tables["Data"];
                table.Merge(table3);
                table = table.AsDataView().ToTable(true);
            }
            //if (table.Rows.Count < 15)
            //{
            //    DataSet mySet2 = newsBll.GetPageData(15, 1, "isdisplay=1", "Createdtime desc");
            //    DataTable table2 = mySet2.Tables["Data"];
            //    table.Merge(table2);
            //    table = table.AsDataView().ToTable(true);
            //}

            int i = 0;
            foreach (DataRow dr in table.Rows)
            {
                i++;
                ClassLibrary.Model.RouteClass temClass = gList.Find(delegate(ClassLibrary.Model.RouteClass trc) { return trc.ID == Convert.ToInt32(dr["LocationID"].ToString()); });
                sb.AppendFormat("<li><a href='{0}/{1}/{2}.html' title='{3}' target='_blank'>{4}</a></li>",
                    SysConfig.webSite, Enum.GetName(typeof(SysConfig.NewsClassPY), Convert.ToInt32(dr["newsClassId"])), dr["ID"], dr["Title"], Function.Clip(dr["Title"].ToString(), 28, true)).AppendLine();
                
                if (i == 15) break;
            }
            dataArticleList = sb.ToString();
        }

    }
}