using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClassLibrary.Common;

namespace WebUI.WebApp
{
    public partial class appAbout : System.Web.UI.Page
    {
        protected string dataAbout = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            BindInfo();
        }
        private void BindInfo()
        {
            ClassLibrary.BLL.SystemArticle bll = new ClassLibrary.BLL.SystemArticle();
            ClassLibrary.Model.SystemArticle model = bll.GetModel((int)SysConfig.SystemArticle.关于我们);
            dataAbout = model.Content.Replace(SysConfig.webSite, SysConfig.webSiteApp);
        }
    }
}