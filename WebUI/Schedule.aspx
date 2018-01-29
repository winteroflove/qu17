<%@ Page Title="" Language="C#" MasterPageFile="~/FireMain.Master" AutoEventWireup="true" CodeBehind="Schedule.aspx.cs" Inherits="WebUI.Schedule" %>

<asp:Content ID="chead" ContentPlaceHolderID="head" runat="server">
<meta name="mobile-agent" content="format=html5;url=<%=appurl %>" /><script type="text/javascript">
    uaredirect("<%=appurl %>");
</script>
</asp:Content>

<asp:Content ID="cbody" ContentPlaceHolderID="body" runat="server">
<div class="location" ><i class="icon"></i><a href="<%=ClassLibrary.Common.SysConfig.webSite %>/" title="">重庆青年旅行社</a><i class="next"></i>豪华游轮船期表</div>

    <div class="schedule_table">
        <div class="schedule_top">
            <h1>长江三峡豪华游轮船期表</h1>
        </div>
        <div class="schedule_detail">
            <%=scheduleList%>
        </div>
        <div class="schedule_notice">
            <p>[豪华游船船期表说明]</p>
            <p>1：因季节、满位、包船、特殊航次等原因，长江三峡豪华游船船期表内容仅供参考，详情请咨询客服，谢谢！</p>
            <p>2：中青旅豪华游船船期咨询电话<span>400-017-5761</span></p>
        </div>
    </div>
</asp:Content>
<asp:Content ID="cfooter" ContentPlaceHolderID="footer" runat="server">

</asp:Content>
