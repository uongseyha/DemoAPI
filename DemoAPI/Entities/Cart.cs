using System.ComponentModel.DataAnnotations.Schema;

namespace DemoAPI.Entities
{
    public class Cart
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public List<CartItem> CartItems{ get; set; } = new List<CartItem>();
        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
    }

    public record CartRecord(int Id, int UserId, List<CartItemRecord> Items);
}
