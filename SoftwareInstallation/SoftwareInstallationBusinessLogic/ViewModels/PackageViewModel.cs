using SoftwareInstallationBusinessLogic.Attributes;
using SoftwareInstallationBusinessLogic.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace SoftwareInstallationBusinessLogic.ViewModels
{
    [DataContract]
    public class PackageViewModel
    {
        [DataMember]
        public int Id { get; set; }

        [Column(title: "Название пакета", gridViewAutoSize: GridViewAutoSize.Fill)]
        [DataMember]
        public string PackageName { get; set; }

        [Column(title: "Цена", width: 100)]
        [DataMember]
        public decimal Price { get; set; }

        [DataMember]
        public Dictionary<int, (string, int)> PackageComponents { get; set; }
    }
}