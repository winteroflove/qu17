<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RouteList.aspx.cs" Inherits="WebUI.WebManage.Routes.RouteList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>路线列表</title>
    <link href="/WebManage/css/main.css" rel="stylesheet" type="text/css" />

    <script src="/WebManage/js/jquery.min.js" type="text/javascript"></script>

    <script src="/WebManage/js/common.js" type="text/javascript"></script>

    <script src="/WebManage/js/WebManage.js" type="text/javascript"></script>

</head>
<body>
    <h1>
        <span><b>路线列表</b></span><a href="RouteAdd.aspx">添加路线</a>
    </h1>
    <form class="form-div" action="RouteList.aspx" name="searchForm">
        <div class="search">
            线路类型： 
            <select name="cid1" onchange="GetSmallClass(this)">
                <option value="">不限　　</option>
                <%=routeClassBig%>
            </select>　
            <select name="cid2" id="sltArea">
                <option value="">不限　　　　</option>
                <%=routeClassNext%>
            </select>　
            地接社：
            <input size="10" class="text" name="skey" value="<%=supKey %>" />
            线路关键字：
            <input size="10" class="text" name="key" value="<%=searchKey %>" />
            <input type="hidden" name="rorder" id="rorder" value="<%=routeorder %>" />
            <input type="hidden" name="torder" id="torder" value="<%=timeorder %>" />
            <input value=" 搜索 " class="button" type="submit" onclick="SubmitRoute()" />
            <input value="隐藏线路" class="button" type="button" onclick="hiddenRoutes()" />
            <input value="显示线路" class="button" type="button" onclick="displayRoutes()" />
            <input value="批量缩图" class="button" type="button" onclick="updateRouteImg()" />
        </div>
    </form>
    <table class="tableList">
        <thead>
            <tr>
                <th>
                    <input type='checkbox' name='checkall' onclick='selectAllRoute(this)' />全选
                </th>
                <th>
                    线路名称
                </th>
                <th>
                    线路地区
                </th>
                <th>
                    地接信息
                </th>
                <th>
                    线路价格
                </th>
                <th>
                    线路排序<i class="rorder"></i>
                </th>
                <th>
                    推荐线路
                </th>
                <th>
                    是否显示
                </th>
                <th>
                    点击量
                </th>
                <th>
                    上传时间
                </th>
                <th>
                    更新时间<i class="torder"></i>
                </th>
                <th>
                    管理
                </th>
            </tr>
        </thead>
        <tbody>
            <%=dataRouteList%>
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
        updateOrderIcon();
    </script>
</body>
</html>
