using SoftwareInstallationBusinessLogic.ViewModels;
using System.Collections.Generic;

namespace SoftwareInstallationBusinessLogic.HelperModels
{
    class ExcelInfo
    {
        public string FileName { get; set; }
        public string Title { get; set; }
        public List<ReportPackageComponentViewModel> PackageComponents { get; set; }
    }
}