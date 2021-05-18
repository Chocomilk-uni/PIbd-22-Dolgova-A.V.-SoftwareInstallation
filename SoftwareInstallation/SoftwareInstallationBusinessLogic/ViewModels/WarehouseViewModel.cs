using SoftwareInstallationBusinessLogic.Attributes;
using SoftwareInstallationBusinessLogic.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace SoftwareInstallationBusinessLogic.ViewModels
{
    public class WarehouseViewModel
    {
        public int Id { get; set; }

        [Column(title: "Название склада", gridViewAutoSize: GridViewAutoSize.Fill)]
        public string WarehouseName { get; set; }

        [Column(title: "ФИО ответственного", gridViewAutoSize: GridViewAutoSize.AllCells)]
        public string WarehouseManagerFullName { get; set; }

        [Column(title: "Дата создания", gridViewAutoSize: GridViewAutoSize.AllCells)]
        public DateTime DateCreate { get; set; }
        public Dictionary<int, (string, int)> WarehouseComponents { get; set; }
    }
}