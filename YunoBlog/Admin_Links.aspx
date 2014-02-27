<%@ Page Title="友情链接" ValidateRequest="false" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Admin_Links.aspx.cs" Inherits="YunoBlog.Admin_Links" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="article">
        <div class="header">
            <div class="title">友情链接管理</div>
        </div>
        <div class="section entry">
            <p>
                <asp:TextBox ID="txtLinks" runat="server" Width="100%" Height="500px" TextMode="MultiLine"></asp:TextBox>
            </p>
            <p>
                <asp:Button ID="BtnSubmit" class='more-link' runat="server" Text="修改" OnClick="BtnSubmit_Click" />
            </p>
        </div>
    </div>
</asp:Content>
