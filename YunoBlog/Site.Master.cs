using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace YunoBlog
{
    public partial class Site : System.Web.UI.MasterPage
    {
        public static string Category = null;
        public string AdminNav = "<li><a href='Admin.aspx'>登录</a></li>", NavList = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Title += " - " + Config.SiteName;
            if (Category == null || Category==String.Empty)
            {
                Category = "";
                if (Dal.ArticleDao.Articles.Count() > 0)
                {
                    for (DateTime i = new DateTime(Dal.ArticleDao.End.Year, Dal.ArticleDao.End.Month, 1); i.Date >= new DateTime(Dal.ArticleDao.Begin.Year, Dal.ArticleDao.Begin.Month, 1); i = i.AddMonths(-1))
                    {
                        Category += String.Format("<li class='cat-item'><a href='Default.aspx?y={0}&m={1}'>{2}</a> ({3})</li>",
                            i.Year,
                            i.Month,
                            i.ToString("yyyy年MM月"),
                            (from a in Dal.ArticleDao.Articles
                             let t = a.CreationTime
                             where t.Year == i.Year
                             && t.Month == i.Month
                             select a.Title).Count());
                    }
                }
            }
            if (Session["Admin"] != null)
            {
                AdminNav = "";
                AdminNav += "<li><a href='Admin_Config.aspx'>站点设置</a></li>";
                AdminNav += "<li><a href='Admin_Articles.aspx'>文章管理</a></li>";
                AdminNav += "<li><a href='Admin_Pages.aspx'>页面管理</a></li>";
                AdminNav += "<li><a href='Admin_Links.aspx'>链接管理</a></li>";
                AdminNav += "<li><a href='Admin_Logout.aspx?sid=" + Session["Admin"] + "'>注销</a></li>";
            }
            foreach (var p in Dal.ArticleDao.Pages)
            {
                NavList += String.Format("<li id='Page_{0}'><a href='/Article.aspx?page={1}'>{2}</a></li>",
                    Dal.ArticleDao.Pages.FindIndex(x => x.Title == p.Title),
                    HttpUtility.UrlEncode(p.Title),
                    p.Title);
            }
        }
    }
}