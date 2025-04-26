using System;
using System.Collections.Generic;

namespace AnalisisSistemasAPI.Models.DataBase;

public partial class RolAccess
{
    public int RolAccessId { get; set; }

    public int RolId { get; set; }

    public int ModuleId { get; set; }

    public virtual Module Module { get; set; } = null!;

    public virtual Rol Rol { get; set; } = null!;
}
