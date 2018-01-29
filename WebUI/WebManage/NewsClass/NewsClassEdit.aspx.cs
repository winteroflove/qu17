using System;
using System.Data;
using ClassLibrary.Common;


namespace WebUI.WebManage.RouteClass
{
    public partial class NewsClassEdit : System.Web.UI.Page
    {
        protected int newsClassId;
        protected string className;

        ClassLibrary.BLL.NewsClass newsClassBLL = new ClassLibrary.BLL.NewsClass();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Function.IsPostMethod())
            {
                if (Request.QueryString["ac"] == "edit")
                {
                    newsClassId = Convert.ToInt32(Request.Form["ID"]);
                    EditNewsClass();
                }
            }
            else
            {
                GetArgument();
                BindData();
            }
        }

        private void GetArgument()
        {
            string id = Request.QueryString["id"];

            if (Function.IsNumber(id))
            {
                newsClassId = Convert.ToInt32(id);
            }
            else
            {
                Function.goMessagePage("修改路线类型", "操作失败，参数错误!", "RouteClass/RouteClassList.aspx");
            }
        }

        private void BindData()
        {

            DataTable myTable = newsClassBLL.GetData(" id =" + newsClassId);

            if (myTable.Rows.Count == 1)
            {
                newsClassId = Convert.ToInt32(myTable.Rows[0]["ID"]);
                className = myTable.Rows[0]["ClassName"].ToString();
            }
            else
            {
                Function.goMessagePage("修改路线类型", "操作失败，数据不存在!", "RouteClass/RouteClassList.aspx");
            }
        }

        private void EditNewsClass()
        {
            ClassLibrary.Model.NewsClass newsClassModel = new ClassLibrary.Model.NewsClass();

            newsClassModel.ID = newsClassId;
            if (string.IsNullOrEmpty(Request.Form["ClassName"]))
            {
                Response.Write("<script>alert('请输入路线类型！');history.back(-1);</script>");
                return;
            }
            else
            {
                newsClassModel.ClassName = Request.Form["ClassName"];

                if (newsClassBLL.Update(newsClassModel) > 0)
                {
                    Function.goMessagePage("修改路线类型", "操作成功", "RouteClass/RouteClassList.aspx");
                }
                else
                {
                    Function.goMessagePage("修改路线类型", "操作失败，请稍后再试", "RouteClass/RouteClassList.aspx");
                }
            }
        }

    }
}
