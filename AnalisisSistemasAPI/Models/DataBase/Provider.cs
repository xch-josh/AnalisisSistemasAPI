using System;
using System.Collections.Generic;

namespace AnalisisSistemasAPI.Models.DataBase;

public partial class Provider
{
    public int ProviderId { get; set; }

    public string Name { get; set; } = null!;

    public string Direction { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public string Mail { get; set; } = null!;

    public bool State { get; set; }
}
