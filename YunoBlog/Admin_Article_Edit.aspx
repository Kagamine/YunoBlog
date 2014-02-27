<%@ Page Title="文章编辑" ValidateRequest="false" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Admin_Article_Edit.aspx.cs" Inherits="YunoBlog.Admin_Article_Edit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="article">
            <div class="header">
                <div class="title">文章编辑</div>
            </div>
            <div class="section entry">
                <p>标题</p>
                <p>
                    <asp:TextBox ID="txtTitle" runat="server" Width="400"></asp:TextBox><asp:Label ID="lbTitle" runat="server" Text=""></asp:Label>
                </p>
                <p>
                    <asp:TextBox ID="txtContent" runat="server" Width="100%" Height="500px" TextMode="MultiLine" ClientIDMode="Static"></asp:TextBox>
                </p>
                <p>文件上传：<asp:FileUpload ID="FileUpload1" runat="server" /> &nbsp;<asp:Button ID="btnUpload" runat="server" Text="上传" OnClick="btnUpload_Click" /></p>
                <p>
                    <asp:Button ID="BtnSubmit" class='more-link' runat="server" Text="提交" OnClick="BtnSubmit_Click" /> <a href="javascript:void(0)" id="btnPreview">预览</a> <asp:Label ID="lbInfo" runat="server" Text=""></asp:Label>
                </p>
                <div id="PreviewArea">

                </div>
            </div>
    </div>
    <script>
        $("#btnPreview").unbind().click(function () {
            $.post("Ajax/Articles.Preview.aspx", {
                Content: $("#txtContent").val()
            }, function (data) {
                $("#PreviewArea").html(data.replace("&lt;br /&gt;", "\r\n").replace("<br />", "\r\n"));
            });
        });
    </script>
</asp:Content>
