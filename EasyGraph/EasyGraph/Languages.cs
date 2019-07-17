using EasyGraph.Properties;
using Microsoft.Win32;
using System.Resources;
using System.Windows.Forms;
using System.Xml;

namespace EasyGraph
{
    public static class Languages
    {
        private static string ReadLanguage()
        {
            using (RegistryKey key = Registry.CurrentUser.CreateSubKey(Config.PathRegistry))
            {
                string language;
                if (key.GetValue("Language", null) != null)
                    language = key.GetValue("Language").ToString();
                else
                {
                    key.SetValue("Language", "English");
                    language = key.GetValue("Language").ToString();
                }
                return language;
            }
        }

        public static void SetLanguage(string language)
        {
            using (RegistryKey key = Registry.CurrentUser.CreateSubKey(Config.PathRegistry))
            {
                switch (language)
                {
                    case "Russian":
                        key.SetValue("Language", "Russian");
                        break;

                    case "English":
                        key.SetValue("Language", "English");
                        break;
                }
            }
        }

        public static void ParsingLanguage()
        {
            string lang = ReadLanguage();
            ResourceManager RM = new ResourceManager("EasyGraph.Properties.Resources", typeof(Resources).Assembly);

            XmlDocument xDoc = new XmlDocument();
            xDoc.LoadXml(RM.GetObject("languages").ToString());
            XmlElement xRoot = xDoc.DocumentElement;

            foreach (XmlNode xnode in xRoot)
            {
                if (xnode.Attributes.GetNamedItem("lang").Value != lang)
                    continue;
                foreach (XmlNode childnode in xnode.ChildNodes)
                {
                    switch (childnode.Name)
                    {
                        case "show_values":
                            Config.LanguageLocale.Add(childnode.InnerText);
                            break;

                        case "options":
                            Config.LanguageLocale.Add(childnode.InnerText);
                            break;

                        case "languageMenuStrip":
                            Config.LanguageLocale.Add(childnode.InnerText);
                            break;

                        case "donation":
                            Config.LanguageLocale.Add(childnode.InnerText);
                            break;

                        case "build":
                            Config.LanguageLocale.Add(childnode.InnerText);
                            break;

                        case "graph":
                            Config.LanguageLocale.Add(childnode.InnerText);
                            break;

                        case "legend":
                            Config.LanguageLocale.Add(childnode.InnerText);
                            break;

                        case "line":
                            Config.LanguageLocale.Add(childnode.InnerText);
                            break;

                        case "file":
                            Config.LanguageLocale.Add(childnode.InnerText);
                            break;

                        case "save_as":
                            Config.LanguageLocale.Add(childnode.InnerText);
                            break;
                    }
                }
            }
        }
    }
}
