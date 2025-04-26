using System;
using System.Collections.Generic;

namespace AnalisisSistemasAPI.Models.DataBase;

public partial class Rol
{
    public int RolId { get; set; }

    public string Name { get; set; } = null!;

    public bool State { get; set; }

    public virtual ICollection<RolAccess> RolAccesses { get; set; } = new List<RolAccess>();

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
