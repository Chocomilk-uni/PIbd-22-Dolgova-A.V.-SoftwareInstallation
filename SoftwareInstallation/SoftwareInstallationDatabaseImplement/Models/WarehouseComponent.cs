using System.ComponentModel.DataAnnotations;

namespace SoftwareInstallationDatabaseImplement.Models
{
    public class WarehouseComponent
    {
        public int Id { get; set; }
        public int ComponentId { get; set; }
        public int WarehouseId { get; set; }

        [Required]
        public int Count { get; set; }

        public virtual Component Component { get; set; }
        public virtual Warehouse Warehouse { get; set; }
    }
}