using System;
using System.Collections.Generic;

namespace Migration.Models;

public partial class LookupDetail
{
    public int Id { get; set; }

    public string? SourceName { get; set; }

    public string? DestinationValue { get; set; }

    public string? DestinationName { get; set; }

    public int LookupCode { get; set; }

    public string CreationDate { get; set; } = null!;

    public string CreationUser { get; set; } = null!;

    public string? ModificationUser { get; set; }

    public string? ModificationDate { get; set; }

    public virtual Lookup LookupCodeNavigation { get; set; } = null!;
}
