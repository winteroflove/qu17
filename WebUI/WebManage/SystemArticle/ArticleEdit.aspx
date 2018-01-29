<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ArticleEdit.aspx.cs" Inherits="WebUI.SystemArticle.ArticleEdit" ValidateRequest="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="/WebManage/css/main.css" rel="stylesheet" type="text/css" />

    <script src="/WebManage/js/jquery.min.js" type="text/javascript"></script>

    <script src="/WebManage/js/common.js" type="text/javascript"></script>

    <script src="/WebManage/js/WebManage.js" type="text/javascript"></script>

    <script type="text/javascript" src="/WebManage/kindsoft/kindeditor.js"></script>

    <script type="text/javascript">
        KindEditor.ready(function(K) {
            K.create('#Content', {
                uploadJson: '/WebManage/kindsoft/upload_json.ashx',
                fileManagerJson: '/WebManage/kindsoft/file_manager_json.ashx',
                allowFileManager: true
            });
        });
    </script>

</head>
<body>
    <h1>
        <span><b>系统文章管理</b></span>
    </h1>
    <form class="form-div" action="articleEdit.aspx?ac=edit" method="post">
    <table width="100%" class="tableAdd">
        <colgroup>
            <col width="120" class="label" />
            <col />
        </colgroup>
        <tr>
            <td align="right">　   
                <%=dataTitle%>：
            </td>
            <td>
                <textarea id="Content" name="Content" cols="1" rows="1" style="width: 700px; height: 300px; visibility: hidden;"><%=dataContent %></textarea>
            </td>
        </tr>
        <tfoot>
            <tr>
                <td colspan="2" align="center">
                    <input class="btn" type="submit" value="保存" />
                    <input type="hidden" name="ID" value="<%=articleID %>" />
                    <input type="hidden" name="Title" value="<%=dataTitle %>" />
                </td>
            </tr>
        </tfoot>
    </table>
    </form>
</body>
</html>
