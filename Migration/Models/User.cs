using System;
using System.Collections.Generic;

namespace Migration.Models;

public partial class User
{
    public int Id { get; set; }

    public string Email { get; set; } = null!;

    public string Name { get; set; } = null!;

    public int Role { get; set; }

    public int Active { get; set; }

    public string CreationUser { get; set; } = null!;

    public string CreationDate { get; set; } = null!;

    public string? ModificationUser { get; set; }

    public string? ModificationDate { get; set; }

    public string Password { get; set; } = null!;

    public string ConfirmPassword { get; set; } = null!;
}
