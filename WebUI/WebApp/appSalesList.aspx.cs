using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Data;
using ClassLibrary.Common;

namespace WebUI.WebApp
{
    public partial class appSalesList : System.Web.UI.Page
    {
        protected string dataSaleList = "";
        ClassLibrary.BLL.SaleAdvertise saBll = new ClassLibrary.BLL.SaleAdvertise();

        protected void Page_Load(object sender, EventArgs e)
        {
            BindSaleList();
        }

        private void BindSaleList()
        {
            StringBuilder sb = new StringBuilder();
            string where = " ExpiredTime > '" + DateTime.Now.ToString("yyyy-MM-dd") + "'";
            DataSet mySet = saBll.GetPageData(12, 1, where, "SaleOrder Asc, CreatedTime desc");
            DataTable myTable = mySet.Tables["Data"];

            List<ClassLibrary.Model.SaleAdvertise> saList = saBll.DataTableToList(myTable);
            foreach (ClassLibrary.Model.SaleAdvertise model in saList)
            {
                sb.AppendFormat("<li><a href='{0}{1}' title='{2}'><img src='{0}{1}' alt='' /></a></li>",
                    SysConfig.webSite, SysConfig.UploadFilePathAdImg + model.Img, model.Title).AppendLine();
            }

            dataSaleList = sb.ToString();
        }
    }
}