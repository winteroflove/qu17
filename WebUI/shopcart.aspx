<%@ Page Title="" Language="C#" MasterPageFile="~/FireMain.Master" AutoEventWireup="true" CodeBehind="shopcart.aspx.cs" Inherits="WebUI.shopcart" %>
<asp:Content ID="chead" ContentPlaceHolderID="head" runat="server">
    <script src="/DatePicker/WdatePicker.js" type="text/javascript"></script>
    <style type="text/css">
        #totalPrice { margin-left:95px;}
    </style>
</asp:Content>

<asp:Content ID="cbody" ContentPlaceHolderID="body" runat="server">
<div class="location" ><i class="icon"></i><a href="<%=ClassLibrary.Common.SysConfig.webSite %>/" title="">重庆青年旅行社</a><i class="next"></i>购物车</div>

<div class="main">
    <div class="cart_box">
        <div class="cart_box_title"><h2>订单信息</h2></div>
        <div class="cart">
            <div class="step s1">第一步</div>
            <div class="content">
                <table class="tableCart_head" cellpadding="0" cellspacing="0">
                    <colgroup>
                        <col width="30%" />
                        <col width="10%" />
                        <col width="10%" />
                        <col width="10%" />
                        <col width="10%" />
                        <col width="10%" />
                        <col width="10%" />
                        <col width="10%" />
                    </colgroup>
                    <thead>
                        <tr>
                            <td>线路名称</td>
                            <td>发团时间</td>
                            <td>成人价格</td>
                            <td>成人人数</td>
                            <td>小孩价格</td>
                            <td>小孩人数</td>
                            <td>小计(元)</td>
                            <td class="lastLine">删除</td>
                        </tr>
                    </thead>
                </table>

                <div id="cartWrap">
                    
                </div>
                <!--div class="cart_calender">
                    <input type="text" class="cart_input" id="1_" value="2015-03-18" readonly="readonly"/>
                    <div class="cart_calender_box">
                        
                    </div>
                </div-->
                <table class="cartSum">
                    <tr>
                        <th width="285" style="padding-left:10px;">
                            合计
                        </th>
                        <th width="340" align="right">
                            <span id="totalAdCount">0</span>人
                        </th>
                        <th width="235" align="right">
                            <span id="totalChCount">0</span>人
                        </th>
                        <th width="290" align="left">
                            <span id="totalPrice">0</span>元
                        </th>
                    </tr>
                </table>
                <table class="cartFun" width="98%">
                    <tr>
                        <td>
                            <img alt="清空购物车" style="cursor:pointer" onclick="clearCart()" src="/image/btn_cart_clear.gif" />
                        </td>
                        <td align="right">
                            <a href="<%=ClassLibrary.Common.SysConfig.webSite %>/"><img alt="继续购物" src="/image/btn_cart_back.gif" /></a>　
                            <img alt="结算" style="cursor:pointer" onclick="checkout('order')" src="/image/btn_cart_go.gif" />
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </div>
    <div class="cartHot">
        <div class="cartHot_title"><h2>热门线路</h2></div>
        <div class="cartHot_list">
            <%=hotRouteList%>
            <span class="clearfix">&nbsp;</span>
        </div>
    </div>
</div>

</asp:Content>
<asp:Content ID="cfooter" ContentPlaceHolderID="footer" runat="server">
    <script type="text/javascript">
        showCart();
    </script>
</asp:Content>