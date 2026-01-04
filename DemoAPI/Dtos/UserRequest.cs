namespace DemoAPI.Dtos
{
    public class UserRequest
    {
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
        public bool IsAdmin { get; set; }
    }
}
