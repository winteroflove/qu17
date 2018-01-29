<%@ Page Title="" Language="C#" MasterPageFile="~/WebApp/AppMain.Master" AutoEventWireup="true" CodeBehind="appRouteDetail.aspx.cs" Inherits="WebUI.WebApp.appRouteDetail" ValidateRequest="false" %>

<asp:Content ID="chead" ContentPlaceHolderID="head" runat="server">
    <link rel="miphtml" href="<%=mipUrl %>" />
    <link href="/WebApp/css/calendar.css" rel="stylesheet" type="text/css" />
    <script src="/WebApp/js/calenderPrice2.js" type="text/javascript"></script>
</asp:Content>

<asp:Content ID="cheader" ContentPlaceHolderID="header" runat="server">
<div class="index_header">
    <div class="in-head">
        <div class="backto"><a href="javascript:history.back();"></a></div>
        <div class="location">线路详情</div>
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
    <div class="article_box2 detail_box">
        <div class="detail_info">
            <div class="detl_img" style="background-image:url(<%=image%>)"></div>
            <div class="detl_tp">
                <div class="detl_title"><%=route.Title %></div>
                <div class="detl_price">&yen;<i><%=price %></i>起</div>
            </div>
        </div>
        <!--div class="detl_tag">
            <%=themeName %>
            <!--div class="detl_zt">自由行</div>
            <div class="detl_no">编号：ZQL<%=route.ID %></div>
        </div-->
        <div class="detl_content">
            <!--ul class="detl_nav">
                <li class="on"><span class="di1">基本信息</span></li>
                <li><span class="di2">行程详情</span></li>
                <li><span class="di3">预订须知</span></li>
            </ul-->
            <div class="detl_item">
                <div class="date_top"><span>出发日期与价格</span>[仅供参考]</div>
                <input type="hidden" id="DatePrice" name="DatePrice" value="<%=datePrice %>" />
                <input type="hidden" id="DateType" name="DateType" value="<%=dateType %>" />
                <input type="hidden" id="Price" name="Price" value="<%=price %>" />
                <input type="hidden" id="ChildPrice" name="ChildPrice" value="<%=childPrice %>" />
                <div id="datePriceLayer">
                    <script type="text/javascript">                            //调用函数
                        document.writeln("<div id='calenderdiv'>日历加载中...</div>");
                        //calender("", "");
                        var nd, nd_year, nd_month;
                        var cdate = '<%=bookingday %>'.split('-');
                        nd_year = cdate[0];
                        nd_month = cdate[1];
                        new_calender(nd_year, nd_month);
                    </script>
                </div>
                <div class="booking_info">
                    <div class="bi_tip">人数：</div>
                    <div class="bi_no">
                        <div class="tn-dr">
                            <div class="minus">-</div><div><input readonly="readonly" value="1" id="adnum" name="adnum" class="price_num" /></div><div class="plus">+</div><div>成人</div>
                        </div>
                        <div class="tn-dr">
                            <div class="minus">-</div><div><input readonly="readonly" value="0" id="childnum" name="childnum" class="price_num" /></div><div class="plus">+</div><div>儿童</div>
                        </div>
                    </div>
                </div>
                <input name="stdate" id="stdate" value="<%=bookingday %>" type="hidden"/>
                <input name="aprice" id="aprice" value="<%=bookingAdultPrice %>" type="hidden"/>
                <input name="cprice" id="cprice" value="<%=bookingChildPrice %>" type="hidden"/>
                <div class="booking_go"><a onclick="<%=buyEventStr %>" >立即预订</a></div>
                <div class="detl_ts_top"><span>线路特色</span></div>
                <div class="detl_ts_txt">
                    <%=routeFeature %>
                </div>
                <div class="detl_ts_top"><span>行程介绍</span></div>
                <div class="detl_ts_txt">
                    <%=routedays%>
                </div>
                <div class="detl_ts_top"><span>费用说明</span></div>
                <div class="detl_ts_txt">
                    <%=descriptionPrice%>
                </div>
                <div class="detl_ts_top"><span>预订须知</span></div>
                <div class="detl_ts_txt">
                    <%=routeNotice%>
                </div>
                <div class="detl_dp_top"><span>游客点评</span></div>
                <div class="detl_dp_txt">
                    <div class="detl_myd">满意度：<span><%=commentGrade%></span></div>
                    <div class="detl_dpn"><span><%=commentCount%></span>人点评</div>
                </div>
            </div>
            <!--div class="detl_item">
                <div class="dtl_top"><span>行程介绍</span></div>
                <%=routedays%>
            </div>
            <div class="detl_item">
                <div class="dtlprice_top"><span>费用说明</span></div>
                <div class="dtltips_con">
                    <%=descriptionPrice%>
                </div>
                <div class="dtltips_top"><span>预订须知</span></div>
                <div class="dtltips_con">
                    <%=routeNotice %>
                </div>
            </div>
            <div class="detl_item">
                <div class="detl_dp_top"><span>游客点评</span></div>
                <div class="detl_dp_txt">
                    <div class="detl_myd">满意度：<span><%=commentGrade%></span></div>
                    <div class="detl_dpn"><span><%=commentCount%></span>人点评</div>
                </div>
            </div-->
        </div>
    </div>
</asp:Content>

<asp:Content ID="cfooter" ContentPlaceHolderID="footer" runat="server">
    <script type="text/javascript">
        switchdetl();
        $("img").attr("style", "");
    </script>
</asp:Content>