<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OrdersDetail.aspx.cs" Inherits="WebUI.WebManage.Orders.OrdersDetail" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>>订单详情</title>
    <link href="/WebManage/css/main.css" rel="stylesheet" type="text/css" />

    <script src="/WebManage/js/jquery.min.js" type="text/javascript"></script>

    <script src="/WebManage/js/common.js" type="text/javascript"></script>

    <script src="/WebManage/js/WebManage.js" type="text/javascript"></script>

    <style type="text/css">
        .tableList{line-height:24px;text-align:center;}
    </style>

</head>
<body>
    <h1>
        <span><b>订单详情</b></span><a href="OrdersList.aspx">订单列表</a>
    </h1>
    <form class="form-div" action="OrdersDetail.aspx?ac=edit" method="post">
    <table width="100%" class="tableAdd">
        <colgroup>
            <col width="100" class="label" />
            <col />
            <col width="100" class="label" />
            <col />
        </colgroup>
        <tr>
            <td align="right">
                订单号：
            </td>
            <td>
                <%=orderNumber %> <input id="Hidden1" name="OrderNumber_Hidden" type="hidden" value="<%=orderNumber %>" />
            </td>
            <td align="right">
                用户名：
            </td>
            <td>
                <%=userName %>
            </td>
        </tr>
        <tr>
            <td align="right">
                联系人：
            </td>
            <td>
                <%=linkman %>
            </td>
            <td align="right">
                固定电话：
            </td>
            <td>
                <%=telphone %>
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
                传真：
            </td>
            <td>
                <%=fax %>
            </td>
        </tr>
        <tr>
            <td align="right">
                身份证号：
            </td>
            <td>
                <%=identityCard %>
            </td>
            <td align="right">
                电子邮件：
            </td>
            <td>
                <%=email %>
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
                商品总价：
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
            <td>
                <span>
                    <input name="Status" type="radio" value="未付款待处理"  />未处理
                    <input name="Status" type="radio" value="已付款处理中" />处理中
                    <input name="Status" type="radio" value="已完成" />已完成
                    <input name="Status" type="radio" value="无效订单" />无效订单
                    <input class="btn" type="submit" value="更改状态" /></span>
            </td>
            <td align="right">
                创建时间：
            </td>
            <td>
                <%=createdTime %>
            </td>
        </tr>
        <tr>
            <td align="right">
                备注：
            </td>
            <td colspan="3">
                <%=remark %>
            </td>
        </tr>
        <tr>
            <td colspan="4">
            
                <table class="tableList">
                    <thead>
                        <tr>
                            <th>
                                线路名称
                            </th>
                            <th>
                                数量
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
                    <%--                    <tfoot>
                        <tr>
                            <td colspan="9">
                                <div id="turn-page" class="page floatR">
                                    <%=pageInfo%>
                                </div>
                            </td>
                        </tr>
                    </tfoot>--%>
                </table>
            </td>
        </tr>
        <tfoot>
            <tr>
                <td colspan="4" align="center">
                    <!--input type="button" class="btn2" value="返回" onclick="../Orders/OrdersList.aspx" /-->
                    <a href="OrdersList.aspx"><img src="../images/back.jpg" /></a>
                </td>
            </tr>
        </tfoot>
    </table>
    </form>
      <script type="text/javascript">
        
        document.getElementsByName("Status")[<%=status%>].checked = true;

    </script>

</body>
</html>
