using System;
using System.Collections.Generic;

namespace Migration.Models;

public partial class WarehouseItem
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? SkuCode { get; set; }

    public int Qty { get; set; }

    public double? CostPrice { get; set; }

    public double? MsrpPrice { get; set; }

    public int WarehouseId { get; set; }

    public string CreationUser { get; set; } = null!;

    public string CreationDate { get; set; } = null!;

    public string? ModificationUser { get; set; }

    public string? ModificationDate { get; set; }

    public virtual Warehouse Warehouse { get; set; } = null!;
}
