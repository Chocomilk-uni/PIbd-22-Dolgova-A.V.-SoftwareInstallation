using SoftwareInstallationBusinessLogic.BindingModels;
using SoftwareInstallationBusinessLogic.Interfaces;
using SoftwareInstallationBusinessLogic.ViewModels;
using SoftwareInstallationDatabaseImplement.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SoftwareInstallationDatabaseImplement.Implementations
{
    public class ImplementerStorage : IImplementerStorage
    {
        public List<ImplementerViewModel> GetFullList()
        {
            using (var context = new SoftwareInstallationDatabase())
            {
                return context.Implementers
                    .Select(rec => new ImplementerViewModel
                    {
                        Id = rec.Id,
                        FIO = rec.FIO,
                        WorkingTime = rec.WorkingTime,
                        PauseTime = rec.PauseTime
                    })
                    .ToList();
            }
        }

        public List<ImplementerViewModel> GetFilteredList(ImplementerBindingModel model)
        {
            if (model == null)
            {
                return null;
            }

            using (var context = new SoftwareInstallationDatabase())
            {
                return context.Implementers
                    .Where(rec => rec.FIO.Contains(model.FIO))
                    .Select(rec => new ImplementerViewModel
                    {
                        Id = rec.Id,
                        FIO = rec.FIO,
                        WorkingTime = rec.WorkingTime,
                        PauseTime = rec.PauseTime
                    })
                    .ToList();
            }
        }

        public ImplementerViewModel GetElement(ImplementerBindingModel model)
        {
            if (model == null)
            {
                return null;
            }

            using (var context = new SoftwareInstallationDatabase())
            {
                var implementer = context.Implementers
                    .FirstOrDefault(rec => rec.Id == model.Id);
                return implementer != null ?
                    new ImplementerViewModel
                    {
                        Id = implementer.Id,
                        FIO = implementer.FIO,
                        WorkingTime = implementer.WorkingTime,
                        PauseTime = implementer.PauseTime
                    } :
                    null;
            }
        }

        public void Insert(ImplementerBindingModel model)
        {
            using (var context = new SoftwareInstallationDatabase())
            {
                context.Implementers.Add(CreateModel(model, new Implementer()));
                context.SaveChanges();
            }
        }

        public void Update(ImplementerBindingModel model)
        {
            using (var context = new SoftwareInstallationDatabase())
            {
                var element = context.Implementers.FirstOrDefault(rec => rec.Id == model.Id);

                if (element == null)
                {
                    throw new Exception("Элемент не найден");
                }
                CreateModel(model, element);
                context.SaveChanges();
            }
        }

        public void Delete(ImplementerBindingModel model)
        {
            using (var context = new SoftwareInstallationDatabase())
            {
                Implementer element = context.Implementers.FirstOrDefault(rec => rec.Id == model.Id);

                if (element != null)
                {
                    context.Implementers.Remove(element);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Элемент не найден");
                }
            }
        }

        private Implementer CreateModel(ImplementerBindingModel model, Implementer implementer)
        {
            implementer.FIO = model.FIO;
            implementer.WorkingTime = model.WorkingTime;
            implementer.PauseTime = model.PauseTime;

            return implementer;
        }
    }
}