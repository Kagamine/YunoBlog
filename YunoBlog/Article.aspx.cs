using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace YunoBlog
{
    public partial class Article : System.Web.UI.Page
    {
        protected string HighLight = "";
        public Entity.Article article = new Entity.Article();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["src"] != null)
            {
                article.Title = Request.QueryString["src"];
                Page.Title = article.Title;
            }
            else if (Request.QueryString["page"] != null)
            {
                article.IsPage = true;
                article.Title = Request.QueryString["page"];
                Page.Title = article.Title;
                HighLight = String.Format("<script>$(\"#Page_{0}\").addClass(\"current_page_item\");</script>",
                    Dal.ArticleDao.Pages.FindIndex(x => x.Title == article.Title));
            }
            else Response.Redirect("Default.aspx");
        }
    }
}