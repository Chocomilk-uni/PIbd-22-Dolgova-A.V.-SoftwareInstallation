using System;
using System.Collections.Generic;

namespace SoftwareInstallationBusinessLogic.ViewModels
{
    public class ReportWarehouseComponentViewModel
    {
        public string WarehouseName { get; set; }
        public int TotalCount { get; set; }
        public List<Tuple<string, int>> WarehouseComponents { get; set; }
    }
}