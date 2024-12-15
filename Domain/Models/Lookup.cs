using Domain.Common;
using InventoryManagement.Domain.Common;
using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class Lookup:BaseModel
{
   
    public int Code { get; set; }

    public string? Name { get; set; } = null!;

    //public virtual ICollection<LookupDetail>? LookupDetails { get; set; } = new List<LookupDetail>();

}
