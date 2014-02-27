using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace YunoBlog
{
    public partial class Admin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Admin"] != null) Response.Redirect("Admin_Config.aspx");
        }
        private string RandomString(Random rand, int length)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < length; i++)
            {
                int ch = rand.Next(26 + 26 + 10);
                if (ch < 26) sb.Append((char)(ch + 'A'));
                else if (ch < 26 + 26) sb.Append((char)(ch - 26 + 'a'));
                else sb.Append((char)(ch - 26 - 26 + '0'));
            }
            return sb.ToString();
        }
        protected void BtnLogin_Click(object sender, EventArgs e)
        {
            if (TxtUsername.Text == Config.Username && TxtPassword.Text == Config.Password)
            {
                Session["Admin"] = RandomString(new Random(), 32);
                Response.Redirect("Admin_Config.aspx");
            }
        }
    }
}