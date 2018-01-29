using System;
using System.Data;
using System.Text;
using ClassLibrary.Common;
using System.Collections.Generic;
using System.Collections;

namespace WebUI.WebManage.Advertise
{
    public partial class SaleAdvertiseList : System.Web.UI.Page
    {
        int pageSize = 20;
        protected int pageIndex;
        protected int saleorder = 0;
        protected string searchKey;
        protected string routeClassID;

        protected string linksList;
        protected string pageInfo;
        protected string routeClassList;

        ClassLibrary.BLL.RouteType rtBLL = new ClassLibrary.BLL.RouteType();
        ClassLibrary.BLL.SaleAdvertise saleBLL = new ClassLibrary.BLL.SaleAdvertise();
        Pagination pg = new Pagination();
        List<ClassLibrary.Model.RouteType> rtList = new List<ClassLibrary.Model.RouteType>();

        protected void Page_Load(object sender, EventArgs e)
        {
            UserInfo.ChekcPower();

            getArgument();
            BindRouteClass();
            BindData();
        }

        private void BindRouteClass()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("<option value='1' {0}>国内旅游</option>", routeClassID == "1" ? "selected" : "");
            sb.AppendFormat("<option value='2' {0}>出境旅游</option>", routeClassID == "2" ? "selected" : "");
            sb.AppendFormat("<option value='3' {0}>三峡旅游</option>", routeClassID == "3" ? "selected" : "");
            sb.AppendFormat("<option value='5' {0}>周边旅游</option>", routeClassID == "5" ? "selected" : "");
            foreach (ClassLibrary.Model.RouteType model in rtList)
            {
                sb.AppendFormat("<option value='z{0}' {2}>{1}</option>", model.ID, model.ClassName, routeClassID == ("z" + model.ID) ? "selected" : "").AppendLine();
            }

            routeClassList = sb.ToString();
        }

        private void getArgument()
        {
            searchKey = Function.GetQueryString("key");
            routeClassID = Function.GetQueryString("cid");
            if (Function.GetQueryString("sorder") != "") saleorder = Convert.ToInt32(Function.GetQueryString("sorder"));

            string strPageIndex = Request.QueryString["page"];
            if (Function.IsNumber(strPageIndex))
            {
                pageIndex = Convert.ToInt32(strPageIndex);
            }
            else
            {
                pageIndex = 1;
            }

            rtList = rtBLL.GetModelList(string.Empty, "ClassOrder Asc, CreatedTime Desc");
        }
        
        private void BindData()
        {

            string strWhere = "1=1 ";
            if (routeClassID != "")
            {
                strWhere += " AND RouteClassId = '" + routeClassID + "'";
            }
            if (!string.IsNullOrEmpty(searchKey))
            {
                strWhere += " AND CHARINDEX('" + searchKey + "', Title)>0";
            }

            string strOrder = "CreatedTime Desc";
            if (saleorder != 0)
            {
                if (saleorder == 1) strOrder = "SaleOrder Asc, " + strOrder;
                else if (saleorder == 2) strOrder = "SaleOrder Desc, " + strOrder;
            }
            strOrder += "";

            DataSet mySet = saleBLL.GetPageData(20, pageIndex, strWhere, strOrder);
            DataTable tableCount = mySet.Tables["Count"];
            DataTable myTable = mySet.Tables["Data"];

            int countRows = 0;
            countRows = Convert.ToInt32(tableCount.Rows[0][0].ToString());
            string[] urlParam = { "key", "cid", "sorder" };
            pageInfo = pg.pageForDynamic(countRows, 20, pageIndex, urlParam);

            StringBuilder sb = new StringBuilder();

            int i = 0;
            int rowIndex = 0;

            List<ClassLibrary.Model.SaleAdvertise> saList = saleBLL.DataTableToList(myTable);

            foreach (ClassLibrary.Model.SaleAdvertise model in saList)
            {
                i++;
                rowIndex = pageSize * (pageIndex - 1) + i;

                sb.AppendFormat("<tr id='tr_{0}'>", model.ID);

                sb.AppendFormat("<td align='center'>{0}</td>", rowIndex);
                sb.AppendFormat("<td align='center'><img src='{0}{1}' width='100' height='60' /></td>", SysConfig.UploadFilePathAdImg, model.Img);

                string className = "";
                if (Function.IsNumber(model.RouteClassId))
                {
                    className = Enum.GetName(typeof(SysConfig.RouteClass), Convert.ToInt32(model.RouteClassId));
                }
                else
                {
                    ClassLibrary.Model.RouteType tmpType = rtList.Find(delegate(ClassLibrary.Model.RouteType rt) { return ("z" + rt.ID) == model.RouteClassId; });
                    if (tmpType != null) className = tmpType.ClassName;
                }
                sb.AppendFormat("<td>{0}</td>", className);
                sb.AppendFormat("<td>{0}</td>", model.Title);
                sb.AppendFormat("<td>{0}</td>", model.LinkUrl);
                sb.AppendFormat("<td align='center'><input type='text' class='ipt' id='SaleOrder_{1}' value='{0}' maxlength='5' size='3'/><input type='button' class='button' value='修改' size='3' onclick='UpdateSaleOrder({1})' /></td>", model.SaleOrder, model.ID);
                sb.AppendFormat("<td align='center'>{0}</td>", model.ExpiredTime.ToString("yyyy-MM-dd"));
                sb.AppendFormat("<td align='center'>{0}</td>", model.CreatedTime.ToString());
                sb.Append("<td align='center'>");
                sb.AppendFormat("<a href='SaleAdvertiseEdit.aspx?id={0}'>修改</a>　", model.ID);
                sb.AppendFormat("<a href='javascript:void(0)' onclick='SaleAdvertiseDelete({0},\"{1}\")'>删除</a>", model.ID, model.Img);
                sb.Append("</td>");

                sb.Append("</tr>");
            }

            if (sb.Length == 0)
            {
                sb.Append("<tr><td colspan='9'>没有相关数据</td></tr>");
            }

            linksList = sb.ToString();
        }
    }
}
