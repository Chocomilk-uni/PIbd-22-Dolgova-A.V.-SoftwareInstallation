using System;
using System.Collections.Generic;

namespace SoftwareInstallationBusinessLogic.ViewModels
{
    public class ReportPackageComponentViewModel
    {
        public string PackageName { get; set; }
        public int TotalCount { get; set; }
        public List<Tuple<string, int>> PackageComponents { get; set; }
    }
}