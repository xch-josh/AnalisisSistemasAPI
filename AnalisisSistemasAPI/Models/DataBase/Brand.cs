using System;
using System.Collections.Generic;

namespace AnalisisSistemasAPI.Models.DataBase;

public partial class Brand
{
    public int BrandId { get; set; }

    public string Name { get; set; } = null!;

    public bool State { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
