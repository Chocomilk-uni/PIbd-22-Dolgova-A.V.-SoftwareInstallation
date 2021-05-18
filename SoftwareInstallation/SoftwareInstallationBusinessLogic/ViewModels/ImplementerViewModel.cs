using SoftwareInstallationBusinessLogic.Attributes;
using SoftwareInstallationBusinessLogic.Enums;

namespace SoftwareInstallationBusinessLogic.ViewModels
{
    public class ImplementerViewModel
    {
        public int Id { get; set; }

        [Column(title: "ФИО", gridViewAutoSize: GridViewAutoSize.Fill)]
        public string FIO { get; set; }

        [Column(title: "Время на заказ", gridViewAutoSize: GridViewAutoSize.ColumnHeader)]
        public int WorkingTime { get; set; }

        [Column(title: "Время на перерыв", gridViewAutoSize: GridViewAutoSize.ColumnHeader)]
        public int PauseTime { get; set; }
    }
}