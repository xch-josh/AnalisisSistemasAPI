namespace AnalisisSistemasAPI.Models.CartModels
{
    public class CartViewModel
    {
        public int CartId { get; set; }
        public decimal Quantity { get; set; }
        public string CodeBar { get; set; }
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Discount { get; set; }
        public decimal SalePrice { get; set; }
        public decimal Subtotal { get; set; }
    }
}
