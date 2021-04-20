using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using SoftwareInstallationBusinessLogic.BindingModels;
using SoftwareInstallationBusinessLogic.ViewModels;
using SoftwareInstallationWarehouseApp.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace SoftwareInstallationWarehouseApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IConfiguration configuration;

        public HomeController(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public IActionResult Index()
        {
            if (!Program.Authorized)
            {
                return Redirect("~/Home/Privacy");
            }

            return View(APIClient.GetRequest<List<WarehouseViewModel>>(
                $"api/warehouse/getfullwarehouselist"));
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpPost]
        public void Privacy(string password)
        {
            if (!string.IsNullOrEmpty(password))
            {
                Program.Authorized = password == configuration["Password"];

                if (!Program.Authorized)
                {
                    throw new Exception("Неверный пароль");
                }

                Response.Redirect("Index");
                return;
            }

            throw new Exception("Введите пароль");
        }

        public IActionResult Create()
        {
            if (!Program.Authorized)
            {
                return Redirect("~/Home/Privacy");
            }
            return View();
        }

        [HttpPost]
        public void Create([Bind("WarehouseName, WarehouseManagerFullName")] WarehouseBindingModel model)
        {
            if (string.IsNullOrEmpty(model.WarehouseName) || string.IsNullOrEmpty(model.WarehouseManagerFullName))
            {
                return;
            }
            model.WarehouseComponents = new Dictionary<int, (string, int)>();
            APIClient.PostRequest("api/warehouse/create", model);
            Response.Redirect("Index");
        }

        public IActionResult Update(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var warehouse = APIClient.GetRequest<List<WarehouseViewModel>>(
                $"api/warehouse/getfullwarehouselist").FirstOrDefault(rec => rec.Id == id);
            if (warehouse == null)
            {
                return NotFound();
            }

            return View(warehouse);
        }

        [HttpPost]
        public IActionResult Update(int id, [Bind("Id,WarehouseName,WarehouseManagerFullName")] WarehouseBindingModel model)
        {
            if (id != model.Id)
            {
                return NotFound();
            }

            var warehouse = APIClient.GetRequest<List<WarehouseViewModel>>(
                $"api/warehouse/getfullwarehouselist").FirstOrDefault(rec => rec.Id == id);

            model.WarehouseComponents = warehouse.WarehouseComponents;

            APIClient.PostRequest("api/warehouse/update", model);
            return Redirect("~/Home/Index");
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var warehouse = APIClient.GetRequest<List<WarehouseViewModel>>(
                $"api/warehouse/getfullwarehouselist").FirstOrDefault(rec => rec.Id == id);
            if (warehouse == null)
            {
                return NotFound();
            }

            return View(warehouse);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            APIClient.PostRequest("api/warehouse/delete", new WarehouseBindingModel { Id = id });
            return Redirect("~/Home/Index");
        }

        public IActionResult AddComponent()
        {
            if (!Program.Authorized)
            {
                return Redirect("~/Home/Privacy");
            }
            ViewBag.Warehouses = APIClient.GetRequest<List<WarehouseViewModel>>("api/warehouse/getfullwarehouselist");
            ViewBag.Components = APIClient.GetRequest<List<ComponentViewModel>>($"api/warehouse/getfullcomponentslist");

            return View();
        }

        [HttpPost]
        public IActionResult AddComponent([Bind("WarehouseId, ComponentId, Count")] AddComponentBindingModel model)
        {
            if (model.WarehouseId == 0 || model.ComponentId == 0 || model.Count <= 0)
            {
                return NotFound();
            }

            var warehouse = APIClient.GetRequest<List<WarehouseViewModel>>(
                "api/warehouse/getfullwarehouselist").FirstOrDefault(rec => rec.Id == model.WarehouseId);

            if (warehouse == null)
            {
                return NotFound();
            }

            var component = APIClient.GetRequest<List<WarehouseViewModel>>(
                "api/warehouse/getfullcomponentslist").FirstOrDefault(rec => rec.Id == model.ComponentId);

            if (component == null)
            {
                return NotFound();
            }

            APIClient.PostRequest("api/warehouse/addcomponent", model);
            return Redirect("~/Home/Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}