using System;
using System.Collections.Generic;

namespace AnalisisSistemasAPI.Models.DataBase;

public partial class UserBranch
{
    public int BranchId { get; set; }

    public int UserId { get; set; }

    public virtual Branch Branch { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
