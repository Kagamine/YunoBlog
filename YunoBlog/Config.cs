using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;

namespace YunoBlog
{
    public static class Config
    {
        private static string sitename;
        public static string SiteName
        {
            get
            {
                if (sitename == null)
                    sitename = GetAppKey("SiteName");
                return sitename;
            }
            set
            {
                SetAppKey("SiteName", value);
                sitename = value;
            }
        }

        private static string disqus;
        public static string Disqus
        {
            get
            {
                if (disqus == null)
                    disqus = GetAppKey("Disqus");
                return disqus;
            }
            set
            {
                SetAppKey("Disqus", value);
                disqus = value;
            }
        }

        private static string username;
        public static string Username
        {
            get
            {
                if (username == null)
                    username = GetAppKey("Username");
                return username;
            }
            set
            {
                SetAppKey("Username", value);
                username = value;
            }
        }

        private static string password;
        public static string Password
        {
            get
            {
                if (password == null)
                    password = GetAppKey("Password");
                return password;
            }
            set
            {
                SetAppKey("Password", value);
                password = value;
            }
        }

        private static void SetAppKey(string KeyName, string Value)
        {
            XmlTextReader reader = new XmlTextReader(System.Web.HttpContext.Current.Server.MapPath("~\\YunoBlog.config"));
            XmlDocument doc = new XmlDocument();
            doc.Load(reader);
            reader.Close();
            reader = null;
            foreach (XmlNode node in doc.DocumentElement.ChildNodes)
            {
                if (node.Attributes["key"].Value == KeyName)
                    node.Attributes["value"].Value = Value;
            }
            doc.Save(System.Web.HttpContext.Current.Server.MapPath("~\\YunoBlog.config"));
            doc.RemoveAll();
            doc = null;
        }
        private static string GetAppKey(string KeyName)
        {
            string value = "";
            XmlTextReader reader = new XmlTextReader(System.Web.HttpContext.Current.Server.MapPath("~\\YunoBlog.config"));
            XmlDocument doc = new XmlDocument();
            doc.Load(reader);
            reader.Close();
            reader = null;
            foreach (XmlNode node in doc.DocumentElement.ChildNodes)
            {
                if (node.Attributes["key"].Value == KeyName)
                {
                    value = node.Attributes["value"].Value;
                    doc.RemoveAll();
                    doc = null;
                    break;
                }
            }
            return value;
        }
    }
}