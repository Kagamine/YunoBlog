using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace YunoBlog
{
    public partial class Admin_Config : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Admin"] == null)
                Response.Redirect("/Admin.aspx");
            if (!IsPostBack)
            {
                TxtSiteName.Text = Config.SiteName;
                TxtDisqus.Text = Config.Disqus;
                TxtUsername.Text = Config.Username;
                TxtPassword.Text = Config.Password;
            }
        }

        protected void BtnSubmit_Click(object sender, EventArgs e)
        {
            Config.SiteName = TxtSiteName.Text;
            Config.Disqus = TxtDisqus.Text;
            Config.Username = TxtUsername.Text;
            if (TxtPassword.Text != String.Empty)
                Config.Password = TxtPassword.Text;
        }

        protected void BtnRefreshCache_Click(object sender, EventArgs e)
        {
            Dal.ArticleDao.Rebuild();
            YunoBlog.Site.Category = null;
        }
    }
}