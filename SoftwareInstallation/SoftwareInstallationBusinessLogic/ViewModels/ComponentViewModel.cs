using System.ComponentModel;

namespace SoftwareInstallationBusinessLogic.ViewModels
{
    public class ComponentViewModel
    {
        public int Id { get; set; }

        [DisplayName("Название компонента")]
        public string ComponentName { get; set; }
    }
}