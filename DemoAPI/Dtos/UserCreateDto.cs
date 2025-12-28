namespace DemoAPI.Dtos
{
    public class UserCreateDto
    {
        public string UserName { get; set; } = null!;
        public string Password { get; set; } = null!;
        public bool IsAdmin { get; set; }
    }
}
