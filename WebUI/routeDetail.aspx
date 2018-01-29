<%@ Page Title="" Language="C#" MasterPageFile="~/FireMain.Master" AutoEventWireup="true" CodeBehind="routeDetail.aspx.cs" Inherits="WebUI.productDetail" ValidateRequest="false" %>

<asp:Content ID="chead" ContentPlaceHolderID="head" runat="server">
<link href="/style/calendar.css" rel="stylesheet" type="text/css" />
<script src="/Scripts/calenderPrice2.js" type="text/javascript"></script><meta name="mobile-agent" content="format=html5;url=<%=appurl %>" /><script type="text/javascript">
    uaredirect("<%=appurl %>");
</script>
</asp:Content>
<asp:Content ID="cbody" ContentPlaceHolderID="body" runat="server">
    <div class="location" ><i class="icon"></i><a href="<%=ClassLibrary.Common.SysConfig.webSite %>/" title="">重庆青年旅行社</a><%=location%></div>
    <div class="main">
        <div class="routeHeader">
            <div class="detail_top">
                <div class="title"><h1><%=route.Title %></h1></div>
                <div class="bright"><%=route.Bright %></div>
                <%=themeName %>
            </div>
            <div class="detail_info">
                <div class="info_img">
                    <div class="info_img_big">
                        <img src="<%=firstImg %>" alt="<%=route.Title %>" width="500" height="310" />
                    </div>
                    <div class="info_img_small">
                        <div class="info_prev inactive"><span></span></div>
                        <div class="info_img_items">
                            <ul>
                                <%=smallImageList%>
                            </ul>
                        </div>
                        <div class="info_next <%=inactive %>"><span></span></div>
                    </div>
                </div>
                <div class="info_items">
                    <div class="item_desc2">
                        <div class="desc_title2">成人价格：</div>
                        <div class="info_left2">
                            <span class="price"><%=strPrice%></span>
                            <span class="price_desc">[起价说明]
                            <div class="pd_detail">此起价是一位成人参加本线路的最低价格，最终的价格会因您所选择的出发日期、出行人数、住宿标准不同而有所差异！<div class="box_up"></div></div></span>
                        </div>
                    </div>
                    <div class="item_desc">
                        <div class="desc_title">目&nbsp;&nbsp;的&nbsp;&nbsp;地：</div>
                        <div class="info_left">
                            <%=ClassLibrary.Common.Function.Clip(route.Destination,13,false) %>
                        </div>
                    </div>
                    <div class="item_desc">
                        <div class="desc_title">行程天数：</div>
                        <div class="info_left">
                            <span class="rcolor"><%=route.RouteTime %>天</span>(建议提前<span class="rcolor"><%=route.AdvanceDays %>天以上</span>)
                        </div>
                    </div>
                    <div class="item_desc">
                        <div class="desc_title">交通方式：</div>
                        <div class="info_right">
                            <%=traffic %>
                        </div>
                    </div>
                    <div class="info_booking">
                        <div class="item_desc">
                            <div class="desc_title">出游日期：</div>
                            <div class="booking_date">
                                <input type="text" name="roaddate" id="roaddate" value="<%=bookingday %> <%=strAdultPrice %>" readonly="readonly" />
                                <div class="dateprice">
                                    <input type="hidden" id="DatePrice" name="DatePrice" value="<%=datePrice %>" />
                                    <input type="hidden" id="DateType" name="DateType" value="<%=dateType %>" />
                                    <input type="hidden" id="Price" name="Price" value="<%=price %>" />
                                    <input type="hidden" id="ChildPrice" name="ChildPrice" value="<%=childPrice %>" />
                                    <div id="datePriceLayer" style="width:500px;">
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
                                    <div class="close_date"></div>
                                </div>
                                <input name="stdate" id="stdate" value="<%=bookingday %>" type="hidden"/>
                                <input name="aprice" id="aprice" value="<%=bookingAdultPrice %>" type="hidden"/>
                                <input name="cprice" id="cprice" value="<%=bookingChildPrice %>" type="hidden"/>
                            </div>
                        </div>
                        <div class="item_desc">
                            <div class="desc_title">出游人数：</div>
                            <div class="booking_number">
                                <span class="changnum"><i class="price_minus"></i><input type="text" value="1" readonly="readonly" id="adnum" name="adnum" class="price_num"/><i class="price_add"></i></span><span class="num_t">成人</span>
                                <span class="changnum"><i class="price_minus"></i><input type="text" value="0" readonly="readonly" id="childnum" name="childnum" class="price_num" /><i class="price_add"></i></span><span class="num_t">儿童</span>
                                <span class="child_desc">儿童标准
                                <div class="cd_detail">儿童跟团旅游因所含内容不同而有所差异，儿童价格请以客服确认为准！<div class="box_up"></div></div></span>
                            </div>
                        </div>
                        <div class="booking_now">
                            <div class="booking_button">
                                <a href="javascript:void(0);" onclick="<%=buyEventStr %>" class="buy_btn">立即预订</a>
                            </div>
                            <div class="tel_visit"><span><em><%=route.ViewCount %></em>赞</span><div class="tel_booking"></div></div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="routedetailed_dcontent">
            <div class="rd_menu">
                <ul>
                    <li class="on">
                        <div>
                            线路特色</div>
                    </li>
                    <li>
                        <div>
                            行程说明</div>
                    </li>
                    <li>
                        <div>
                            费用说明</div>
                    </li>
                    <li>
                        <div>
                            预订须知</div>
                    </li>
                    <li>
                        <div>
                            如何预订</div>
                    </li>
                    <li>
                        <div>
                            线路点评</div>
                    </li>
                    <li>
                        <div>
                            相关线路</div>
                    </li>
                    <li>
                        <div>
                            旅游攻略</div>
                    </li>
                </ul>
                <div class="rd_booking" onclick="<%=buyEventStr %>">立即预订</div>
            </div>
            <div class="rd_item rd_feature">
                <div class="rd_item_feature"><div class="ft_title">经理推荐</div></div>
                <div class="rd_item_content">
                    <%=routeFeature %>
                </div>
            </div>
            <div class="rd_item rd_description">
                <div class="rd_item_nav"><span>行程说明</span></div>
                <div class="rd_desc_content">
                    <%=dataDayInfo%>
                </div>
                <div class="clear"></div>
            </div>
            <div class="rd_item rd_price">
                <div class="rd_item_nav"><span>费用说明</span></div>
                <div class='rd_item_content2'>
                    <%=descriptionPrice %>
                </div>
            </div>
            <div class="rd_item rd_notice">
                <div class="rd_item_nav"><span>预订须知</span></div>
                <div class='rd_item_content2'>
                    <%=routeNotice %>
                </div>
            </div>
            <div class="rd_item rd_notice">
                <div class="rd_item_nav"><span>如何预订</span></div>
                <div class='rd_item_content2'>
                    <%=bookinginfo %>
                </div>
            </div>
            <div class="rd_item rd_comment">
                <div class="rd_item_nav"><span>线路点评</span></div>
                <div class="detail_items">
                    <div class="comment_summary" >
                        <div class="comment_rate" >
                            <div class="comment_score"><%=commentGrade %></div>
                            <div class="comment_title">满意度</div>
                        </div>
                        <div class="writeback">点评来自<span class="comment_num"><%=commentCount%></span>位游客真实旅游感受！归来点评，好礼相送</div>
                        <a  id="btnAddComment" onclick="javascript:document.getElementById('comment_Info').style.display = 'block';" href="javascript:void(0);">我来点评</a>
                    </div>
                    <div class="comment_Info" id="comment_Info">
                        <form action="/addcomment/" onsubmit="return commentAdd()" method="post" >
                            <div class="commentline">
                                <div class="comment_title">昵 称：</div>
                                <input type="text" name="Nickname" id="Nickname" value="<%=userNickname %>" />　
                                <input type="checkbox" name="Anonymous" value="True" style="margin-top: 10px;"/><span>匿名</span>
                            </div>
                            <div class="commentline">
                                <div class="comment_title">邮 箱：</div>
                                <input type="text" style="width:300px;" name="Email" id="Email" onblur="checkEmail(this)" />
                                <div id="chkemail" class="checkinput hide">请输入正确的电子邮箱！</div>
                            </div>
                            <div class="commentline">
                                <div class="comment_title">评论星级：</div>
                                <div class="xing_div"><input  type="radio" name="xing"   value="1" /><div class="xing_1"></div></div>
                                <div class="xing_div"><input  type="radio" name="xing"   value="2" /><div class="xing_2"></div></div>
                                <div class="xing_div"><input  type="radio" name="xing"   value="3" /><div class="xing_3"></div></div>
                                <div class="xing_div"><input  type="radio" name="xing"   value="4" /><div class="xing_4"></div></div>
                                <div class="xing_div"><input  type="radio" name="xing" checked="checked"   value="5" /><div class="xing_5"></div></div>
                            </div>
                            <div class="commentline" style="height:90px;">
                                <div class="comment_title">评论内容：</div>
                                <textarea id="Content" name="Content" class="coment_text" cols="20" rows="2"></textarea>
                            </div>
                            <div class="commentline">
                                <div class="comment_title">验证码：</div>
                                <input type="text" id="yanz" name="yanz" maxlength="50" value="" />
                                <img src="/random.aspx" id="imgcode" style="vertical-align:middle;" onclick="ChangeCode()" alt="看不清？点击刷新" />
                            </div>
                            <div class="commentline">
                                <div class="comment_title"></div>
                                <input id="SubmitComment" type="submit" class="submit" value="提交" disabled />
                                <input type="hidden" name="routeID" id="routeID" value="<%=routeID %>" />
                                <input type="hidden" name="pingyin" id="pingyin" value="<%=pingYin %>" />
                                <input type="hidden" name="routetime" id="routetime" value="<%=route.RouteTime %>" />
                                <input type="hidden" name="routetitle" id="routetitle" value="<%=route.Title %>" />
                            </div>
                        </form>
                    </div>
                    <div class="comment_list" >
                        <%=datacomment%>
                    </div>
                </div>
            </div>
            <div class="rd_item rd_relatedroute">
                <div class="rd_item_nav"><span>相关线路</span>
                <div class="idx_more"><a href="<%=ClassLibrary.Common.SysConfig.webSite %>/<%=displayPy %>/" target="_blank">更多<%=displayName%>旅游线路</a></div>
                </div>
                <ul class="relateroute_items">
                    <%=dataXiangRoute %>
                </ul>
            </div>
            <div class="rd_item rd_relatearticle">
                <div class="rd_item_nav"><span>旅游攻略</span></div>
                <div class="routedetail_articles">
                    <ul class="content_articlelist">
                        <%=dataArticleList%>
                    </ul>
                </div>
            </div>
        </div>
        <div class="clear"></div>
    </div>
    <div class="clear"></div>
</asp:Content>
<asp:Content ID="cfooter" ContentPlaceHolderID="footer" runat="server">
<script src="/Scripts/scollImg.js" type="text/javascript"></script>
<script type="text/javascript">
    scollImg();
    scollrout();
    pushRoutes('<%=routeID %>', '<%=route.Title %>', '<%=price %>', '<%=firstImg %>', '<%=pingYin %>');
    var islogin = '<%=isLogin %>';
    if (islogin == 'True') {
        $("#SubmitComment").attr("disabled", false); 
        $("#SubmitComment").attr("value", "提交");
    } else {
        $("#SubmitComment").attr("disabled", true);
        $("#SubmitComment").attr("value", "请登录");
    }
</script>
</asp:Content>
