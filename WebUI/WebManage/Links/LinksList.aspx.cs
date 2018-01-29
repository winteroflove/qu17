using System;
using System.Data;
using System.Text;
using System.Collections.Generic;
using ClassLibrary.Common;

namespace WebUI.WebManage.Links
{
    public partial class LinksList : System.Web.UI.Page
    {
        int pageSize = 20;
        int pageIndex;
        protected string searchKey;
        protected string linksList;
        protected string pageInfo;

        protected string searchClass1;
        protected string searchClass2;
        protected string routeClassBig = "";
        protected string routeClassNext = "";

        ClassLibrary.BLL.Links linksBLL = new ClassLibrary.BLL.Links();
        ClassLibrary.Common.Pagination pg = new ClassLibrary.Common.Pagination();
        List<ClassLibrary.Model.RouteClass> list = new List<ClassLibrary.Model.RouteClass>();
        ClassLibrary.BLL.RouteClass rBll = new ClassLibrary.BLL.RouteClass();

        protected void Page_Load(object sender, EventArgs e)
        {
            ClassLibrary.Common.UserInfo.ChekcPower();

            getArgument();
            BindData();

            SearchFormRouteBigClass();
            SearchFormRouteNextClass();
        }
        //搜索  线路类型
        private void SearchFormRouteBigClass()
        {
            List<ClassLibrary.Model.RouteClass> tlist = list.FindAll(delegate(ClassLibrary.Model.RouteClass rc) { return rc.ParentID == 0; }); //routeClassBLL.GetModelList("ParentID=0");

            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("<option value='0' {0}>首页    </option>", searchClass1 == "0" ? "selected" : "");

            foreach (ClassLibrary.Model.RouteClass model in tlist)
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

                DataTable myTable = rBll.GetTableSubList(maxClassID, string.Empty);

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

            list = rBll.GetModelList(string.Empty);
        }
        
        private void BindData()
        {
            searchKey = Function.GetQueryString("key");
            int routeClassID = -1;

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
            if (routeClassID != -1)
            {
                strWhere += " AND LinkClass = " + routeClassID;
            }
            if (!string.IsNullOrEmpty(searchKey))
            {
                strWhere += " AND CHARINDEX('" + searchKey + "',LinkUrl)>0";
            }
            DataSet mySet = linksBLL.GetPageData(pageSize, pageIndex, strWhere, "CreatedTime Desc");
            DataTable tableCount = mySet.Tables["Count"];
            DataTable myTable = mySet.Tables["Data"];

            int countRows = 0;
            countRows = Convert.ToInt32(tableCount.Rows[0][0].ToString());
            string[] urlParam = { "key", "cid1", "cid2" };
            pageInfo = pg.pageForDynamic(countRows, pageSize, pageIndex, urlParam);

            StringBuilder sb = new StringBuilder();

            int i = 0;
            int rowIndex = 0;

            foreach (DataRow dr in myTable.Rows)
            {
                i++;
                rowIndex = pageSize * (pageIndex - 1) + i;

                sb.AppendFormat("<tr id='tr_{0}'>", dr["ID"].ToString());
                sb.AppendFormat("<td align='center'><input type='checkbox' name='linksCheckbox' id='checkbox{0}' value='{0}' /></td>", dr["ID"].ToString());
                sb.AppendFormat("<td align='center'>{0}</td>", rowIndex);
                sb.AppendFormat("<td>{0}</td>", dr["Title"].ToString());
                sb.AppendFormat("<td>{0}</td>", dr["LinkURL"].ToString());
                string className = "首页";
                if (dr["LinkClass"].ToString() != "0")
                {
                    ClassLibrary.Model.RouteClass tclass = list.Find(delegate(ClassLibrary.Model.RouteClass rc) { return rc.ID == Convert.ToInt32(dr["LinkClass"].ToString()); });
                    className = tclass.ClassName;
                }
                sb.AppendFormat("<td>{0}</td>", className);
                sb.AppendFormat("<td align='center'>{0}</td>", dr["CreatedTime"].ToString());
                sb.Append("<td align='center'>");
                sb.AppendFormat("<a href='LinksEdit.aspx?id={0}'>修改</a>　", dr["ID"].ToString());
                sb.AppendFormat("<a href='javascript:void(0)' onclick='linksDelete({0})'>删除</a>", dr["ID"].ToString());
                sb.Append("</td>");

                sb.Append("</tr>");
            }

            if (sb.Length == 0)
            {
                sb.Append("<tr><td colspan='5'>没有相关数据</td></tr>");
            }

            linksList = sb.ToString();
        }
    }
}
