using Domain.Common;
using InventoryManagement.Domain.Common;
using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class LookupDetail: BaseModel
{
 
    public string? SourceName { get; set; }

    public string? DestinationValue { get; set; }

    public string? DestinationName { get; set; }

    public int LookupCode { get; set; }

    //public virtual Lookup LookupCodeNavigation { get; set; } = null!;

}


