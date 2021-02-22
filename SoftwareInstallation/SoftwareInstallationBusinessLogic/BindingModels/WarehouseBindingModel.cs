using System;
using System.Collections.Generic;

namespace SoftwareInstallationBusinessLogic.BindingModels
{
    public class WarehouseBindingModel
    {
        public int? Id { get; set; }
        public string WarehouseName { get; set; }
        public string WarehouseManagerFullName { get; set; }
        public DateTime DateCreate { get; set; }
        public Dictionary<int, (string, int)> WarehouseComponents { get; set; }
    }
}