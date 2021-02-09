using System.Collections.Generic;

namespace SoftwareInstallationBusinessLogic.BindingModels
{
    public class PackageBindingModel
    {
        public int? Id { get; set; }
        public string PackageName { get; set; }
        public decimal Price { get; set; }
        public Dictionary<int, (string, int)> PackageComponents { get; set; }
    }
}