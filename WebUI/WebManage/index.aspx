<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="WebUI.Manager.index" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>网站后台管理</title>
</head>
<frameset rows="115,*" framespacing="0" border="0" id="frame1">
  <frame src="banner.aspx" id="banner-frame" name="banner-frame" frameborder="no" scrolling="no"></frame>
  <frameset cols="212, 9, *" framespacing="0" border="0" id="frame2">
    <frame src="menu.aspx" id="menu-frame" name="menu-frame" frameborder="no" scrolling="yes"></frame>
    <frame src="scroll.aspx" id="scroll-frame" name="scroll-frame" frameborder="no" scrolling="no"></frame>
    <frame src="main.aspx" id="main-frame" name="main-frame" frameborder="no" scrolling="yes"></frame>
  </frameset>
</frameset><noframes></noframes>
</html>
