using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Text;
using ClassLibrary.Common;
using System.Collections;

namespace WebUI
{
    public partial class shopcart : System.Web.UI.Page
    {
        protected string hotRouteList = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            GetHotRoute();
        }

        protected void GetHotRoute()
        {
            ClassLibrary.BLL.Routes bll = new ClassLibrary.BLL.Routes();
            ClassLibrary.BLL.RouteClass rcBll = new ClassLibrary.BLL.RouteClass();
            List<ClassLibrary.Model.RouteClass> rcList = rcBll.GetModelList(String.Empty);
            List<ClassLibrary.Model.Routes> list = bll.GetModelList(6, "isdisplay = 1", "RecommendHot Desc,routeOrder Asc,CreatedTime Desc");

            string strHTML = @"<div class='pro'>
                                    <a href='{6}/{5}/{3}.html' target='_blank'>
                                        <img src='{0}' width='180px' height='120px' alt='{1}' />
                                    </a>
                                    <p class='name'><a href='{6}/{5}/{3}.html' title='{1}' target='_blank'>{2}</a></p>
                                    <p class='price'>{4}</p>
                                </div>";

            StringBuilder sb = new StringBuilder();

            foreach (ClassLibrary.Model.Routes model in list)
            {
                //int classId = Convert.ToInt32(model.routesClassID.Split(',')[1]);
                sb.AppendFormat(strHTML,
                    SysConfig.GetRoutePhoto(model.Image),
                    model.Title,
                    Function.Clip(model.Title, 14, true),
                    model.ID,
                    (model.Price == 0 ? "价格电询" : "&yen;" + Convert.ToInt32(model.Price) + "起"),
                    rcList.Find(delegate(ClassLibrary.Model.RouteClass rcm) { return rcm.ID == model.LocationID; }).ClassNamePY,
                    SysConfig.webSite);
            }

            hotRouteList = sb.ToString();

        }

    }
}