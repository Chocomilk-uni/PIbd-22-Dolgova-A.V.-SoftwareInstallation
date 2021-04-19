using SoftwareInstallationBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;

namespace SoftwareInstallationBusinessLogic.HelperModels
{
    class PdfOrdersByDatesInfo
    {
        public string FileName { get; set; }
        public string Title { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public List<ReportOrdersByDatesViewModel> Orders { get; set; }
    }
}