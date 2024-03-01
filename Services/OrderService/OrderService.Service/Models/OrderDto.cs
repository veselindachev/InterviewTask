namespace OrderService.Service.Models
{
    public class OrderDto
    {
        public string StockTicker { get; set; }
        public int Quantity { get; set; }
        public string Side { get; set; }
        public int UserId { get; set; }
    }
}
