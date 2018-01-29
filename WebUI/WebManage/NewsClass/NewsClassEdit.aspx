<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NewsClassEdit.aspx.cs" Inherits="WebUI.WebManage.NewsClass.NewsClassEdit"
    ValidateRequest="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>添加新闻类型</title>
    <link href="/WebManage/css/main.css" rel="stylesheet" type="text/css" />

    <script src="/WebManage/js/jquery.min.js" type="text/javascript"></script>

    <script src="/WebManage/js/common.js" type="text/javascript"></script>

    <script src="/WebManage/js/WebManage.js" type="text/javascript"></script>
  
</head>
<body>
    <h1>
        <span><b>编辑新闻类型</b></span><a href="NewsClassList.aspx">新闻类型列表</a>
    </h1>
    <form class="form-div" action="NewsClassEdit.aspx?ac=edit" 
    method="post" onsubmit="return formNews(this)">
    <table width="100%" class="tableAdd">
        <colgroup>
            <col width="100" class="label" />
            <col />
        </colgroup>
        <tr>
            <td align="right">
                新闻类型：<span>*</span>
            </td>
            <td>
                <input type="text" name="ClassName" value="<%=className %>" size="60" />
            </td>
        </tr>
        
        <tfoot>
            <tr>
                <td colspan="2" align="center">
                    <input class="btn" type="submit" value="确定提交" />
                    <input type="button" class="btn2" value="返回" onclick="history.back(-1)" />
                    <input type="hidden" name="ID" value="<%=newsClassId %>" />
                </td>
            </tr>
        </tfoot>
    </table>
    </form>
</body>
</html>
