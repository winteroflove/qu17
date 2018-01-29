<%@ Page Title="" Language="C#" MasterPageFile="~/vip.master" AutoEventWireup="true" CodeBehind="message.aspx.cs" Inherits="WebUI.vip.message" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h2>我的评论</h2>
    <table width="100%" class="vip martop8">
        <tr>
            <th>
                NO.
            </th>
            <th>
                线路名称
            </th>
            <th>
                评分
            </th>
            <th>
                评价内容
            </th>
            <th>
                状态
            </th>
            <th>
                评价日期
            </th>
        </tr>
        <%=dataList%>

    </table>
    
    <br />
        <%=pageInfo %>


</asp:Content>
