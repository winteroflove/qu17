<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NewsList.aspx.cs" Inherits="WebUI.WebManage.News.NewsList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>文章列表</title>
    <link href="/WebManage/css/main.css" rel="stylesheet" type="text/css" />

    <script src="/WebManage/js/jquery.min.js" type="text/javascript"></script>

    <script src="/WebManage/js/common.js" type="text/javascript"></script>

    <script src="/WebManage/js/WebManage.js" type="text/javascript"></script>

</head>
<body>
    <h1>
        <span><b>文章列表</b></span><a href="NewsAdd.aspx?cid=<%=newsClassIDs %>">添加文章</a>
    </h1>
    
    <form class="form-div" action="NewsList.aspx?cid=<%=newsClassIDs %>" name="searchForm">
        <div class="search">
        <% if (!newsClassIDs.Contains("8") && !newsClassIDs.Contains("9") && !newsClassIDs.Contains("10"))
            {%>
            线路类型： 
            <select name="cid1" onchange="GetSmallClass(this)">
                <option value="">不限　　</option>
                <%=routeClassBig%>
            </select>　
            <select name="cid2" id="sltArea">
                <option value="">不限　　　　</option>
                <%=routeClassNext%>
            </select>
            <%} %>
            关键字：
            <input size="15" class="text" name="key" value="<%=searchKey %>" />
            <input type="hidden" id="hidden_newsClassId" name="hidden_newsClassId" value="<%=newsClassIDs %>" />
            <input type="hidden" id="hidden_parentId" name="hidden_parentId" value="1" />
            <input type="hidden" id="cid" name="cid" value="<%=newsClassIDs %>" />
            <input value=" 搜索 " class="button" type="submit" />
            <input value="隐藏文章" class="button" type="button" onclick="hiddenNews()" />
            <input value="显示文章" class="button" type="button" onclick="displayNews()" />
            <input value="批量删除" class="button" type="button" onclick="deleteNews()" />
            <%if (newsClassIDs == "6")
              { %>
            <!--input value="批量缩图" class="button" type="button" onclick="updateNewsImg()" /-->
            <%} %>
            <%if (newsClassIDs != "6")
              { %>
            <!--input value="更新图片" class="button" type="button" onclick="setNewsImg('<%=newsClassIDs %>')" /-->
            <%} %>
        </div>
    </form>
    <table class="tableList">
        <thead>
            <tr>
                <th>
                    <input type='checkbox' name='checkall' onclick='selectAllNews(this)' />全选
                </th>
                <th style="width:30%">
                    标题
                </th>
                <th>
                    文章类型
                </th>
                <th>
                    所属区域
                </th>
                <th>
                    浏览量
                </th>
                <th>
                    是否显示
                </th>
                <th>
                    创建时间
                </th>
                <th>管理</th>
            </tr>
        </thead>
        <tbody>
            <%=dataNewsList%>
        </tbody>
        <tfoot>
            <tr>
                <td colspan="7">
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
