using SoftwareInstallationBusinessLogic.ViewModels;
using System.Collections.Generic;

namespace SoftwareInstallationBusinessLogic.HelperModels
{
    class ExcelPackageComponentsInfo
    {
        public string FileName { get; set; }
        public string Title { get; set; }
        public List<ReportPackageComponentViewModel> PackageComponents { get; set; }
    }
}