<%@ Page Title="Home" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="YunoBlog.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script>
        $("#navHome").addClass("current_page_item");
        var page = 0;
        var lock = false;
        function LoadArticles() {
            if (lock) return;
            lock = true;
            $.post("Ajax/Articles.GetList.aspx", {
                Page: page
                <%=Request.QueryString["y"]!=null?",Year: "+Request.QueryString["y"]:""%>
                <%=Request.QueryString["m"]!=null?",Month: "+Request.QueryString["m"]:""%>
            }, function (data) {
                $("#main").append(data);
                page++;
                $(".article").unbind();
                blog.init();
                window.enable_autoHighlight = '#main>.article';
                lock = false;
            });
        }
        $(document).ready(function () {
            LoadArticles();
            $(window).scroll(function () {
                totalheight = parseFloat($(window).height()) + parseFloat($(window).scrollTop());
                if ($(document).height() <= totalheight) {
                    LoadArticles();
                }
            });
        });
    </script>
</asp:Content>
