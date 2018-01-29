<%@ Page Title="" Language="C#" MasterPageFile="~/WebApp/AppMain.Master" AutoEventWireup="true" CodeBehind="appAbout.aspx.cs" Inherits="WebUI.WebApp.appAbout" ValidateRequest="false" %>

<asp:Content ID="chead" ContentPlaceHolderID="head" runat="server">
<link rel="miphtml" href="http://m.qu17.com/mip/aboutus/" />
</asp:Content>

<asp:Content ID="cheader" ContentPlaceHolderID="header" runat="server">
    <div class="index_header">
    <div class="in-head">
        <div class="backto"><a href="javascript:history.back();"></a></div>
        <div class="location"><h1>关于青旅</h1></div>
        <div class="backhome">
            <a href="<%=ClassLibrary.Common.SysConfig.webSiteApp %>" class="icon_h">首页</a>
        </div>
    </div>
    </div>
</asp:Content>

<asp:Content ID="carticle" ContentPlaceHolderID="article" runat="server">
    <div class="article_box3">
        <div class="atl_info">
            <%=dataAbout%>
        </div>
    </div>
</asp:Content>

<asp:Content ID="cfooter" ContentPlaceHolderID="footer" runat="server">

</asp:Content>
