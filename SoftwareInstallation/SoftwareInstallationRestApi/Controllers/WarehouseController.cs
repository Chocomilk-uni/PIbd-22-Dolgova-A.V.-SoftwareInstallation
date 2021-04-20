using Microsoft.AspNetCore.Mvc;
using SoftwareInstallationBusinessLogic.BindingModels;
using SoftwareInstallationBusinessLogic.BusinessLogic;
using SoftwareInstallationBusinessLogic.ViewModels;
using System.Collections.Generic;

namespace SoftwareInstallationRestApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class WarehouseController : ControllerBase
    {
        private readonly WarehouseLogic warehouseLogic;
        private readonly ComponentLogic componentLogic;

        public WarehouseController(WarehouseLogic warehouseLogic, ComponentLogic componentLogic)
        {
            this.warehouseLogic = warehouseLogic;
            this.componentLogic = componentLogic;
        }

        public List<WarehouseViewModel> GetFullWarehouseList() => warehouseLogic.Read(null);

        public List<ComponentViewModel> GetFullComponentsList() => componentLogic.Read(null);

        [HttpPost]
        public void Create(WarehouseBindingModel model) => warehouseLogic.CreateOrUpdate(model);

        [HttpPost]
        public void Update(WarehouseBindingModel model) => warehouseLogic.CreateOrUpdate(model);

        [HttpPost]
        public void Delete(WarehouseBindingModel model) => warehouseLogic.Delete(model);

        [HttpPost]
        public void AddComponent(AddComponentBindingModel model) => warehouseLogic.AddComponents(model);
    }
}