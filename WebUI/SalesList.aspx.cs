using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Data;
using ClassLibrary.Common;
using System.Collections;

namespace WebUI
{
    public partial class SalesList : System.Web.UI.Page
    {
        protected string dataSaleAd = "";
        protected string pageInfo;
        int pageIndex = 1;
        protected string appurl = SysConfig.webSiteApp + "/sale/";

        ClassLibrary.BLL.SaleAdvertise saBLL = new ClassLibrary.BLL.SaleAdvertise();
        Pagination pg = new Pagination();

        protected void Page_Load(object sender, EventArgs e)
        {
            GetArgument();
            BindSalesList();
        }
        private void BindSalesList()
        {
            string where = " ExpiredTime > '" + DateTime.Now.ToString("yyyy-MM-dd") + "'";
            DataSet mySet = saBLL.GetPageData(24, pageIndex, where, "SaleOrder Asc, CreatedTime desc");
            DataTable tableCount = mySet.Tables["Count"];
            DataTable myTable = mySet.Tables["Data"];

            int countRows = 0;
            countRows = Convert.ToInt32(tableCount.Rows[0][0].ToString());

            string currUrl = SysConfig.webSite + "/sale/";
            pageInfo = pg.pagination5(countRows, 24, pageIndex, currUrl);

            StringBuilder sb = new StringBuilder();
            List<ClassLibrary.Model.SaleAdvertise> saList = saBLL.DataTableToList(myTable);
            foreach (ClassLibrary.Model.SaleAdvertise model in saList)
            {
                sb.AppendFormat("<li><a href='{0}' title='{1}'><img src='{2}' alt='' width='272' height='345' /></a>",
                    model.LinkUrl, model.Title, SysConfig.UploadFilePathAdImg + model.Img).AppendLine();
                sb.AppendFormat("<a class='showimg' href='{0}' target='_blank' rel='nofollow'>查看</a></li>",
                    SysConfig.webSite + SysConfig.UploadFilePathAdImg + model.Img).AppendLine();
            }
            dataSaleAd = sb.ToString();
        }

        private void GetArgument()
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
    }
}