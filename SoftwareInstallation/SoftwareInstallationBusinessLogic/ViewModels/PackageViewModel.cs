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

        [DataMember]
        [DisplayName("Название пакета")]
        public string PackageName { get; set; }

        [DataMember]
        [DisplayName("Цена")]
        public decimal Price { get; set; }

        [DataMember]
        public Dictionary<int, (string, int)> PackageComponents { get; set; }
    }
}