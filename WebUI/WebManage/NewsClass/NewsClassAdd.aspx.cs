using System;
using ClassLibrary.Common;


namespace WebUI.WebManage.NewsClass
{
    public partial class NewsClassAdd : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Function.IsPostMethod())
            {
                if (Request.QueryString["ac"] == "add")
                {
                    AddNewsClass();
                }
            }
        }

        public void AddNewsClass()
        {
            ClassLibrary.BLL.NewsClass newsClassBLL = new ClassLibrary.BLL.NewsClass();
            ClassLibrary.Model.NewsClass newsClassModel = new ClassLibrary.Model.NewsClass();

            if (string.IsNullOrEmpty(Request.Form["ClassName"]))
            {
                Response.Write("<script>alert('请输入新闻类型！');history.back(-1);</script>");
                return;
            }
            else
            {
                newsClassModel.ClassName = Request.Form["ClassName"];
            }

            if (newsClassBLL.Add(newsClassModel)>0)
            {
                Function.goMessagePage("添加新闻类型", "操作成功", "NewsClass/NewsClassList.aspx");
            }
            else
            {
                Function.goMessagePage("添加新闻类型", "操作失败，请稍后再试", "NewsClass/NewsClassList.aspx");
            }

        }

    }
}
