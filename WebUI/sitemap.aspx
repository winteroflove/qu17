<%@ Page Title="" Language="C#" MasterPageFile="~/FireMain.Master" AutoEventWireup="true" CodeBehind="sitemap.aspx.cs" ValidateRequest="false" Inherits="WebUI.sitemap" %>

<asp:Content ID="chead" ContentPlaceHolderID="head" runat="server">
     
</asp:Content>

<asp:Content ID="cbody" ContentPlaceHolderID="body" runat="server">
     <div class="location" ><i class="icon"></i><a href="<%=ClassLibrary.Common.SysConfig.webSite %>/" title="">重庆青年旅行社</a><i class="next"></i>网站地图</div>
      <div class="SiteMap">
            <%=DataMap%>
            <div class="map_route">
                <div class="map_route_top">最新线路</div>
                <ul>
                    <%=mapRoute%>
                </ul>
            </div>
            <div class="map_route">
                <div class="map_route_top"><a href="<%=ClassLibrary.Common.SysConfig.webSite %>/news/" target="_blank">最新旅游资讯</a></div>
                <ul>
                    <%=mapArticle%>
                </ul>
            </div>
            <div class="map_route">
                <div class="map_route_top"><a href="<%=ClassLibrary.Common.SysConfig.webSite %>/article/" target="_blank">最新旅游攻略</a></div>
                <ul>
                    <%=mapNews%>
                </ul>
            </div>
      </div>
      
</asp:Content>
<asp:Content ID="cfooter" ContentPlaceHolderID="footer" runat="server">
 
</asp:Content>