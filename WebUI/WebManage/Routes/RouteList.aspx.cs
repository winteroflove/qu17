using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using ClassLibrary.Common;

namespace WebUI.WebManage.Routes 
{
    public partial class RouteList : System.Web.UI.Page
    {
        protected string searchClass1;
        protected string searchClass2;
        protected string searchKey;
        protected string supKey;
        protected string dataRouteList;
        protected string pageInfo;
        protected int pageIndex;

        protected string routeClassBig = "";
        protected string routeClassNext = "";
        protected int routeorder = 0;
        protected int timeorder = 0;

        ClassLibrary.BLL.Routes routeBLL = new ClassLibrary.BLL.Routes();
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
            searchKey = Function.GetQueryString("key");
            supKey = Function.GetQueryString("sKey");
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
                strWhere += " AND (CHARINDEX('," + routeClassID + ",',','+routesPrentClassID+',')>0)";
            }

            if (!string.IsNullOrEmpty(searchKey))
            {
                strWhere += " AND CHARINDEX('" + searchKey + "',Title)>0";
            }
            if (!string.IsNullOrEmpty(supKey))
            {
                strWhere += " AND CHARINDEX('" + supKey + "',Supplier)>0";
            }
            /*DataTable myTable = routeBLL.GetData(strWhere, "firstTime desc, createdTime desc");

            string[] urlParam = { "key", "cid1", "cid2" };
            myTable = pg.pagination(myTable, 20, urlParam);
            pageInfo = pg.pageNumList;*/
            string strOrder = "isdisplay desc";
            if (!string.IsNullOrEmpty(supKey))
            {
                strOrder += ",Supplier desc";
            }
            if (Function.GetQueryString("rorder") != "") routeorder = Convert.ToInt32(Function.GetQueryString("rorder"));
            if (Function.GetQueryString("torder") != "") timeorder = Convert.ToInt32(Function.GetQueryString("torder"));
            if (routeorder != 0)
            {
                if (routeorder == 1) strOrder += ",RouteOrder asc, createdtime desc";
                else if (routeorder == 2) strOrder += ",RouteOrder desc, createdtime desc";
            }
            else if (timeorder != 0)
            {
                if (timeorder == 1) strOrder += ",createdtime desc";
                else if (timeorder == 2) strOrder += ",createdtime asc";
            }
            else
            {
                strOrder += ",firstTime desc";
            }
            DataSet mySet = routeBLL.GetPageData(20, pageIndex, strWhere, strOrder);
            DataTable tableCount = mySet.Tables["Count"];
            DataTable myTable = mySet.Tables["Data"];

            int countRows = 0;
            countRows = Convert.ToInt32(tableCount.Rows[0][0].ToString());
            string[] urlParam = { "key", "cid1", "cid2", "rorder", "torder", "sKey" };
            pageInfo = pg.pageForDynamic(countRows, 20, pageIndex, urlParam);

            StringBuilder sb = new StringBuilder();

            foreach (DataRow dr in myTable.Rows)
            {
                sb.AppendFormat("<tr id='tr_{0}'>", dr["ID"].ToString());
                sb.AppendFormat("<td align='center'><input type='checkbox' name='routeCheckbox' id='checkbox{0}' value='{0}' /></td>", dr["ID"].ToString());
                string pingyin = rcList.Find(delegate(ClassLibrary.Model.RouteClass rc) { return rc.ID == Convert.ToInt32(dr["LocationID"].ToString()); }).ClassNamePY;
                
                sb.AppendFormat("<td title='{1}'><a href='/{3}/{2}.html' target='_blank'>{0}</a></td>", Function.Clip(dr["Title"].ToString(), 10, true), dr["Title"].ToString(), dr["ID"].ToString(), pingyin);
                sb.AppendFormat("<td align='center'>{0}</td>", GetRouteClass(Convert.ToInt32(dr["LocationID"].ToString())));
                sb.AppendFormat("<td align='center'>{0}<br/>{1}</td>", dr["Supplier"].ToString(), dr["SupplierTel"].ToString());
                sb.AppendFormat("<td align='center'><input type='text' class='ipt' id='RoutePrice_{1}' value='{0}' maxlength='6' size='5'/><input type='button' class='button' value='修改' size='3' onclick='UpdateRoutePrice({1})' /></td>", Convert.ToInt32(dr["Price"]) == 0 ? 0 : Convert.ToInt32(dr["Price"]), Convert.ToInt32(dr["ID"].ToString()));
                //sb.AppendFormat("<td align='center'>{0}</td>", dr["StartPosition"].ToString());
                sb.AppendFormat("<td align='center'><input type='text' class='ipt' id='RouteOrder_{1}' value='{0}' maxlength='5' size='3'/><input type='button' class='button' value='修改' size='3' onclick='UpdateRouteOrder({1})' /></td>", dr["RouteOrder"].ToString(), Convert.ToInt32(dr["ID"].ToString()));
                //sb.AppendFormat("<td align='center'>{0}</td>", Function.Clip(dr["Destination"].ToString(), 8, true));
                //sb.AppendFormat("<td align='center'><select name='routeShow_{0}' onchange='UpdateRouteShow({0})'><option value='1'>是</option><option value='0'>否</option></select></td>", Convert.ToInt32(dr["ID"].ToString()));
                //sb.AppendFormat("<td align='center'>{0}</td>", dr["RouteTime"].ToString());
                //sb.AppendFormat("<td align='center'>{0}</td>", dr["TrafficModel"].ToString());
                //sb.AppendFormat("<td align='center'>{0}</td>", dr["StartTime"].ToString());
                sb.AppendFormat("<td align='center'>{0}</td>", Convert.ToBoolean(dr["RecommendHot"]) ? "<span class='red'>是<span>" : "否");
                sb.AppendFormat("<td align='center'>{0}</td>", Convert.ToBoolean(dr["IsDisplay"]) ? "<span class='red'>是</span>" : "否");
                sb.AppendFormat("<td align='center'>{0}</td>", dr["ViewCount"].ToString());
                sb.AppendFormat("<td align='center'>{0}</td>", Convert.ToDateTime(dr["firstTime"]).ToString("yyyy-MM-dd"));
                sb.AppendFormat("<td align='center'>{0}</td>", Convert.ToDateTime(dr["CreatedTime"]).ToString("yyyy-MM-dd"));
                //sb.AppendFormat("<td align='center'>{0}</td>", dr["FirstTime"].ToString());
                sb.Append("<td align='center'>");
                //sb.AppendFormat("<a href='javascript:void(0)' onclick='routeCopy({0})'>复制</a>　", dr["ID"].ToString());
                sb.AppendFormat("<a href='RouteEdit.aspx?id={0}'>修改</a>　", dr["ID"].ToString());
                sb.AppendFormat("<a href='javascript:void(0)' onclick='routeDelete({0})'>删除</a>　", dr["ID"].ToString());
                sb.AppendFormat("<a href='../RouteComment/RouteCommentList.aspx?routeId={0}'>查看评论</a>", dr["ID"].ToString());
                sb.Append("</td>");

                sb.Append("</tr>");
            }
            dataRouteList = sb.ToString();
        }

        private string GetRouteClass(int routeClassId)
        {
            return routeClassBLL.GetModel(routeClassId).ClassName;
        }
    }
}
