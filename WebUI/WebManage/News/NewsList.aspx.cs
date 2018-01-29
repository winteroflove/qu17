using System;
using System.Data;
using System.Text;
using ClassLibrary.Common;
using System.Collections.Generic;

namespace WebUI.WebManage.News 
{
    public partial class NewsList : System.Web.UI.Page
    {
        int pageSize = 20;
        protected int pageIndex;

        protected string newsClassIDs;
        protected string dataNewsList;
        protected string pageInfo;
        protected string searchClass1;
        protected string searchClass2;
        protected string searchKey;
        protected string routeClassBig = "";
        protected string routeClassNext = "";
        ClassLibrary.BLL.News newsBLL = new ClassLibrary.BLL.News();
        Pagination pg = new Pagination();
        ClassLibrary.BLL.NewsClass newsClassBLL = new ClassLibrary.BLL.NewsClass();
        ClassLibrary.BLL.RouteClass routeClassBLL = new ClassLibrary.BLL.RouteClass();
        List<ClassLibrary.Model.RouteClass> rcList = new List<ClassLibrary.Model.RouteClass>();
        List<ClassLibrary.Model.NewsClass> nList = new List<ClassLibrary.Model.NewsClass>();

        protected void Page_Load(object sender, EventArgs e)
        {
            ClassLibrary.Common.UserInfo.ChekcPower();

            newsClassIDs = Request.QueryString["cid"];

            getArgument();
            GetNewsClass();
            GetRouteClass();
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
        }

        private void BindData()
        {
            searchKey = Function.GetQueryString("key");
            int routeClassID = 0;
            string sqlwhere = "1=1";
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
            if (newsClassIDs == null || newsClassIDs.Equals(""))
            {
                newsClassIDs = Function.GetQueryString("hidden_newsClassId");
            }

            sqlwhere += " and newsClassID in (" + newsClassIDs + ")";

            if (routeClassID != 0)
            {
                sqlwhere += " and CHARINDEX('," + routeClassID + ",',','+routeClassID+',')>0";
            }
            if (!string.IsNullOrEmpty(searchKey))
            {
                sqlwhere += " AND CHARINDEX('" + searchKey + "',Title)>0";
            }

            DataSet mySet = newsBLL.GetPageData(pageSize, pageIndex, sqlwhere, "CreatedTime Desc");
            DataTable tableCount = mySet.Tables["Count"];
            DataTable myTable = mySet.Tables["Data"];

            int countRows = 0;
            countRows = Convert.ToInt32(tableCount.Rows[0][0].ToString());
            string[] urlParam = { "cid", "cid1", "cid2", "key" };
            pageInfo = pg.pageForDynamic(countRows, pageSize, pageIndex, urlParam);

            StringBuilder sb = new StringBuilder();

            int i = 0;
            int rowIndex = 0;

            string temClassName = "无类型";
            string pingyin = "";
            ClassLibrary.Model.RouteClass temRClass;

            foreach (DataRow dr in myTable.Rows)
            {
                i++;
                rowIndex = pageSize * (pageIndex - 1) + i;

                if (dr["routeClassID"].ToString() != "")
                {
                    string tmpRouteClassID = "";
                    if (dr["LocationID"] != DBNull.Value && Convert.ToInt32(dr["LocationID"].ToString()) != 0)
                    {
                        tmpRouteClassID = dr["LocationID"].ToString();
                    }
                    else
                    {
                        tmpRouteClassID = dr["routeClassID"].ToString().Split(',')[2];
                    }
                    temRClass = rcList.Find(delegate(ClassLibrary.Model.RouteClass tm) { return tm.ID == Convert.ToInt32(tmpRouteClassID); });
                    temClassName = temRClass.ClassName;
                    pingyin = temRClass.ClassNamePY;
                }

                sb.AppendFormat("<tr id='tr_{0}'>", dr["ID"].ToString());

                //sb.AppendFormat("<td align='center'>{0}</td>", rowIndex);
                sb.AppendFormat("<td align='center'><input type='checkbox' name='newsCheckbox' id='checkbox{0}' value='{0}' /></td>", dr["ID"].ToString());
                sb.AppendFormat("<td><a href='/{3}/{1}.html' title='{2}' target='_blank'>{0}</a></td>", Function.Clip(dr["Title"].ToString(), 15, true), dr["ID"].ToString(), dr["Title"].ToString(), Enum.GetName(typeof(SysConfig.NewsClassPY), Convert.ToInt32(dr["newsClassID"].ToString())));

                ClassLibrary.Model.NewsClass temNClass = nList.Find(delegate(ClassLibrary.Model.NewsClass nm) { return nm.ID == Convert.ToInt32(dr["newsClassID"].ToString()); });

                
                sb.AppendFormat("<td align='center'>{0}</td>", temNClass.ClassName);
                sb.AppendFormat("<td align='center'>{0}</td>", temClassName);
                sb.AppendFormat("<td align='center'>{0}</td>", dr["ViewCount"].ToString());
                sb.AppendFormat("<td align='center'>{0}</td>", Convert.ToBoolean(dr["IsDisplay"]) ? "<span class='red'>是</span>" : "否");
                sb.AppendFormat("<td align='center'>{0}</td>", dr["CreatedTime"].ToString());
                sb.Append("<td align='center'>");
                sb.AppendFormat("<a href='NewsEdit.aspx?cid={0}&id={1}'>修改</a>　", newsClassIDs, dr["ID"].ToString());
                sb.AppendFormat("<a href='javascript:void(0)' onclick='newsDelete({0},\"{1}\")'>删除</a>", dr["ID"].ToString(), "");  //dr["Image"].ToString()
                sb.Append("</td>");

                sb.Append("</tr>");
            }

            if (sb.Length == 0)
            {
                sb.Append("<tr><td colspan='7'>没有相关数据</td></tr>");
            }

            dataNewsList = sb.ToString();
        }

        //新闻类型
        private void GetNewsClass()
        {
            nList = newsClassBLL.GetModelList(String.Empty);
        }

        //线路类型
        private void GetRouteClass()
        {
            rcList = routeClassBLL.GetModelList(String.Empty);
        }
        //搜索  线路类型
        private void SearchFormRouteBigClass()
        {
            List<ClassLibrary.Model.RouteClass> list = rcList.FindAll(delegate(ClassLibrary.Model.RouteClass rc) { return rc.ParentID == 0; }); //routeClassBLL.GetModelList("ParentID=0");

            StringBuilder sb = new StringBuilder();

            foreach (ClassLibrary.Model.RouteClass model in list)
            {
                if (model.ID > 2) continue;
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
    }
}
