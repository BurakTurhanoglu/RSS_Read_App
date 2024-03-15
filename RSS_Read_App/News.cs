using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSS_Read_App
{
    internal class News
    {
        public string Headline { get; set; }
        public string Link { get; set; }
        public string Phrase { get; set; }

        // The overriding process was done because when the listbox gathers the data, it returns the namespace rather than the headline, so ToString() method was overrided so it returns the Headline of the news.
        public override string ToString()
        {
            return Headline;
        }
    }
}
