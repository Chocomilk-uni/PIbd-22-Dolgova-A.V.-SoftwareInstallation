using SoftwareInstallationBusinessLogic.ViewModels;
using System.Collections.Generic;

namespace SoftwareInstallationBusinessLogic.HelperModels
{
    class WordPackagesInfo
    {
        public string FileName { get; set; }
        public string Title { get; set; }
        public List<PackageViewModel> Packages { get; set; }
    }
}