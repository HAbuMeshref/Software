using Domain.Common;
using InventoryManagement.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models;

public partial class UserDto
{


    public int Id { get; set; }
    public string? Nmae { get; set; }
    public string? Email { get; set; }
    public byte[]? HashPassword { get; set; }
    public byte[]? PasswordSalt { get; set; }
}
