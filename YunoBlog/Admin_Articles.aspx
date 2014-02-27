﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Admin_Articles.aspx.cs" Inherits="YunoBlog.Admin_Articles" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="article">
        <div class="header">
            <div class="title">文章列表</div>
        </div>
        <div class="section entry">
            <p><a href="Admin_Article_Edit.aspx">新建文章</a></p>
            <table style="width:100%">
                <thead>
                    <tr>
                        <th>文章标题</th>
                        <th>创建时间</th>
                        <th>操作</th>
                    </tr>
                </thead>
                <tbody>
                    <%=ArticlesList %>
                </tbody>
            </table>
        </div>
    </div>
</asp:Content>
