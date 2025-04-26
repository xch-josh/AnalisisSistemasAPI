using System;
using System.Collections.Generic;

namespace AnalisisSistemasAPI.Models.DataBase;

public partial class SaleCancellationReason
{
    public int SaleId { get; set; }

    public string Reason { get; set; } = null!;

    public virtual Sale Sale { get; set; } = null!;
}
