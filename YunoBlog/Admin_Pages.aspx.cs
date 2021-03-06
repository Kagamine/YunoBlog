﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace YunoBlog
{
    public partial class Admin_Pages : System.Web.UI.Page
    {
        public string ArticlesList = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Admin"] == null)
                Response.Redirect("/Admin.aspx");
            foreach (var a in Dal.ArticleDao.Pages)
            {
                ArticlesList += String.Format("<tr><td><a href='Article.aspx?page={Article_Title_Url}'>{Article_Title}</a></td><td>{Article_CreationTime}</td><td><a href='Admin_Article_Edit.aspx?IsPage=true&src={Article_Title_Url}'>编辑</a>  <a href='Admin_Article_Delete.aspx?sid={Session_ID}&page={Article_Title_Url}'>删除</a></td></tr>"
                    .Replace("{Article_Title}", a.Title)
                    .Replace("{Article_Title_Url}", HttpUtility.UrlEncode(a.Title))
                    .Replace("{Article_CreationTime}", a.CreationTime.ToString())
                    .Replace("{Session_ID}", Session["Admin"].ToString()));
            }
        }
    }
}