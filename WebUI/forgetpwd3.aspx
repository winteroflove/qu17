<%@ Page Title="" Language="C#" MasterPageFile="~/FireMain.Master" AutoEventWireup="true"
    CodeBehind="forgetpwd3.aspx.cs" Inherits="WebUI.forgetpwd3" %>

<asp:Content ID="chead" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="adverse" ContentPlaceHolderID="adverse" runat="server">
<div class="login_main">
    <div class="main">
        <div class="findpwd_wrap">
            <div class="login_top"><span class="login_title">找回登录密码</span><span class="reg_link"><a href="<%=ClassLibrary.Common.SysConfig.webSite %>/login/">登录</a></span></div>
            <form action="/forgetpwd3/post" method="post" onsubmit="return formForgetpwd3(this)">
                <ul>
                    <li>
                        <label>新密码：</label>
                        <input type="password" name="Password" maxlength="50" /></li>
                    <li>
                        <label>确认密码：</label>
                        <input type="password" name="Password2" maxlength="50" /></li>
                    <li><div class="login_submit"><input type="submit" class="submit" value="修改密码" /></div></li>
                </ul>
                <input type="hidden" name="UserName" value="<%=userName %>" />
                <input type="hidden" name="SafetyAnswer" value="<%=safetyAnswer %>" />
            </form>
        </div>
    </div>
</div>
</asp:Content>
