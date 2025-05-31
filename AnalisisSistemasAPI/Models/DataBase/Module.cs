using System;
using System.Collections.Generic;

namespace AnalisisSistemasAPI.Models.DataBase;

public partial class Module
{
    public int ModuleId { get; set; }

    public string Name { get; set; } = null!;

    public bool State { get; set; }

    public int? Father { get; set; }

    public string Link { get; set; } = null!;

    public string? Icon { get; set; }

    public virtual ICollection<RolAccess> RolAccesses { get; set; } = new List<RolAccess>();
}
