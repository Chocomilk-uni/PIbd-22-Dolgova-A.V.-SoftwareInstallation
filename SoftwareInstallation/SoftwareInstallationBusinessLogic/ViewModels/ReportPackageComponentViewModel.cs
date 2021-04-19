using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace SoftwareInstallationBusinessLogic.ViewModels
{
   [DataContract]
    public class ReportPackageComponentViewModel
    {
        [DataMember]
        public string PackageName { get; set; }

        [DataMember]
        public int TotalCount { get; set; }

        [DataMember]
        public List<Tuple<string, int>> PackageComponents { get; set; }
    }
}