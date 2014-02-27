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
        public Entity.Article article = new Entity.Article();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["src"] == null)
            {
                Response.Redirect("Default.aspx");
            }
            else
            {
                article.Title = Request.QueryString["src"];
                Page.Title = article.Title;
            }
        }
    }
}