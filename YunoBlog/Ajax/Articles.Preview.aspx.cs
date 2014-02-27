using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace YunoBlog.Ajax
{
    public partial class Articles_Preview : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Bll.Markdown md = new Bll.Markdown();
            Response.Write(md.Transform(Request.Form["Content"].ToString()));
        }
    }
}