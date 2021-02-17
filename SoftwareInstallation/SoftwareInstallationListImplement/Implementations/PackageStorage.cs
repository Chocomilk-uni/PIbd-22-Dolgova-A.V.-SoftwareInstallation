using SoftwareInstallationBusinessLogic.BindingModels;
using SoftwareInstallationBusinessLogic.Interfaces;
using SoftwareInstallationBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SoftwareInstallationListImplement
{
    public class PackageStorage : IPackageStorage
    {
        private readonly DataListSingleton source;

        public PackageStorage()
        {
            source = DataListSingleton.GetInstance();
        }

        public List<PackageViewModel> GetFullList()
        {
            List<PackageViewModel> result = new List<PackageViewModel>();
            foreach (var product in source.Packages)
            {
                result.Add(CreateModel(product));
            }
            return result;
        }

        public List<PackageViewModel> GetFilteredList(PackageBindingModel model)
        {
            if (model == null)
            {
                return null;
            }

            List<PackageViewModel> result = new List<PackageViewModel>();
            foreach (var product in source.Packages)
            {
                if (product.PackageName.Contains(model.PackageName))
                {
                    result.Add(CreateModel(product));
                }
            }
            return result;
        }

        public PackageViewModel GetElement(PackageBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            foreach (var product in source.Packages)
            {
                if (product.Id == model.Id || product.PackageName == model.PackageName)
                {
                    return CreateModel(product);
                }
            }
            return null;
        }

        public void Insert(PackageBindingModel model)
        {
            Package tempProduct = new Package { Id = 1, PackageComponents = new Dictionary<int, int>() };

            foreach (var product in source.Packages)
            {
                if (product.Id >= tempProduct.Id)
                {
                    tempProduct.Id = product.Id + 1;
                }
            }
            source.Packages.Add(CreateModel(model, tempProduct));
        }

        public void Update(PackageBindingModel model)
        {
            Package tempProduct = null;

            foreach (var product in source.Packages)
            {
                if (product.Id == model.Id)
                {
                    tempProduct = product;
                }
            }
            if (tempProduct == null)
            {
                throw new Exception("Элемент не найден");
            }
            CreateModel(model, tempProduct);
        }

        public void Delete(PackageBindingModel model)
        {
            for (int i = 0; i < source.Packages.Count; i++)
            {
                if (source.Packages[i].Id == model.Id)
                {
                    source.Packages.RemoveAt(i);
                    return;
                }
            }
            throw new Exception("Элемент не найден");
        }

        private Package CreateModel(PackageBindingModel model, Package product)
        {
            product.PackageName = model.PackageName;
            product.Price = model.Price;

            foreach(var key in product.PackageComponents.Keys.ToList())
            {
                if (!model.PackageComponents.ContainsKey(key))
                {
                    product.PackageComponents.Remove(key);
                }
            }
            foreach (var component in model.PackageComponents)
            {
                if (product.PackageComponents.ContainsKey(component.Key))
                {
                    product.PackageComponents[component.Key] = model.PackageComponents[component.Key].Item2;
                }
                else
                {
                    product.PackageComponents.Add(component.Key, model.PackageComponents[component.Key].Item2);
                }
            }
            return product;
        }

        private PackageViewModel CreateModel(Package product)
        {
            Dictionary<int, (string, int)> productComponents = new Dictionary<int, (string, int)>();

            foreach (var pc in product.PackageComponents)
            {
                string componentName = string.Empty;
                foreach (var component in source.Components)
                {
                    if (pc.Key == component.Id)
                    {
                        componentName = component.ComponentName;
                        break;
                    }
                }
                productComponents.Add(pc.Key, (componentName, pc.Value));
            }
            return new PackageViewModel
            {
                Id = product.Id,
                PackageName = product.PackageName,
                Price = product.Price,
                PackageComponents = productComponents
            };
        }
    }
}