using System;
using System.Collections.Generic;

namespace AnalisisSistemasAPI.Models.DataBase;

public partial class SaleDetail
{
    public int DetailId { get; set; }

    public decimal Quantity { get; set; }

    public decimal PurchasePrice { get; set; }

    public decimal UnitPrice { get; set; }

    public decimal Discount { get; set; }

    public decimal SalePrice { get; set; }

    public decimal Subtotal { get; set; }

    public int ProductId { get; set; }

    public int SaleId { get; set; }

    public virtual Product Product { get; set; } = null!;

    public virtual Sale Sale { get; set; } = null!;
}
