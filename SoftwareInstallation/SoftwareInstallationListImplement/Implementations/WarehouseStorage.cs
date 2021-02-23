using SoftwareInstallationBusinessLogic.BindingModels;
using SoftwareInstallationBusinessLogic.Interfaces;
using SoftwareInstallationBusinessLogic.ViewModels;
using SoftwareInstallationListImplement.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SoftwareInstallationListImplement.Implementations
{
    public class WarehouseStorage : IWarehouseStorage
    {
        private readonly DataListSingleton source;

        public WarehouseStorage()
        {
            source = DataListSingleton.GetInstance();
        }

        private Warehouse CreateModel(WarehouseBindingModel model, Warehouse warehouse)
        {
            warehouse.WarehouseName = model.WarehouseName;
            warehouse.WarehouseManagerFullName = model.WarehouseManagerFullName;

            foreach (var key in warehouse.WarehouseComponents.Keys.ToList())
            {
                if (!model.WarehouseComponents.ContainsKey(key))
                {
                    warehouse.WarehouseComponents.Remove(key);
                }
            }

            foreach (var component in model.WarehouseComponents)
            {
                if (warehouse.WarehouseComponents.ContainsKey(component.Key))
                {
                    warehouse.WarehouseComponents[component.Key] =
                        model.WarehouseComponents[component.Key].Item2;
                }
                else
                {
                    warehouse.WarehouseComponents.Add(component.Key, model.WarehouseComponents[component.Key].Item2);
                }
            }
            return warehouse;
        }

        private WarehouseViewModel CreateModel(Warehouse warehouse)
        {
            Dictionary<int, (string, int)> warehouseComponents = new Dictionary<int, (string, int)>();

            foreach (var warehouseComponent in warehouse.WarehouseComponents)
            {
                string componentName = string.Empty;
                foreach (var component in source.Components)
                {
                    if (warehouseComponent.Key == component.Id)
                    {
                        componentName = component.ComponentName;
                        break;
                    }
                }
                warehouseComponents.Add(warehouseComponent.Key, (componentName, warehouseComponent.Value));
            }

            return new WarehouseViewModel
            {
                Id = warehouse.Id,
                WarehouseName = warehouse.WarehouseName,
                WarehouseManagerFullName = warehouse.WarehouseManagerFullName,
                DateCreate = warehouse.DateCreate,
                WarehouseComponents = warehouseComponents
            };
        }

        public List<WarehouseViewModel> GetFullList()
        {
            List<WarehouseViewModel> result = new List<WarehouseViewModel>();
            foreach (var warehouse in source.Warehouses)
            {
                result.Add(CreateModel(warehouse));
            }
            return result;
        }

        public List<WarehouseViewModel> GetFilteredList(WarehouseBindingModel model)
        {
            if (model == null)
            {
                return null;
            }

            List<WarehouseViewModel> result = new List<WarehouseViewModel>();

            foreach (var warehouse in source.Warehouses)
            {
                if (warehouse.WarehouseName.Contains(model.WarehouseName))
                {
                    result.Add(CreateModel(warehouse));
                }
            }
            return result;
        }

        public WarehouseViewModel GetElement(WarehouseBindingModel model)
        {
            if (model == null)
            {
                return null;
            }

            foreach (var warehouse in source.Warehouses)
            {
                if (warehouse.Id == model.Id)
                {
                    return CreateModel(warehouse);
                }
            }
            return null;
        }

        public void Insert(WarehouseBindingModel model)
        {
            Warehouse tempWarehouse = new Warehouse
            {
                Id = 1,
                WarehouseComponents = new Dictionary<int, int>(),
                DateCreate = DateTime.Now
            };

            foreach (var warehouse in source.Warehouses)
            {
                if (warehouse.Id >= tempWarehouse.Id)
                {
                    tempWarehouse.Id = warehouse.Id + 1;
                }
            }
            source.Warehouses.Add(CreateModel(model, tempWarehouse));
        }

        public void Update(WarehouseBindingModel model)
        {
            Warehouse tempWarehouse = null;

            foreach (var warehouse in source.Warehouses)
            {
                if (warehouse.Id == model.Id)
                {
                    tempWarehouse = warehouse;
                }
            }

            if (tempWarehouse == null)
            {
                throw new Exception("Элемент не найден");
            }
            CreateModel(model, tempWarehouse);
        }

        public void Delete(WarehouseBindingModel model)
        {
            for (int i = 0; i < source.Warehouses.Count; ++i)
            {
                if (source.Warehouses[i].Id == model.Id)
                {
                    source.Warehouses.RemoveAt(i);
                    return;
                }
            }
            throw new Exception("Элемент не найден");
        }

        public void Print()
        {
            foreach (Warehouse warehouse in source.Warehouses)
            {
                Console.WriteLine(warehouse.WarehouseName + " " + warehouse.WarehouseManagerFullName + " " + warehouse.DateCreate);
                foreach (KeyValuePair<int, int> keyValue in warehouse.WarehouseComponents)
                {
                    string componentName = source.Components.FirstOrDefault(component => component.Id == keyValue.Key).ComponentName;
                    Console.WriteLine(componentName + " " + keyValue.Value);
                }
            }
        }
    }
}