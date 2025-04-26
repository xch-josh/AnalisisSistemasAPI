using System;
using System.Collections.Generic;

namespace AnalisisSistemasAPI.Models.DataBase;

public partial class Cart
{
    public int CartId { get; set; }

    public decimal Quantity { get; set; }

    public decimal PurchasePrice { get; set; }

    public decimal UnitPrice { get; set; }

    public decimal Discount { get; set; }

    public decimal SalePrice { get; set; }

    public decimal Subtotal { get; set; }

    public int ProductId { get; set; }

    public int UserId { get; set; }

    public int BranchId { get; set; }

    public virtual Branch Branch { get; set; } = null!;

    public virtual Product Product { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
