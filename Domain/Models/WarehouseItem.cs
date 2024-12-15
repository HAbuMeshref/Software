using Domain.Common;
using InventoryManagement.Domain.Common;
using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class WarehouseItem: BaseModel
{
  
    public string Name { get; set; } = null!;

    public string? SkuCode { get; set; }

    public int Qty { get; set; }

    public double? CostPrice { get; set; }

    public double? MsrpPrice { get; set; }

    public int WarehouseId { get; set; }



    //public virtual Warehouse Warehouse { get; set; } = null!;
}
