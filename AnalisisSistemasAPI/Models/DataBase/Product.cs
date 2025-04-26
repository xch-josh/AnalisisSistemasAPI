using System;
using System.Collections.Generic;

namespace AnalisisSistemasAPI.Models.DataBase;

public partial class Product
{
    public int ProductId { get; set; }

    public string CodeBar { get; set; } = null!;

    public string Name { get; set; } = null!;

    public decimal PurchasePrice { get; set; }

    public decimal GainPercentage { get; set; }

    public decimal UnitPrice { get; set; }

    public string Description { get; set; } = null!;

    public bool State { get; set; }

    public int MeasureId { get; set; }

    public int BrandId { get; set; }

    public int CategoryId { get; set; }

    public virtual Brand Brand { get; set; } = null!;

    public virtual ICollection<Cart> Carts { get; set; } = new List<Cart>();

    public virtual Category Category { get; set; } = null!;

    public virtual Measure Measure { get; set; } = null!;

    public virtual ICollection<SaleDetail> SaleDetails { get; set; } = new List<SaleDetail>();
}
