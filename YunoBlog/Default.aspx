<%@ Page Title="Home" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="YunoBlog.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script>
        function date2str(x,y) { 
            var z ={y:x.getFullYear(),M:x.getMonth()+1,d:x.getDate(),h:x.getHours(),m:x.getMinutes(),s:x.getSeconds()};
            return y.replace(/(y+|M+|d+|h+|m+|s+)/g,function(v) {return ((v.length>1?"0":"")+eval('z.'+v.slice(-1))).slice(-(v.length>2?v.length:2))}); 
        } 
        $("#navHome").addClass("current_page_item");
        var page = 0;
        var lock = false;
        function LoadArticles() {
            if (lock) return;
            lock = true;
            $.getJSON("Ajax/Articles.GetList.aspx", {
                Page: page
                <%=Request.QueryString["y"]!=null?",Year: "+Request.QueryString["y"]:""%>
                <%=Request.QueryString["m"]!=null?",Month: "+Request.QueryString["m"]:""%>
            }, function (data) {
                for (var i in data)
                {
                    var article = "<div class='article'><div class='header'><div class='title'><a href='Article.aspx?src={Article_Title_Url}'>{Article_Title}</a></div><div class='info info1'><span class='time'>{Article_CreationTime}</span></div></div><div class='section entry'>{Article_Html}{Article_More}</div></div>"
                    .replace("{Article_Title_Url}", encodeURIComponent(data[i].Title))
                    .replace("{Article_Title}", data[i].Title)
                    .replace("{Article_CreationTime}", data[i].CreationTimeAsString)
                    .replace("{Article_Html}", data[i].Summary)
                    .replace("{Article_More}", data[i].Lines < 10 ? "" : "<p><a href='Article.aspx?src={Article_Title_Url}' class='more-link'>(更多&#8230;)</a></p>")
                    $("#main").append(article);
                }
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
