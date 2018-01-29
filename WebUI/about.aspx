<%@ Page Language="C#" MasterPageFile="~/FireMain.Master" AutoEventWireup="true" CodeBehind="about.aspx.cs" Inherits="WebUI.about" %>

<asp:Content ID="chead" ContentPlaceHolderID="head" runat="server">
<meta name="mobile-agent" content="format=html5;url=<%=appurl %>" /><script type="text/javascript">
    uaredirect("<%=appurl %>");
</script>
</asp:Content>

<asp:Content ID="cbody" ContentPlaceHolderID="body" runat="server">
<div class="location" ><i class="icon"></i><a href="<%=ClassLibrary.Common.SysConfig.webSite %>/" title="">重庆青年旅行社</a><i class="next"></i><%=model.Title%></div>
<div class="main">
    <div class="sidebar">
        <div class="side_sales side_rec">
            <div class="side_rec_top">当季推荐</div>
			<ul class="sales_items">
			    <%=dataSalesList %>
            </ul>
        </div>
    </div>
    <div class="index_left">
        <div class='articleDetail_box'>
            <div class='articleDetail_summary about'>
                <div class='articleDetail_title'><h1><%=model.Title%></h1></div>
                <div class='articleDetail_writer'>&nbsp;</div>
            </div>
            <div class="articleDetail_content">
                <%=model.Content%>
            </div>
        </div>
    </div>
</div>
</asp:Content>

<asp:Content ID="cfooter" ContentPlaceHolderID="footer" runat="server">

</asp:Content>