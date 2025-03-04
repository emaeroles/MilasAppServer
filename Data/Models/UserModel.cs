using System;
using System.Collections.Generic;

namespace Data.Models;

public partial class UserModel
{
    public Guid Id { get; set; }

    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Email { get; set; } = null!;

    public bool IsActive { get; set; }

    public virtual ICollection<KioscoModel> Kioscos { get; set; } = new List<KioscoModel>();
}
