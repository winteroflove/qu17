using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Text;
using System.Data;
using ClassLibrary.Common;

namespace WebUI
{
    public partial class links : System.Web.UI.Page
    {
        protected string dataLinkList;

        protected void Page_Load(object sender, EventArgs e)
        {
            //BindLinkList();
        }

        private void BindLinkList()
        {
            ClassLibrary.BLL.Links linksBLL = new ClassLibrary.BLL.Links();
            List<ClassLibrary.Model.Links> list = linksBLL.GetModelList(string.Empty);

            StringBuilder sb = new StringBuilder();

            foreach (ClassLibrary.Model.Links model in list)
            {
                sb.AppendFormat("<li><a href='{0}' target='_blank'>{1}</a></li>", model.LinkURL, model.Title);
            }

            dataLinkList = sb.ToString();

        }
    }
}
