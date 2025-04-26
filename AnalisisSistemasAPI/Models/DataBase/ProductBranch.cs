using System;
using System.Collections.Generic;

namespace AnalisisSistemasAPI.Models.DataBase;

public partial class ProductBranch
{
    public int ProductId { get; set; }

    public int BranchId { get; set; }

    public decimal Stock { get; set; }

    public virtual Branch Branch { get; set; } = null!;

    public virtual Product Product { get; set; } = null!;
}
