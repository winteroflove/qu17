<%@ Page Title="" Language="C#" MasterPageFile="~/vip.master" AutoEventWireup="true" CodeBehind="orders.aspx.cs" Inherits="WebUI.vip.orders" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<form action="/vip/orders/" method="post">
<h2>我的订单　 
<input type="text" size="36" name="order_no" value="<%=orderNumber %>" style="padding-left:3px;" />&nbsp;&nbsp;<input class="submit" type="submit" value="搜索" /></h2>
</form>

    <table width="100%" class="vip martop8">
        <tr>
            <th>
                NO.
            </th>
            <th>
                订单号
            </th>
            <th>
                商品数量
            </th>
            <th>
                订单总价
            </th>
            <th>
                联系人
            </th>
            <th>创建时间</th>
            <th>状态</th>
            <th>
                管理
            </th>
        </tr>
        <%=dataOrdersList%>
        
    </table>

</asp:Content>