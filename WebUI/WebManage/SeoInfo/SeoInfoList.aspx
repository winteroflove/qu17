<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SeoInfoList.aspx.cs" Inherits="WebUI.WebManage.SeoInfo.SeoInfoList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>SEO信息列表</title>
    <link href="/WebManage/css/main.css" rel="stylesheet" type="text/css" />

    <script src="/WebManage/js/jquery.min.js" type="text/javascript"></script>

    <script src="/WebManage/js/common.js" type="text/javascript"></script>

    <script src="/WebManage/js/WebManage.js" type="text/javascript"></script>
</head>
<body>
    <h1>
        <span><b>SEO信息列表</b></span><a href="SeoInfoAdd.aspx">添加SEO信息</a>
    </h1>
    <form class="form-div" action="SeoInfoList.aspx" name="searchForm">
        <div class="search">
            目的地： 
            <select name="cid1" onchange="GetSmallClass(this)">
                <option value="">不限　　</option>
                <%=routeClassBig%>
            </select>　
            <select name="cid2" id="sltArea">
                <option value="">不限　　　　</option>
                <%=routeClassNext%>
            </select>
            <input value=" 搜索 " class="button" type="submit" />
        </div>
    </form>
    <table class="tableList">
        <thead>
            <tr>
                <th>
                    目的地
                </th>
                <th>
                    主题
                </th>
                <th>
                    天数
                </th>
                <th>
                    价格
                </th>
                <th>
                    更新时间
                </th>
                <th>
                    管理
                </th>
            </tr>
        </thead>
        <tbody>
            <%=dataSeoInfoList%>
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
    </script>
</body>
</html>
