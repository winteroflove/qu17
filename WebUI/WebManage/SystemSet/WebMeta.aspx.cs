using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClassLibrary.Common;
using ClassLibrary;

namespace WebUI.WebManage.SystemSet
{
    public partial class WebMeta : System.Web.UI.Page
    {
        protected int id;
        protected string QQ;
		protected string OnlineService;
        protected string title;
        protected string keyword;
        protected string telphone;
        protected string description;
        ClassLibrary.BLL.WebMeta webMetaBLL = new ClassLibrary.BLL.WebMeta();

        protected void Page_Load(object sender, EventArgs e)
        {
            ClassLibrary.Common.UserInfo.ChekcPower();

            if (Function.IsPostMethod())
            {
                if (Request.QueryString["ac"] == "edit")
                {
                    Edit();
                }
            }

            BindInfo();
        }

        //绑定信息
        private void BindInfo()
        {
            string strid = Request.QueryString["id"];

            if (Function.IsNumber(strid))
            {
                id = Convert.ToInt32(strid);
            }
            else
            {
                Function.goMessagePage("添加网站信息", "操作失败");
            }

            ClassLibrary.Model.WebMeta webMetaModel = webMetaBLL.GetModel(id);

            QQ = webMetaModel.QQ;
			OnlineService = webMetaModel.OnlineService;
            title = webMetaModel.Title;
            keyword = webMetaModel.Keyword;
            telphone = webMetaModel.Telphone;
            description = webMetaModel.Description;
        }

        //修改信息
        private void Edit()
        {
            ClassLibrary.Model.WebMeta webMetaModel = new ClassLibrary.Model.WebMeta();

            webMetaModel.ID = Convert.ToInt32(Request.Form["ID"]);
            webMetaModel.QQ = Request.Form["QQ"];
			webMetaModel.OnlineService = Request.Form["OnlineService"];
            webMetaModel.Title = Request.Form["Title"];
            webMetaModel.Telphone = Request.Form["Telphone"];
            webMetaModel.Keyword = Request.Form["Keyword"].Replace(" ", "").Replace("\r\n", "").Replace("\n", "");
            webMetaModel.Description = Request.Form["Description"].Replace(" ", "").Replace("\r\n", "").Replace("\n", "");

            if (webMetaBLL.Update(webMetaModel) > 0)
            {
                Function.goMessagePage("更新网站信息", "操作成功", "SystemSet/WebMeta.aspx?id=" + webMetaModel.ID);
            }
            else
            {
                Function.goMessagePage("更新网站信息", "操作失败", "SystemSet/WebMeta.aspx?id=" + webMetaModel.ID);
            }
        }
    }
}
