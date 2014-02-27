using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace YunoBlog
{
    public partial class Admin_Article_Edit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Admin"] == null) Response.Redirect("Admin.aspx");
            if (Request.QueryString["src"] == null)
            {
                lbTitle.Visible = false;
            }
            else
            {
                txtTitle.Visible = false;
                if (!IsPostBack)
                {
                    Entity.Article article = new Entity.Article() { Title = Request.QueryString["src"] };
                    txtContent.Text = article.MarkdownContent;
                }
            }
        }

        protected void BtnSubmit_Click(object sender, EventArgs e)
        {
            if (Request.QueryString["src"] == null)
            {
                var IsExisted = (from a in Dal.ArticleDao.Articles
                                 where a.Title == txtTitle.Text
                                 select a.Title).Count() == 0 ? false : true;
                if (IsExisted)
                {
                    lbInfo.Text = "文章标题已存在，请修改后尝试！";
                }
                else if (txtTitle.Text.Trim(' ') == "")
                {
                    lbInfo.Text = "文章标题不可为空！";
                }
                else
                {
                    Entity.Article article = new Entity.Article();
                    article.Title = txtTitle.Text;
                    article.MarkdownContent = txtContent.Text;
                    Dal.ArticleDao.Push(article);
                    Response.Redirect("Admin_Articles.aspx");
                }
            }
            else
            {
                Entity.Article article = new Entity.Article();
                article.Title = Request.QueryString["src"];
                article.MarkdownContent = txtContent.Text;
                article.Save();
                Dal.ArticleDao.Rebuild();
                Response.Redirect("Admin_Articles.aspx");
            }
        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            if (FileUpload1.HasFile)
            {
                string[] ImageExtension = { ".gif", ".jpg", ".jpeg", ".png", ".bmp" };
                var filename = DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss") + System.IO.Path.GetExtension(FileUpload1.FileName);
                System.IO.File.WriteAllBytes(System.Web.HttpContext.Current.Request.PhysicalApplicationPath + "\\Upload\\" + filename, FileUpload1.FileBytes);
                if (ImageExtension.Contains(System.IO.Path.GetExtension(FileUpload1.FileName).ToLower()))
                {
                    txtContent.Text += "\r\n![Picture](Upload\\" + filename + ")";
                }
                else
                {
                    txtContent.Text += "\r\n[" + FileUpload1.FileName + "](Upload\\" + filename + ")";
                }
            }

        }
    }
}