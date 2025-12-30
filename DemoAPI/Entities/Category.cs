using System.ComponentModel.DataAnnotations.Schema;

namespace DemoAPI.Entities
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
