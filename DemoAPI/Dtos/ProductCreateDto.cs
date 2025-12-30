namespace DemoAPI.Dtos
{
    public class ProductCreateDto
    {
        public string Title { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
        public string ImageUrl { get; set; }
    }
}
