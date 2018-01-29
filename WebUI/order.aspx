<%@ Page Title="" Language="C#" MasterPageFile="~/FireMain.Master" AutoEventWireup="true" CodeBehind="order.aspx.cs" Inherits="WebUI.order" %>
<asp:Content ID="chead" ContentPlaceHolderID="head" runat="server">
     
</asp:Content>

<asp:Content ID="cbody" ContentPlaceHolderID="body" runat="server">
<div class="location" ><i class="icon"></i><a href="<%=ClassLibrary.Common.SysConfig.webSite %>/" title="">重庆青年旅行社</a><i class="next"></i>订单确认</div>
<div class="main">
    <div class="order_box">
        <div class="order_box_title"><h2>订单信息</h2></div>
        <div class="order">
            <div class="step s2">第二步</div>
            <div class="content box">
                <form action="/order/ac" onsubmit="return formOrder(this)" method="post">
                <!--联系人信息-->
                <div class="title lastLine">联系人信息</div>
                <div class="ordermessages">
                    <ul>
                        <li>
                            <label>联系人姓名：</label>
                            <input type="text" class="text2" name="Linkman" maxlength="20" size="15" />
                            <span>(必填)</span>
                        </li>
                        <li>
                            <label>手机：</label>
                            <input type="text" class="text2" name="Mobile" maxlength="11" size="20" onblur="checkMobile(this)" />
                            <span>(必填)</span>
                            <div id="chkmobile" class="checkinput hide">请输入正确的手机号码！</div>
                        </li>
                        <li>
                            <label>固定电话：</label>
                            <input type="text" class="text2" name="Telphone" maxlength="20" size="20" />
                        </li>
                        <li>
                            <label>合同方式：</label>
                            <input type="radio" name="ContractType" value="传真合同" />传真合同　
                            <input type="radio" name="ContractType" value="现场合同" checked="checked" />现场合同
                        </li>
                        <li>
                            <label>支付方式：</label>
                            <input type="radio" name="Payment" value="银行转账" />银行转账
                            <input type="radio" name="Payment" value="上门付款" checked="checked" />上门付款
                        </li>
                    </ul>
                </div>
                <div class="clear"></div>
                <!--线路清单-->
                <div class="title">线路清单 <a href="<%=ClassLibrary.Common.SysConfig.webSite %>/shopcart/">[返回修改购物车]</a></div>
                <table id="cartWrap" class="tableOrder" cellpadding="0" cellspacing="0">
                    <colgroup>
                    <col width="50%" />
                    <col />
                    <col />
                    <col />
                    <col />
                    </colgroup>
                    <thead>
                        <tr>
                            <td align="left">线路名称</td>
                            <td>行程天数</td>
                            <td>发团时间</td>
                            <td>人数</td>
                            <td>线路价格</td>
                        </tr>
                    </thead>
                    <tbody>
                        
                    </tbody>
                </table>
                <!--结算信息-->
                <div class="title">结算信息</div>
                <div class="order_total">
                    <span class="total_right">应付总金额：<label class="txtTotalPrice">0</label>元</span>
                    <div class="clearfix">&nbsp;</div>
                </div>
                <input type="hidden" id="productList" name="productList" title="商品列表: id,名称,数量,价格,天数,出发时间|..." />
                <input type="hidden" id="totalAdCount" name="totalAdCount" title="成人数量" value="0" />
                <input type="hidden" id="totalChCount" name="totalChCount" title="小孩数量" value="0" />
                <input type="hidden" id="totalPrice" name="totalPrice" title="总价格" />
                <p class="pLine"><input type="submit" class="btnOrder" value="" /></p>
                </form>
            </div>
        </div>
    </div>
</div>
</asp:Content>

<asp:Content ID="cfooter" ContentPlaceHolderID="footer" runat="server">
    <script type="text/javascript">
        showOrderCart();
    </script>
</asp:Content>
