﻿using SoftwareInstallationBusinessLogic.Enums;
using System;

namespace SoftwareInstallationListImplement.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int PackageId { get; set; }
        public int ClientId { get; set; }
        public int? ImplementerId { get; set; }
        public int Count { get; set; }
        public decimal Sum { get; set; }
        public OrderStatus Status { get; set; }
        public DateTime DateCreate { get; set; }
        public DateTime? DateImplement { get; set; }
    }
}