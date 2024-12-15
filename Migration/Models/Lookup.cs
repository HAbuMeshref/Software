using System;
using System.Collections.Generic;

namespace Migration.Models;

public partial class Lookup
{
    public int Id { get; set; }

    public int Code { get; set; }

    public string Name { get; set; } = null!;

    public string CreationUser { get; set; } = null!;

    public string CreationDate { get; set; } = null!;

    public string? ModificationUser { get; set; }

    public string? ModificationDate { get; set; }

    public virtual ICollection<LookupDetail> LookupDetails { get; set; } = new List<LookupDetail>();
}
