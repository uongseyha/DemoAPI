using DemoAPI.Migrations;

namespace DemoAPI.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Password { get; set; }
        public string Username { get; set; }
        public bool IsAdmin { get; set; }
    }
}
