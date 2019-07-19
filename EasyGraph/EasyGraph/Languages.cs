using EasyGraph.Properties;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Resources;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace EasyGraph
{
    public static class Languages
    {

        async public static void SetLanguage(string language, string PathRegistry)
        {
            await Task.Run(() =>
            {
                using (RegistryKey key = Registry.CurrentUser.CreateSubKey(PathRegistry))
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

        public static List<string> GetLanguage(Form1 form1, string PathRegistry)
        {
            List<string> LanguageLocale = new List<string>();
            string lang = ReadLanguage(PathRegistry);
            ResourceManager RM = new ResourceManager("EasyGraph.Properties.Resources", typeof(Resources).Assembly);

            XmlDocument xDoc = new XmlDocument();
            xDoc.LoadXml(RM.GetObject("languages").ToString());
            XmlElement xRoot = xDoc.DocumentElement;

            foreach (XmlNode xnode in xRoot)
            {
                if (xnode.Attributes.GetNamedItem("lang").Value != lang)
                    continue;
                foreach (XmlNode childnode in xnode.ChildNodes)
                    LanguageLocale.Add(childnode.InnerText);
            }
            SetNames(form1, LanguageLocale);
            return LanguageLocale;
        }

        private static string ReadLanguage(string PathRegistry)
        {
            using (RegistryKey key = Registry.CurrentUser.CreateSubKey(PathRegistry))
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

        private static void SetNames(Form1 form1, List<string> LanguageLocale)
        {
            form1.showValues.Text = LanguageLocale[0];
            form1.Options.Text = LanguageLocale[1];
            form1.Language.Text = LanguageLocale[2];
            form1.Donation.Text = LanguageLocale[3];
            form1.Build.Text = LanguageLocale[4];
            form1.File.Text = LanguageLocale[8];
            form1.SaveAs.Text = LanguageLocale[9];
            form1.PageChart.Text = LanguageLocale[10];
            form1.PageEdit.Text = LanguageLocale[11];
            form1.PageOuput.Text = LanguageLocale[12];
            form1.NameLine.Text = LanguageLocale[13];
            form1.ColorLine.Text = LanguageLocale[14];
            form1.NamePoint.Text = LanguageLocale[15];
            form1.ColorPoint.Text = LanguageLocale[16];

            form1.NameLineBox.Location = new Point(form1.NameLine.Location.X + form1.NameLine.Width + 3,
                form1.NameLine.Location.Y);
            form1.ColorLineBox.Location = new Point(form1.ColorLine.Location.X + form1.ColorLine.Width + 3,
                form1.ColorLine.Location.Y);

            form1.NamePointBox.Location = new Point(form1.NamePoint.Location.X + form1.NamePoint.Width + 3,
                form1.NamePoint.Location.Y);
            form1.ColorPointBox.Location = new Point(form1.ColorPoint.Location.X + form1.ColorPoint.Width + 3,
                form1.ColorPoint.Location.Y);

            if (LanguageLocale[0] == "Show values")
            {
                form1.LanguageRussian.Checked = false;
                form1.LanguageEnglish.Checked = true;
            }
            else
            {
                form1.LanguageRussian.Checked = true;
                form1.LanguageEnglish.Checked = false;
            }
        }
    }
}
