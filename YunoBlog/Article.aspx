<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Article.aspx.cs" Inherits="YunoBlog.Article" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="article">
        <div class="header">
            <div class="title"><a href="#"><%=article.Title %></a></div>
            <div class="info info1">
                <span class="time"><%=article.CreationTime.ToString("yyyy年MM月dd日 HH:mm") %></span>
            </div>
        </div>
        <div class="section entry">
            <%=article.Html %>
        </div>
    </div>
    <div id="cmt">
        <p>
            <div id="disqus_thread" style="padding: 15px 15px 15px 15px">
                <script type="text/javascript">
                    /* * * CONFIGURATION VARIABLES: EDIT BEFORE PASTING INTO YOUR WEBPAGE * * */
                    var disqus_shortname = '<%=YunoBlog.Config.Disqus%>'; // required: replace example with your forum shortname

                    /* * * DON'T EDIT BELOW THIS LINE * * */
                    (function () {
                        var dsq = document.createElement('script'); dsq.type = 'text/javascript'; dsq.async = true;
                        dsq.src = '//' + disqus_shortname + '.disqus.com/embed.js';
                        (document.getElementsByTagName('head')[0] || document.getElementsByTagName('body')[0]).appendChild(dsq);
                    })();
                </script>
            </div>
        </p>
    </div>
    <%=HighLight %>
</asp:Content>
