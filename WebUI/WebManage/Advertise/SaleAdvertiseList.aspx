<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SaleAdvertiseList.aspx.cs" Inherits="WebUI.WebManage.Advertise.SaleAdvertiseList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>特价广告列表</title>
    <link href="/WebManage/css/main.css" rel="stylesheet" type="text/css" />

    <script src="/WebManage/js/jquery.min.js" type="text/javascript"></script>

    <script src="/WebManage/js/common.js" type="text/javascript"></script>

    <script src="/WebManage/js/WebManage.js" type="text/javascript"></script>

</head>
<body>
    <h1>
        <span><b>特价广告列表</b></span><a href="SaleAdvertiseAdd.aspx">添加特价广告</a>
    </h1>
    <form class="form-div" action="SaleAdvertiseList.aspx" name="searchForm">
        <div class="search">
            线路类型： 
            <select name="cid" >
                <option value="">不限　　</option>
                <%=routeClassList %>
            </select>
            标题：
            <input size="10" class="text" name="key" value="<%=searchKey %>" />
            <input type="hidden" name="sorder" id="sorder" value="<%=saleorder %>" />
            <input value=" 搜索 " class="button" type="submit" onclick="SubmitSale()" />
        </div>
    </form>
    <table class="tableList">
        <thead>
            <tr>
                <th>
                    NO.
                </th>
                <th>图片</th>
                <th>
                    广告分类
                </th>
                <th>
                    标题
                </th>
                <th>
                    链接地址
                </th>
                <th>
                    排序<i class="sorder"></i>
                </th>
                <th>
                    过期时间
                </th>
                <th>
                    创建时间
                </th>
                <th>
                   管理
                </th>
            </tr>
        </thead>
        <tbody>
            <%=linksList%>
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
    <script type="text/javascript">
        var page = '<%=pageIndex %>';
        document.getElementById("gotoPage").value = page;
        updateSaleOrderIcon();
    </script>
</body>
</html>
