<%@ Page Title="" Language="C#" MasterPageFile="~/FireMain.Master" AutoEventWireup="true" CodeBehind="routeSearchList.aspx.cs" Inherits="WebUI.routeSearchList" %>
<%@ OutputCache Duration="60" VaryByParam="*" %>

<asp:Content ID="chead" ContentPlaceHolderID="head" runat="server">
     
</asp:Content>

<asp:Content ID="cbody" ContentPlaceHolderID="body" runat="server">
<div class="location" ><i class="icon"></i><a href="<%=ClassLibrary.Common.SysConfig.webSite %>/" title="">重庆青年旅行社</a><%=location%></div>
    <div class="main">
        <div class="sidebar">
            <div class="side_rec">
                <div class="side_rec_top">热门推荐</div>
                <ul class="side_rec_items">
                    <%=dataSalesList %>
                </ul>
            </div>
            <div class="side_gonglue">
                <div class="side_gonglue_top">旅游攻略</div>
                <ul class="side_gonglue_items">
                    <%=dataGongLuList %>
                </ul>
            </div>
        </div>
        <div class="index_left" >
            <div class="rl_filter">
                <div class="place"><h1>旅游线路搜索结果</h1></div>
            </div>
            <div class="route_sort">
                <div class="hc_top" >
                    <ul>
                        <li class=""><a onclick="RouteSort('<%=currentFilter2 %>',this)" title="默认排序" data="0">默认</a><i></i></li>
                        <li class=""><a onclick="RouteSort('<%=currentFilter2 %>',this)" title="按价格排序" data="<%=order==1?2:1 %>">价格</a><i></i></li>
                    </ul>
                    <div class="keyword"><h2><%=displayKey%></h2></div>
                </div>
            </div>
            <div class="rootlist_listtable"  id="rootlist_listtable">
                <%=dataRouteList %>
                <%=pageInfo %>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="cfooter" ContentPlaceHolderID="footer" runat="server">
    <script type="text/javascript">
  		var vo = <%=order %>;
  		if(vo==0){
  		$(".hc_top ul li").eq(0).addClass("on");
  		} else if(vo==1){
  		$(".hc_top ul li").eq(1).addClass("on2");
  		} else if(vo==2){
  		$(".hc_top ul li").eq(1).addClass("on");
  		} else if(vo==3){
  		$(".hc_top ul li").eq(2).addClass("on");
  		} else if(vo==4){
  		$(".hc_top ul li").eq(2).addClass("on2");
  		}else{
  		$(".hc_top ul li").eq(0).addClass("on");
  		}
    </script>
</asp:Content>
