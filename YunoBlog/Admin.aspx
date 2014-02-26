<%@ Page Title="登录" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Admin.aspx.cs" Inherits="YunoBlog.Admin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="article">
        <div class="header">
            <div class="title">登录</div>
        </div>
        <div class="section entry">
            <p>用户名</p>
            <p>
                <asp:TextBox ID="TxtUsername" runat="server"></asp:TextBox>
            </p>
            <p>密码</p>
            <p>
                <asp:TextBox ID="TxtPassword" runat="server" TextMode="Password"></asp:TextBox>
            </p>
            <p>
                <asp:Button ID="BtnLogin" class='more-link' runat="server" Text="登录" OnClick="BtnLogin_Click" />
            </p>
        </div>
    </div>
</asp:Content>
