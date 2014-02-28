using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace YunoBlog
{
    public partial class Admin_Article_Delete : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Admin"] == null) Response.Redirect("Admin.aspx");
            if (Request.QueryString["sid"] == Session["Admin"].ToString())
            {
                if (Request.QueryString["src"] != null)
                    Dal.ArticleDao.Pop(new Entity.Article() { Title = Request.QueryString["src"] });
                else if (Request.QueryString["page"] != null)
                    Dal.ArticleDao.Pop(new Entity.Article() { Title = Request.QueryString["page"], IsPage = true });
            }
            if (Request.QueryString["src"] != null)
                Response.Redirect("Admin_Articles.aspx");
            if (Request.QueryString["page"] != null)
                Response.Redirect("Admin_Pages.aspx");
        }
    }
}