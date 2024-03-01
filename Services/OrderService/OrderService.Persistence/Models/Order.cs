
namespace OrderService.Persistence.Models
{
    public class Order
    {
        public int UserId { get; set; }
        public string StockTicker { get; set; }
        public int Quantity { get; set; }
        public string Side { get; set; }
        public decimal Price { get; set; }

        public override string ToString()
        {
            return $"User: {UserId}, Stock: {StockTicker}, Quantity: {Quantity}, Side: {Side}, Price: {Price}";
        }
    }
}
