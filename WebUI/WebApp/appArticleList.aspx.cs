using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClassLibrary.Common;
using System.Data;
using System.Text;

namespace WebUI.WebApp
{
    public partial class appArticleList : System.Web.UI.Page
    {
        protected string pageInfo;
        int pageIndex = 0;
        protected int countPage = 0;
        protected int typeId = 0;
        protected string newsList;
        protected string typeName = "旅游指南";
        protected string mipUrl = "";

        ClassLibrary.BLL.News newsBll = new ClassLibrary.BLL.News();
        Pagination pg = new Pagination();
        ClassLibrary.BLL.RouteClass rcBll = new ClassLibrary.BLL.RouteClass();
        List<ClassLibrary.Model.RouteClass> gList = new List<ClassLibrary.Model.RouteClass>();

        protected void Page_Load(object sender, EventArgs e)
        {
            GetArgument();
            BindArticleList();
        }
        private void GetArgument()
        {
            string strTypeID = Function.GetQueryString("id");
            mipUrl = SysConfig.webSiteApp + "/mip/zhinan/";

            if (strTypeID != "")
            {
                if (Function.IsNumberStr(strTypeID))
                {
                    typeId = Convert.ToInt32(strTypeID);
                    if (typeId != 1 && typeId != 2)
                    {
                        Response.StatusCode = 404;
                        Response.End();
                    }
                    typeName = Enum.GetName(typeof(SysConfig.NewsClass), typeId);
                }
                else
                {
                    Response.StatusCode = 404;
                    Response.End();
                }
                mipUrl = SysConfig.webSiteApp + "/mip/" + Enum.GetName(typeof(SysConfig.NewsClassPY), typeId) + "/";
            }
            string strPageIndex = Request.QueryString["page"];
            if (ClassLibrary.Common.Function.IsNumber(strPageIndex))
            {
                pageIndex = Convert.ToInt32(strPageIndex);
            }
            else
            {
                pageIndex = 1;
            }
            if (typeId < 7)
            {
                gList = rcBll.GetModelList(String.Empty, "ClassOrder Asc");
            }
        }
        //列表
        private void BindArticleList()
        {
            string strWhere = "isdisplay = 1";

            if (typeId != 0)
            {
                if (typeId == 5)
                {
                    strWhere += " and newsClassID < " + typeId;
                }
                else
                {
                    strWhere += " and newsClassID=" + typeId;
                }
            }
            //string urlMiddle = "";
            //if (typeId == 0){
            
            //    urlMiddle = "zhinan";
            //}
            //else if (typeId == (int)SysConfig.NewsClass.签证问题)
            //{
            //    urlMiddle = "visa/article";
            //}
            //else
            //{
            //    urlMiddle = Enum.GetName(typeof(SysConfig.NewsClassPY), typeId);
            //}
            DataSet mySet = newsBll.GetPageData(10, pageIndex, strWhere, "CreatedTime Desc");
            DataTable tableCount = mySet.Tables["Count"];
            DataTable myTable = mySet.Tables["Data"];

            int countRows = 0;
            countRows = Convert.ToInt32(tableCount.Rows[0][0].ToString());
            if (countRows % 10 == 0)
            {
                countPage = countRows / 10;
            }
            else
            {
                countPage = countRows / 10 + 1;
            }
            StringBuilder sb = new StringBuilder();

            List<ClassLibrary.Model.News> tnewsList = newsBll.GetModelList(myTable);
            
            foreach (ClassLibrary.Model.News model in tnewsList)
            {
                string turl = Enum.GetName(typeof(SysConfig.NewsClassPY), model.newsClassID);
                
                sb.AppendLine("<div class='aricleitem'>");
                sb.AppendFormat("<a href='{0}/{1}/{2}.html'>", SysConfig.webSiteApp, turl, model.ID);
                string aimg = "/image/defaultImg.jpg";
                if (model.Image != "")
                {
                    aimg = SysConfig.UploadFilePathNewsImg + model.Image;
                }
                sb.AppendFormat("<div class='ai_img'><img src='{0}{1}' alt='' /></div>", SysConfig.webSite, aimg);
                sb.AppendLine("<div class='ai_content'>");
                sb.AppendFormat("<div class='ai_title'>{0}</div>", Function.Clip(model.Title, 13, true));
                sb.AppendFormat("<div class='ai_desc'>{0}</div>",
                    Function.Clip(Function.ClearHtml(model.Content), 27, true));
                sb.AppendFormat("<div class='ai_ctime'>{0}</div>", model.CreatedTime.ToString("yyyy-MM-dd HH:mm"));
                sb.AppendLine("</div>");
                sb.AppendLine("</a>");
                sb.AppendLine("</div>");
            }

            if (sb.Length == 0)
            {
                sb.Append("<div class='nodata'>没有相关数据!</div>");
            }

            newsList = sb.ToString();

        }
    }
}