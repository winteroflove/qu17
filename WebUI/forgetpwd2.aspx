<%@ Page Title="" Language="C#" MasterPageFile="~/FireMain.Master" AutoEventWireup="true"
    CodeBehind="forgetpwd2.aspx.cs" Inherits="WebUI.forgetpwd2" %>

<asp:Content ID="chead" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="adverse" ContentPlaceHolderID="adverse" runat="server">
<div class="login_main">
    <div class="main">
        <div class="findpwd_wrap">
            <div class="login_top"><span class="login_title">找回登录密码</span><span class="reg_link"><a href="<%=ClassLibrary.Common.SysConfig.webSite %>/login/">登录</a></span></div>
            <form action="/forgetpwd3/" method="post" onsubmit="return formForgetpwd2(this)">
                <ul>
                    <li><label>用户名：</label><%=userName%></li>
                    <li><label>密码保护问题：</label><%=safetyQuestion%></li>
                    <li><label>密码保护答案：</label><input type="text" name="SafetyAnswer" maxlength="30" /></li>
                    <li><div class="login_submit"><input type="submit" class="submit" value="下一步" /></div></li>
                </ul>
                <input type="hidden" name="UserName" value="<%=userName %>" />
            </form>
        </div>
    </div>
</div>
</asp:Content>
