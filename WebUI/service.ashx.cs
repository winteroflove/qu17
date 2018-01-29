using System;
using System.Collections;
using System.Data;
using System.Web;
using System.Text;
using System.Collections.Generic;
using ClassLibrary.Common;

namespace WebUI
{    
    public class service : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            if (context.Request.QueryString["ac"] == "getarea")
            {
                string strMaxClassID = context.Request.QueryString["cid"];
                string strParentID = context.Request.QueryString["parentID"];
                if (strParentID == null || strParentID == "")
                {
                    strParentID = "0";
                }
                if (ClassLibrary.Common.Function.IsNumber(strMaxClassID))
                {
                    int maxClassID = Convert.ToInt32(strMaxClassID);

                    ClassLibrary.BLL.RouteClass bll = new ClassLibrary.BLL.RouteClass();

                    DataTable myTable = bll.GetTableSubList(maxClassID, string.Empty);

                    myTable = ClassLibrary.BLL.WebClass.GetRouteTree(myTable, Int32.Parse(strParentID));

                    StringBuilder sb = new StringBuilder();

                    int rowIndex = 0;
                    foreach (DataRow dr in myTable.Rows)
                    {
                        rowIndex++;
                        if (rowIndex == 1) //去掉第一行数据，第一行是顶级(ParendID=0)
                        {
                            continue;
                        }

                        sb.AppendFormat("<option value='{0}'>{1}</option>", dr["ID"].ToString(), dr["ClassName"].ToString());
                    }

                    Print(context, sb.ToString());
                }

                Print(context, string.Empty);

            }
        }

        private void Print(HttpContext context, string msg)
        {
            context.Response.Cache.SetCacheability(HttpCacheability.NoCache);
            context.Response.ContentType = "text/plain";
            context.Response.Write(msg);
            context.Response.End();
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}
