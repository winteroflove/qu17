using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClassLibrary.Common;
using System.Text;
using System.Collections;
using System.Data;

namespace WebUI.WebApp
{
    public partial class appRouteDetail : System.Web.UI.Page
    {
        protected int routeID;
        string comePY = "";
        protected ClassLibrary.Model.Routes route = new ClassLibrary.Model.Routes();
        protected string themeName = "";
        protected int routeClassId;
        protected string buyEventStr = "";
        protected string datePrice = "";
        protected bool dateType;
        protected int price = 0;
        protected int childPrice = 0;
        protected string routeFeature = "";
        protected string descriptionPrice = "";
        protected string routeNotice = "";
        protected bool detailType;
        protected string bookingday = "";
        protected int bookingAdultPrice = 0;
        protected int bookingChildPrice = 0;
        protected string image = "";
        protected string commentGrade = "";
        protected int commentCount = 0;
        protected string routedays = "";
        protected string mipUrl = "";

        ClassLibrary.BLL.Routes bll = new ClassLibrary.BLL.Routes();
        ClassLibrary.BLL.RouteClass rcBLL = new ClassLibrary.BLL.RouteClass();
        List<ClassLibrary.Model.RouteClass> gList = new List<ClassLibrary.Model.RouteClass>();

        protected void Page_Load(object sender, EventArgs e)
        {
            GetArgument();
            BindInfo();
            BindRouteDays();
            BindBooking();
            bll.Updates("ViewCount=ViewCount+1", "ID=" + routeID);
            BindComment();
        }
        private void BindRouteDays()
        {
            StringBuilder sb = new StringBuilder();
            if (!detailType)
            {
                sb.AppendFormat("<div class='detl_route'>{0}</div>", replaceSite(route.DescriptionRoute));
            }
            else
            {
                ClassLibrary.BLL.RouteDetails rdBll = new ClassLibrary.BLL.RouteDetails();
                List<ClassLibrary.Model.RouteDetails> detailList = rdBll.GetModelList("routeid =" + route.ID + " order by dayorder");
                sb.AppendLine("<div class='route_days'>");
                foreach (ClassLibrary.Model.RouteDetails model in detailList)
                {
                    sb.AppendLine("<div class='days_item'>");
                    sb.AppendLine("<div class='route_date'>");
                    sb.AppendLine("<i class='icon_r'></i>");
                    sb.AppendLine("<div class='rdtitle'>");
                    sb.AppendFormat("<div class='date_no'>第{0}天</div>", model.DayOrder).AppendLine();
                    sb.AppendFormat("<div class='date_title'>{0}</div>", model.DayTitle).AppendLine();
                    sb.AppendLine("</div>");
                    sb.AppendLine("</div>");
                    sb.AppendFormat("<div class='route_dtl'>{0}</div>", replaceSite(model.DayDetail)).AppendLine();
                    sb.AppendLine("<div class='route_tips'>");
                    sb.AppendFormat("<div class='catering'><span>早餐：{0}</span><span>中餐：{1}</span><span>晚餐：{2}</span></div>",
                        model.BreakFast ? "含" : "无", model.Lunch ? "含" : "无", model.Dinner ? "含" : "无");
                    sb.AppendFormat("<div class='hotel'>住宿：{0}</div>", model.Hotel == "" ? "无" : model.Hotel);
                    sb.AppendLine("</div>");
                    sb.AppendLine("</div>");
                }
                sb.AppendLine("</div>");
            }
            routedays = sb.ToString();
        }
        private void BindComment()
        {
            ClassLibrary.BLL.RouteComment cBll = new ClassLibrary.BLL.RouteComment();
            DataSet mtSet = cBll.GetPageData(100, 1, "checked = 1 and routeID=" + routeID, " createdTime desc");
            DataTable myTable1 = mtSet.Tables["Data"];
            int i = 0;
            int fen = 0;
            foreach (DataRow row in myTable1.Rows)
            {
                i++;
                fen += Convert.ToInt32(row["grade"]);
            }
            commentGrade = i == 0 ? "100%" : Convert.ToDouble(fen / i) * 20 + "%";
            commentCount = i;

        }
        private void BindBooking()
        {
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
                        foreach (DateTime dtitem in priceList)
                        {
                            string cdate = dtitem.Year + "-" + dtitem.Month + "-" + dtitem.Day;
                            string[] cprice = pricetable[dtitem].ToString().Split(',');
                            bookingday = cdate;
                            bookingAdultPrice = Convert.ToInt32(cprice[0]);
                            bookingChildPrice = Convert.ToInt32(cprice[1]);
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
            }
        }
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
                ClassLibrary.Model.RouteClass classmodel = gList.Find(delegate(ClassLibrary.Model.RouteClass rc) { return rc.ID == Convert.ToInt32(route.ThemeID.Split(',')[0]); });
                themeName = "<div class='detl_zt'>" + classmodel.ClassName + "</div>";
            }
            routeClassId = route.LocationID;
            ClassLibrary.Model.RouteClass curClass = gList.Find(delegate(ClassLibrary.Model.RouteClass rc) { return rc.ID == routeClassId; });
            
            if (curClass.ClassNamePY != comePY)
            {
                Response.StatusCode = 404;
                Response.End();
            }
            mipUrl = SysConfig.webSiteApp + "/mip/" + comePY + "/" + routeID + ".html";
            //购买事件
            buyEventStr = string.Format("buy2('{0}','{1}','{2}','{3}')",
                        route.ID,
                        Function.Clip(route.Title, 18, true),
                        route.RouteTime,
                        curClass.ClassNamePY);

            dateType = route.DateType;
            price = Convert.ToInt32(route.Price);
            childPrice = Convert.ToInt32(route.ChildPrice);
            routeFeature = replaceSite(route.RouteFeature);
            descriptionPrice = replaceSite(route.DescriptionPrice);
            routeNotice = replaceSite(route.RouteNotice);
            detailType = route.DetailType;

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

            string[] imgs = route.Image.Split(',');
            image = SysConfig.webSite + SysConfig.UploadFilePathRoutesImg + imgs[0];
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
        }

        protected string replaceSite(string content)
        {
            return content.Replace(SysConfig.webSite, SysConfig.webSiteApp)
                .Replace(SysConfig.webSiteApp + "/images/", SysConfig.webSite + "/images/")
                .Replace("\"/images/", "\"" + SysConfig.webSite + "/images/");
        }
    }
}