<%@ Page Language="C#" MasterPageFile="~/FireMain.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="WebUI.vip.index" %>

<asp:Content ID="chead" ContentPlaceHolderID="head" runat="server">
     <link href="/style/layout.css" rel="stylesheet" type="text/css" />
</asp:Content>

<asp:Content ID="cbody" ContentPlaceHolderID="body" runat="server">
<div class="main">
    <div class="location" ><i class="icon"></i><a href="<%=ClassLibrary.Common.SysConfig.webSite %>/" title="">重庆青年旅行社</a><i class="next"></i>订单查询</div>
</div>
<div class="main">
    <div class="order_box">
        <div class="order_box_title"><h2>订单查询</h2></div>
        <div class="order">
            <div class="order_form">
                <form action="/vip/" method="post">
                    请输入订单编号：<input type="text" name="order_no" size="30" value="<%=orderNumber %>" maxlength="20" /> 
                    <input type="submit" value="搜索" />
                </form>
            </div>
            <table width="100%" class="vip martop8" style="text-align:center">
                <caption>
                    订单列表
                </caption>
                <tr>
                    <th>订单号</th>
                    <th>用户名</th>
                    <th>商品数量</th>
                    <th>商品总价</th>
                    <th>联系人</th>
                    <th>合同方式</th>
                    <th>支付方式</th>
                    <th>创建时间</th>
                    <th>状态</th>
                    <th>管理</th>
                </tr>
                <tbody>
                    <%=dataOrdersList%>
                </tbody>
            </table>
        </div>
    </div>
</div>
</asp:Content>
