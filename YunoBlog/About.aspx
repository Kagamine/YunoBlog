<%@ Page Title="关于我" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="YunoBlog.About" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="article">
            <div class="header">
                <div class="title">关于我</div>
            </div>
            <div class="section entry">
                <p>Gasai Yuno 亦为 がさいゆの 是《未来日记》里面的女主角，我觉得我的个性和她略微类似，于是取名Gasai Yuno。</p>
                <p>学生，软件工程专业，倾向C#.Net、VC.MFC、Windows SDK。略反感java(因为运行它的虚拟机会导致我的电脑发热瞬间增大)。</p>
                <p>目前从事ASP.Net WebForm应用开发、Windows Phone SDK手机应用程序、基于WPF的UI开发、WCF网络通信框架、Entity Framework等。（概括来说基本上都是M$的东西）并且正在研究集群分布式算法、云计算方向的技术。</p>
                <p>规划在近一年内，学习UML与软件建模、X-Code(Cocoa)、Linux、Nodejs、Less样式表等。</p>
                <p><b>Contact:</b></p>
                <p>QQ: 18045054321 / 911574351</p>
                <p>Email: 1#4321.io</p>
            </div>
    </div>
    <script>
        $("#navAbout").addClass("current_page_item");
    </script>
</asp:Content>
