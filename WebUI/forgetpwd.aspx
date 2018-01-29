<%@ Page Title="" Language="C#" MasterPageFile="~/FireMain.Master" AutoEventWireup="true" CodeBehind="forgetpwd.aspx.cs" Inherits="WebUI.forgetpwd" %>
<asp:Content ID="chead" ContentPlaceHolderID="head" runat="server">

</asp:Content>

<asp:Content ID="adverse" ContentPlaceHolderID="adverse" runat="server">
<div class="login_main">
    <div class="main">
        <div class="findpwd_wrap">
            <div class="login_top"><span class="login_title">找回登录密码</span><span class="reg_link"><a href="<%=ClassLibrary.Common.SysConfig.webSite %>/login/">登录</a></span></div>
            <form action="/forgetpwd2/" method="post" onsubmit="return formForgetpwd(this)">
                <ul>
                    <li><label>您的用户名：</label>
                    <input type="text" style="vertical-align:middle" name="UserName" maxlength="30" />　
                    </li>
                    <li><div class="login_submit"><input type="submit" class="submit" value="下一步" /></div></li>
                </ul>
            </form>
        </div>
   </div>
</div>
</asp:Content>
