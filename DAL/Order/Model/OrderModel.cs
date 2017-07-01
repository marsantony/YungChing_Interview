﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Order.Model
{
    public class OrderModel
    {
        [PrimaryKey]
        public int? OrderID { get; set; } //(int, not null)
        public string CustomerID { get; set; } //(nchar(5), null)
        public int? EmployeeID { get; set; } //(int, null)
        public DateTime? OrderDate { get; set; } //(datetime, null)
        public DateTime? RequiredDate { get; set; } //(datetime, null)
        public DateTime? ShippedDate { get; set; } //(datetime, null)
        public int? ShipVia { get; set; } //(int, null)
        public decimal Freight { get; set; } //(money, null)
        public string ShipName { get; set; } //(nvarchar(40), null)
        public string ShipAddress { get; set; } //(nvarchar(60), null)
        public string ShipCity { get; set; } //(nvarchar(15), null)
        public string ShipRegion { get; set; } //(nvarchar(15), null)
        public string ShipPostalCode { get; set; } //(nvarchar(10), null)
        public string ShipCountry { get; set; } //(nvarchar(15), null)
    }
}
