using Microsoft.EntityFrameworkCore;
using SoftwareInstallationBusinessLogic.BindingModels;
using SoftwareInstallationBusinessLogic.Interfaces;
using SoftwareInstallationBusinessLogic.ViewModels;
using SoftwareInstallationDatabaseImplement.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SoftwareInstallationDatabaseImplement.Implementations
{
    public class PackageStorage : IPackageStorage
    {
        public List<PackageViewModel> GetFullList()
        {
            using (var context = new SoftwareInstallationDatabase())
            {
                return context.Packages
                    .Include(rec => rec.PackageComponents)
                    .ThenInclude(rec => rec.Component)
                    .ToList()
                    .Select(rec => new PackageViewModel
                {
                    Id = rec.Id,
                    PackageName = rec.PackageName,
                    Price = rec.Price,
                    PackageComponents = rec.PackageComponents.ToDictionary(recPC => recPC.ComponentId, recPC => (recPC.Component?.ComponentName, recPC.Count))
                }).ToList();
            }
        }

        public List<PackageViewModel> GetFilteredList(PackageBindingModel model)
        {
            if (model == null)
            {
                return null;
            }

            using (var context = new SoftwareInstallationDatabase())
            {
                return context.Packages
                    .Include(rec => rec.PackageComponents)
                    .ThenInclude(rec => rec.Component)
                    .Where(rec => rec.PackageName.Contains(model.PackageName)).ToList().Select(rec => new PackageViewModel
                {
                    Id = rec.Id,
                    PackageName = rec.PackageName,
                    Price = rec.Price,
                    PackageComponents = rec.PackageComponents.ToDictionary(recPC => recPC.ComponentId, recPC => (recPC.Component?.ComponentName, recPC.Count))
                }).ToList();
            }
        }

        public PackageViewModel GetElement(PackageBindingModel model)
        {
            if (model == null)
            {
                return null;
            }

            using (var context = new SoftwareInstallationDatabase())
            {
                Package package = context.Packages
                    .Include(rec => rec.PackageComponents)
                    .ThenInclude(rec => rec.Component)
                    .FirstOrDefault(rec => rec.PackageName == model.PackageName || rec.Id == model.Id);
                return package != null ? new PackageViewModel
                {
                    Id = package.Id,
                    PackageName = package.PackageName,
                    Price = package.Price,
                    PackageComponents = package.PackageComponents.ToDictionary(recPC => recPC.ComponentId, recPC => (recPC.Component?.ComponentName, recPC.Count))
                } : null;
            }
        }
        public void Insert(PackageBindingModel model)
        {
            using (var context = new SoftwareInstallationDatabase())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        CreateModel(model, new Package(), context);
                        transaction.Commit();
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }

        public void Update(PackageBindingModel model)
        {
            using (var context = new SoftwareInstallationDatabase())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        Package element = context.Packages.FirstOrDefault(rec => rec.Id == model.Id);

                        if (element == null)
                        {
                            throw new Exception("Элемент не найден");
                        }

                        CreateModel(model, element, context);
                        transaction.Commit();
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }

        public void Delete(PackageBindingModel model)
        {
            using (var context = new SoftwareInstallationDatabase())
            {
                Package element = context.Packages.FirstOrDefault(rec => rec.Id == model.Id);
                if (element != null)
                {
                    context.Packages.Remove(element);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Элемент не найден");
                }
            }
        }

        private Package CreateModel(PackageBindingModel model, Package package, SoftwareInstallationDatabase context)
        {
            package.PackageName = model.PackageName;
            package.Price = model.Price;

            if(package.Id == 0)
            {
                context.Packages.Add(package);
                context.SaveChanges();
            }

            if (model.Id.HasValue)
            {
                List<PackageComponent> packageComponents = context.PackageComponents.Where(rec => rec.PackageId == model.Id.Value).ToList();
                context.PackageComponents.RemoveRange(packageComponents.Where(rec => !model.PackageComponents.ContainsKey(rec.ComponentId)).ToList());
                context.SaveChanges();

                foreach (PackageComponent updateComponent in packageComponents)
                {
                    updateComponent.Count = model.PackageComponents[updateComponent.ComponentId].Item2;
                    model.PackageComponents.Remove(updateComponent.ComponentId);
                }
                context.SaveChanges();
            }
            foreach (var pc in model.PackageComponents)
            {
                context.PackageComponents.Add(new PackageComponent
                {
                    PackageId = package.Id,
                    ComponentId = pc.Key,
                    Count = pc.Value.Item2
                });
                context.SaveChanges();
            }
            return package;
        }
    }
}