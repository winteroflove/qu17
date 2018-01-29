<%@ Page Title="" Language="C#" MasterPageFile="~/FireMain.Master" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="WebUI._default" ValidateRequest="false" %>

<asp:Content ID="chead" ContentPlaceHolderID="head" runat="server">
<meta name="mobile-agent" content="format=html5;url=<%=appurl %>" />
<script type="text/javascript">
    uaredirect("<%=appurl %>");
</script>
</asp:Content>
<asp:Content ID="adverse" ContentPlaceHolderID="adverse" runat="server">
    <div class="outerContainer">
        <div class="main_header">
            <div class="scoll_ad">
                <!-- 图片切换  begin -->
                <div class="activity_slide">
                    <ul class="activity_images">
                        <%=DataScroll%>
                    </ul>
                    <ul class="activity_titles">
                        <%=DataScrollTitles%>
                    </ul>
                    <a class="slide_icon icon_prev" ></a>
                    <a class="slide_icon icon_next" ></a>
                </div>
                <!-- 图片切换  end -->
            </div>
        </div>
    </div>
    <div class="clear"></div>
</asp:Content>
<asp:Content ID="cbody" ContentPlaceHolderID="body" runat="server">
    <div class="idx_rmtj">
        <div class="idx_rmtj_top">
            <div class="icon_rm"></div>
            <div class="rmtj_title">聚划算</div>
            <div class="rmtj_title2"><h1>重庆中国青年旅行社</h1>特价秒杀！</div>
            <div class="icon_more"><a href="<%=ClassLibrary.Common.SysConfig.webSite %>/sale/" rel="nofollow">查看更多</a></div>
        </div>
        <ul class="rmtj_items">
            <%=DataSaleAd %>
        </ul>
    </div>
    <div class="clear"></div>
    <div class="idx_cj">
        <div class="idx_cj_top">
            <div class="icon_cj"></div>
            <div class="cj_title">出境游</div>
            <div class="cj_title2">一场说走就走的旅行尽在重庆青年旅行社</div>
            <div class="icon_more"><a href="<%=ClassLibrary.Common.SysConfig.webSite %>/chujing/" rel="nofollow">查看更多</a></div>
        </div>
        <div class="cj_box">
            <div class="cj_daohang">
                <div class="cjd_cnty"><span>国家推荐</span></div>
                <div class="cjd_items">
                    <%=dataCjCity %>
                </div>
                <div class="cjd_senc"><span>景点推荐</span></div>
                <div class="cjd_items lastline">
                    <%=dataCjScenic %>
                </div>
            </div>
            <ul class="cj_items">
                <%=dataCjList %>
            </ul>
        </div>
    </div>
    <div class="idx_gn">
        <div class="idx_gn_top">
            <div class="icon_gn"></div>
            <div class="gn_title">国内游</div>
            <div class="gn_title2">祖国的大好河山尽收眼里</div>
            <div class="icon_more"><a href="<%=ClassLibrary.Common.SysConfig.webSite %>/guonei/" rel="nofollow">查看更多</a></div>
        </div>
        <div class="gn_box">
            <ul class="gn_daohang">
                <%=dataGnCity %>
            </ul>
            <ul class="gn_items">
                <%=dataGnList %>
            </ul>
        </div>
    </div>
    <div class="idx_zb">
        <div class="idx_zb_top">
            <div class="icon_zb"></div>
            <div class="zb_title">周边游</div>
            <div class="zb_title2">重庆旅行社带你发现身边的美</div>
            <div class="icon_more"><a href="<%=ClassLibrary.Common.SysConfig.webSite %>/chongqing/" rel="nofollow">查看更多</a></div>
        </div>
        <div class="zb_box">
            <ul class="zb_daohang">
                <%=dataZbCity %>
            </ul>
            <ul class="zb_items">
                <%=dataZbList %>
            </ul>
        </div>
    </div>
    <div class="idx_sx">
        <div class="idx_sx_top">
            <div class="icon_sx"></div>
            <div class="sx_title">三峡游</div>
            <div class="sx_title2">跟随重庆旅行社享受难忘水上时光</div>
            <div class="icon_more"><a href="<%=ClassLibrary.Common.SysConfig.webSite %>/sanxia/" rel="nofollow">查看更多</a></div>
            <div class="sx_top_items">
                <a href="<%=ClassLibrary.Common.SysConfig.webSite %>/guoneichuan/">国内游船</a><i></i>
                <a href="<%=ClassLibrary.Common.SysConfig.webSite %>/haohuachuan/">豪华游轮</a><i></i>
                <a href="<%=ClassLibrary.Common.SysConfig.webSite %>/schedule/">船期表</a>
            </div>
        </div>
        <ul class="sx_box">
            <%=dataSxList %>
        </ul>
    </div>
</asp:Content>
<asp:Content ID="cfooter" ContentPlaceHolderID="footer" runat="server">
    <div id="links" class="link_list" >
        <div class="link_title">友情链接</div>
        <ul>
            <%=BindLink() %>
        </ul>
    </div>
    <script src="/Scripts/imgfs.js" type="text/javascript"></script>
    <script type="text/javascript">
        activity_slide();
        var hasAd = "<%=hasSaleAd %>";
        if (hasAd == "False") $(".idx_rmtj").hide();
    </script>
</asp:Content>