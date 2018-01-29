﻿<%@ Page Language="C#" MasterPageFile="~/WebApp/AppMain.Master" AutoEventWireup="true" CodeBehind="appSalesList.aspx.cs" Inherits="WebUI.WebApp.appSalesList" ValidateRequest="false" %>

<asp:Content ID="chead" ContentPlaceHolderID="head" runat="server">
<link rel="miphtml" href="http://m.qu17.com/mip/sale/" />
</asp:Content>

<asp:Content ID="cheader" ContentPlaceHolderID="header" runat="server">
<div class="index_header">
    <div class="in-head">
        <div class="backto"><a href="javascript:history.back();"></a></div>
        <div class="location"><h1>聚划算</h1></div>
        <div class="backhome">
            <a href="<%=ClassLibrary.Common.SysConfig.webSiteApp %>" class="icon_h">首页</a>
        </div>
    </div>
    <div class="in-head-sous2">
        <div class="search">
            <form action="/" method="post" onsubmit="return gotoDataList(this)">
                <input type="text" placeholder="搜索旅游目的地..." id="skey" name="skey" class="sous" />
                <input type="submit" class="submit" value="搜索" />
            </form>
        </div>
        <div class="main_nav">
            <a href="<%=ClassLibrary.Common.SysConfig.webSiteApp %>/daohang/" class="icon_m">导航</a>
        </div>
    </div>
</div>
</asp:Content>

<asp:Content ID="carticle" ContentPlaceHolderID="article" runat="server">
<div class="article_box2">
    <ul class="saleList">
        <%=dataSaleList %>
    </ul>
</div>
</asp:Content>

<asp:Content ID="cfooter" ContentPlaceHolderID="footer" runat="server">

</asp:Content>
