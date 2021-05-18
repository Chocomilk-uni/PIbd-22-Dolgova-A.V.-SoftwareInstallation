using SoftwareInstallationBusinessLogic.Attributes;
using SoftwareInstallationBusinessLogic.Enums;
using System.Runtime.Serialization;

namespace SoftwareInstallationBusinessLogic.ViewModels
{
    [DataContract]
    public class ClientViewModel
    {
        [DataMember]
        public int Id { get; set; }

        [Column(title: "ФИО", gridViewAutoSize: GridViewAutoSize.AllCells)]
        [DataMember]
        public string ClientFIO { get; set; }

        [Column(title: "Почта", gridViewAutoSize: GridViewAutoSize.AllCells)]
        [DataMember]
        public string Email { get; set; }

        [Column(title: "Пароль", gridViewAutoSize: GridViewAutoSize.Fill)]
        [DataMember]
        public string Password { get; set; }
    }
}