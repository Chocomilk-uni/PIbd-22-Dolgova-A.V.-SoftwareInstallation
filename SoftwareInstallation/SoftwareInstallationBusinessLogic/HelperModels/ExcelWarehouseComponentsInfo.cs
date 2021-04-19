using SoftwareInstallationBusinessLogic.ViewModels;
using System.Collections.Generic;

namespace SoftwareInstallationBusinessLogic.HelperModels
{
    class ExcelWarehouseComponentsInfo
    {
        public string FileName { get; set; }
        public string Title { get; set; }
        public List<ReportWarehouseComponentViewModel> WarehouseComponents { get; set; }
    }
}