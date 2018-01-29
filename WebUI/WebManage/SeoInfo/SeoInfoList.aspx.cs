using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using ClassLibrary.Common;
using System.Text;

namespace WebUI.WebManage.SeoInfo
{
    public partial class SeoInfoList : System.Web.UI.Page
    {
        protected string searchClass1;
        protected string searchClass2;
        protected string dataSeoInfoList;
        protected string pageInfo;
        protected int pageIndex;

        protected string routeClassBig = "";
        protected string routeClassNext = "";

        ClassLibrary.BLL.SeoInfo siBLL = new ClassLibrary.BLL.SeoInfo();
        ClassLibrary.Common.Pagination pg = new ClassLibrary.Common.Pagination();
        ClassLibrary.BLL.RouteClass routeClassBLL = new ClassLibrary.BLL.RouteClass();
        List<ClassLibrary.Model.RouteClass> rcList = new List<ClassLibrary.Model.RouteClass>();

        protected void Page_Load(object sender, EventArgs e)
        {
            ClassLibrary.Common.UserInfo.ChekcPower();
            getArgument();
            BindData();
            SearchFormRouteBigClass();
            SearchFormRouteNextClass();
        }
        private void getArgument()
        {
            string strPageIndex = Request.QueryString["page"];
            if (ClassLibrary.Common.Function.IsNumber(strPageIndex))
            {
                pageIndex = Convert.ToInt32(strPageIndex);
            }
            else
            {
                pageIndex = 1;
            }
            rcList = routeClassBLL.GetModelList(String.Empty);
        }
        //搜索  线路类型
        private void SearchFormRouteBigClass()
        {
            List<ClassLibrary.Model.RouteClass> list = rcList.FindAll(delegate(ClassLibrary.Model.RouteClass rc) { return rc.ParentID == 0; }); //routeClassBLL.GetModelList("ParentID=0");

            StringBuilder sb = new StringBuilder();

            foreach (ClassLibrary.Model.RouteClass model in list)
            {
                sb.AppendFormat("<option value='{0}' {2}>{1}</option>", model.ID, model.ClassName, searchClass1 == model.ID.ToString() ? "selected" : "");
            }

            routeClassBig = sb.ToString();
        }
        private void SearchFormRouteNextClass()
        {
            if (Function.IsNumber(searchClass1))
            {
                int maxClassID = Convert.ToInt32(searchClass1);

                DataTable myTable = routeClassBLL.GetTableSubList(maxClassID, string.Empty);

                myTable = ClassLibrary.BLL.WebClass.GetRouteTree(myTable, 0);

                StringBuilder sb = new StringBuilder();

                int rowIndex = 0;
                foreach (DataRow dr in myTable.Rows)
                {
                    rowIndex++;
                    if (rowIndex == 1) //去掉第一行数据，第一行是顶级(ParendID=0)
                    {
                        continue;
                    }

                    sb.AppendFormat("<option value='{0}' {2}>{1}</option>", dr["ID"].ToString(), dr["ClassName"].ToString(), searchClass2 == dr["ID"].ToString() ? "selected" : "");
                }

                routeClassNext = sb.ToString();
            }
        }
        private void BindData()
        {
            int routeClassID = 0;

            string strWhere = "1=1 ";

            //搜索 - 大类
            searchClass1 = Function.GetQueryString("cid1");
            if (Function.IsNumber(searchClass1))
            {
                routeClassID = Convert.ToInt32(searchClass1);
            }
            //搜索 - 小类
            searchClass2 = Function.GetQueryString("cid2");
            if (Function.IsNumber(searchClass2))
            {
                routeClassID = Convert.ToInt32(searchClass2);
            }
            //跟据传过来的类别ID
            if (routeClassID != 0)
            {
                strWhere += " AND RouteClassID=" + routeClassID;
            }
            strWhere += " AND month = 0";
            DataSet mySet = siBLL.GetPageData(20, pageIndex, strWhere, "createdTime desc");
            DataTable tableCount = mySet.Tables["Count"];
            DataTable myTable = mySet.Tables["Data"];

            int countRows = 0;
            countRows = Convert.ToInt32(tableCount.Rows[0][0].ToString());
            string[] urlParam = { "key", "cid1", "cid2" };
            pageInfo = pg.pageForDynamic(countRows, 20, pageIndex, urlParam);

            StringBuilder sb = new StringBuilder();

            foreach (DataRow dr in myTable.Rows)
            {
                sb.AppendFormat("<tr id='tr_{0}'>", dr["ID"].ToString());
                string className = rcList.Find(delegate(ClassLibrary.Model.RouteClass rc) { return rc.ID == Convert.ToInt32(dr["RouteClassID"].ToString()); }).ClassName;
                sb.AppendFormat("<td align='center'>{0}</td>", className);
                string themeName = "";
                if (dr["ThemeId"].ToString() != "0")
                {
                    themeName = rcList.Find(delegate(ClassLibrary.Model.RouteClass rc) { return rc.ID == Convert.ToInt32(dr["ThemeId"].ToString()); }).ClassName;
                }
                sb.AppendFormat("<td align='center'>{0}</td>", themeName);
                int days = Convert.ToInt32(dr["Days"].ToString());
                string dayName = Enum.GetName(typeof(SysConfig.Numbers), days) + "日游";
                if (dr["MaxClassId"].ToString() == "2" && days == 5) dayName += "及以下";
                if (dr["MaxClassId"].ToString() == "1" && days == 7) dayName += "及以上";
                if (days == 11) dayName += "及以上";
                sb.AppendFormat("<td align='center'>{0}</td>", days == 0 ? "" : dayName);
                string price = dr["Price"].ToString();
                if (price != null && price != "")
                {
                    string[] temPrice = price.Split('-');
                    if (temPrice[0] == "0")
                    {
                        price = temPrice[1] + "元以下";
                    }
                    else if (temPrice[1] == "0")
                    {
                        price = temPrice[0] + "元以上";
                    }
                    else
                    {
                        price += "元";
                    }
                }
                sb.AppendFormat("<td align='center'>{0}</td>", price);
                sb.AppendFormat("<td align='center'>{0}</td>", Convert.ToDateTime(dr["CreatedTime"]).ToString("yyyy-MM-dd"));
                sb.Append("<td align='center'>");
                sb.AppendFormat("<a href='SeoInfoEdit.aspx?id={0}'>修改</a>　", dr["ID"].ToString());
                sb.AppendFormat("<a href='javascript:void(0)' onclick='seoInfoDelete({0})'>删除</a>　", dr["ID"].ToString());
                sb.Append("</td>");

                sb.Append("</tr>");
            }
            dataSeoInfoList = sb.ToString();
        }

    }
}