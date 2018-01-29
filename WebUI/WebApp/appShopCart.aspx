<%@ Page Title="" Language="C#" MasterPageFile="~/WebApp/AppMain.Master" AutoEventWireup="true" CodeBehind="appShopCart.aspx.cs" Inherits="WebUI.WebApp.appShopCart" ValidateRequest="false" %>

<asp:Content ID="chead" ContentPlaceHolderID="head" runat="server">

</asp:Content>

<asp:Content ID="cheader" ContentPlaceHolderID="header" runat="server">
    <div class="in-head">
        <div class="backto"><a href="javascript:history.back();"></a></div>
        <div class="location"><h1>订单信息</h1></div>
        <div class="backhome">
            <a href="<%=ClassLibrary.Common.SysConfig.webSiteApp %>" class="icon_h">首页</a>
        </div>
    </div>
</asp:Content>

<asp:Content ID="carticle" ContentPlaceHolderID="article" runat="server">
    <div class="article_box">
        <form action="/addroute/" method="post" onsubmit="return formOrder(this)" >
            <div class="order_info">
                <ul id="orderinfo">

                </ul>
                <div class="orderprice"><span class="optitle">合计：</span><span id="op_total">0元</span></div>
                <div class="ordername">
                    <input class="orderinput" type="text" name="Linkman" placeholder="联系人姓名..." />
                    <span class="bt">(必填)</span>
                </div>
                <div class="ordertel">
                    <input class="orderinput" type="text" name="Mobile" placeholder="联系人手机号码..." />
                    <span class="bt">(必填)</span>
                </div>
                <div class="ordertype">
                    <span>合同：</span>
                    <input type="radio" name="ContractType" value="传真合同" />传真合同
                    <input type="radio" name="ContractType" value="现场合同" checked />现场合同
                </div>
                <div class="ordertype">
                    <span>付款：</span>
                    <input type="radio" name="Payment" value="银行转账" checked />银行转账
                    <input type="radio" name="Payment" value="上门付款" />上门付款
                </div>
            </div>
            <div class="gen_order">
                <a class="clearcart" onclick="javascript:history.back();">重新选择</a>
                <input type="hidden" id="productList" name="productList" title="商品列表: id,名称,数量,价格,天数,出发时间|..." />
                <input type="hidden" id="totalPrice" name="totalPrice" title="总价格" />
                <input type="submit" class="submitorder" value="提交订单" />
            </div>
        </form>
    </div>
</asp:Content>

<asp:Content ID="cfooter" ContentPlaceHolderID="footer" runat="server">
    <script type="text/javascript">
        showOrderCart();
    </script>
</asp:Content>
