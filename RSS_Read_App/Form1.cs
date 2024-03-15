using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace RSS_Read_App
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            List<News> Records = XMLConvert(); // The list was captured on List Generic called "Records." It's type is "News."
            lst_title.DataSource = Records;
        }
        private List<News> XMLConvert()
        {
            List<News> NewsRecord = new List<News>();

            // Reads the XML file from the TextBox.
            XDocument XMLSource = XDocument.Load(txt_rssurl.Text);


            // Gets the item object because it is the parent node.
            List<XElement> Rows = XMLSource.Descendants("item").ToList();
            foreach (XElement item in Rows)
            {
                News Temp = new News();
                Temp.Headline = item.Element("title").Value;
                Temp.Link = item.Element("link").Value;
                Temp.Phrase = item.Element("description").Value;
                NewsRecord.Add(Temp);
                // Pretty self-explanatory, gets the headline, link, and the phrase itself on the XML file and fills the list with it.
            }
            return NewsRecord; // The list was filled with the records, it now returns the NewsRecord list because the method was linked as a list generic, thus enabling to capture the list.
        }

        private void lst_title_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListBox SelectedAttribute = (ListBox)sender;
            News selectedNews = (News)SelectedAttribute.SelectedItem;
            web_browser.DocumentText = selectedNews.Phrase;
        }
    }
}
