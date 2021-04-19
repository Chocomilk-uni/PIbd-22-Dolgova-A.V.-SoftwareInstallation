using System;

namespace SoftwareInstallationBusinessLogic.ViewModels
{
    public class ReportOrdersForInfoViewModel
    {
        public DateTime Date { get; set; }
        public int Count { get; set; }
        public decimal Sum { get; set; }
    }
}