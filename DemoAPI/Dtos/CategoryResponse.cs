using System.ComponentModel.DataAnnotations;

namespace DemoAPI.Dtos
{
    public class CategoryResponse
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
