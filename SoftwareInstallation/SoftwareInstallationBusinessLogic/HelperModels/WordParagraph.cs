using System;
using System.Collections.Generic;
using System.Text;

namespace SoftwareInstallationBusinessLogic.HelperModels
{
    class WordParagraph
    {
        public List<(string, WordParagraphProperties)> Texts { get; set; }
        public WordParagraphProperties ParagraphProperties { get; set; }
    }
}