using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace YunoBlog
{
    public partial class Admin_Logout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Admin"] == null) Response.Redirect("Admin.aspx");
            if (Request.QueryString["sid"] == Session["Admin"].ToString())
                Session.Clear();
            Response.Redirect("Default.aspx");
        }
    }
}