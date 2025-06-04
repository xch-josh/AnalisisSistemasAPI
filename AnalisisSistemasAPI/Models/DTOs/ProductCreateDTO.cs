using System;
using System.Collections.Generic;

namespace AnalisisSistemasAPI.Models.DTOs
{
    public class ProductCreateDTO
    {
        public string CodeBar { get; set; } = string.Empty;
        
        public string Name { get; set; } = string.Empty;
        
        public decimal PurchasePrice { get; set; }
        
        public decimal GainPercentage { get; set; }
        
        public decimal UnitPrice { get; set; }
        
        public string Description { get; set; } = string.Empty;
        
        public bool State { get; set; }
        
        public int MeasureId { get; set; }
        
        public int BrandId { get; set; }
        
        public int CategoryId { get; set; }
    }
}
