using System;
using System.Data;
using System.IO;
using System.Text;
using System.Web;
using ClassLibrary.Common;

namespace WebUI.WebManage.RouteComment
{
    public partial class RouteCommentDetail : System.Web.UI.Page
    {
        protected int routeCommentId;
        protected string userName;
        protected string nickname;
        protected string anonymous;
        protected string route;
        protected int grade;
        protected string email;
        protected string content;
        protected string checkeds;
        protected DateTime createdTime;

        ClassLibrary.BLL.RouteComment routeCommentBLL = new ClassLibrary.BLL.RouteComment();
        ClassLibrary.BLL.Routes routeBLL = new ClassLibrary.BLL.Routes();
        protected void Page_Load(object sender, EventArgs e)
        {

            GetArgument();
            BindData();
        }

        private void GetArgument()
        {
            string id = Request.QueryString["id"];

            if (Function.IsNumber(id))
            {
                routeCommentId = Convert.ToInt32(id);
            }
            else
            {
                Function.goMessagePage("显示路线评论", "操作失败，参数错误!", "RouteComment/RouteCommentList.aspx");
            }
        }

        private void BindData()
        {

            DataTable myTable = routeCommentBLL.GetData(" id =" + routeCommentId);

            if (myTable.Rows.Count == 1)
            {
                userName = myTable.Rows[0]["UserName"].ToString();
                nickname = myTable.Rows[0]["Nickname"].ToString();
                anonymous = Convert.ToBoolean(myTable.Rows[0]["Anonymous"]) ? "是" : "否";
                route =GetRoute(Convert.ToInt32(myTable.Rows[0]["routeID"].ToString()));
                grade = Convert.ToInt32(myTable.Rows[0]["Grade"]);
                email = myTable.Rows[0]["Email"].ToString();
                content = myTable.Rows[0]["Content"].ToString();
                checkeds = Convert.ToBoolean(myTable.Rows[0]["Checked"]) ? "是" : "否";
                createdTime = Convert.ToDateTime(myTable.Rows[0]["CreatedTime"]);
            }
            else
            {
                Function.goMessagePage("显示路线评论", "操作失败，数据不存在!", "RouteComment/RouteCommentList.aspx");
            }

        }

        private string GetRoute(int routeId)
        {
            return routeBLL.GetModel(routeId).Title;
        }
    }
}
