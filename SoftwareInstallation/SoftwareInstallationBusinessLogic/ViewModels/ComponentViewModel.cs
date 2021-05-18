using SoftwareInstallationBusinessLogic.Attributes;
using SoftwareInstallationBusinessLogic.Enums;

namespace SoftwareInstallationBusinessLogic.ViewModels
{
    public class ComponentViewModel
    {
        public int Id { get; set; }

        [Column(title: "Название компонента", gridViewAutoSize: GridViewAutoSize.Fill)]
        public string ComponentName { get; set; }
    }
}