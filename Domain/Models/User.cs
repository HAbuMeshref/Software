using Domain.Common;
using InventoryManagement.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models;

public partial class User: BaseModel
{
  
    public string? Email { get; set; } = null!;

    public string? Name { get; set; } = null!;

    public int Role { get; set; }

    public bool Active { get; set; }

    public string Password { get; set; } = null!;

    public string ConfirmPassword { get; set; } = null!;

   
}
