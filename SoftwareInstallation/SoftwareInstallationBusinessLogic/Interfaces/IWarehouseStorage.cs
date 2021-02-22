using SoftwareInstallationBusinessLogic.BindingModels;
using SoftwareInstallationBusinessLogic.ViewModels;
using System.Collections.Generic;

namespace SoftwareInstallationBusinessLogic.Interfaces
{
    public interface IWarehouseStorage
    {
        List<WarehouseViewModel> GetFullList();
        List<WarehouseViewModel> GetFilteredList(WarehouseBindingModel model);
        WarehouseViewModel GetElement(WarehouseBindingModel model);
        void Insert(WarehouseBindingModel model);
        void Update(WarehouseBindingModel model);
        void Delete(WarehouseBindingModel model);
    }
}