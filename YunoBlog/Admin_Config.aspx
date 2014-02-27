<%@ Page Title="站点信息" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Admin_Config.aspx.cs" Inherits="YunoBlog.Admin_Config" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="article">
        <div class="header">
            <div class="title">站点信息</div>
        </div>
        <div class="section entry">
            <p>站点名称</p>
            <p>
                <asp:TextBox ID="TxtSiteName" runat="server" Width="380px"></asp:TextBox>
            </p>
            <p>Disqus帐号</p>
            <p>
                <asp:TextBox ID="TxtDisqus" runat="server" Width="380px"></asp:TextBox>
            </p>
            <p>管理员用户名</p>
            <p>
                <asp:TextBox ID="TxtUsername" runat="server" Width="380px"></asp:TextBox>
            </p>
            <p>管理员密码</p>
            <p>
                <asp:TextBox ID="TxtPassword" TextMode="Password" runat="server" Width="380px"></asp:TextBox>
            </p>
            <p>
                <asp:Button ID="BtnSubmit" class='more-link' runat="server" Text="修改" OnClick="BtnSubmit_Click" />
            </p>
        </div>
    </div>
    <div class="article">
        <div class="header">
            <div class="title">工具</div>
        </div>
        <div class="section entry">
            <p>
                <asp:Button ID="BtnRefreshCache" class='more-link' runat="server" Text="更新缓存" OnClick="BtnRefreshCache_Click" />
            </p>
        </div>
    </div>
</asp:Content>
