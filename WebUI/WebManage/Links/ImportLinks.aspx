<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ImportLinks.aspx.cs" Inherits="WebUI.WebManage.Links.ImportLinks" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>批量导入链接</title>
    <link href="/WebManage/css/main.css" rel="stylesheet" type="text/css" />

    <script src="/WebManage/js/jquery.min.js" type="text/javascript"></script>

    <script src="/WebManage/js/common.js" type="text/javascript"></script>

    <script src="/WebManage/js/WebManage.js" type="text/javascript"></script>
</head>
<body>
    <h1>
        <span><b>批量导入链接</b></span><a href="LinksList.aspx">友情链接列表</a>
    </h1>
    <form class="form-div" action="ImportLinks.aspx?ac=add" name="searchForm" enctype="multipart/form-data" method="post">
        <div class="search">
            链接文件：
            <input type="file" name="linkFile" />
            <input value=" 上传 " class="button" type="submit" />
            仅支持.txt文件，格式为:链接词^链接url^目的地ID，每行一个链接！
        </div>
    </form>
</body>
</html>
