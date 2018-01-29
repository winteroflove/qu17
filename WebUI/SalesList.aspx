<%@ Page Language="C#" MasterPageFile="~/FireMain.Master" AutoEventWireup="true" CodeBehind="SalesList.aspx.cs" Inherits="WebUI.SalesList" %>

<asp:Content ID="chead" ContentPlaceHolderID="head" runat="server">
<meta name="mobile-agent" content="format=html5;url=<%=appurl %>" /><script type="text/javascript">
    uaredirect("<%=appurl %>");
</script>
</asp:Content>

<asp:Content ID="cbody" ContentPlaceHolderID="body" runat="server">
<div class="location" ><i class="icon"></i><a href="<%=ClassLibrary.Common.SysConfig.webSite %>/" title="">重庆青年旅行社</a><i class="next"></i>限时特价</div>
<div class="main">
    <div class="salesList_box">
        <div class="salseList_top">限时特价</div>
        <ul class="rmtj_items">
            <%=dataSaleAd %>
        </ul>
        <%=pageInfo %>
    </div>
</div>
</asp:Content>

<asp:Content ID="cfooter" ContentPlaceHolderID="footer" runat="server">

</asp:Content>