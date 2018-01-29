using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClassLibrary.Common;
using System.Text;

namespace WebUI.WebManage.SeoInfo
{
    public partial class SeoInfoAdd : System.Web.UI.Page
    {
        protected string routeClassList;
        protected string themeClassList;
        ClassLibrary.BLL.RouteClass rcBll = new ClassLibrary.BLL.RouteClass();
        ClassLibrary.BLL.SeoInfo siBll = new ClassLibrary.BLL.SeoInfo();
        ClassLibrary.BLL.RouteType rtBll = new ClassLibrary.BLL.RouteType();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Function.IsPostMethod())
            {
                if (Request.QueryString["ac"] == "add")
                {
                    AddSeoInfo();
                }
            }
            else
            {
                BindRouteClass();
                BindThemeClass();
            }
        }
        private void BindThemeClass()
        {
            List<ClassLibrary.Model.RouteType> list = rtBll.GetModelList("");

            StringBuilder sb = new StringBuilder();

            foreach (ClassLibrary.Model.RouteType model in list)
            {
                sb.AppendFormat("<option value='{0}'>{1}</option>", model.ID, model.ClassName);
            }

            themeClassList = sb.ToString();
        }
        private void BindRouteClass()
        {
            List<ClassLibrary.Model.RouteClass> list = rcBll.GetModelList("parentId = 0", "ID Asc");

            StringBuilder sb = new StringBuilder();

            foreach (ClassLibrary.Model.RouteClass model in list)
            {
                sb.AppendFormat("<option value='{0}'>{1}</option>", model.ID, model.ClassName);
            }

            routeClassList = sb.ToString();
        }
        private void AddSeoInfo()
        {
            ClassLibrary.Model.SeoInfo siModel = new ClassLibrary.Model.SeoInfo();
            if (Request.Form["classId1"] == "0")
            {
                Response.Write("<script>alert('请选择目的地！');history.back(-1);</script>");
                return;
            }
            if (Request.Form["themeId"] == "0" && Request.Form["routeDays"] == "0" && Request.Form["routePrice"] == "")
            {
                Response.Write("<script>alert('请选择组合条件！');history.back(-1);</script>");
                return;
            }
            siModel.MaxClassId = Convert.ToInt32(Request.Form["classId1"]);
            if (Request.Form["classId2"] != "")
            {
                siModel.RouteClassID = Convert.ToInt32(Request.Form["classId2"]);
            }
            else
            {
                siModel.RouteClassID = siModel.MaxClassId;
            }
            if (Request.Form["themeId"] != "0") siModel.ThemeId = Convert.ToInt32(Request.Form["themeId"]);
            if (Request.Form["routeDays"] != "0") siModel.Days = Convert.ToInt32(Request.Form["routeDays"]);
            siModel.Price = Request.Form["routePrice"];
            siModel.SeoTitle = Request.Form["SeoTitle"];
            siModel.SeoKeyword = Request.Form["SeoKeywords"];
            siModel.SeoDescription = Request.Form["SeoDescription"];
            if (siBll.Add(siModel) > 0)
            {
                Function.goMessagePage("添加SEO信息", "操作成功", "SeoInfo/SeoInfoList.aspx");
            }
            else
            {
                Function.goMessagePage("添加SEO信息", "操作失败，请稍后再试", "SeoInfo/SeoInfoList.aspx");
            }
        }
    }
}