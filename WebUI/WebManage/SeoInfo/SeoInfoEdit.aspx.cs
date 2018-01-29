using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClassLibrary.Common;
using System.Text;
using System.Data;

namespace WebUI.WebManage.SeoInfo
{
    public partial class SeoInfoEdit : System.Web.UI.Page
    {
        protected int seoId;
        protected string routeClassList;
        protected string subRClassList;
        protected string themeClassList;
        protected string daysList;
        protected string priceList;
        protected string seoTitle;
        protected string seoKey;
        protected string seoDesc;
        protected int maxClassId;
        ClassLibrary.Model.SeoInfo mymodel = new ClassLibrary.Model.SeoInfo();
        ClassLibrary.BLL.RouteClass rcBll = new ClassLibrary.BLL.RouteClass();
        ClassLibrary.BLL.SeoInfo siBll = new ClassLibrary.BLL.SeoInfo();
        ClassLibrary.BLL.RouteType rtBll = new ClassLibrary.BLL.RouteType();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Function.IsPostMethod())
            {
                if (Request.QueryString["ac"] == "add")
                {
                    EditSeoInfo();
                }
            }
            else
            {
                GetArgument();
                BindData();
                BindRouteClass();
                BindThemeClass();
                BindSubRouteClass();
                BindDays();
                BindPrice();
            }
        }
        private void BindPrice()
        {
            StringBuilder sb = new StringBuilder();
            if (mymodel.MaxClassId == (int)SysConfig.RouteClass.出境旅游)
            {
                sb.AppendFormat("<option value='0-3000' {0}>3000以下</option>", mymodel.Price == "0-3000" ? "selected" : "");
                sb.AppendFormat("<option value='3000-8000' {0}>3000-8000元</option>", mymodel.Price == "3000-8000" ? "selected" : "");
                sb.AppendFormat("<option value='8000-15000' {0}>8000-15000元</option>", mymodel.Price == "8000-15000" ? "selected" : "");
                sb.AppendFormat("<option value='15000-20000' {0}>15000-20000元</option>", mymodel.Price == "15000-20000" ? "selected" : "");
                sb.AppendFormat("<option value='20000-0' {0}>20000元以上</option>", mymodel.Price == "20000-0" ? "selected" : "");
            }
            else if (mymodel.MaxClassId != 0)
            {
                sb.AppendFormat("<option value='0-500' {0}>500以下</option>", mymodel.Price == "0-500" ? "selected" : "");
                sb.AppendFormat("<option value='500-1500' {0}>500-1500元</option>", mymodel.Price == "500-1500" ? "selected" : "");
                sb.AppendFormat("<option value='1500-3000' {0}>1500-3000元</option>", mymodel.Price == "1500-3000" ? "selected" : "");
                sb.AppendFormat("<option value='3000-10000' {0}>3000-10000元</option>", mymodel.Price == "3000-10000" ? "selected" : "");
                sb.AppendFormat("<option value='10000-0' {0}>10000元以上</option>", mymodel.Price == "10000-0" ? "selected" : "");
            }
            priceList = sb.ToString();
        }
        private void BindDays()
        {
            StringBuilder sb = new StringBuilder();
            if (mymodel.MaxClassId == (int)SysConfig.RouteClass.出境旅游)
            {
                sb.AppendFormat("<option value='5' {0}>五日游及以下</option>", mymodel.Days == 5 ? "selected" : "");
                sb.AppendFormat("<option value='6' {0}>六日游</option>", mymodel.Days == 6 ? "selected" : "");
                sb.AppendFormat("<option value='7' {0}>七日游</option>", mymodel.Days == 7 ? "selected" : "");
                sb.AppendFormat("<option value='8' {0}>八日游</option>", mymodel.Days == 8 ? "selected" : "");
                sb.AppendFormat("<option value='9' {0}>九日游</option>", mymodel.Days == 9 ? "selected" : "");
                sb.AppendFormat("<option value='10' {0}>十日游</option>", mymodel.Days == 10 ? "selected" : "");
                sb.AppendFormat("<option value='11' {0}>十一日游及以上</option>", mymodel.Days == 11 ? "selected" : "");
            }
            else if (mymodel.MaxClassId != 0)
            {
                sb.AppendFormat("<option value='1' {0}>一日游</option>", mymodel.Days == 1 ? "selected" : "");
                sb.AppendFormat("<option value='2' {0}>二日游</option>", mymodel.Days == 2 ? "selected" : "");
                sb.AppendFormat("<option value='3' {0}>三日游</option>", mymodel.Days == 3 ? "selected" : "");
                sb.AppendFormat("<option value='4' {0}>四日游</option>", mymodel.Days == 4 ? "selected" : "");
                sb.AppendFormat("<option value='5' {0}>五日游</option>", mymodel.Days == 5 ? "selected" : "");
                sb.AppendFormat("<option value='6' {0}>六日游</option>", mymodel.Days == 6 ? "selected" : "");
                sb.AppendFormat("<option value='7' {0}>七日游及以上</option>", mymodel.Days == 7 ? "selected" : "");
            }
            daysList = sb.ToString();
        }
        private void GetArgument()
        {
            string id = Request.QueryString["id"];

            if (Function.IsNumber(id))
            {
                seoId = Convert.ToInt32(id);
            }
            else
            {
                Function.goMessagePage("修改SEO信息", "操作失败，参数错误!", "SeoInfo/SeoInfoList.aspx");
            }
        }
        private void BindData()
        {
            mymodel = siBll.GetModel(seoId);
            seoTitle = mymodel.SeoTitle;
            seoKey = mymodel.SeoKeyword;
            seoDesc = mymodel.SeoDescription;
            maxClassId = mymodel.MaxClassId;
        }
        private void BindThemeClass()
        {
            List<ClassLibrary.Model.RouteType> list = rtBll.GetModelList("");

            StringBuilder sb = new StringBuilder();

            foreach (ClassLibrary.Model.RouteType model in list)
            {
                sb.AppendFormat("<option value='{0}' {2}>{1}</option>", model.ID, model.ClassName, mymodel.ThemeId == model.ID ? "selected" : "");
            }

            themeClassList = sb.ToString();
        }
        private void BindRouteClass()
        {
            List<ClassLibrary.Model.RouteClass> list = rcBll.GetModelList("parentId = 0", "ID Asc");

            StringBuilder sb = new StringBuilder();

            foreach (ClassLibrary.Model.RouteClass model in list)
            {
                sb.AppendFormat("<option value='{0}' {2}>{1}</option>", model.ID, model.ClassName, mymodel.MaxClassId == model.ID ? "selected" : "");
            }

            routeClassList = sb.ToString();
        }
        private void BindSubRouteClass()
        {
            DataTable myTable = rcBll.GetTableSubList(mymodel.MaxClassId, string.Empty);

            myTable = ClassLibrary.BLL.WebClass.GetRouteTree(myTable, 0);

            StringBuilder sb = new StringBuilder();
            sb.Append("<option value=''>不限　　　　</option>");
            int rowIndex = 0;
            foreach (DataRow dr in myTable.Rows)
            {
                rowIndex++;
                if (rowIndex == 1)
                {
                    continue;
                }
                sb.AppendFormat("<option value='{0}' {2}>{1}</option>", dr["ID"].ToString(), dr["ClassName"].ToString(), dr["ID"].ToString() == mymodel.RouteClassID.ToString() ? "selected" : "");
            }
            subRClassList = sb.ToString();
        }
        private void EditSeoInfo()
        {
            ClassLibrary.Model.SeoInfo siModel = new ClassLibrary.Model.SeoInfo();
            siModel.ID = Convert.ToInt32(Request.Form["seoId"]);
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

            if (siBll.Update(siModel))
            {
                Function.goMessagePage("编辑SEO信息", "操作成功", "SeoInfo/SeoInfoList.aspx");
            }
            else
            {
                Function.goMessagePage("编辑SEO信息", "操作失败，请稍后再试", "SeoInfo/SeoInfoList.aspx");
            }
        }
    }
}