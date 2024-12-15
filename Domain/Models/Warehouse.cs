using Domain.Common;
using InventoryManagement.Domain.Common;
using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class Warehouse: BaseModel
{
   
    public string Name { get; set; } = null!;

    public string Address { get; set; } = null!;

    public string City { get; set; } = null!;

    public string CountryCode { get; set; } = null!;


    //public virtual ICollection<WarehouseItem> WarehouseItems { get; set; } = new List<WarehouseItem>();
}
