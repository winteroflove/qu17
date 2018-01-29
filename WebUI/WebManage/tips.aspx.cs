using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Text.RegularExpressions;

namespace WebUI.Manager
{
    public partial class tips : System.Web.UI.Page
    {
        protected string title;
        protected string message;
        protected string backUrl;

        protected int time = 5;

        protected void Page_Load(object sender, EventArgs e)
        {
            title = "系统提示";
            message = "当前操作已终止，请重试。";

            if (!string.IsNullOrEmpty(Request.QueryString["msg"]))
            {
                message = Request.QueryString["msg"];
                message = HttpUtility.HtmlDecode(HttpUtility.UrlDecode(message));
            }
            if (!string.IsNullOrEmpty(Request.QueryString["title"]))
            {
                title = Request.QueryString["title"];
                title = HttpUtility.UrlDecode(title);
            }
            if (!string.IsNullOrEmpty(Request.QueryString["url"]))
            {
                backUrl = Request.QueryString["url"];
                backUrl = HttpUtility.HtmlDecode(HttpUtility.UrlDecode(backUrl));
                Regex reg = new Regex(@"[\u4e00-\u9fa5]+");
                backUrl = reg.Replace(backUrl, new MatchEvaluator(EnCode));
            }
            else
            {
                time = 300;
            }
        }

        protected string EnCode(Match m)
        {
            string str = m.ToString();
            return HttpUtility.UrlEncode(str);
        }
    }
}
