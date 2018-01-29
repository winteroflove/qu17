<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdvertiseEdit.aspx.cs" Inherits="WebUI.WebManage.Advertise.AdvertiseEdit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
    <title>修改广告</title>
     <link href="/WebManage/css/main.css" rel="stylesheet" type="text/css" />
    <script src="/WebManage/js/jquery.min.js" type="text/javascript"></script>

    <script src="/WebManage/js/common.js" type="text/javascript"></script>

    <script src="/WebManage/js/WebManage.js" type="text/javascript"></script>
</head>
<body>
    <h1><a href="AdvertiseList.aspx">广告列表</a><span><b>修改广告</b></span></h1>
    <div id="tabbody-div">
        <form method="post" action="AdvertiseEdit.aspx?ac=edit" enctype="multipart/form-data" onsubmit="return ckFormAdvertiseAdd(this,true)">
            <table class="tableAdd" width="100%">
            <colgroup>
                    <col width="100" class="label" />
                    <col />
            </colgroup>
            <tbody>
                <tr>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>广告位置<span>*</span></td>
                    <td>
                        <select name="position" id="position" onchange="updateAdSize(this)">
                            <%=dataPositionList %>
                        </select>
                    </td>
                </tr>
                <tr>
                    <td>广告标题</td>
                    <td>
                        <input type="text" name="Title" class="w300" value="<%=model.Title %>" maxlength="50" />
                    </td>
                </tr>
                <tr>
                    <td>广告图片<span>*</span></td>
                    <td>
                        <input type="file" class="w300" name="Img" onchange="CheckFile(this,'.jpg|.gif|.png|.swf')" />
                        <br /><br />
                        <p class="hui">(支持.JPG、.PNG、.GIF、.SWF格式；图片大小<span id="adsize"><%=size%></span>)</p>
                        <%if (model.Img.LastIndexOf(".swf") > -1) { %>
                         <script type="text/javascript">swfobject("<%=ClassLibrary.Common.SysConfig.UploadFilePathAdImg + model.Img %>");</script>
                        <%}else{ %>
                        <img src="<%=ClassLibrary.Common.SysConfig.UploadFilePathAdImg + model.Img %>" width="300" />
                        <%} %>
                        <input type="hidden" name="imgSize" id="imgSize" value="<%=size%>" />
                    </td>
                </tr>
                <tr>
                    <td>链接地址</td>
                    <td>
                        <input type="text" name="LinkURL" size="100" value="<%=model.LinkURL %>" maxlength="250" />
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td>　
                        <input value=" 确定 " type="submit" class="btn2" />　
                        <input value=" 返回 " type="button" onclick="history.back()" class="btn2" />
                        <input type="hidden" name="oldImg" value="<%=model.Img %>" />
                        <input type="hidden" name="ID" value="<%=model.ID %>" />
                    </td>
                </tr>
            </tbody>
        </table>
        </form>
    </div>
    
</body>
</html>