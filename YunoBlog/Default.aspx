<%@ Page Title="Home" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="YunoBlog.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script>
        $("#navHome").addClass("current_page_item");
        var page = 0;
        var ArticleList = true;
        var year = <%=Request.QueryString["y"]==null?"0":Request.QueryString["y"]%>;
        var month = <%=Request.QueryString["m"]==null?"0":Request.QueryString["m"]%>;
    </script>
</asp:Content>
