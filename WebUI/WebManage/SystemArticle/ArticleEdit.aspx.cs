using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClassLibrary.Common;
using ClassLibrary;

namespace WebUI.SystemArticle
{
    public partial class ArticleEdit : System.Web.UI.Page
    {
        protected int articleID; //获取点菜单传过来的ID
        protected string dataTitle;//标题
        protected string dataContent; //内容

        ClassLibrary.BLL.SystemArticle systemArticleBLL = new ClassLibrary.BLL.SystemArticle();

        protected void Page_Load(object sender, EventArgs e)
        {
            ClassLibrary.Common.UserInfo.ChekcPower();

            GetArgument();

            if (Function.IsPostMethod())
            {
                if (Request.QueryString["ac"] == "edit")
                {
                    Edit();
                }
            }

            BindInfo();

        }

        private void GetArgument()
        {
            string strid = Request["id"];

            if (Function.IsNumber(strid))
            {
                articleID = Convert.ToInt32(strid);
            }
            else
            {
                Function.goMessagePage("添加系统文章", "操作失败", "SystemArticle/ArticleEdit.aspx?id=" + articleID);
            }
        }

        //绑定信息
        private void BindInfo()
        {
            ClassLibrary.Model.SystemArticle systemArticleModel = systemArticleBLL.GetModel(articleID);

            dataTitle = systemArticleModel.Title;
            dataContent = systemArticleModel.Content;
        }

        //修改信息
        private void Edit()
        {
            ClassLibrary.Model.SystemArticle systemArticleModel = new ClassLibrary.Model.SystemArticle();

            systemArticleModel.ID = Convert.ToInt32(Request.Form["ID"]);
            systemArticleModel.Title = Request.Form["Title"];
            systemArticleModel.Content = Request.Form["Content"];

            systemArticleModel.Content = systemArticleModel.Content.Replace("©", "&copy;");

            if (systemArticleBLL.Update(systemArticleModel) > 0)
            {

                Function.goMessagePage("添加系统文章", "操作成功", "SystemArticle/ArticleEdit.aspx?id=" + articleID);
            }
            else
            {
                Function.goMessagePage("添加系统文章", "操作失败", "SystemArticle/ArticleEdit.aspx?id=" + articleID);
            }
        }
    }
}