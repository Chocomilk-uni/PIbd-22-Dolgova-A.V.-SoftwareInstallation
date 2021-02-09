using System.Collections.Generic;
using System.ComponentModel;

namespace SoftwareInstallationBusinessLogic.ViewModels
{
    public class PackageViewModel
    {
        public int Id { get; set; }

        [DisplayName("Название изделия")]
        public string PackageName { get; set; }

        [DisplayName("Цена")]
        public decimal Price { get; set; }

        public Dictionary<int, (string, int)> PackageComponents { get; set; }
    }
}