using System;
using System.Collections.Generic;

namespace AnalisisSistemasAPI.Models.DataBase;

public partial class Branch
{
    public int BranchId { get; set; }

    public string Name { get; set; } = null!;

    public string Direction { get; set; } = null!;

    public bool State { get; set; }

    public virtual ICollection<Cart> Carts { get; set; } = new List<Cart>();

    public virtual ICollection<Sale> Sales { get; set; } = new List<Sale>();
}
