using SoftwareInstallationBusinessLogic.ViewModels;
using System.Collections.Generic;

namespace SoftwareInstallationBusinessLogic.HelperModels
{
    class PdfAllOrdersInfo
    {
        public string FileName { get; set; }
        public string Title { get; set; }
        public List<ReportOrdersForInfoViewModel> Orders { get; set; }
    }
}