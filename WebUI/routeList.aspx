<%@ Page Title="" Language="C#" MasterPageFile="~/FireMain.Master" AutoEventWireup="true" CodeBehind="routeList.aspx.cs" Inherits="WebUI.routeList" %>

<asp:Content ID="chead" ContentPlaceHolderID="head" runat="server">
<meta name="mobile-agent" content="format=html5;url=<%=appurl %>" /><script type="text/javascript">
    uaredirect("<%=appurl %>");
</script>
</asp:Content>

<asp:Content ID="cbody" ContentPlaceHolderID="body" runat="server">
    <div class="location" ><i class="icon"></i><a href="<%=ClassLibrary.Common.SysConfig.webSite %>"/" title="">重庆青年旅行社</a><%=location%></div>
    <div class="main">
        <div class="sidebar" >
            <div class="side_nav">
                <%=leftNavList %>
            </div>
            <div class="side_rec">
                <div class="side_rec_top"><%=currentName%>热门推荐</div>
                <ul class="side_rec_items">
                    <%=dataSalesList %>
                </ul>
            </div>
            <div class="side_gonglue">
                <div class="side_gonglue_top"><%=currentName%>攻略资讯</div>
                <ul class="side_gonglue_items">
                    <%=dataGongLuList %>
                </ul>
            </div>
        </div>
        <div class="index_left">
            <div class="rl_filter">
                <%=routelistAds %>
                <div class="place"><h1><%=currentName%></h1></div>
                <div class="route_condition" >
                    <%=areaFilter%>
                    <%=themeFilter%>
                    <div class="condition_item" id="priceFilter">
                        <p class="item_title" data="2">行程预算</p>
                        <div class="item_list" >
                            <div class="item_cur" ><a href="<%=pricehref %>" rel="nofollow">全部</a></div>
                            <ul>
                                <%=priceFilter%>
                            </ul>
                        </div>
                    </div>
                    <div class="condition_item" id="daysFilter">
                        <p class="item_title" data="4">行程天数</p>
                        <div class="item_list">
                            <div class="item_cur"><a href="<%=dayshref %>" rel="nofollow">全部</a></div>
                            <ul>
                                <%=daysFilter %>
                            </ul>
                        </div>
                    </div>
                    <div class="selectitems"><div id="rootlist_search_ture" ><span class="cur_title">您已选择</span></div><a id="alldelete" onclick="clearFilter('<%=clearAllPy %>','')" rel="nofollow">全部清除</a></div>
                </div>
            </div>
            <div class="clear"></div>
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
                <%=pageInfo%>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="cfooter" ContentPlaceHolderID="footer" runat="server">
    <%=linkList%>
    <script type="text/javascript">
        var cFilter = '<%=currentFilter %>';
        checkCurrentFilter(cFilter);
        
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
