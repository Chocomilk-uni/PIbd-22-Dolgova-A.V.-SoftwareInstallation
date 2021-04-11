using System;
using System.Collections.Generic;
using System.Text;

namespace SoftwareInstallationBusinessLogic.HelperModels
{
    class WordParagraph
    {
        public List<(string, WordTextProperties)> Texts { get; set; }
        public WordTextProperties ParagraphProperties { get; set; }
    }
}