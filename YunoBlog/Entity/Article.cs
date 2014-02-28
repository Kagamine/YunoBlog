using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Web.Script.Serialization;

namespace YunoBlog.Entity
{
    public class Article
    {
        [ScriptIgnore]
        public DateTime CreationTime
        {
            get
            {
                return File.GetCreationTime(Directory);
            }
        }

        [ScriptIgnore]
        public bool IsPage { get; set; }

        public string CreationTimeAsString
        {
            get { return CreationTime.ToString("yyyy年MM月dd日 HH:mm"); }
        }

        [ScriptIgnore]
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

        [ScriptIgnore]
        public string Directory
        {
            get
            {
                if (IsPage)
                    return System.Web.HttpContext.Current.Request.PhysicalApplicationPath + "\\Pages\\" + Title + ".md";
                else
                    return System.Web.HttpContext.Current.Request.PhysicalApplicationPath + "\\Articles\\" + Title + ".md";
            }
        }

        [ScriptIgnore]
        public string MarkdownContent { get; set; }
        public void Save()
        {
            File.WriteAllText(this.Directory, MarkdownContent);
        }

        [ScriptIgnore]
        public string Html
        {
            get
            {
                Bll.Markdown md = new Bll.Markdown();
                return md.Transform(MarkdownContent);
            }
        }

        [ScriptIgnore]
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