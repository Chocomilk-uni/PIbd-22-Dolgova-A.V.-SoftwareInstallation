using SoftwareInstallationBusinessLogic.BindingModels;
using SoftwareInstallationBusinessLogic.ViewModels;
using System.Collections.Generic;

namespace SoftwareInstallationBusinessLogic.Interfaces
{
    public interface IPackageStorage
    {
        List<PackageViewModel> GetFullList();
        List<PackageViewModel> GetFilteredList(PackageBindingModel model);
        PackageViewModel GetElement(PackageBindingModel model);
        void Insert(PackageBindingModel model);
        void Update(PackageBindingModel model);
        void Delete(PackageBindingModel model);
    }
}