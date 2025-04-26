using System;
using System.Collections.Generic;

namespace AnalisisSistemasAPI.Models.DataBase;

public partial class Sale
{
    public int SaleId { get; set; }

    public DateTime Date { get; set; }

    public decimal Total { get; set; }

    public bool State { get; set; }

    public int ClientId { get; set; }

    public int BranchId { get; set; }

    public int UserId { get; set; }

    public virtual Branch Branch { get; set; } = null!;

    public virtual Client Client { get; set; } = null!;

    public virtual ICollection<SaleDetail> SaleDetails { get; set; } = new List<SaleDetail>();

    public virtual User User { get; set; } = null!;
}
