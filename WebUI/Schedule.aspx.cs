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
    public partial class Schedule : System.Web.UI.Page
    {
        protected string scheduleList = "";
        protected string appurl = SysConfig.webSiteApp + "/sanxia/";

        ClassLibrary.BLL.Routes routeBll = new ClassLibrary.BLL.Routes();
        ClassLibrary.BLL.RouteClass rcBll = new ClassLibrary.BLL.RouteClass();

        List<ClassLibrary.Model.RouteClass> gList;

        protected void Page_Load(object sender, EventArgs e)
        {
            BindSchedule();
        }

        private void BindSchedule()
        {
            DateTime dt = DateTime.Now;
            StringBuilder sb = new StringBuilder();
            gList = rcBll.GetModelList(string.Empty);
            List<ClassLibrary.Model.Routes> routeList = routeBll.GetModelList("isdisplay = 1 and CHARINDEX('," + (int)SysConfig.RouteClass.豪华船 + ",',','+routesPrentClassID+',') > 0 and DateType = 1");

            for (int n = 0; n < 30; n++)
            {
                dt = dt.AddDays(1);
                sb.AppendLine("<dl>");
                sb.AppendFormat("<dd class='tgs_date'>{0}月{1}日&nbsp;&nbsp;{2}</dd>", dt.Month, dt.Day, System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.GetDayName(dt.DayOfWeek).Replace("星期", "周"));
                string cdate = dt.Year + "-" + dt.Month + "-" + dt.Day;
                List<ClassLibrary.Model.Routes> cList = routeList.FindAll(delegate(ClassLibrary.Model.Routes rs) { return rs.DatePrice.IndexOf(cdate + ",") > -1; });

                if (cList.Count == 0)
                {
                    sb.AppendLine("<dd>今日暂无船期</dd>");
                }
                else
                {
                    int cn = 0;
                    foreach (ClassLibrary.Model.Routes rm in cList)
                    {
                        cn++;
                        string price = getPrice(cdate, rm.DatePrice);
                        string tmpPing = gList.Find(delegate(ClassLibrary.Model.RouteClass rc) { return rc.ID == rm.LocationID; }).ClassNamePY;
                        sb.AppendFormat("<dd><a href='{0}/{1}/{2}.html' target='_blank'>{3}</a><span>&yen;{4}元</span></dd>",
                            SysConfig.webSite, tmpPing, rm.ID, rm.BoatName, price);
                        if (cn >= 8) break;
                    }
                }
                sb.AppendLine("</dl>");
            }

            scheduleList = sb.ToString();
        }
        private string getPrice(string cdate, string dprice)
        {
            string[] prices = dprice.Split('|');
            string p = "";
            foreach (string price in prices)
            {
                if (price.IndexOf(cdate + ",") > -1)
                {
                    p = price.Split(',')[1];
                    break;
                }
            }
            return p;
        }
    }
}
