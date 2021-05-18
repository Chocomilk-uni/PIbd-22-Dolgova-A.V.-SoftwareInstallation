using SoftwareInstallationBusinessLogic.BindingModels;
using SoftwareInstallationBusinessLogic.ViewModels;
using System.Collections.Generic;

namespace SoftwareInstallationBusinessLogic.Interfaces
{
    public interface IMessageInfoStorage
    {
        List<MessageInfoViewModel> GetFullList();
        List<MessageInfoViewModel> GetFilteredList(MessageInfoBindingModel model);
        void Insert(MessageInfoBindingModel model);
    }
}