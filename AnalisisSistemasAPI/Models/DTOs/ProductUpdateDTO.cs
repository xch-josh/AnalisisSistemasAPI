using System;
using System.Collections.Generic;

namespace AnalisisSistemasAPI.Models.DTOs
{
    public class ProductUpdateDTO : ProductCreateDTO
    {
        public int ProductId { get; set; }
    }
}
