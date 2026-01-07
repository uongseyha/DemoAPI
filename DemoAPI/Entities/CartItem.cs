namespace DemoAPI.Entities
{
    public class CartItem
    {
        public int Id { get; set; }

        public int CartId { get; set; }
        public Cart Cart { get; set; } = null!;

        public int ProductId { get; set; }
        public Product Product { get; set; } = null!;

        public int Quantity { get; set; }
    }

    public record CartItemRecord(
        int Id,
        int ProductId,
        string ProductTitle,
        decimal Price,
        int Quantity,
        string ImageUrl
    );

    public record AddCartItemRecord(int ProductId, int Quantity);
}
