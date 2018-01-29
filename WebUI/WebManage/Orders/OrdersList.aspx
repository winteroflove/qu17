<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OrdersList.aspx.cs" Inherits="WebUI.WebManage.Orders.OrdersList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>订单列表</title>
    <link href="/WebManage/css/main.css" rel="stylesheet" type="text/css" />

    <script src="/WebManage/js/jquery.min.js" type="text/javascript"></script>

    <script src="/WebManage/js/common.js" type="text/javascript"></script>

    <script src="/WebManage/js/WebManage.js" type="text/javascript"></script>

</head>
<body>
    <h1>
        <span><b>订单列表</b></span>
    </h1>
    <table class="tableList">
        <thead>
            <tr>
                <th>
                    订单号
                </th>
                <th>
                    用户名
                </th>
                <th>
                    商品数量
                </th>
                <th>
                    商品总价
                </th>
                <th>
                    联系人
                </th>
                <th>
                    合同方式
                </th>
                <th>
                    支付方式
                </th>
                <th>
                    状态
                </th>
                <th>
                    创建时间
                </th>
                <th>管理</th>
            </tr>
        </thead>
        <tbody>
            <%=dataOrdersList%>
        </tbody>
        <tfoot>
            <tr>
                <td colspan="9">
                    <div id="turn-page" class="page floatR">
                        <%=pageInfo%>
                    </div>
                </td>
            </tr>
        </tfoot>
    </table>
</body>
</html>
