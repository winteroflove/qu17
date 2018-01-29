<%@ Page Title="" Language="C#" MasterPageFile="~/WebApp/AppMain.Master" AutoEventWireup="true" CodeBehind="appArticleList.aspx.cs" Inherits="WebUI.WebApp.appArticleList" ValidateRequest="false" %>

<asp:Content ID="chead" ContentPlaceHolderID="head" runat="server">
<link rel="miphtml" href="<%=mipUrl %>" />
</asp:Content>

<asp:Content ID="cheader" ContentPlaceHolderID="header" runat="server">
<div class="index_header">
    <div class="in-head">
        <div class="backto"><a href="javascript:history.back();"></a></div>
        <div class="location"><h1><%=typeName %></h1></div>
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
        <div class="list_item_top">
            <div class="item_top_txt">旅游指南</div>
        </div>
        <ul class="alist_items">
            <li>
                <a href="<%=ClassLibrary.Common.SysConfig.webSiteApp %>/news/">旅游资讯</a>
            </li>
            <li>
                <a href="<%=ClassLibrary.Common.SysConfig.webSiteApp %>/article/">旅游攻略</a>
            </li>
        </ul>
        <div class="aritcleList" id="newsList">
            <%=newsList %>
        </div>
    </div>
</asp:Content>

<asp:Content ID="cfooter" ContentPlaceHolderID="footer" runat="server">
    <script type="text/javascript">
        var typeid = <%=typeId %>;
        if(typeid != 0){
            if(typeid == 8){
                $(".alist_items li:nth-child(1)").addClass("current");
            } else if(typeid == 10){
                $(".alist_items li:nth-child(2)").addClass("current");
            } else if(typeid == 5){
                $(".alist_items li:nth-child(3)").addClass("current");
            } else if(typeid == 6){
                $(".alist_items li:nth-child(4)").addClass("current");
            } else if(typeid == 11){
                $(".alist_items li:nth-child(5)").addClass("current");
            } 
        }
        var currentPage = 1;
        var totalPage = <%=countPage %>;
        var isRequest = true;
        loadMoreArticle(<%=typeId %>);
    </script>
</asp:Content>