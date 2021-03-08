using SoftwareInstallationBusinessLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SoftwareInstallationFileImplement.Implementations
{
    public class WarehouseStorage : IWarehouseStorage
    {
        private readonly FileDataListSingleton source;

        public WarehouseStorage()
        {
            source = FileDataListSingleton.GetInstance();
        }

        private Warehouse
    }
}
