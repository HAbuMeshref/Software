using System;
using System.Collections.Generic;

namespace Migration.Models;

public partial class Warehouse
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Address { get; set; } = null!;

    public string City { get; set; } = null!;

    public string CountryCode { get; set; } = null!;

    public string CreationUser { get; set; } = null!;

    public string CreationDate { get; set; } = null!;

    public string? ModificationUser { get; set; }

    public string? ModificationDate { get; set; }

    public virtual ICollection<WarehouseItem> WarehouseItems { get; set; } = new List<WarehouseItem>();
}
