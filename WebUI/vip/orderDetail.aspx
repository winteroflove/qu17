<%@ Page Language="C#" MasterPageFile="~/FireMain.Master" AutoEventWireup="true" CodeBehind="orderDetail.aspx.cs" Inherits="WebUI.vip.orderDetail" Title="无标题页" %>
<asp:Content ID="chead" ContentPlaceHolderID="head" runat="server">
     <style type="text/css">
    .tableList a{color:#06a7d3;}
    .tableList a:hover{text-decoration:underline; color:#ff4200;}
</style>
</asp:Content>

<asp:Content ID="cbody" ContentPlaceHolderID="body" runat="server">
<div class="location" ><i class="icon"></i><a href="<%=ClassLibrary.Common.SysConfig.webSite %>/" title="">重庆青年旅行社</a><i class="next"></i>订单详情</div>

<div class="main">
    <div class="order_box">
        <div class="order_box_title"><h2>订单详情</h2></div>
        <table width="100%" class="tableAdd" cellpadding="0" cellspacing="0">
            <colgroup>
                <col />
                <col width="40%" />
                <col />
                <col />
            </colgroup>
            <tr>
                <td align="right">
                    订单号：
                </td>
                <td>
                    <%=orderNumber %>
                </td>
                <td align="right">
                    联系人：
                </td>
                <td>
                    <%=linkman %>
                </td>
            </tr>
            <tr>
                <td align="right">
                    手机：
                </td>
                <td>
                    <%=mobile %>
                </td>
                <td align="right">
                    固定电话：
                </td>
                <td>
                    <%=telphone %>
                </td>
            </tr>
            <tr>
                <td colspan="4">
                </td>
            </tr>
            <tr>
                <td align="right">
                    商品数量：
                </td>
                <td>
                    <%=proQuantity %>
                </td>
                <td align="right">
                    订单总价：
                </td>
                <td>
                    &yen;<%=proTotalPrice %>元
                </td>
            </tr>
            <tr>
                <td align="right">
                    合同方式：
                </td>
                <td>
                    <%=contractType %>
                </td>
                <td align="right">
                    支付方式：
                </td>
                <td>
                    <%=payment %>
                </td>
            </tr>
            <tr>
                <td align="right">
                    状态：
                </td>
                <td><%=status %></td>
                <td align="right">
                    创建时间：
                </td>
                <td>
                    <%=createdTime %>
                </td>
            </tr>
            <tr style="display:none">
                <td align="right">
                    备注：
                </td>
                <td colspan="3">
                    <%=remark %>
                </td>
            </tr>
            <tr>
                <td colspan="4">
                
                    <table class="tableList" cellpadding="0" cellspacing="0">
                        <thead>
                            <tr>
                                <th>
                                    线路名称
                                </th>
                                <th>
                                    人数
                                </th>
                                <th>
                                    线路价格
                                </th>
                                <th>
                                    行程天数
                                </th>
                                <th>
                                    发团时间
                                </th>
                                <th>
                                    创建时间
                                </th>
                            </tr>
                        </thead>
                        <tbody>
                            <%=dataOrderDetailList%>
                        </tbody>
                    </table>
                </td>
            </tr>
            <tfoot>
                <tr>
                    <td colspan="4" align="center">
                        <input type="button" class="btn2" value="返回" onclick="history.back(-1)" />
                    </td>
                </tr>
            </tfoot>
        </table>
    </div>
</div>
    
</asp:Content>
