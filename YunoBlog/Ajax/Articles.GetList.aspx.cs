using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace YunoBlog.Ajax
{
    public partial class Articles_GetList : System.Web.UI.Page
    {
        public const string ArticleTemplate = "<div class='article'><div class='header'><div class='title'><a href='Article.aspx?src={Article_Title_Url}'>{Article_Title}</a></div><div class='info info1'><span class='time'>{Article_CreationTime}</span></div></div><div class='section entry'>{Article_Html}{Article_More}</div></div>";
        protected void Page_Load(object sender, EventArgs e)
        {
            var page = Convert.ToInt32(Request.Form["Page"]);
            List<Entity.Article> articles;
            if (Request.Form["Year"] == null || Request.Form["Month"] == null)
                articles = Dal.ArticleDao.Articles.Skip(page * 5).Take(5).ToList();
            else
                articles = (from a in Dal.ArticleDao.Articles
                            where a.CreationTime.Year == Convert.ToInt32(Request.Form["Year"])
                            && a.CreationTime.Month == Convert.ToInt32(Request.Form["Month"])
                            select a).Skip(page * 5).Take(5).ToList();
            foreach (var article in articles)
            {
                Response.Write(ArticleTemplate
                    .Replace("{Article_More}", article.Lines < 10 ? "" : "<p><a href='Article.aspx?src={Article_Title_Url}' class='more-link'>(更多&#8230;)</a></p>")
                    .Replace("{Article_Title}", article.Title)
                    .Replace("{Article_Title_Url}", HttpUtility.UrlEncode(article.Title))
                    .Replace("{Article_CreationTime}", article.CreationTime.ToString("yyyy年MM月dd日 HH:mm"))
                    .Replace("{Article_Html}", article.Summary));
            }
        }
    }
}