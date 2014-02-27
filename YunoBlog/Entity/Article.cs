using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;

namespace YunoBlog.Entity
{
    public class Article
    {
        public DateTime CreationTime
        {
            get
            {
                return File.GetCreationTime(Directory);
            }
        }
        private string title;
        public string Title
        {
            get
            {
                return title;
            }
            set
            {
                title = value;
                if (File.Exists(Directory))
                    MarkdownContent = File.ReadAllText(Directory);
            }
        }
        public string Directory
        {
            get
            {
                return System.Web.HttpContext.Current.Request.PhysicalApplicationPath + "\\Articles\\" + Title + ".md";
            }
        }
        public string MarkdownContent { get; set; }
        public void Save()
        {
            File.WriteAllText(this.Directory, MarkdownContent);
        }
        public string Html
        {
            get
            {
                Bll.Markdown md = new Bll.Markdown();
                return md.Transform(MarkdownContent);
            }
        }
        private string MarkdownSummary
        {
            get
            {
                var tmp = MarkdownContent.Replace("\r", "")
                    .Replace("\n\n\n\n", "\n")
                    .Replace("\n\n\n", "\n")
                    .Replace("\n\n", "\n");
                var lines = tmp.Split('\n');
                if (lines.Length < 10) return MarkdownContent;
                else
                {
                    string summary = "";
                    for (int i = 0; i < 10; i++)
                    {
                        summary += lines[i] + "\r\n\r\n";
                    }
                    return summary;
                }
            }
        }
        public int Lines
        {
            get
            {
                var tmp = MarkdownContent.Replace("\r", "")
                    .Replace("\n\n\n", "\n")
                    .Replace("\n\n", "\n");
                var lines = tmp.Split('\n');
                return lines.Length;
            }
        }
        public string Summary
        {
            get
            {
                Bll.Markdown md = new Bll.Markdown();
                return md.Transform(MarkdownSummary);
            }
        }
        public static bool Existed(string Title)
        {
            if (File.Exists(System.Web.HttpContext.Current.Request.PhysicalApplicationPath + "\\Articles\\" + Title + ".md"))
                return true;
            else 
                return false;
        }
    }
}