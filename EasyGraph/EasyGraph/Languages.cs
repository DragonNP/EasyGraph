using EasyGraph.Properties;
using Microsoft.Win32;
using System;
using System.Resources;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace EasyGraph
{
    public static class Languages
    {

        async public static void SetLanguage(string language)
        {
            await Task.Run(() =>
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
            });
            Application.Restart();
            Environment.Exit(0);
        }

        public static void SetLanguage()
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
                    Config.LanguageLocale.Add(childnode.InnerText);
            }
        }

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
    }
}
