using System;

namespace SoftwareInstallationBusinessLogic.ViewModels
{
    public class ReportOrdersByDatesViewModel
    {
        public DateTime DateCreate { get; set; }
        public string PackageName { get; set; }
        public int Count { get; set; }
        public decimal Sum { get; set; }
        public string Status { get; set; }
    }
}