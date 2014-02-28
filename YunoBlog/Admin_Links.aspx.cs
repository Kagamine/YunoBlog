using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace YunoBlog
{
    public partial class Admin_Links : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Admin"] == null)
                Response.Redirect("/Admin.aspx");
            if (!IsPostBack)
                txtLinks.Text = System.IO.File.ReadAllText(System.Web.HttpContext.Current.Server.MapPath("~\\Scripts\\Links.js"));
        }

        protected void BtnSubmit_Click(object sender, EventArgs e)
        {
            System.IO.File.WriteAllText(System.Web.HttpContext.Current.Server.MapPath("~\\Scripts\\Links.js"), txtLinks.Text);
            Response.Redirect("/Admin_Links.aspx");
        }
    }
}