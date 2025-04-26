using System;
using System.Collections.Generic;

namespace AnalisisSistemasAPI.Models.DataBase;

public partial class RolAccessPermission
{
    public int RolAccessId { get; set; }

    public int PermissionId { get; set; }

    public virtual Permission Permission { get; set; } = null!;

    public virtual RolAccess RolAccess { get; set; } = null!;
}
