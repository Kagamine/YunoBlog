using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace YunoBlog.Dal
{
    public static class ArticleDao
    {
        public static List<Entity.Article> Articles = new List<Entity.Article>();
        public static List<Entity.Article> Pages = new List<Entity.Article>(); 
        public static DateTime Begin, End;
        public static void Push(Entity.Article article)
        {
            article.Save();
            if (article.IsPage)
            {
                Pages.Add(article);
                Pages.Sort((a, b) => { return DateTime.Compare(b.CreationTime, a.CreationTime); });
            }
            else
            {
                Articles.Add(article);
                Articles.Sort((a, b) => { return DateTime.Compare(b.CreationTime, a.CreationTime); });
            }
            Dal.ArticleDao.Rebuild();
            try
            {
                Site.Category = null;
                Begin = Articles[Articles.Count() - 1].CreationTime;
                End = Articles[0].CreationTime;
            }
            catch { }
        }
        public static void Pop(Entity.Article article)
        {
            System.IO.File.Delete(article.Directory);
            Articles.RemoveAt(Articles.FindIndex(x => x.Title == article.Title));
            try
            {
                Site.Category = null;
                Begin = Articles[Articles.Count() - 1].CreationTime;
                End = Articles[0].CreationTime;
            }
            catch { }
        }
        public static void Rebuild()
        {
            RebuildArticles();
            RebuildPages();
        }
        public static void RebuildPages()
        {
            Pages.Clear();
            var files = System.IO.Directory.GetFiles(System.Web.HttpContext.Current.Server.MapPath("~") + "\\Pages", "*.md");
            foreach (var file in files)
            {
                var article = new Entity.Article();
                article.Title = System.IO.Path.GetFileNameWithoutExtension(file);
                article.IsPage = true;
                Pages.Add(article);
            }
            Pages.Sort((a, b) => { return DateTime.Compare(b.CreationTime, a.CreationTime); });
        }
        public static void RebuildArticles()
        {
            Articles.Clear();
            var files = System.IO.Directory.GetFiles(System.Web.HttpContext.Current.Server.MapPath("~") + "\\Articles", "*.md");
            foreach (var file in files)
            {
                var article = new Entity.Article();
                article.Title = System.IO.Path.GetFileNameWithoutExtension(file);
                Articles.Add(article);
            }
            Articles.Sort((a, b) => { return DateTime.Compare(b.CreationTime, a.CreationTime); });
            try
            {
                Begin = Articles[Articles.Count() - 1].CreationTime;
                End = Articles[0].CreationTime;
            }
            catch { }
        }
    }
}