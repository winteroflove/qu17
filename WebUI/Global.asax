﻿<%@ Application Language="C#" %>

<script runat="server">

    void Application_Start(object sender, EventArgs e) 
    {
        //在应用程序启动时运行的代码

    }
    
    void Application_End(object sender, EventArgs e) 
    {
        //在应用程序关闭时运行的代码

    }
        
    void Application_Error(object sender, EventArgs e) 
    { 
        

    }

    void Session_Start(object sender, EventArgs e) 
    {
        //在新会话启动时运行的代码

    }

    void Session_End(object sender, EventArgs e) 
    {
        //在会话结束时运行的代码。 
        // 注意: 只有在 Web.config 文件中的 sessionstate 模式设置为
        // InProc 时，才会引发 Session_End 事件。如果会话模式 
        //设置为 StateServer 或 SQLServer，则不会引发该事件。

    }

    //在接收到一个应用程序请求时触发。对于一个请求来说，它是第一个被触发的事件，请求一般是用户输入的一个页面请求（URL）。
    void Application_BeginRequest(object sender, EventArgs e)
    {
        string q="<div style='position:fixed;top:0px;width:100%;height:100%;background-color:white;color:green;font-weight:bold;border-bottom:5px solid #999;'><br>您的提交带有不合法参数,谢谢合作!<br><br>了解更多请点击:<a href='http://webscan.360.cn'>360网站安全检测</a></div>";

        string url = Request.Url.AbsolutePath;
        if (url.ToLower().IndexOf("webmanage") < 0)
        {
            if (Request.Cookies != null)
            {
                if (safe_360.CookieData())
                {
                    Response.Write(q);
                    Response.End();

                }


            }

            if (Request.UrlReferrer != null)
            {
                if (safe_360.referer())
                {
                    Response.Write(q);
                    Response.End();
                }
            }

            if (Request.RequestType.ToUpper() == "POST")
            {
                if (safe_360.PostData())
                {

                    Response.Write(q);
                    Response.End();
                }
            }
            if (Request.RequestType.ToUpper() == "GET")
            {
                if (safe_360.GetData())
                {
                    Response.Write(q);
                    Response.End();
                }
            }

        }
    }
       
</script>

