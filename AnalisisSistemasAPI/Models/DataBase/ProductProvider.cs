using System;
using System.Collections.Generic;

namespace AnalisisSistemasAPI.Models.DataBase;

public partial class ProductProvider
{
    public int ProductId { get; set; }

    public int ProviderId { get; set; }

    public virtual Product Product { get; set; } = null!;

    public virtual Provider Provider { get; set; } = null!;
}
