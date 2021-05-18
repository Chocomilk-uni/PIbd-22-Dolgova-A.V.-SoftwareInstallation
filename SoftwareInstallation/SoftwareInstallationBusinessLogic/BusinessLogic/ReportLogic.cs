﻿using SoftwareInstallationBusinessLogic.BindingModels;
using SoftwareInstallationBusinessLogic.Enums;
using SoftwareInstallationBusinessLogic.HelperModels;
using SoftwareInstallationBusinessLogic.Interfaces;
using SoftwareInstallationBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace SoftwareInstallationBusinessLogic.BusinessLogic
{
    public class ReportLogic
    {
        private readonly IPackageStorage _packageStorage;
        private readonly IOrderStorage _orderStorage;
        private readonly IWarehouseStorage _warehouseStorage;

        public ReportLogic(IPackageStorage packageStorage, IOrderStorage orderStorage, IWarehouseStorage warehouseStorage)
        {
            _packageStorage = packageStorage;
            _orderStorage = orderStorage;
            _warehouseStorage = warehouseStorage;
        }

        //Получение списка компонентов с указанием того, в каких изделиях они используются
        public List<ReportPackageComponentViewModel> GetPackageComponent()
        {
            var packages = _packageStorage.GetFullList();
            var list = new List<ReportPackageComponentViewModel>();

            foreach (var package in packages)
            {
                var record = new ReportPackageComponentViewModel
                {
                    PackageName = package.PackageName,
                    PackageComponents = new List<Tuple<string, int>>(),
                    TotalCount = 0
                };

                foreach (var component in package.PackageComponents)
                {
                    record.PackageComponents.Add(new Tuple<string, int>(component.Value.Item1, component.Value.Item2));
                    record.TotalCount += component.Value.Item2;
                }
                list.Add(record);
            }
            return list;
        }

        //Получение списка компонентов с указанием того, на каких складах они хранятся
        public List<ReportWarehouseComponentViewModel> GetWarehouseComponent()
        {
            var warehouses = _warehouseStorage.GetFullList();
            var list = new List<ReportWarehouseComponentViewModel>();

            foreach (var warehouse in warehouses)
            {
                var record = new ReportWarehouseComponentViewModel
                {
                    WarehouseName = warehouse.WarehouseName,
                    WarehouseComponents = new List<Tuple<string, int>>(),
                    TotalCount = 0
                };

                foreach (var component in warehouse.WarehouseComponents)
                {
                    record.WarehouseComponents.Add(new Tuple<string, int>(component.Value.Item1, component.Value.Item2));
                    record.TotalCount += component.Value.Item2;
                }
                list.Add(record);
            }
            return list;
        }

        //Получение списка заказов за определённый период
        public List<ReportOrdersByDatesViewModel> GetOrdersByDates(ReportBindingModel model)
        {
            return _orderStorage.GetFilteredList(new OrderBindingModel { DateFrom = model.DateFrom, DateTo = model.DateTo })
            .Select(x => new ReportOrdersByDatesViewModel
            {
                ClientFIO = x.ClientFIO,
                DateCreate = x.DateCreate,
                PackageName = x.PackageName,
                Count = x.Count,
                Sum = x.Sum,
                Status = Convert.ToString((OrderStatus)Enum.Parse(typeof(OrderStatus), x.Status.ToString()))
            })
           .ToList();
        }

        //Получение полного списка заказов, сгруппированных по датам
        public List<ReportAllOrdersInfoViewModel> GetOrdersForInfo()
        {
            return _orderStorage.GetFullList()
                .GroupBy(order => order.DateCreate.ToShortDateString())
                .Select(rec => new ReportAllOrdersInfoViewModel
                {
                    Date = Convert.ToDateTime(rec.Key),
                    Count = rec.Count(),
                    Sum = rec.Sum(order => order.Sum)
                })
                .ToList();
        }

        //Сохранение пакетов в Word-файл
        public void SavePackagesToWordFile(ReportBindingModel model)
        {
            SaveToWord.CreateDocWithPackages(new WordPackagesInfo
            {
                FileName = model.FileName,
                Title = "Список пакетов",
                Packages = _packageStorage.GetFullList()
            });
        }

        //Сохранение складов в Word-файл
        public void SaveWarehousesToWordFile(ReportBindingModel model)
        {

            SaveToWord.CreateDocWithWarehouses(new WordWarehousesInfo
            {
                FileName = model.FileName,
                Title = "Список складов",
                Warehouses = _warehouseStorage.GetFullList()
            });
        }

        //Сохранение компонентов с указанием пакетов в Excel-файл
        public void SavePackageComponentToExcelFile(ReportBindingModel model)
        {
            MethodInfo method = GetType().GetMethod("GetPackageComponent");

            SaveToExcel.CreateDocWithPackageComponents(new ExcelPackageComponentsInfo
            {
                FileName = model.FileName,
                Title = "Список компонентов по пакетам",
                PackageComponents = (List<ReportPackageComponentViewModel>)method.Invoke(this, null)
            });
        }

        //Сохранение компонентов с указанием складов в Excel-файл
        public void SaveWarehouseComponentsToExcelFile(ReportBindingModel model)
        {
            MethodInfo method = GetType().GetMethod("GetWarehouseComponent");

            SaveToExcel.CreateDocWithWarehouseComponents(new ExcelWarehouseComponentsInfo
            {
                FileName = model.FileName,
                Title = "Список компонентов по складам",
                WarehouseComponents = (List<ReportWarehouseComponentViewModel>)method.Invoke(this, null)
            });
        }

        //Сохранение заказов по определённым датам в Pdf-файл
        public void SaveOrdersByDatesToPdfFile(ReportBindingModel model)
        {
            MethodInfo method = GetType().GetMethod("GetOrdersByDates");

            SaveToPdf.CreateDocWithOrdersByDates(new PdfOrdersByDatesInfo
            {
                FileName = model.FileName,
                Title = "Список заказов",
                DateFrom = model.DateFrom.Value,
                DateTo = model.DateTo.Value,
                Orders = (List<ReportOrdersByDatesViewModel>)method.Invoke(this, new object[] { model })
            });
        }

        //Сохранение всех заказов в Pdf-файл
        public void SaveOrdersForInfoToPdfFile(ReportBindingModel model)
        {
            MethodInfo method = GetType().GetMethod("GetOrdersForInfo");

            SaveToPdf.CreateDocWithAllOrders(new PdfAllOrdersInfo
            {
                FileName = model.FileName,
                Title = "Список заказов",
                Orders = (List<ReportAllOrdersInfoViewModel>)method.Invoke(this, null)
            });
        }
    }
}