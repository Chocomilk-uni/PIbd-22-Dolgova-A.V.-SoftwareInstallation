using SoftwareInstallationBusinessLogic.Attributes;
using SoftwareInstallationBusinessLogic.Enums;
using System;
using System.Runtime.Serialization;

namespace SoftwareInstallationBusinessLogic.ViewModels
{
    [DataContract]
    public class OrderViewModel
    {
        [Column(title: "Номер", gridViewAutoSize: GridViewAutoSize.ColumnHeader)]
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public int PackageId { get; set; }

        [DataMember]
        public int ClientId { get; set; }

        [DataMember]
        public int? ImplementerId { get; set; }

        [Column(title: "Клиент", gridViewAutoSize: GridViewAutoSize.AllCells)]
        [DataMember]
        public string ClientFIO { get; set; }

        [Column(title: "Исполнитель", gridViewAutoSize: GridViewAutoSize.AllCells)]
        [DataMember]
        public string ImplementerFIO { get; set; }

        [Column(title: "Пакет", gridViewAutoSize: GridViewAutoSize.AllCells)]
        [DataMember]
        public string PackageName { get; set; }

        [Column(title: "Количество", gridViewAutoSize: GridViewAutoSize.Fill)]
        [DataMember]
        public int Count { get; set; }

        [Column(title: "Сумма", gridViewAutoSize: GridViewAutoSize.ColumnHeader)]
        [DataMember]
        public decimal Sum { get; set; }

        [Column(title: "Статус", gridViewAutoSize: GridViewAutoSize.AllCells)]
        [DataMember]
        public OrderStatus Status { get; set; }

        [Column(title: "Дата создания", gridViewAutoSize: GridViewAutoSize.AllCells)]
        [DataMember]
        public DateTime DateCreate { get; set; }

        [Column(title: "Дата выполнения", gridViewAutoSize: GridViewAutoSize.AllCells)]
        [DataMember]
        public DateTime? DateImplement { get; set; }
 
    }
}