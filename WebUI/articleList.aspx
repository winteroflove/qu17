<%@ Page Title="" Language="C#" MasterPageFile="~/FireMain.Master" AutoEventWireup="true" CodeBehind="ArticleList.aspx.cs" Inherits="WebUI.articleList" ValidateRequest="false" %>

<asp:Content ID="chead" ContentPlaceHolderID="head" runat="server">
<meta name="mobile-agent" content="format=html5;url=<%=appurl %>" /><script type="text/javascript">
    uaredirect("<%=appurl %>");
</script>
</asp:Content>

<asp:Content ID="cbody" ContentPlaceHolderID="body" runat="server">
    <div class="location" ><i class="icon"></i><a href="<%=ClassLibrary.Common.SysConfig.webSite %>/" title="">重庆青年旅行社</a><i class="next"></i><%=typeName%></div>
    <div class="main">
        <div class="sidebar">
            <div class="side_rec">
                <div class="side_rec_top">当季推荐</div>
                <ul class="side_rec_items">
                    <%=dataSalesList %>
                </ul>
            </div>
            
        </div>
        <div class="index_left">
            <div class="articleList_box">
                <div class="alb_top"><h1><%=typeName%></h1></div>
                <ul>
                    <%=dataArticleList%>
                </ul>
                <%=pageInfo%>
            </div>
        </div>
    </div>
    <div class="clear"></div>
</asp:Content>

<asp:Content ID="cfooter" ContentPlaceHolderID="footer" runat="server">

</asp:Content>